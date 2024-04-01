Public Class ActividadContable

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

    Private _actividadPrincipal As String
    Public Property actividadPrincipal() As String
        Get
            Return _actividadPrincipal
        End Get
        Set(ByVal value As String)
            _actividadPrincipal = value
        End Set
    End Property

    Private _cantidadEmpleados As String
    Public Property cantidadEmpleados() As String
        Get
            Return _cantidadEmpleados
        End Get
        Set(ByVal value As String)
            _cantidadEmpleados = value
        End Set
    End Property

    Private _ventasNetas As String
    Public Property ventasNetas() As String
        Get
            Return _ventasNetas
        End Get
        Set(ByVal value As String)
            _ventasNetas = value
        End Set
    End Property

    Private _activosFijos As String
    Public Property activosFijos() As String
        Get
            Return _activosFijos
        End Get
        Set(ByVal value As String)
            _activosFijos = value
        End Set
    End Property

    Private _activosTotales As String
    Public Property activosTotales() As String
        Get
            Return _activosTotales
        End Get
        Set(ByVal value As String)
            _activosTotales = value
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

    Private _codProvincia As String
    Public Property codProvincia() As String
        Get
            Return _codProvincia
        End Get
        Set(ByVal value As String)
            _codProvincia = value
        End Set
    End Property

    Private _codCanton As String
    Public Property codCanton() As String
        Get
            Return _codCanton
        End Get
        Set(ByVal value As String)
            _codCanton = value
        End Set
    End Property

    Private _codDistrito As String
    Public Property codDistrito() As String
        Get
            Return _codDistrito
        End Get
        Set(ByVal value As String)
            _codDistrito = value
        End Set
    End Property

    Private _direcExacta As String
    Public Property direcExacta() As String
        Get
            Return _direcExacta
        End Get
        Set(ByVal value As String)
            _direcExacta = value
        End Set
    End Property

    Private _codregion As String
    Public Property codregion() As String
        Get
            Return _codregion
        End Get
        Set(ByVal value As String)
            _codregion = value
        End Set
    End Property

End Class
