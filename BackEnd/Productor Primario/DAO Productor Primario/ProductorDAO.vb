Imports System.Data.SqlClient

''' <summary>
''' Clase que proporciona métodos para interactuar con la base de datos relacionados con productores.
''' </summary>
Public Class ProductorDAO
    Private Shared _instancia As ProductorDAO = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase ProductorDAO utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As ProductorDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New ProductorDAO()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Inserta la inscripción de un productor en la base de datos.
    ''' </summary>
    ''' <param name="modelo">El objeto Productor que contiene los datos del productor a inscribir.</param>
    ''' <returns>El código del nuevo productor inscrito.</returns>
    Public Function insertarInscripcionProductor(ByVal modelo As Productor) As String
        Dim codigoNuevo As String = ""
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "INSERT INTO GC_PRODUCTOR (NOMBRE, GENERO, CEDULA, TIPO_CEDULA, TIPO_PRODUCTOR, TELEFONO_FIJO, TELEFONO_MOVIL, EMAIL, EMPRESA_ASOCIADA, DIRECCION_RESIDENCIA," 
            sql += " DISTRITO, ESTADO, REGION, ESTADO_CCSS, ETNIA, INGRESOS_PROPIOS, SOLO_AGRICOLA, DEPENDIENTES_INGRESOS, ESTADO_CIVIL, HIJOS_MENORES, ESCOLARIDAD,"
            sql += " DISCAPACIDAD, CARNET_CONAPDIS, FECHA_ENVIO, PROVINCIA, CANTON, CHECK_MH, CHECK_MAG)"
            sql += " VALUES (@VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8, @VALOR9, @VALOR10, @VALOR11, @VALOR12, @VALOR13,"
            sql += " @VALOR14, @VALOR15, @VALOR16, @VALOR17, @VALOR18, @VALOR19, @VALOR20, @VALOR21, @VALOR22, @VALOR23, @VALOR24, @VALOR25, @VALOR26, @VALOR27, @VALOR28, @VALOR29);"
            Dim cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@VALOR2", modelo.nombre)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.genero)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.tipoCedula)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.tipoProductor)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.telefonoFijo)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.telefonoMovil)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.email)
            cmd.Parameters.AddWithValue("@VALOR10", modelo.empresaAsociada)
            cmd.Parameters.AddWithValue("@VALOR11", modelo.direccionResidencia)
            cmd.Parameters.AddWithValue("@VALOR12", modelo.codDistrito)
            cmd.Parameters.AddWithValue("@VALOR13", 1)
            cmd.Parameters.AddWithValue("@VALOR14", modelo.codRegion)
            cmd.Parameters.AddWithValue("@VALOR15", modelo.ccss)

            cmd.Parameters.AddWithValue("@VALOR16", modelo.etnia)
            cmd.Parameters.AddWithValue("@VALOR17", modelo.IngresosPropios)
            cmd.Parameters.AddWithValue("@VALOR18", modelo.SoloAgricola)
            cmd.Parameters.AddWithValue("@VALOR19", modelo.Dependientes)
            cmd.Parameters.AddWithValue("@VALOR20", modelo.EstadoCivil)
            cmd.Parameters.AddWithValue("@VALOR21", modelo.HijosMenores)
            cmd.Parameters.AddWithValue("@VALOR22", modelo.Escolaridad)
            cmd.Parameters.AddWithValue("@VALOR23", modelo.Discapacidad)
            cmd.Parameters.AddWithValue("@VALOR24", modelo.Conapdis)
            cmd.Parameters.AddWithValue("@VALOR25", modelo.fecha_envio)
            cmd.Parameters.AddWithValue("@VALOR26", modelo.codProvincia)
            cmd.Parameters.AddWithValue("@VALOR27", modelo.codCanton)
            cmd.Parameters.AddWithValue("@VALOR28", modelo.checkMH)
            cmd.Parameters.AddWithValue("@VALOR29", modelo.checkMAG)

            cmd.ExecuteNonQuery()

            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return codigoNuevo
    End Function

    ''' <summary>
    ''' Actualiza los datos de inscripción de un productor en la base de datos.
    ''' </summary>
    ''' <param name="inscripcion">El código de inscripción del productor.</param>
    ''' <param name="modelo">El objeto Productor que contiene los nuevos datos del productor.</param>
    ''' <returns>El objeto Productor con los datos actualizados.</returns>
    Public Function actualizarInscripcionProductor(ByVal inscripcion As String, ByVal modelo As Productor) As Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_PRODUCTOR SET NOMBRE = @VALOR2, GENERO = @VALOR3, TIPO_CEDULA = @VALOR5, TIPO_PRODUCTOR = @VALOR6, TELEFONO_FIJO = @VALOR7,"
            sql += " TELEFONO_MOVIL = @VALOR8, EMAIL = @VALOR9, EMPRESA_ASOCIADA = @VALOR10, DIRECCION_RESIDENCIA = @VALOR11,"
            sql += " DISTRITO = @VALOR12, REGION = @VALOR13, ESTADO = 1, ESTADO_CCSS = @VALOR14, ETNIA=@VALOR16, INGRESOS_PROPIOS = @VALOR17,"
            sql += " SOLO_AGRICOLA = @VALOR18, DEPENDIENTES_INGRESOS = @VALOR19, ESTADO_CIVIL = @VALOR20, HIJOS_MENORES = @VALOR21, ESCOLARIDAD = @VALOR22,"
            sql += " DISCAPACIDAD = @VALOR23, CARNET_CONAPDIS = @VALOR24, FECHA_ENVIO = @VALOR25, PROVINCIA = @VALOR26, CANTON = @VALOR27, CHECK_MH = @VALOR28, CHECK_MAG = @VALOR29"
            sql += " WHERE CODIGO = @Inscripcion;"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.nombre)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.genero)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.tipoCedula)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.tipoProductor)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.telefonoFijo)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.telefonoMovil)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.email)
            cmd.Parameters.AddWithValue("@VALOR10", modelo.empresaAsociada)
            cmd.Parameters.AddWithValue("@VALOR11", modelo.direccionResidencia)
            cmd.Parameters.AddWithValue("@VALOR12", modelo.codDistrito)
            cmd.Parameters.AddWithValue("@VALOR13", modelo.codRegion)
            cmd.Parameters.AddWithValue("@VALOR14", modelo.ccss)
            cmd.Parameters.AddWithValue("@Inscripcion", inscripcion)
            cmd.Parameters.AddWithValue("@VALOR16", modelo.etnia)
            cmd.Parameters.AddWithValue("@VALOR17", modelo.IngresosPropios)
            cmd.Parameters.AddWithValue("@VALOR18", modelo.SoloAgricola)
            cmd.Parameters.AddWithValue("@VALOR19", modelo.Dependientes)
            cmd.Parameters.AddWithValue("@VALOR20", modelo.EstadoCivil)
            cmd.Parameters.AddWithValue("@VALOR21", modelo.HijosMenores)
            cmd.Parameters.AddWithValue("@VALOR22", modelo.Escolaridad)
            cmd.Parameters.AddWithValue("@VALOR23", modelo.Discapacidad)
            cmd.Parameters.AddWithValue("@VALOR24", modelo.Conapdis)
            cmd.Parameters.AddWithValue("@VALOR25", modelo.fecha_envio)
            cmd.Parameters.AddWithValue("@VALOR26", modelo.codProvincia)
            cmd.Parameters.AddWithValue("@VALOR27", modelo.codCanton)
            cmd.Parameters.AddWithValue("@VALOR28", modelo.checkMH)
            cmd.Parameters.AddWithValue("@VALOR29", modelo.checkMAG)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ''' <summary>
    ''' Actualiza el estado de inscripción de un productor en la base de datos.
    ''' </summary>
    ''' <param name="inscripcion">El código de inscripción del productor.</param>
    ''' <returns>True si se actualizó el estado correctamente, False en caso contrario.</returns>
    Function actualizarEstadoInscripcion(ByVal inscripcion As String) As Boolean
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_PRODUCTOR SET ESTADO = 2, FECHA_ENVIO = @fechaEnvio, AREA_REVISION = 1,
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

    ''' <summary>
    ''' Trae los datos de un productor dado su código de inscripción.
    ''' </summary>
    ''' <param name="inscripcion">El código de inscripción del productor.</param>
    ''' <returns>El objeto Productor con los datos del productor.</returns>
    Public Function traerDatosProductor(ByVal inscripcion As String) As Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_PRODUCTOR Where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New Productor
            While dr.Read
                modelo.tipoProductor = dr(5).ToString
                modelo.telefonoFijo = dr(6).ToString
                modelo.telefonoMovil = dr(7).ToString
                modelo.empresaAsociada = dr(9).ToString
                modelo.direccionResidencia = dr(10).ToString
                modelo.Discapacidad = dr(14)
                modelo.etnia = dr(15)
                modelo.EstadoCivil = dr(16)
                modelo.Escolaridad = dr(17)
                modelo.IngresosPropios = dr(18)
                modelo.SoloAgricola = dr(19)
                modelo.Dependientes = dr(20)
                modelo.Conapdis = dr(21)
                modelo.ccss = dr(22)
                modelo.HijosMenores = dr(23)
                modelo.codProvincia = dr(25)
                modelo.codCanton = dr(26)
                modelo.codDistrito = dr(11)
                modelo.checkMH = dr(27)
                modelo.checkMAG = dr(28)
            End While

            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function

    ''' <summary>
    ''' Trae el historial de inscripciones de un productor.
    ''' </summary>
    ''' <param name="cedula">El código de inscripción del productor.</param>
    ''' <returns>El objeto Productor con los datos del productor.</returns>
    Public Function traerHistorial(ByVal cedula As String) As List(Of Productor)
        Dim historial As New List(Of Productor)()
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From [VW_GC_PP_HISTORIAL]"
            sql = sql + "Where CEDULA=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", cedula)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read
                    Dim modelo As New Productor()
                    modelo.codigo = dr(0).ToString
                    modelo.fecha_envio = dr(1).ToString

                    modelo.estado_form = dr(2).ToString
                    modelo.cedula = dr(3).ToString

                    Dim fechaDevolucion As DateTime
                    If DateTime.TryParse(dr(4).ToString, fechaDevolucion) Then
                        modelo.fecha_devolucion = fechaDevolucion.ToString("yyyy/MM/dd")
                    Else
                        modelo.fecha_devolucion = String.Empty
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


    ''' <summary>
    ''' Obtiene una lista de estados de inscripción de un productor a partir de su número de cédula.
    ''' </summary>
    ''' <param name="cedula">El número de cédula del productor.</param>
    ''' <returns>Una lista de objetos EstadosInscripcion.</returns>
    Public Function buscarEstadosInscripcion(ByVal cedula As String) As List(Of EstadosInscripcion)
        Dim estadosDeInscripciones As New List(Of EstadosInscripcion)()
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT TOP 1 CODIGO, ESTADO From GC_PRODUCTOR Where CEDULA=@VALOR1 ORDER BY FECHA_ENVIO DESC;"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", cedula)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New EstadosInscripcion
                modelo.inscripcion = dr(0).ToString
                modelo.estado = dr(1).ToString
                estadosDeInscripciones.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return estadosDeInscripciones
    End Function

End Class
