Public Class Suplidor


    Private _codigo As String
    Public Property codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
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

    Private _cedula As String
    Public Property cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
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

    Private _tipoCedula As String
    Public Property tipoCedula() As String
        Get
            Return _tipoCedula
        End Get
        Set(ByVal value As String)
            _tipoCedula = value
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
    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
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

    Private _ActividadHM As String
    Public Property ActividadHM() As String
        Get
            Return _ActividadHM
        End Get
        Set(ByVal value As String)
            _ActividadHM = value
        End Set
    End Property

    Private _direccionResidencia As String
    Public Property direccionResidencia() As String
        Get
            Return _direccionResidencia
        End Get
        Set(ByVal value As String)
            _direccionResidencia = value
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

    Private _codRegion As String
    Public Property codRegion() As String
        Get
            Return _codRegion
        End Get
        Set(ByVal value As String)
            _codRegion = value
        End Set
    End Property

    Private _fecha_envio As String
    Public Property fecha_envio() As String
        Get
            Return _fecha_envio
        End Get
        Set(ByVal value As String)
            _fecha_envio = value
        End Set
    End Property

    Private _estado_form As String
    Public Property estado_form() As String
        Get
            Return _estado_form
        End Get
        Set(ByVal value As String)
            _estado_form = value
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

    Private _areaVerificacion As String
    Public Property areaVerificacion() As String
        Get
            Return _areaVerificacion
        End Get
        Set(ByVal value As String)
            _areaVerificacion = value
        End Set
    End Property
    Private _numResolucion As String
    Public Property numResolucion() As String
        Get
            Return _numResolucion
        End Get
        Set(ByVal value As String)
            _numResolucion = value
        End Set
    End Property

    Private _observaciones As String
    Public Property observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property

    Private _fecha_devolucion As String
    Public Property fecha_devolucion() As String
        Get
            Return _fecha_devolucion
        End Get
        Set(ByVal value As String)
            _fecha_devolucion = value
        End Set
    End Property


End Class
