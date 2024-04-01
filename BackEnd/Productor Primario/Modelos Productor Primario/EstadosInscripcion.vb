Public Class EstadosInscripcion

    Private _inscripcion As Int16
    Public Property inscripcion() As Int16
        Get
            Return _inscripcion
        End Get
        Set(ByVal value As Int16)
            _inscripcion = value
        End Set
    End Property

    Private _estado As Int16
    Public Property estado() As Int16
        Get
            Return _estado
        End Get
        Set(ByVal value As Int16)
            _estado = value
        End Set
    End Property

    Private _nombre As Int16
    Public Property nombre() As Int16
        Get
            Return _nombre
        End Get
        Set(ByVal value As Int16)
            _nombre = value
        End Set
    End Property

End Class
