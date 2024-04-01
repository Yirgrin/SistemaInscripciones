Imports System
Public Class DAOExcepcion
    Inherits System.ApplicationException

    Public Sub New(ByVal mensaje As String)
        MyBase.New(mensaje)
    End Sub
End Class
