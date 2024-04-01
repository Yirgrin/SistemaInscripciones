Public Class UsuarioInternoNegocio

    Private Shared _instancia As UsuarioInternoNegocio = Nothing
    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase UsuarioNegocio.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As UsuarioInternoNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New UsuarioInternoNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ' Registra un nuevo usuario en la base de datos.

    ''' <param name="cedula">Número de cédula del usuario.</param>
    ''' <param name="nombre">Nombre del usuario.</param>
    ''' <param name="usuario">Usuario cnp del usuario.</param>
    ''' <param name="email">Dirección de correo electrónico del usuario.</param>
    ''' <param name="pass">Contraseña del usuario.</param>
    ''' <param name="genero">Género del usuario.</param>
    ''' <returns>Un objeto Usuario que representa al usuario registrado.</returns>
    Public Function guardarUsuarioNuevo(ByVal cedula As String, ByVal nombre As String, ByVal usuario As String,
                                        ByVal email As String, ByVal pass As String, ByVal genero As String,
                                        ByVal region As String, ByVal rol As String) As UsuarioInterno
        Dim modelo As New UsuarioInterno
        modelo.cedula = cedula
        modelo.nombre = nombre
        modelo.usuario = usuario
        modelo.correo = email
        modelo.pass = pass
        modelo.genero = genero
        modelo.region = region
        modelo.rol = rol
        Return UsuarioInternoDAO.Instancia.guardarUsuarioNuevo(modelo)
    End Function


    ' Valida si una cédula de usuario ya existe en la base de datos.
    ''' <param name="cedula">Número de cédula a validar.</param>
    ''' <returns>True si la cédula existe en la base de datos, False en caso contrario.</returns>
    Public Function validarCedulaUsuario(ByVal cedula As String) As Boolean
        Return UsuarioInternoDAO.Instancia.validarCedulaUsuario(cedula)
    End Function

    ' Valida si una dirección de correo electrónico de usuario Interno ya existe en la base de datos.
    ''' <param name="correo">Dirección de correo electrónico a validar.</param>
    ''' <returns>True si el correo electrónico existe en la base de datos, False en caso contrario.</returns>
    Public Function validarCorreoUsuario(ByVal correo As String) As Boolean
        Return UsuarioInternoDAO.Instancia.validarCorreoUsuario(correo)
    End Function

    ' Valida si el usuario cnp ya existe en la base de datos.
    ''' <param name="usuario">usuario a validar.</param>
    ''' <returns>True si el usuario existe en la base de datos, False en caso contrario.</returns>
    Public Function validarUsuario(ByVal usuario As String) As Boolean
        Return UsuarioInternoDAO.Instancia.validarUsuario(usuario)
    End Function

    ' Busca y retorna una colección de regiones.
    ''' <returns>Una colección de objetos de regiones.</returns>
    Public Function buscarRoles() As Collection
        Return UsuarioInternoDAO.Instancia.buscarRoles()
    End Function

    ' Busca y retorna una colección de regiones.
    ''' <returns>Una colección de objetos de regiones.</returns>
    Public Function buscarRegiones() As Collection
        Return UsuarioInternoDAO.Instancia.buscarRegiones()
    End Function

    ' Valida las credenciales de inicio de sesión de un usuario.
    ''' <param name="modelo">Objeto Usuario que contiene las credenciales de inicio de sesión.</param>
    ''' <returns>True si las credenciales son válidas, False en caso contrario.</returns>
    Function validarPassword(ByVal modelo As UsuarioInterno) As Boolean
        Return UsuarioInternoDAO.Instancia.validarPassword(modelo)
    End Function

    ' Verifica si la respuesta a una pregunta de seguridad proporcionada por el usuario es correcta.
    ''' <param name="usuario">número de cedula del usuario.</param>
    ''' <param name="codigo">Código de la pregunta de seguridad.</param>
    ''' <param name="respuesta">Respuesta proporcionada por el usuario.</param>
    ''' <returns>True si la respuesta es correcta, False en caso contrario.</returns>
    Function verificarRespuestaPregunta(ByVal usuario As String, ByVal codigo As String, ByVal respuesta As String) As Boolean
        Return UsuarioInternoDAO.Instancia.verificarRespuestaPregunta(usuario, codigo, respuesta)
    End Function


    ' Guarda las respuestas de un usuario a las preguntas de seguridad en la base de datos.
    ''' <param name="usuario">usuario cnp del usuario.</param>
    ''' <param name="listaRespuestas">La lista de respuestas a guardar.</param>
    ''' <returns>La lista de respuestas guardadas.</returns>
    Function guardarRespuestas(ByVal usuario As String, ByVal listaRespuestas As List(Of String)) As List(Of Respuestas_Access)
        Dim listaModelos As New List(Of Respuestas_Access)
        For index = 0 To 4
            Dim modelo As New Respuestas_Access
            modelo.usuario = usuario
            modelo.codigoPregunta = index + 1.ToString
            modelo.respuesta = listaRespuestas(index)
            listaModelos.Add(modelo)
        Next
        Return UsuarioInternoDAO.Instancia.guardarRespuestas(listaModelos)
    End Function


    ' Obtiene la región de un funcionario a partir de su usuario cnp.
    ''' <param name="usuario">Usuario cnp del usuario.</param>
    ''' <returns>Un objeto Usuario que representa los datos del usuario.</returns>
    Function traerRegionUI(ByRef usuario As String) As Regiones
        Return UsuarioInternoDAO.Instancia.traerRegionUI(usuario)
    End Function

    ' Obtiene el rol de un funcionario a partir de su usuario cnp.
    ''' <param name="usuario">Usuario cnp del usuario.</param>
    ''' <returns>Un objeto UsuarioInterno que representa el rol usuario.</returns>
    Function cargarRolUI(ByRef usuario As String) As UsuarioInterno
        Return UsuarioInternoDAO.Instancia.cargarRolUI(usuario)
    End Function

    ' Selecciona si la opcion filtrar region según el Rol está habilitada.
    ''' <param name="rolSelect">opción de rol seleccionada .</param>
    ''' <returns>Objeto Roles que trae un SI o un NO</returns>
    Function RolRegion(ByVal rolSelect As String) As Roles
        Return UsuarioInternoDAO.Instancia.RolRegion(rolSelect)
    End Function





End Class
