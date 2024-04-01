Imports System.Data.SqlClient
Public Class VistaInscripcionSADAO

    Private Shared _instancia As VistaInscripcionSADAO = Nothing
    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase VistaInscripcionSADAO.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As VistaInscripcionSADAO
        Get
            If _instancia Is Nothing Then
                _instancia = New VistaInscripcionSADAO()
            End If
            Return _instancia
        End Get
    End Property

    ' Trae los datos de un productor dado su código de inscripción.
    ''' <param name="inscripcion">El código de inscripción del productor.</param>
    ''' <returns>El objeto Productor con los datos del productor.</returns>
    Public Function traerDatosSuplidor(ByVal inscripcion As String) As Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From VW_GC_INSCRIP_1_INFO_SA Where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New Suplidor
            While dr.Read
                modelo.codigo = dr(0).ToString
                modelo.cedula = dr(1).ToString
                modelo.nombre = dr(2).ToString
                modelo.tipoCedula = dr(3).ToString
                modelo.genero = dr(4).ToString
                modelo.email = dr(5).ToString
                modelo.telefonoFijo = dr(6).ToString
                modelo.telefonoMovil = dr(7).ToString
                modelo.ActividadHM = dr(8).ToString
                modelo.direccionResidencia = dr(9).ToString
                modelo.codProvincia = dr(10)
                modelo.codCanton = dr(11)
                modelo.codDistrito = dr(12)
                modelo.fecha_envio = dr(13)
            End While
            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function

    ' Obtiene los datos de la información contable por su inscripción.
    ''' <param name="inscripcion">La inscripción del suplidor.</param>
    ''' <returns>El objeto ActividadContable correspondiente a la inscripción.</returns>
    Public Function cargarDatosContables(ByVal inscripcion As String) As ActividadContable
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From VW_GC_INSCRIP_3_INFOCONTA_SA Where INSCRIPCION=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New ActividadContable
            While dr.Read
                modelo.codigo = dr(9).ToString
                modelo.actividadPrincipal = dr(5).ToString
                modelo.cantidadEmpleados = dr(0).ToString
                modelo.ventasNetas = dr(1).ToString
                modelo.activosFijos = dr(2).ToString
                modelo.activosTotales = dr(3).ToString
                modelo.codProvincia = dr(7).ToString
                modelo.codCanton = dr(8).ToString
                modelo.codDistrito = dr(6).ToString
                modelo.direcExacta = dr(4).ToString
                modelo.codigoProduccion = dr(11).ToString

            End While
            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene los datos para hacer la formula de clasificacion de suplidores.
    ''' </summary>
    ''' <returns>Un objeto FormulaClasificacion con los detalles de la formula.</returns>
    Public Function traerFormulaIndustria() As FormulaClasificacion
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT SIMBOLOGIA, INDUSTRIA FROM GC_FORMULA_CLASIFICACION"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New FormulaClasificacion

            While dr.Read()
                Dim simbologia = dr("SIMBOLOGIA").ToString
                If simbologia = "Fpe" Then
                    modelo.Fpe = dr("INDUSTRIA").ToString()
                ElseIf simbologia = "Fipf" Then
                    modelo.Fipf = dr("INDUSTRIA").ToString()
                ElseIf simbologia = "Fan" Then
                    modelo.Fan = dr("INDUSTRIA").ToString()
                ElseIf simbologia = "Dpe" Then
                    modelo.Dpe = dr("INDUSTRIA").ToString()
                ElseIf simbologia = "Dinpf" Then
                    modelo.Dinpf = dr("INDUSTRIA").ToString()
                ElseIf simbologia = "Dan" Then
                    modelo.Dan = dr("INDUSTRIA").ToString()
                End If
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
    Public Function buscarRutaArchivo(ByVal inscripcion As String) As Certificaciones
        Dim modelo As New Certificaciones
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select ARCHIVO From GC_CERTIFICACION_SUPLIDORES Where SUPLIDOR=@VALOR1"
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

    ' Obtiene la cuenta IBAN del usuario
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Certificacion que contiene los datos de la cuenta.</returns>
    Public Function buscarCuentaIBAN(ByVal inscripcion As String) As Certificaciones
        Dim modelo As New Certificaciones
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CUENTA_IBAN, BANCO From VW_GC_CERTIFICACION_SUPLIDOR Where SUPLIDOR=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                modelo.cuentaIBAN = dr(0).ToString
                modelo.codigoBanco = dr(1).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Actualiza el area de revision del formulario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <param name="areaRevision">estado del area de revision.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Public Function enviarSolicitud(ByVal areaRevision As String, ByVal inscripcion As String) As Suplidor
        Dim modelo As New Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_SUPLIDORES SET AREA_REVISION = @VALOR1 WHERE CODIGO = @VALOR2"
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

    ' Subsana la inscripción de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Productor que contiene los datos.</returns>
    Public Function subsanarSoliPP(ByVal inscripcion As String) As Suplidor
        Dim modelo As New Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "DELETE FROM GC_CERTIFICACION_SUPLIDORES WHERE SUPLIDOR = @VALOR1"
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
    Public Function actualizarSuplidorSubs(ByRef inscripcion As String, ByRef numResolucion As String, ByRef observacion As String) As Suplidor
        Dim modelo As New Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_SUPLIDORES SET NUM_RESOLUCION = @VALOR2, OBSERVACIONES = @VALOR3, 
                                ESTADO_FORM = @VALOR4, AREA_REVISION = @VALOR5 WHERE CODIGO = @VALOR1"
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

    ' Busca y carga si la verificación en campo está completada.
    ''' <param name="modelo">modelo con toda los datos de inspección técnica a insertar.</param>
    ''' <returns>Un objeto InspeccionTecnica que contiene los datos.</returns>
    Public Function guardarInspeccion(ByRef modelo As InspeccionTecnica) As String
        Dim inspeccion As String = ""
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "INSERT INTO GC_INSPECCION_TECNICA_SA (SUPLIDOR, REALIZADA_UI, FECHA_INSPECCION, NUM_SOLICITUD, FECHA_SOLICITUD, NUM_OFICIO, FECHA_OFICIO, CUMPLIMIENTO_MAYOR, CUMPLIMIENTO_MENOR)"
            sql += "VALUES (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8, @VALOR9);"
            Dim cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@VALOR1", modelo.suplidor)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.realizadaPor)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.fechaInspeccion)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.numSolicitud)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.fechaSolicitud)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.numOficio)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.fechaOficio)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.cumplimientoMayor)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.cumplimientoMenor)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return inspeccion
    End Function

    ' Actualiza la información de resolución de un suplidor.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <param name="numResolucion">Número de resolución agregado por un UI.</param>
    ''' <param name="fechaResolucion">fecha de devolución del formulario.</param>
    ''' <param name="condicion">condicion rechazada o aceptada del formulario.</param>
    ''' <param name="observaciones">observaciones opcionales agregadas por el funcionario.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Public Function actualizarInscripSA(ByRef inscripcion As String, ByRef numResolucion As String,
                                        ByRef fechaResolucion As String, ByRef condicion As String, ByRef observaciones As String) As Suplidor
        Dim modelo As New Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_SUPLIDORES SET NUM_RESOLUCION = @VALOR2, FECHA_DEVOLUCION = @VALOR3, 
                                ESTADO_FORM = @VALOR4, AREA_REVISION = @VALOR5, OBSERVACIONES = @VALOR6 WHERE CODIGO = @VALOR1"
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
    Public Function borrarInfoSA(ByVal inscripcion As String) As Suplidor
        Dim modelo As New Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()

            Dim sql As String = "UPDATE GC_SUPLIDORES SET GENERO = @VALOR3, TELEFONO_FIJO = @VALOR4, 
                                TELEFONO_CELULAR = @VALOR5, ACTIVIDAD_MH = @VALOR6, DIRECCION_EXACTA = @VALOR7, DISTRITO = @VALOR8, 
                                 REGION = @VALOR9, PROVINCIA = @VALOR10, CANTON = @VALOR11 WHERE CODIGO = @VALOR1"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.Parameters.AddWithValue("@VALOR3", "")
            cmd.Parameters.AddWithValue("@VALOR4", "")
            cmd.Parameters.AddWithValue("@VALOR5", "")
            cmd.Parameters.AddWithValue("@VALOR6", "")
            cmd.Parameters.AddWithValue("@VALOR7", "")
            cmd.Parameters.AddWithValue("@VALOR8", "")
            cmd.Parameters.AddWithValue("@VALOR9", "")
            cmd.Parameters.AddWithValue("@VALOR10", "")
            cmd.Parameters.AddWithValue("@VALOR11", "")
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function


    ' Elimina los datos deL representante legal de un usuario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Public Function borrarRLSA(ByVal inscripcion As String) As Suplidor
        Dim modelo As New Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "DELETE FROM GC_RL_SUPLIDOR WHERE INSCRIPCION = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Elimina los datos de la actividad contable de un usuario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Public Function borrarInfoContaSA(ByVal inscripcion As String) As ActividadContable
        Dim modelo As New ActividadContable
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()

            ' Primera consulta para eliminar registros de la tabla GC_ACTIVIDAD_CONTABLE
            Dim sql1 As String = "DELETE FROM GC_ACTIVIDAD_CONTABLE WHERE INSCRIPCION = @VALOR1"
            Dim cmd1 As New SqlCommand(sql1, cn)
            cmd1.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd1.ExecuteNonQuery()

            ' Segunda consulta para eliminar registros de la tabla GC_ACTIVIDADES_COMERCIALES
            Dim sql2 As String = "DELETE FROM GC_ACTIVIDADES_COMERCIALES WHERE INSCRIPCION = @VALOR1"
            Dim cmd2 As New SqlCommand(sql2, cn)
            cmd2.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd2.ExecuteNonQuery()

            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Elimina los datos de la información sobre certificaciones de un usuario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Public Function borrarCertSA(ByVal inscripcion As String) As Certificaciones
        Dim modelo As New Certificaciones
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "DELETE FROM GC_CERTIFICACION_SUPLIDORES WHERE SUPLIDOR = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' actualiza la información de inspección técnica.
    ''' <param name="modelo">modelo con toda los datos de inspección técnica a modificar.</param>
    ''' <returns>Un objeto InspeccionTecnica que contiene los datos.</returns>
    Public Function actualizarInspeccion(ByRef modelo As InspeccionTecnica) As String
        Dim inspeccion As String = ""
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_INSPECCION_TECNICA_SA SET REALIZADA_UI = @VALOR2, FECHA_INSPECCION = @VALOR3, 
                                NUM_SOLICITUD = @VALOR4, FECHA_SOLICITUD = @VALOR5, NUM_OFICIO = @VALOR6, FECHA_OFICIO = @VALOR7,
                                CUMPLIMIENTO_MAYOR = @VALOR8, CUMPLIMIENTO_MENOR = @VALOR9 WHERE SUPLIDOR = @VALOR1;"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.suplidor)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.realizadaPor)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.fechaInspeccion)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.numSolicitud)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.fechaSolicitud)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.numOficio)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.fechaOficio)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.cumplimientoMayor)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.cumplimientoMenor)

            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return inspeccion
    End Function

    ' Obtiene la información de inspección técnica.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Certificacion que contiene los datos de la ruta.</returns>
    Public Function cargarInspeccion(ByVal inscripcion As String) As InspeccionTecnica
        Dim modelo As New InspeccionTecnica
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From  GC_INSPECCION_TECNICA_SA Where SUPLIDOR=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                modelo.realizadaPor = dr(2).ToString
                modelo.fechaInspeccion = dr(3).ToString
                modelo.numSolicitud = dr(4).ToString
                modelo.fechaSolicitud = dr(5).ToString
                modelo.numOficio = dr(6).ToString
                modelo.fechaOficio = dr(7).ToString
                modelo.cumplimientoMayor = dr(8).ToString
                modelo.cumplimientoMenor = dr(9).ToString

            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Obtiene la información de resolucion de inscripcion de un suplidor.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Certificacion que contiene los datos de la ruta.</returns>
    Public Function cargarResolucion(ByVal inscripcion As String) As Suplidor
        Dim modelo As New Suplidor
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select ESTADO_FORM, NUM_RESOLUCION, OBSERVACIONES, FECHA_DEVOLUCION From  GC_SUPLIDORES Where CODIGO = @VALOR1"
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
