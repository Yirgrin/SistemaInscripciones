Imports System.Data.SqlClient
Public Class SuplidorDAO

    Private Shared _instancia As SuplidorDAO = Nothing

    ' Obtiene una instancia única de la clase SuplidorNegocio utilizando el patrón Singleton.
    Public Shared ReadOnly Property Instancia As SuplidorDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New SuplidorDAO()
            End If
            Return _instancia
        End Get
    End Property

    ' inserta los datos de la inscripción de un suplidor
    Public Function insertarInscripcionSuplidor(ByVal modelo As Suplidor) As String
        Dim codigoNuevo As String = ""
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "INSERT INTO GC_SUPLIDORES (CEDULA, NOMBRE, TIPO_CEDULA, GENERO, EMAIL, TELEFONO_FIJO, TELEFONO_CELULAR, ACTIVIDAD_MH, DIRECCION_EXACTA, DISTRITO, REGION, FECHA_ENVIO, ESTADO_FORM, PROVINCIA, CANTON )"
            sql += "VALUES (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8, @VALOR9, @VALOR10, @VALOR11, @VALOR12, @VALOR13, @VALOR14, @VALOR15);"
            Dim cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@VALOR1", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.nombre)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.tipoCedula)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.genero)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.email)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.telefonoFijo)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.telefonoMovil)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.ActividadHM)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.direccionResidencia)
            cmd.Parameters.AddWithValue("@VALOR10", modelo.codDistrito)
            cmd.Parameters.AddWithValue("@VALOR11", modelo.codRegion)
            cmd.Parameters.AddWithValue("@VALOR12", modelo.fecha_envio)
            cmd.Parameters.AddWithValue("@VALOR13", 1)
            cmd.Parameters.AddWithValue("@VALOR14", modelo.codProvincia)
            cmd.Parameters.AddWithValue("@VALOR15", modelo.codCanton)

            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return codigoNuevo
    End Function



    ''' Actualiza los datos de inscripción de un suplidor en la base de datos.
    ''' <param name="inscripcion">El código de inscripción del suplidor.</param>
    ''' <param name="modelo">El objeto Productor que contiene los nuevos datos del suplidor.</param>
    ''' <returns>El objeto Suplidor con los datos actualizados.</returns>
    Public Function actualizarInscripcionSuplidor(ByVal inscripcion As String, ByVal modelo As Suplidor) As Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_SUPLIDORES SET CEDULA = @VALOR1, NOMBRE = @VALOR2, TIPO_CEDULA = @VALOR3, GENERO = @VALOR4, EMAIL = @VALOR5, TELEFONO_FIJO = @VALOR6,"
            sql += " TELEFONO_CELULAR = @VALOR7, ACTIVIDAD_MH = @VALOR8, DIRECCION_EXACTA = @VALOR9, DISTRITO = @VALOR10, REGION = @VALOR11, FECHA_ENVIO = @VALOR12,
                    PROVINCIA = @VALOR13, CANTON = @VALOR14"
            sql += " WHERE CODIGO = @Inscripcion;"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.nombre)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.tipoCedula)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.genero)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.email)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.telefonoFijo)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.telefonoMovil)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.ActividadHM)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.direccionResidencia)
            cmd.Parameters.AddWithValue("@VALOR10", modelo.codDistrito)
            cmd.Parameters.AddWithValue("@VALOR11", modelo.codRegion)
            cmd.Parameters.AddWithValue("@VALOR12", modelo.fecha_envio)
            cmd.Parameters.AddWithValue("@VALOR13", modelo.codProvincia)
            cmd.Parameters.AddWithValue("@VALOR14", modelo.codCanton)
            cmd.Parameters.AddWithValue("@Inscripcion", inscripcion)

            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function


    ' Obtiene una lista de estados de inscripción de un suplidor a partir de su número de cédula.
    ''' <param name="cedula">El número de cédula del suplidor.</param>
    ''' <returns>Una lista de objetos EstadosInscripcion.</returns>
    Public Function buscarEstadosInscripcion(ByVal cedula As String) As List(Of EstadosInscripcion)
        Dim estadosInscripciones As New List(Of EstadosInscripcion)()
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT TOP 1 CODIGO, ESTADO_FORM From GC_SUPLIDORES Where CEDULA=@VALOR1 ORDER BY FECHA_ENVIO DESC;"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", cedula)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New EstadosInscripcion
                modelo.inscripcion = dr(0).ToString
                modelo.estado = dr(1).ToString
                estadosInscripciones.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return estadosInscripciones
    End Function

    ' Trae los datos de un suplidor dado su código de inscripción.
    ''' <param name="inscripcion">El código de inscripción del suplidor.</param>
    ''' <returns>El objeto Suplidor con los datos del suplidor.</returns>
    Public Function cargarDatosSuplidor(ByVal inscripcion As String) As Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_SUPLIDORES Where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New Suplidor
            While dr.Read
                modelo.cedula = dr(1).ToString
                modelo.nombre = dr(2).ToString
                modelo.tipoCedula = dr(3).ToString
                modelo.genero = dr(4).ToString
                modelo.email = dr(5).ToString
                modelo.telefonoFijo = dr(6).ToString
                modelo.telefonoMovil = dr(7).ToString
                modelo.ActividadHM = dr(8).ToString
                modelo.direccionResidencia = dr(9).ToString
                modelo.codProvincia = dr(14).ToString
                modelo.codCanton = dr(15).ToString
                modelo.codDistrito = dr(10).ToString
            End While
            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function

    ' Actualiza el estado de inscripción de un suplidor en la base de datos.
    ''' <param name="inscripcion">El código de inscripción del suplidor.</param>
    ''' <returns>True si se actualizó el estado correctamente, False en caso contrario.</returns>
    Function actualizarEstadoInscripcion(ByVal inscripcion As String) As Boolean
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_SUPLIDORES SET ESTADO_FORM = 2, FECHA_ENVIO = @fechaEnvio, AREA_REVISION = 1,
            NUM_RESOLUCION = @numResolucion, OBSERVACIONES = @observaciones, FECHA_DEVOLUCION = @fechaDevolucion WHERE CODIGO = @Inscripcion;"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Inscripcion", inscripcion)
            cmd.Parameters.AddWithValue("@fechaEnvio", DateTime.Now)
            cmd.Parameters.AddWithValue("@numResolucion", "")
            cmd.Parameters.AddWithValue("@observaciones", "")
            cmd.Parameters.AddWithValue("@fechaDevolucion", "No se ha devuelto")
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return True
    End Function


    ' Trae el historial de inscripciones de un suplidor.
    ''' <param name="cedula">El código de inscripción del suplidor.</param>
    ''' <returns>El objeto Suplidor con los datos del suplidor.</returns>
    Public Function traerHistorial(ByVal cedula As String) As List(Of Suplidor)
        Dim historial As New List(Of Suplidor)()
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From [VW_GC_SA_HISTORIAL]"
            sql = sql + "Where CEDULA=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", cedula)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read
                    Dim modelo As New Suplidor()
                    modelo.codigo = dr(0).ToString
                    modelo.fecha_envio = dr(1).ToString
                    modelo.estado_form = dr(3).ToString
                    modelo.cedula = dr(2).ToString
                    Dim fechaDevolucion As DateTime
                    If DateTime.TryParse(dr(4).ToString, fechaDevolucion) Then
                        modelo.fecha_devolucion = fechaDevolucion.ToString("yyyy/MM/dd")
                    Else
                        modelo.fecha_devolucion = String.Empty ' o manejar el error de conversión según sea necesario
                    End If
                    modelo.observaciones = dr(5).ToString
                    historial.Add(modelo)
                End While
            Else
                historial = Nothing
            End If
            dr.Close()
            cn.Close()

        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return historial
    End Function
End Class
