Public Class LineasProduccion

    Private _codigo As Int16
    Public Property codigo() As Int16
        Get
            Return _codigo
        End Get
        Set(ByVal value As Int16)
            _codigo = value
        End Set
    End Property

    Private _categoria As String
    Public Property categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
        End Set
    End Property

    Private _clasificacion As Int16
    Public Property clasificacion() As Int16
        Get
            Return _clasificacion
        End Get
        Set(ByVal value As Int16)
            _clasificacion = value
        End Set
    End Property

End Class
