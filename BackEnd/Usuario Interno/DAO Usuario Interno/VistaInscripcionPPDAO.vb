Imports System.Data.SqlClient
Public Class VistaInscripcionPPDAO

    Private Shared _instancia As VistaInscripcionPPDAO = Nothing
    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase VistaInscripcionPPDAO.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As VistaInscripcionPPDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New VistaInscripcionPPDAO()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Trae los datos de un productor dado su código de inscripción.
    ''' </summary>
    ''' <param name="inscripcion">El código de inscripción del productor.</param>
    ''' <returns>El objeto Productor con los datos del productor.</returns>
    Public Function traerDatosProductor(ByVal inscripcion As String) As Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From VW_GC_INSCRIP_1_INFO_PP Where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New Productor
            While dr.Read
                modelo.nombre = dr(0).ToString
                modelo.genero = dr(1).ToString
                modelo.cedula = dr(2).ToString
                modelo.tipoCedula = dr(3).ToString
                modelo.tipoProductor = dr(4).ToString
                modelo.telefonoMovil = dr(5).ToString
                modelo.telefonoFijo = dr(6).ToString
                modelo.email = dr(7).ToString
                modelo.empresaAsociada = dr(8).ToString
                modelo.direccionResidencia = dr(9).ToString
                modelo.codProvincia = dr(10)
                modelo.codCanton = dr(11)
                modelo.codDistrito = dr(12)
                modelo.Discapacidad = dr(13)
                modelo.etnia = dr(14)
                modelo.EstadoCivil = dr(15)
                modelo.Escolaridad = dr(16)
                modelo.Dependientes = dr(17)
                modelo.SoloAgricola = dr(18)
                modelo.Conapdis = dr(19)
                modelo.ccss = dr(20)
                modelo.HijosMenores = dr(21)
                modelo.fecha_envio = dr(22)
                modelo.checkMH = dr(23)
                modelo.checkMAG = dr(24)
                modelo.codigo = dr(25).ToString
                modelo.IngresosPropios = dr(26)

            End While
            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function

    ' Obtiene la ruta del archivo pdf.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Certificacion que contiene los datos de la ruta.</returns>
    Public Function buscarRutaArchivo(ByVal inscripcion As String) As Certificacion
        Dim modelo As New Certificacion
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select ARCHIVO From GC_CERTIFICACION Where PRODUCTOR=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                modelo.archivo = dr(0).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Actualiza la condición de la verificación en campo a verdadera.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="codigo">codigo de la línea de datos a actualizar.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Public Function verificacionCampo(ByVal inscripcion As String, ByVal codigo As String) As DatosFormulario
        Dim modelo As New DatosFormulario
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "UPDATE GC_DATOS_LINEA_AB SET VERIFICACION_CAMPO = @VALOR1 WHERE CODIGO = @VALOR2"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", codigo)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Busca y carga si la verificación en campo está completada.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Public Function buscarVerificacionCampo(ByVal inscripcion As String) As DatosFormulario
        Dim modelo As New DatosFormulario
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT VERIFICACION_CAMPO From GC_DATOS_LINEA_AB Where INSCRIPCION=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                modelo.verificacionCampo = dr(0).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Inserta los datos de la observación en la base de datos.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="observaciones">datos a insertar.</param>>
    Public Function agregarObservaciones(ByVal observaciones As String, ByVal inscripcion As String) As DatosFormulario
        Dim modelo As New DatosFormulario
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_DATOS_LINEA_AB SET OBSERVACIONES = @VALOR1 WHERE INSCRIPCION = @VALOR2"
            Dim cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@VALOR1", observaciones)
            cmd.Parameters.AddWithValue("@VALOR2", inscripcion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Actualiza el area de revision del formulario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="areaRevision">estado del area de revision.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Public Function enviarSolicitud(ByVal areaRevision As String, ByVal inscripcion As String) As Productor
        Dim modelo As New Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_PRODUCTOR SET AREA_REVISION = @VALOR1 WHERE CODIGO = @VALOR2"
            Dim cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@VALOR1", areaRevision)
            cmd.Parameters.AddWithValue("@VALOR2", inscripcion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Obtiene la ruta del archivo pdf.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Certificacion que contiene los datos de la ruta.</returns>
    Public Function traerObservaciones(ByVal inscripcion As String) As DatosFormulario
        Dim modelo As New DatosFormulario
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select OBSERVACIONES From GC_DATOS_LINEA_AB Where INSCRIPCION = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                modelo.observaciones = dr(0).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Subsana la inscripción de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Productor que contiene los datos.</returns>
    Public Function subsanarSoliPP(ByVal inscripcion As String) As Productor
        Dim modelo As New Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "DELETE FROM GC_CERTIFICACION WHERE PRODUCTOR = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Actualiza el area de revision del formulario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="numResolucion">Número de resolución agregado por un UI.</param>
    ''' <param name="observacion">observaciones de la subsanación agregado por un UI.</param>
    ''' <returns>Un objeto Productor que contiene los datos.</returns>
    Public Function actualizarProductorSubs(ByRef inscripcion As String, ByRef numResolucion As String, ByRef observacion As String) As Productor
        Dim modelo As New Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_PRODUCTOR SET NUM_RESOLUCION = @VALOR2, OBSERVACIONES = @VALOR3, 
                                ESTADO = @VALOR4, AREA_REVISION = @VALOR5 WHERE CODIGO = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", numResolucion)
            cmd.Parameters.AddWithValue("@VALOR3", observacion)
            cmd.Parameters.AddWithValue("@VALOR4", 3)
            cmd.Parameters.AddWithValue("@VALOR5", " ")
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function


    ' Actualiza la información de resolución de un suplidor.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <param name="numResolucion">Número de resolución agregado por un UI.</param>
    ''' <param name="fechaResolucion">fecha de devolución del formulario.</param>
    ''' <param name="condicion">condicion rechazada o aceptada del formulario.</param>
    ''' <param name="observaciones">observaciones opcionales agregadas por el funcionario.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Public Function actualizarInscripPP(ByRef inscripcion As String, ByRef numResolucion As String,
                                        ByRef fechaResolucion As String, ByRef condicion As String, ByRef observaciones As String) As Productor
        Dim modelo As New Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_PRODUCTOR SET NUM_RESOLUCION = @VALOR2, FECHA_DEVOLUCION = @VALOR3, 
                                ESTADO = @VALOR4, AREA_REVISION = @VALOR5, OBSERVACIONES = @VALOR6 WHERE CODIGO = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", numResolucion)
            cmd.Parameters.AddWithValue("@VALOR3", fechaResolucion)
            cmd.Parameters.AddWithValue("@VALOR4", condicion)
            cmd.Parameters.AddWithValue("@VALOR5", " ")
            cmd.Parameters.AddWithValue("@VALOR6", observaciones)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Elimina la inscripción de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Productor que contiene los datos.</returns>
    Public Function borrarInfoPP(ByVal inscripcion As String) As Productor
        Dim modelo As New Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()

            Dim sql As String = "UPDATE GC_PRODUCTOR SET TELEFONO_FIJO = @VALOR2, 
                                TELEFONO_MOVIL = @VALOR3, EMPRESA_ASOCIADA = @VALOR4, DIRECCION_RESIDENCIA = @VALOR5, DISTRITO = @VALOR6, 
                                REGION = @VALOR7, PROVINCIA = @VALOR8, CANTON = @VALOR9, DISCAPACIDAD = @VALOR10, ETNIA = @VALOR11, 
                                ESTADO_CIVIL = @VALOR12, ESCOLARIDAD = @VALOR13, INGRESOS_PROPIOS = @VALOR14, SOLO_AGRICOLA = @VALOR15,
                                DEPENDIENTES_INGRESOS = @VALOR16, CARNET_CONAPDIS = @VALOR17, ESTADO_CCSS = @VALOR18, HIJOS_MENORES = @VALOR19,
                                CHECK_MH = @VALOR20, CHECK_MAG = @VALOR21 WHERE CODIGO = @VALOR1"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", "")
            cmd.Parameters.AddWithValue("@VALOR3", "")
            cmd.Parameters.AddWithValue("@VALOR4", "")
            cmd.Parameters.AddWithValue("@VALOR5", "")
            cmd.Parameters.AddWithValue("@VALOR6", "")
            cmd.Parameters.AddWithValue("@VALOR7", "")
            cmd.Parameters.AddWithValue("@VALOR8", "")
            cmd.Parameters.AddWithValue("@VALOR9", "")
            cmd.Parameters.AddWithValue("@VALOR10", "")
            cmd.Parameters.AddWithValue("@VALOR11", "")
            cmd.Parameters.AddWithValue("@VALOR12", "")
            cmd.Parameters.AddWithValue("@VALOR13", "")
            cmd.Parameters.AddWithValue("@VALOR14", "")
            cmd.Parameters.AddWithValue("@VALOR15", "")
            cmd.Parameters.AddWithValue("@VALOR16", "")
            cmd.Parameters.AddWithValue("@VALOR17", "")
            cmd.Parameters.AddWithValue("@VALOR18", "")
            cmd.Parameters.AddWithValue("@VALOR19", "")
            cmd.Parameters.AddWithValue("@VALOR20", "False")
            cmd.Parameters.AddWithValue("@VALOR21", "False")
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function


    ' Elimina los datos deL representante legal de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto RepresentanteLegal que contiene los datos.</returns>
    Public Function borrarRLPP(ByVal inscripcion As String) As RepresentanteLegal
        Dim modelo As New RepresentanteLegal
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "DELETE FROM GC_REPRESENTANTE_LEGAL WHERE INSCRIPCION = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function


    ' Elimina los datos de la información sobre Lineas de abastecimiento de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto LineaAbastecimiento que contiene los datos.</returns>
    Public Function borrarLineaAbPP(ByVal inscripcion As String) As LineaAbastecimiento
        Dim modelo As New LineaAbastecimiento
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "DELETE FROM GC_DATOS_LINEA_AB WHERE INSCRIPCION = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Elimina los datos de la información sobre certificaciones de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Productor que contiene los datos.</returns>
    Public Function borrarCertPP(ByVal inscripcion As String) As Certificacion
        Dim modelo As New Certificacion
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "DELETE FROM GC_CERTIFICACION WHERE PRODUCTOR = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Obtiene la información de resolucion de inscripcion de un productor.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Productor que contiene los datos de la resolución.</returns>
    Public Function cargarResolucion(ByVal inscripcion As String) As Productor
        Dim modelo As New Productor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select ESTADO, NUM_RESOLUCION, OBSERVACIONES, FECHA_DEVOLUCION From GC_PRODUCTOR Where CODIGO = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                modelo.estado_form = dr(0).ToString
                modelo.numResolucion = dr(1).ToString
                modelo.observaciones = dr(2).ToString
                Dim fechaDevolucion As DateTime
                If DateTime.TryParse(dr(3).ToString, fechaDevolucion) Then
                    modelo.fecha_devolucion = fechaDevolucion.ToString("yyyy/MM/dd")
                Else
                    modelo.fecha_devolucion = String.Empty
                End If
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function
End Class
