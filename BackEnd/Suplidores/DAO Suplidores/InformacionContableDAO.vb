Imports System.Data.SqlClient
Public Class InformacionContableDAO

    Private Shared _instancia As InformacionContableDAO = Nothing
    ' Instancia única de la clase InformacionContableDAO utilizando el patrón Singleton.
    Public Shared ReadOnly Property Instancia As InformacionContableDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New InformacionContableDAO()
            End If
            Return _instancia
        End Get
    End Property

    ' Selecciona la colección de lineas de producción
    Public Function cargarLineasProduccion() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_LINEAS_PRODUCCION"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New LineasProduccion
                modelo.codigo = dr(0).ToString
                modelo.categoria = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Inserta los datos de información contable de un suplidor
    Public Function InsertarInfoContable(ByVal modelo As ActividadContable) As ActividadContable
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_ACTIVIDAD_CONTABLE (INSCRIPCION, CATEGORIA_PRINCIPAL, CANTIDAD_EMPLEADOS, VENTAS_NETAS, ACTIVOS_FIJOS, 
                       ACTIVOS_TOTALES, CODIGO_PRODUCCION, PROVINCIA, CANTON, DISTRITO, DIREC_EXACTA, REGION)"
            sql = sql + "Values (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8, @VALOR9, @VALOR10, @VALOR11, @VALOR12)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.actividadPrincipal)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.cantidadEmpleados)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.ventasNetas)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.activosFijos)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.activosTotales)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.codigoProduccion)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.codProvincia)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.codCanton)
            cmd.Parameters.AddWithValue("@VALOR10", modelo.codDistrito)
            cmd.Parameters.AddWithValue("@VALOR11", modelo.direcExacta)
            cmd.Parameters.AddWithValue("@VALOR12", modelo.codregion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Obtiene los datos de la información contable por su inscripción.
    ''' <param name="inscripcion">La inscripción del suplidor.</param>
    ''' <returns>El objeto ActividadContable correspondiente a la inscripción.</returns>
    Public Function cargarDatosContables(ByVal inscripcion As String) As ActividadContable
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_ACTIVIDAD_CONTABLE Where INSCRIPCION=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New ActividadContable
            While dr.Read
                modelo.codigo = dr(0).ToString
                modelo.actividadPrincipal = dr(2).ToString
                modelo.cantidadEmpleados = dr(3).ToString
                modelo.ventasNetas = dr(4).ToString
                modelo.activosFijos = dr(5).ToString
                modelo.activosTotales = dr(6).ToString
                modelo.codigoProduccion = dr(7).ToString
                modelo.codProvincia = dr(8).ToString
                modelo.codCanton = dr(9).ToString
                modelo.codDistrito = dr(10).ToString
                modelo.direcExacta = dr(11).ToString
            End While
            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function


    ''' <summary>
    ''' Actualiza los datos de inscripción de un suplidor en la base de datos.
    ''' </summary>
    ''' <param name="inscripcion">El código de inscripción del suplidor.</param>
    ''' <param name="modelo">El objeto Productor que contiene los nuevos datos del suplidor.</param>
    ''' <returns>El objeto ActividadContable con los datos actualizados.</returns>
    Public Function ActualizarInfoContable(ByVal inscripcion As String, ByVal modelo As ActividadContable) As ActividadContable
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_ACTIVIDAD_CONTABLE SET CATEGORIA_PRINCIPAL = @VALOR2, CANTIDAD_EMPLEADOS = @VALOR3, VENTAS_NETAS = @VALOR4, ACTIVOS_FIJOS = @VALOR5, 
                       ACTIVOS_TOTALES = @VALOR6, CODIGO_PRODUCCION = @VALOR7, PROVINCIA = @VALOR8, CANTON = @VALOR9, DISTRITO = @VALOR10, DIREC_EXACTA = @VALOR11, REGION = @VALOR12 WHERE INSCRIPCION = @VALOR1;"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.actividadPrincipal)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.cantidadEmpleados)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.ventasNetas)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.activosFijos)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.activosTotales)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.codigoProduccion)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.codProvincia)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.codCanton)
            cmd.Parameters.AddWithValue("@VALOR10", modelo.codDistrito)
            cmd.Parameters.AddWithValue("@VALOR11", modelo.direcExacta)
            cmd.Parameters.AddWithValue("@VALOR12", modelo.codregion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

End Class
