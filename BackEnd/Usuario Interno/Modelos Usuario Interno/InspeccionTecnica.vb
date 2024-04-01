Public Class InspeccionTecnica

    Private _codigo As Int32
    Public Property codigo() As Int32
        Get
            Return _codigo
        End Get
        Set(ByVal value As Int32)
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

    Private _realizadaPor As String
    Public Property realizadaPor() As String
        Get
            Return _realizadaPor
        End Get
        Set(ByVal value As String)
            _realizadaPor = value
        End Set
    End Property


    Private _fechaInspeccion As String
    Public Property fechaInspeccion() As String
        Get
            Return _fechaInspeccion
        End Get
        Set(ByVal value As String)
            _fechaInspeccion = value
        End Set
    End Property


    Private _numSolicitud As String
    Public Property numSolicitud() As String
        Get
            Return _numSolicitud
        End Get
        Set(ByVal value As String)
            _numSolicitud = value
        End Set
    End Property

    Private _fechaSolicitud As String
    Public Property fechaSolicitud() As String
        Get
            Return _fechaSolicitud
        End Get
        Set(ByVal value As String)
            _fechaSolicitud = value
        End Set
    End Property


    Private _numOficio As String
    Public Property numOficio() As String
        Get
            Return _numOficio
        End Get
        Set(ByVal value As String)
            _numOficio = value
        End Set
    End Property

    Private _fechaOficio As String
    Public Property fechaOficio() As String
        Get
            Return _fechaOficio
        End Get
        Set(ByVal value As String)
            _fechaOficio = value
        End Set
    End Property


    Private _cumplimientoMayor As String
    Public Property cumplimientoMayor() As String
        Get
            Return _cumplimientoMayor
        End Get
        Set(ByVal value As String)
            _cumplimientoMayor = value
        End Set
    End Property

    Private _cumplimientoMenor As String
    Public Property cumplimientoMenor() As String
        Get
            Return _cumplimientoMenor
        End Get
        Set(ByVal value As String)
            _cumplimientoMenor = value
        End Set
    End Property
End Class
