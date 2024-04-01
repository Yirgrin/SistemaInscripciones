Public Class UsuarioInterno


    Private _cedula As String
    Public Property cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
        End Set
    End Property

    Private _genero As String
    Public Property genero() As String
        Get
            Return _genero
        End Get
        Set(ByVal value As String)
            _genero = value
        End Set
    End Property

    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _usuario As String
    Public Property usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private _correo As String
    Public Property correo() As String
        Get
            Return _correo
        End Get
        Set(ByVal value As String)
            _correo = value
        End Set
    End Property

    Private _pass As String
    Public Property pass() As String
        Get
            Return _pass
        End Get
        Set(ByVal value As String)
            _pass = value
        End Set
    End Property

    Private _region As String
    Public Property region() As String
        Get
            Return _region
        End Get
        Set(ByVal value As String)
            _region = value
        End Set
    End Property

    Private _rol As String
    Public Property rol() As String
        Get
            Return _rol
        End Get
        Set(ByVal value As String)
            _rol = value
        End Set
    End Property


End Class
