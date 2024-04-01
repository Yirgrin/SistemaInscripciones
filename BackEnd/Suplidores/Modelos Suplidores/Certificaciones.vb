Public Class Certificaciones

    Private _codigo As Int16
    Public Property codigo() As Int16
        Get
            Return _codigo
        End Get
        Set(ByVal value As Int16)
            _codigo = value
        End Set
    End Property

    Private _suplidor As String
    Public Property suplidor() As String
        Get
            Return _suplidor
        End Get
        Set(ByVal value As String)
            _suplidor = value
        End Set
    End Property

    Private _tipoCertificado As String
    Public Property tipoCertificado() As String
        Get
            Return _tipoCertificado
        End Get
        Set(ByVal value As String)
            _tipoCertificado = value
        End Set
    End Property

    Private _numero As String
    Public Property numero() As String
        Get
            Return _numero
        End Get
        Set(ByVal value As String)
            _numero = value
        End Set
    End Property

    Private _archivo As String
    Public Property archivo() As String
        Get
            Return _archivo
        End Get
        Set(ByVal value As String)
            _archivo = value
        End Set
    End Property

    Private _extencion As String
    Public Property extencion() As String
        Get
            Return _extencion
        End Get
        Set(ByVal value As String)
            _extencion = value
        End Set
    End Property

    Private _fechaEmision As String
    Public Property fechaEmision() As String
        Get
            Return _fechaEmision
        End Get
        Set(ByVal value As String)
            _fechaEmision = value
        End Set
    End Property

    Private _fechaVencimiento As String
    Public Property fechaVencimiento() As String
        Get
            Return _fechaVencimiento
        End Get
        Set(ByVal value As String)
            _fechaVencimiento = value
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

    Private _desCertifica As String
    Public Property desCertifica() As String
        Get
            Return _desCertifica
        End Get
        Set(ByVal value As String)
            _desCertifica = value
        End Set
    End Property

    Private _cuentaIBAN As String
    Public Property cuentaIBAN() As String
        Get
            Return _cuentaIBAN
        End Get
        Set(ByVal value As String)
            _cuentaIBAN = value
        End Set
    End Property

    Private _codigoBanco As String
    Public Property codigoBanco() As String
        Get
            Return _codigoBanco
        End Get
        Set(ByVal value As String)
            _codigoBanco = value
        End Set
    End Property

    Private _detalleBanco As String
    Public Property detalleBanco() As String
        Get
            Return _detalleBanco
        End Get
        Set(ByVal value As String)
            _detalleBanco = value
        End Set
    End Property
End Class
