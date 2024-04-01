Public Class FormulaClasificacion

    Private _Fpe As String
    Public Property Fpe() As String
        Get
            Return _Fpe
        End Get
        Set(ByVal value As String)
            _Fpe = value
        End Set
    End Property


    Private _Fipf As String
    Public Property Fipf() As String
        Get
            Return _Fipf
        End Get
        Set(ByVal value As String)
            _Fipf = value
        End Set
    End Property


    Private _Fan As String
    Public Property Fan() As String
        Get
            Return _Fan
        End Get
        Set(ByVal value As String)
            _Fan = value
        End Set
    End Property

    Private _Dpe As String
    Public Property Dpe() As String
        Get
            Return _Dpe
        End Get
        Set(ByVal value As String)
            _Dpe = value
        End Set
    End Property

    Private _Dinpf As String
    Public Property Dinpf() As String
        Get
            Return _Dinpf
        End Get
        Set(ByVal value As String)
            _Dinpf = value
        End Set
    End Property

    Private _Dan As String
    Public Property Dan() As String
        Get
            Return _Dan
        End Get
        Set(ByVal value As String)
            _Dan = value
        End Set
    End Property
End Class
