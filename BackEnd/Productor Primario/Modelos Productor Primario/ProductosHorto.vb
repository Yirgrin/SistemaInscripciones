Public Class ProductosHorto

    Private _codClasificacion As Int16
    Public Property codClasificacion() As Int16
        Get
            Return _codClasificacion
        End Get
        Set(ByVal value As Int16)
            _codClasificacion = value
        End Set
    End Property

    Private _desClasificacion As String
    Public Property desClasificacion() As String
        Get
            Return _desClasificacion
        End Get
        Set(ByVal value As String)
            _desClasificacion = value
        End Set
    End Property

End Class
