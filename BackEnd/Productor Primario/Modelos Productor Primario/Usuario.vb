Public Class Usuario
    Private _codigo As Int16
    Public Property codigo() As Int16
        Get
            Return _codigo
        End Get
        Set(ByVal value As Int16)
            _codigo = value
        End Set
    End Property

    Private _tipoCedula As String
    Public Property tipoCedula() As String
        Get
            Return _tipoCedula
        End Get
        Set(ByVal value As String)
            _tipoCedula = value
        End Set
    End Property

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
End Class
