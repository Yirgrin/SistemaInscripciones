Public Class TipoCertificado
    Private _codigo As Integer
    Public Property codigo() As Integer
        Get
            Return _codigo
        End Get
        Set(ByVal value As Integer)
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

    Private _institucion As String
    Public Property institucion() As String
        Get
            Return _institucion
        End Get
        Set(ByVal value As String)
            _institucion = value
        End Set
    End Property

    Private _campoNumero As Boolean
    Public Property campoNumero() As Boolean
        Get
            Return _campoNumero
        End Get
        Set(ByVal value As Boolean)
            _campoNumero = value
        End Set
    End Property

    Private _campoFechaEmision As Boolean
    Public Property campoFechaEmision() As Boolean
        Get
            Return _campoFechaEmision
        End Get
        Set(ByVal value As Boolean)
            _campoFechaEmision = value
        End Set
    End Property

    Private _campoFechaVencimiento As Boolean
    Public Property campoFechaVencimiento() As Boolean
        Get
            Return _campoFechaVencimiento
        End Get
        Set(ByVal value As Boolean)
            _campoFechaVencimiento = value
        End Set
    End Property

End Class
