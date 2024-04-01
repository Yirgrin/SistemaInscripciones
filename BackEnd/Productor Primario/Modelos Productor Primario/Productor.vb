Public Class Productor

    Private _codigo As Int32
    Public Property codigo() As Int32
        Get
            Return _codigo
        End Get
        Set(ByVal value As Int32)
            _codigo = value
        End Set
    End Property

    Private _ccss As String
    Public Property ccss() As String
        Get
            Return _ccss
        End Get
        Set(ByVal value As String)
            _ccss = value
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

    Private _tipoCedula As String
    Public Property tipoCedula() As String
        Get
            Return _tipoCedula
        End Get
        Set(ByVal value As String)
            _tipoCedula = value
        End Set
    End Property

    Private _tipoProductor As String
    Public Property tipoProductor() As String
        Get
            Return _tipoProductor
        End Get
        Set(ByVal value As String)
            _tipoProductor = value
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

    Private _empresaAsociada As String
    Public Property empresaAsociada() As String
        Get
            Return _empresaAsociada
        End Get
        Set(ByVal value As String)
            _empresaAsociada = value
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

    Private _etnia As String
    Public Property etnia() As String
        Get
            Return _etnia
        End Get
        Set(ByVal value As String)
            _etnia = value
        End Set
    End Property

    Private _ingresosPropios As String
    Public Property IngresosPropios() As String
        Get
            Return _ingresosPropios
        End Get
        Set(ByVal value As String)
            _ingresosPropios = value
        End Set
    End Property

    Private _soloAgricola As String
    Public Property SoloAgricola() As String
        Get
            Return _soloAgricola
        End Get
        Set(ByVal value As String)
            _soloAgricola = value
        End Set
    End Property

    Private _dependientes As String
    Public Property Dependientes() As String
        Get
            Return _dependientes
        End Get
        Set(ByVal value As String)
            _dependientes = value
        End Set
    End Property

    Private _estadoCivil As String
    Public Property EstadoCivil() As String
        Get
            Return _estadoCivil
        End Get
        Set(ByVal value As String)
            _estadoCivil = value
        End Set
    End Property

    Private _hijosMenores As String
    Public Property HijosMenores() As String
        Get
            Return _hijosMenores
        End Get
        Set(ByVal value As String)
            _hijosMenores = value
        End Set
    End Property

    Private _escolaridad As String
    Public Property Escolaridad() As String
        Get
            Return _escolaridad
        End Get
        Set(ByVal value As String)
            _escolaridad = value
        End Set
    End Property

    Private _discapacidad As String
    Public Property Discapacidad() As String
        Get
            Return _discapacidad
        End Get
        Set(ByVal value As String)
            _discapacidad = value
        End Set
    End Property

    Private _conapdis As String
    Public Property Conapdis() As String
        Get
            Return _conapdis
        End Get
        Set(ByVal value As String)
            _conapdis = value
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

    Private _codEstado As String
    Public Property codEstado() As String
        Get
            Return _codEstado
        End Get
        Set(ByVal value As String)
            _codEstado = value
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

    Private _checkMH As String
    Public Property checkMH() As String
        Get
            Return _checkMH
        End Get
        Set(ByVal value As String)
            _checkMH = value
        End Set
    End Property

    Private _checkMAG As String
    Public Property checkMAG() As String
        Get
            Return _checkMAG
        End Get
        Set(ByVal value As String)
            _checkMAG = value
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
