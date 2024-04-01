Imports System.Data.SqlClient
Public Class UsuarioInternoDAO

    Private Shared _instancia As UsuarioInternoDAO = Nothing

    ' Propiedad de solo lectura para obtener una instancia única de la clase UsuarioInternoDAO.
    Public Shared ReadOnly Property Instancia As UsuarioInternoDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New UsuarioInternoDAO()
            End If
            Return _instancia
        End Get
    End Property


    ' Registra un nuevo usuario en la base de datos.
    ''' <param name="modelo">El objeto Usuario a registrar.</param>
    ''' <returns>El objeto Usuario registrado.</returns>
    Public Function guardarUsuarioNuevo(ByVal modelo As UsuarioInterno) As UsuarioInterno
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_USUARIOS_INTERNOS (CEDULA, NOMBRE, USUARIO, CORREO, PASS, GENERO, REGION, ROL)"
            sql = sql + " Values (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.nombre)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.usuario)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.correo)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.pass)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.genero)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.region)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.rol)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function


    ' Verifica si una cédula de usuario interno ya está registrada en la base de datos.
    ''' <param name="cedula">La cédula a verificar.</param>
    ''' <returns>True si la cédula ya está registrada, False en caso contrario.</returns>
    Public Function validarCedulaUsuario(ByVal cedula As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CEDULA From GC_USUARIOS_INTERNOS Where CEDULA=@VALOR1"
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


    ' Verifica si una dirección de correo electrónico de usuario Inteerno ya está registrada en la base de datos.
    ''' <param name="correo">La dirección de correo electrónico a verificar.</param>
    ''' <returns>True si la dirección de correo ya está registrada, False en caso contrario.</returns>
    Public Function validarCorreoUsuario(ByVal correo As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CORREO From GC_USUARIOS_INTERNOS Where CORREO=@VALOR1"
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

    ' Verifica si usuario cnp ya está registrada en la base de datos.
    ''' <param name="usuario">El usuario a verificar.</param>
    ''' <returns>True si el usuario ya está registrada, False en caso contrario.</returns>
    Public Function validarUsuario(ByVal usuario As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select USUARIO From GC_USUARIOS_INTERNOS Where USUARIO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", usuario)
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

    ' Busca y retorna una colección de tipos de roles desde la base de datos.
    ''' <returns>Una colección de objetos Roles.</returns>
    Public Function buscarRoles() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_ROL_USUARIO_INTERNO"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Roles
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                modelo.filtrarRegion = dr(2).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Busca y retorna una colección de tipos de regiones desde la base de datos.
    ''' <returns>Una colección de objetos regiones.</returns>
    Public Function buscarRegiones() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_TERRITORIO_REGION"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Regiones
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function


    ' Guarda las respuestas en la base de datos.
    ''' <param name="listaModelos">La lista de respuestas a guardar.</param>
    ''' <returns>La lista de respuestas guardadas.</returns>
    Public Function guardarRespuestas(ByVal listaModelos As List(Of Respuestas_Access)) As List(Of Respuestas_Access)
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones())
            cn.Open()
            Dim sql As String = "INSERT INTO GC_RESPUESTAS_SEGURIDAD_UI (USUARIO, COD_PREGUNTA, RESPUESTA) VALUES (@VALOR1, @VALOR2, @VALOR3)"
            Dim cmd As New SqlCommand(sql, cn)
            For Each modelo As Respuestas_Access In listaModelos
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@VALOR1", modelo.usuario)
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

    ' Valida las credenciales de inicio de sesión de un usuario.
    ''' <param name="modelo">El objeto Usuario con las credenciales a validar.</param>
    ''' <returns>True si las credenciales son válidas, False en caso contrario.</returns>
    Public Function validarPassword(ByVal modelo As UsuarioInterno) As Boolean
        Dim coincide As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT 1 FROM GC_USUARIOS_INTERNOS WHERE USUARIO = @VALOR1 AND PASS = @VALOR2"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.usuario)
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

    ' Verifica si la respuesta a la pregunta de seguridad es correcta para un usuario dado.
    ''' <param name="usuario">usuario cnp del usuario.</param>
    ''' <param name="codigo">El código de la pregunta de seguridad.</param>
    ''' <param name="respuesta">La respuesta a la pregunta de seguridad.</param>
    ''' <returns>True si la respuesta es correcta, False en caso contrario.</returns>
    Public Function verificarRespuestaPregunta(ByVal usuario As String, ByVal codigo As String, ByVal respuesta As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT * FROM GC_RESPUESTAS_SEGURIDAD_UI where USUARIO = @VALOR1 and COD_PREGUNTA = @VALOR2 and RESPUESTA = @VALOR3"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", usuario)
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

    ' Obtiene la región de un funcionario a partir de su usuario cnp.
    ''' <param name="usuario">Usuario cnp del usuario.</param>
    ''' <returns>Un objeto Usuariointerno que representa los datos del usuario.</returns>
    Public Function traerRegionUI(ByVal usuario As String) As Regiones
        Dim modelo As New Regiones
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_USUARIOS_INTERNOS Where USUARIO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", usuario)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()

            While dr.Read
                modelo.codigo = dr(6).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Selecciona si la opcion filtrar region según el Rol está habilitada.
    ''' <param name="rolSelect">La selección del rol del combobox.</param>
    ''' <returns>modelo Roles con un SI o un NO</returns>
    Public Function RolRegion(ByVal rolSelect As String) As Roles
        Dim modelo As New Roles
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select FILTRAR_REGION From GC_ROL_USUARIO_INTERNO Where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", rolSelect)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                modelo.filtrarRegion = dr(0).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Obtiene el rol de un funcionario a partir de su usuario cnp.
    ''' <param name="usuario">Usuario cnp del usuario.</param>
    ''' <returns>Un objeto UsuarioInterno que representa el rol usuario.</returns>
    Public Function cargarRolUI(ByVal usuario As String) As UsuarioInterno
        Dim modelo As New UsuarioInterno
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select ROL From GC_USUARIOS_INTERNOS Where USUARIO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", usuario)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                modelo.rol = dr(0).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

End Class
