Public Class Respuestas_Access

    Private _cedula As String
    Public Property cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
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

    Private _codigoPregunta As String
    Public Property codigoPregunta() As String
        Get
            Return _codigoPregunta
        End Get
        Set(ByVal value As String)
            _codigoPregunta = value
        End Set
    End Property

    Private _respuesta As String
    Public Property respuesta() As String
        Get
            Return _respuesta
        End Get
        Set(ByVal value As String)
            _respuesta = value
        End Set
    End Property

End Class
