Public Class RepresentanteLegal
    Private _codigo As Int16
    Public Property codigo() As Int16
        Get
            Return _codigo
        End Get
        Set(ByVal value As Int16)
            _codigo = value
        End Set
    End Property

    Private _inscripcion As String
    Public Property inscripcion() As String
        Get
            Return _inscripcion
        End Get
        Set(ByVal value As String)
            _inscripcion = value
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

    Private _genero As Char
    Public Property genero() As Char
        Get
            Return _genero
        End Get
        Set(ByVal value As Char)
            _genero = value
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

    Private _telefonoFijo As String
    Public Property telefonoFijo() As String
        Get
            Return _telefonoFijo
        End Get
        Set(ByVal value As String)
            _telefonoFijo = value
        End Set
    End Property

    Private _telefonoMovil As String
    Public Property telefonoMovil() As String
        Get
            Return _telefonoMovil
        End Get
        Set(ByVal value As String)
            _telefonoMovil = value
        End Set
    End Property

    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _estado As Boolean
    Public Property estado() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property

    Private _sinRepLegal As Boolean
    Public Property sinRepLegal() As Boolean
        Get
            Return _sinRepLegal
        End Get
        Set(ByVal value As Boolean)
            _sinRepLegal = value
        End Set
    End Property

End Class
