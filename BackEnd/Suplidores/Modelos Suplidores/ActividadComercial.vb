Public Class ActividadComercial

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

    Private _categoria As String
    Public Property categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
        End Set
    End Property

    Private _prodPrimaria As String
    Public Property prodPrimaria() As String
        Get
            Return _prodPrimaria
        End Get
        Set(ByVal value As String)
            _prodPrimaria = value
        End Set
    End Property

    Private _distribucion As String
    Public Property distribucion() As String
        Get
            Return _distribucion
        End Get
        Set(ByVal value As String)
            _distribucion = value
        End Set
    End Property

    Private _comercializacion As String
    Public Property comercializacion() As String
        Get
            Return _comercializacion
        End Get
        Set(ByVal value As String)
            _comercializacion = value
        End Set
    End Property

    Private _transformacion As String
    Public Property transformacion() As String
        Get
            Return _transformacion
        End Get
        Set(ByVal value As String)
            _transformacion = value
        End Set
    End Property

    Private _codigoProduccion As String
    Public Property codigoProduccion() As String
        Get
            Return _codigoProduccion
        End Get
        Set(ByVal value As String)
            _codigoProduccion = value
        End Set
    End Property

End Class
