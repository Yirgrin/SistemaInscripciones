Public Class Roles

    Private _codigo As Int16
    Public Property codigo() As Int16
        Get
            Return _codigo
        End Get
        Set(ByVal value As Int16)
            _codigo = value
        End Set
    End Property

    Private _detalle As String
    Public Property detalle() As String
        Get
            Return _detalle
        End Get
        Set(ByVal value As String)
            _detalle = value
        End Set

    End Property

    Private _filtrarRegion As String
    Public Property filtrarRegion() As String
        Get
            Return _filtrarRegion
        End Get
        Set(ByVal value As String)
            _filtrarRegion = value
        End Set

    End Property

End Class
