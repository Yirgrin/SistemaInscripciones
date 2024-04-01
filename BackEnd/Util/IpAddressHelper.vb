Imports System.Net
Imports System.Net.Sockets

''' <summary>
''' Clase de utilidad para obtener la dirección IP del usuario actual.
''' </summary>
Public Class IpAddressHelper
    Private Shared _instancia As IpAddressHelper = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase IpAddressHelper utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As IpAddressHelper
        Get
            If _instancia Is Nothing Then
                _instancia = New IpAddressHelper()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Obtiene la dirección IP del usuario actual.
    ''' </summary>
    ''' <returns>La dirección IP del usuario actual como una cadena de texto.</returns>
    Public Function GetIpAddress() As String
        Try
            ' Obtener la entrada de host IP (dirección IP del host local)
            Dim host As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
            Dim ipAddress As String = ""

            ' Buscar la primera dirección IPv4 disponible en la lista de direcciones
            For Each ip As IPAddress In host.AddressList
                If ip.AddressFamily = AddressFamily.InterNetwork Then
                    ipAddress = ip.ToString()
                    Exit For
                End If
            Next

            Return ipAddress
        Catch ex As Exception
            ' Manejar errores en caso de que ocurra una excepción
            Return "Error al obtener la dirección IP del usuario."
        End Try
    End Function
End Class

