Imports System.Data.SqlClient
Public Class ActividadComercialDAO


    Private Shared _instancia As ActividadComercialDAO = Nothing
    ' Instancia única de la clase InformacionContableNegocio utilizando el patrón Singleton.
    Public Shared ReadOnly Property Instancia As ActividadComercialDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New ActividadComercialDAO()
            End If
            Return _instancia
        End Get
    End Property

    'Inserta nuevas actividades en la base de datos
    Public Function InsertarActividadComercial(ByVal modelo As ActividadComercial) As ActividadComercial
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_ACTIVIDADES_COMERCIALES (INSCRIPCION, CATEGORIA, CODIGO_PRODUCCION)"
            sql = sql + "Values (@VALOR1, @VALOR2, @VALOR3)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.categoria)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.codigoProduccion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function


    ' Se trae la coleccion de líneas de producción de la base de datos
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
                modelo.clasificacion = dr(2).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
            Return lista
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function

    ' Se trae las actividades registradas por una misma inscripción.
    Public Function preCargarActividades(ByVal Inscripcion As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From [VW_GC_ACTIVIDADES_COMERCIALES]"
            sql = sql + " Where INSCRIPCION = @VALOR1"
            sql = sql + " Order by [CODIGO]"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", Inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New ActividadComercial
                modelo.categoria = dr(0).ToString
                modelo.codigo = dr(1).ToString
                modelo.codigoProduccion = dr(3).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Elimina una actividad comercial de la base de datos.
    ''' <param name="Codigo">Código de la actividad comercial a eliminar.</param>
    ''' <returns>El código de la actividad comercial eliminado.</returns>
    Public Function eliminarActividadComercial(ByVal Codigo As String) As String
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Delete from GC_ACTIVIDADES_COMERCIALES Where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", Codigo)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return Codigo
    End Function
End Class
