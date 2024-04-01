''' <summary>
''' Clase que representa la lógica de negocio relacionada con los Usuarios.
''' </summary>
Public Class UsuarioNegocio

    Private Shared _instancia As UsuarioNegocio = Nothing

    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase UsuarioNegocio.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As UsuarioNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New UsuarioNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Registra un nuevo usuario en la base de datos.
    ''' </summary>
    ''' <param name="tipoCedula">Tipo de cédula del usuario.</param>
    ''' <param name="cedula">Número de cédula del usuario.</param>
    ''' <param name="genero">Género del usuario.</param>
    ''' <param name="nombre">Nombre del usuario.</param>
    ''' <param name="email">Dirección de correo electrónico del usuario.</param>
    ''' <param name="pass">Contraseña del usuario.</param>
    ''' <returns>Un objeto Usuario que representa al usuario registrado.</returns>
    Public Function guardarUsuarioNuevo(ByVal tipoCedula As String, ByVal cedula As String, ByVal genero As String, ByVal nombre As String, ByVal email As String, ByVal pass As String) As Usuario
        Dim modelo As New Usuario
        modelo.tipoCedula = tipoCedula
        modelo.cedula = cedula
        modelo.genero = genero
        modelo.nombre = nombre
        modelo.correo = email
        modelo.pass = pass
        Return UsuarioDAO.Instancia.guardarUsuarioNuevo(modelo)
    End Function

    ''' <summary>
    ''' Valida si una cédula de usuario ya existe en la base de datos.
    ''' </summary>
    ''' <param name="cedula">Número de cédula a validar.</param>
    ''' <returns>True si la cédula existe en la base de datos, False en caso contrario.</returns>
    Public Function validarCedulaUsuario(ByVal cedula As String) As Boolean
        Return UsuarioDAO.Instancia.validarCedulaUsuario(cedula)
    End Function

    ''' <summary>
    ''' Valida si una dirección de correo electrónico de usuario ya existe en la base de datos.
    ''' </summary>
    ''' <param name="correo">Dirección de correo electrónico a validar.</param>
    ''' <returns>True si el correo electrónico existe en la base de datos, False en caso contrario.</returns>
    Public Function validarCorreoUsuario(ByVal correo As String) As Boolean
        Return UsuarioDAO.Instancia.validarCorreoUsuario(correo)
    End Function

    ''' <summary>
    ''' Valida las credenciales de inicio de sesión de un usuario.
    ''' </summary>
    ''' <param name="modelo">Objeto Usuario que contiene las credenciales de inicio de sesión.</param>
    ''' <returns>True si las credenciales son válidas, False en caso contrario.</returns>
    Function validarPassword(ByVal modelo As Usuario) As Boolean
        Return UsuarioDAO.Instancia.validarPassword(modelo)
    End Function

    ''' <summary>
    ''' Obtiene los datos de un usuario a partir de su número de cédula.
    ''' </summary>
    ''' <param name="cedula">Número de cédula del usuario.</param>
    ''' <returns>Un objeto Usuario que representa los datos del usuario.</returns>
    Function traerDatosUsuario(ByRef cedula As String) As Usuario
        Return UsuarioDAO.Instancia.traerDatosUsuario(cedula)
    End Function

    ''' <summary>
    ''' Verifica si la respuesta a una pregunta de seguridad proporcionada por el usuario es correcta.
    ''' </summary>
    ''' <param name="cedula">Número de cédula del usuario.</param>
    ''' <param name="codigo">Código de la pregunta de seguridad.</param>
    ''' <param name="respuesta">Respuesta proporcionada por el usuario.</param>
    ''' <returns>True si la respuesta es correcta, False en caso contrario.</returns>
    Function verificarRespuestaPregunta(ByVal cedula As String, ByVal codigo As String, ByVal respuesta As String) As Boolean
        Return UsuarioDAO.Instancia.verificarRespuestaPregunta(cedula, codigo, respuesta)
    End Function


    ''' <summary>
    ''' Busca y retorna una lista de preguntas desde la capa de acceso a datos.
    ''' </summary>
    ''' <returns>Una lista de objetos Preguntas_Access.</returns>
    Function buscarPreguntas() As List(Of Preguntas_Access)
        Return UsuarioDAO.Instancia.buscarPreguntas()
    End Function

    ''' <summary>
    ''' Guarda las respuestas de un usuario en la base de datos.
    ''' </summary>
    ''' <param name="cedula">La cédula del usuario.</param>
    ''' <param name="listaRespuestas">La lista de respuestas a guardar.</param>
    ''' <returns>La lista de respuestas guardadas.</returns>
    Function guardarRespuestas(ByVal cedula As String, ByVal listaRespuestas As List(Of String)) As List(Of Respuestas_Access)
        'usuario
        Dim listaModelos As New List(Of Respuestas_Access)
        For index = 0 To 4
            Dim modelo As New Respuestas_Access
            modelo.cedula = cedula
            modelo.codigoPregunta = index + 1.ToString
            modelo.respuesta = listaRespuestas(index)
            listaModelos.Add(modelo)
        Next
        Return UsuarioDAO.Instancia.guardarRespuestas(listaModelos)
    End Function

    'modifica la contraseña de un usuario asociado a una cédula 
    Function modificarPassword(ByVal cedula As String, ByVal pass As String) As Usuario
        Dim modelo As New Usuario
        modelo.cedula = cedula
        modelo.pass = pass
        Return UsuarioDAO.Instancia.modificarPassword(modelo)
    End Function

End Class
