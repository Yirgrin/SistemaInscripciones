Imports System.Data.SqlClient

''' <summary>
''' Clase que proporciona métodos para interactuar con la base de datos relacionados con usuarios.
''' </summary>
Public Class UsuarioDAO
    Private Shared _instancia As UsuarioDAO = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase UsuarioDAO utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As UsuarioDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New UsuarioDAO()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Verifica si la respuesta a la pregunta de seguridad es correcta para un usuario dado.
    ''' </summary>
    ''' <param name="cedula">La cédula del usuario.</param>
    ''' <param name="codigo">El código de la pregunta de seguridad.</param>
    ''' <param name="respuesta">La respuesta a la pregunta de seguridad.</param>
    ''' <returns>True si la respuesta es correcta, False en caso contrario.</returns>
    Public Function verificarRespuestaPregunta(ByVal cedula As String, ByVal codigo As String, ByVal respuesta As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT * FROM GC_RESPUESTAS_ACCESS where CEDULA = @VALOR1 and COD_PREGUNTA = @VALOR2 and RESPUESTA = @VALOR3"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", cedula)
            cmd.Parameters.AddWithValue("@VALOR2", codigo)
            cmd.Parameters.AddWithValue("@VALOR3", respuesta)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                existe = True
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return existe
    End Function


    ''' <summary>
    ''' Registra un nuevo usuario en la base de datos.
    ''' </summary>
    ''' <param name="modelo">El objeto Usuario a registrar.</param>
    ''' <returns>El objeto Usuario registrado.</returns>
    Public Function guardarUsuarioNuevo(ByVal modelo As Usuario) As Usuario
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_USUARIO (CEDULA, NOMBRE, CORREO, PASS, TIPO_CEDULA, GENERO)"
            sql = sql + " Values (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.nombre)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.correo)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.pass)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.tipoCedula)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.genero)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ''' <summary>
    ''' Verifica si una cédula de usuario ya está registrada en la base de datos.
    ''' </summary>
    ''' <param name="cedula">La cédula a verificar.</param>
    ''' <returns>True si la cédula ya está registrada, False en caso contrario.</returns>
    Public Function validarCedulaUsuario(ByVal cedula As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CEDULA From GC_USUARIO Where CEDULA=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", cedula)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                existe = True
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return existe
    End Function

    ''' <summary>
    ''' Verifica si una dirección de correo electrónico de usuario ya está registrada en la base de datos.
    ''' </summary>
    ''' <param name="correo">La dirección de correo electrónico a verificar.</param>
    ''' <returns>True si la dirección de correo ya está registrada, False en caso contrario.</returns>
    Public Function validarCorreoUsuario(ByVal correo As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CORREO From GC_USUARIO Where CORREO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", correo)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                existe = True
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return existe
    End Function

    ''' <summary>
    ''' Valida las credenciales de inicio de sesión de un usuario.
    ''' </summary>
    ''' <param name="modelo">El objeto Usuario con las credenciales a validar.</param>
    ''' <returns>True si las credenciales son válidas, False en caso contrario.</returns>
    Public Function validarPassword(ByVal modelo As Usuario) As Boolean
        Dim coincide As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT 1 FROM GC_USUARIO WHERE CEDULA = @VALOR1 AND PASS = @VALOR2"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.pass)
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                coincide = True
            End If
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return coincide
    End Function

    ''' <summary>
    ''' Obtiene los datos de un usuario a partir de su cédula.
    ''' </summary>
    ''' <param name="cedula">La cédula del usuario.</param>
    ''' <returns>El objeto Usuario con los datos del usuario.</returns>
    Public Function traerDatosUsuario(ByVal cedula As String) As Usuario
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_USUARIO Where CEDULA=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", cedula)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New Usuario
            While dr.Read
                modelo.cedula = dr(0).ToString
                modelo.nombre = dr(1).ToString
                modelo.correo = dr(2).ToString
                modelo.tipoCedula = dr(11).ToString
                modelo.genero = dr(12).ToString

            End While
            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene una lista de preguntas desde la base de datos.
    ''' </summary>
    ''' <returns>Una lista de objetos Preguntas_Access.</returns>
    Public Function buscarPreguntas() As List(Of Preguntas_Access)
        Dim preguntas As New List(Of Preguntas_Access)
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones())
            cn.Open()
            Dim sql As String = "SELECT * FROM GC_PREGUNTAS_ACCESS Order BY CODIGO"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Preguntas_Access
                modelo.codigo = dr(0)
                modelo.detalle = dr(1)
                preguntas.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return preguntas
    End Function

    ''' <summary>
    ''' Guarda las respuestas en la base de datos.
    ''' </summary>
    ''' <param name="listaModelos">La lista de respuestas a guardar.</param>
    ''' <returns>La lista de respuestas guardadas.</returns>
    Public Function guardarRespuestas(ByVal listaModelos As List(Of Respuestas_Access)) As List(Of Respuestas_Access)
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones())
            cn.Open()
            Dim sql As String = "INSERT INTO GC_RESPUESTAS_ACCESS (CEDULA, COD_PREGUNTA, RESPUESTA) VALUES (@VALOR1, @VALOR2, @VALOR3)"
            Dim cmd As New SqlCommand(sql, cn)
            For Each modelo As Respuestas_Access In listaModelos
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@VALOR1", modelo.cedula)
                cmd.Parameters.AddWithValue("@VALOR2", modelo.codigoPregunta)
                cmd.Parameters.AddWithValue("@VALOR3", modelo.respuesta)
                cmd.ExecuteNonQuery()
            Next
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return listaModelos
    End Function

    ''' actualiza la password asociada a una cédula.
    ''' <param name="modelo">vienen los datos de la cédula y la pass que ya existe.</param>
    Public Function modificarPassword(ByVal modelo As Usuario) As Usuario
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "UPDATE GC_USUARIO SET PASS = @VALOR2 WHERE CEDULA = @VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.pass)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function
End Class
