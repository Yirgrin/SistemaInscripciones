Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime

''' <summary>
''' Clase que proporciona métodos para enviar correos electrónicos.
''' </summary>
Public Class CorreoNegocio

    Private Shared _instancia As CorreoNegocio = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase CorreoNegocio utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As CorreoNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New CorreoNegocio()
            End If
            Return _instancia
        End Get
    End Property

    Dim correo As MailMessage = New MailMessage()
    Dim smtp As SmtpClient = New SmtpClient()

    ''' <summary>
    ''' Envía un correo electrónico para notificar el final de una inscripción.
    ''' </summary>
    ''' <param name="correoDestino">La dirección de correo electrónico del destinatario.</param>
    ''' <param name="asunto">El asunto del correo electrónico.</param>
    ''' <param name="ip">La dirección IP relacionada con la inscripción.</param>
    ''' <param name="nombreUsuario">El nombre de usuario relacionado con la inscripción.</param>
    ''' <param name="inscripcion">El número de inscripción.</param>
    ''' <returns>True si el correo se envía correctamente, False en caso contrario.</returns>
    Public Function enviarCorreoFinInscripcion(ByVal correoDestino As String, ByVal asunto As String,
                                               ByVal ip As String, ByVal nombreUsuario As String,
                                               ByVal inscripcion As String) As Boolean
        Try
            Dim Mail = New MailMessage
            Dim negocio As New ParametroDAO
            Dim userMail As String = negocio.traerParametros("MAIL_ACCESO")
            Dim claveUserMail As String = negocio.traerParametros("MAIL_ACCESO_PASS")
            Dim host As String = negocio.traerParametros("SMTP")
            Dim port As String = negocio.traerParametros("PORT")
            Dim default_account As String = negocio.traerParametros("MAIL_ACCOUNT")

            ' Configurar el correo electrónico
            Mail.From = New MailAddress(default_account)
            Mail.To.Add(New MailAddress(correoDestino))
            Mail.Subject = asunto

            ' Configurar el contenido del correo (texto y HTML)
            Dim Text As String = "CNP Informa"
            Dim plainView As AlternateView
            plainView = AlternateView.CreateAlternateViewFromString(Text, Encoding.UTF8, MediaTypeNames.Text.Plain)
            Dim dateTime = Date.Now.Date
            Dim html As String = "<p><img style='display: block; margin-left: auto; margin-right: auto;' src='cid:imagen' /></p>" +
                                 "<table>" +
                                 "<tbody>" +
                                 "   <tr>" +
                                 "      <td style='width: 602px;' colspan='2' bgcolor='#339966'>" +
                                 "         <p style='text-align: center;'><span style='background-color: #339966;'><strong>Consejo Nacional de Producci&oacute;n</strong></span></p>" +
                                 "    </td>" +
                                 "</tr>" +
                                 "<tr>" +
                                 "   <td style='width: 602px;' colspan='2'>" +
                                 "      <p style='text-align: center;'><span style='background-color: #ffffff;'><strong>Solicitud de Inscripci&oacute;n</strong></span></p>" +
                                 "  </td>" +
                                 "</tr>" +
                                 "<tr>" +
                                 "   <td style='width: 602px;' colspan='2' bgcolor='#999999'>" +
                                 "      <p><strong>Se ha registrado en nuestras bases de datos la solicitud de inscripci&oacute;n #" + inscripcion + "</strong></p>" +
                                 " </td>" +
                                 "</tr>" +
                                 "<tr>" +
                                 "   <td style='width: 169px;'>" +
                                 "      <p><strong>Nombre del Solicitante</strong></p>" +
                                 " </td>" +
                                 "<td style='width: 427px;'>" +
                                 "   <p>" + nombreUsuario + " </p>" +
                                 " </td>" +
                                 "</tr>" +
                                 "<tr>" +
                                 "   <td style='width: 169px;'>" +
                                 "      <p><strong>Resultado</strong></p>" +
                                 " </td>" +
                                 "<td style='width: 427px;'>" +
                                 "<p>Solicitud de Inscripci&oacute;n</p>" +
                                 "</td>" +
                                 "</tr>" +
                                 "<tr>" +
                                 "   <td style='width: 169px;'>" +
                                 "      <p><strong>Fecha / Hora</strong></p>" +
                                 " </td>" +
                                 "<td style='width: 427px;'>" +
                                 "   <p>" + Date.Now + " </p>" +
                                 "</td>" +
                                 "</tr>" +
                                 "<tr>" +
                                 "   <td style='width: 169px;'>" +
                                 "      <p><strong>Ubicaci&oacute;n</strong></p>" +
                                 " </td>" +
                                 "<td style='width: 427px;'>" +
                                 "   <p>" + ip + " </p>" +
                                 "</td>" +
                                 "</tr>" +
                                 "<tr>" +
                                 "   <td style='width: 602px;' colspan='2'>" +
                                 "      <p><strong>&nbsp;</strong></p>" +
                                 "   </td>" +
                                 "</tr>" +
                                 "<tr>" +
                                 "<td style='width: 602px;' colspan='2'> " +
                                 "<p><span style='color: #808080;'><strong>El CNP le informa que su registro se encuentra en estado <span style='color: #008000;'><u>Verificaci&oacute;n</u> </span> por los agentes de servicio</strong></span></p>" +
                                 "<p><span style='color: #808080;'><strong>Nuestros Agentes lo contactar&oacute;n para proceder con el procedimiento seg&uacute;n Reglamento PAI</a>.</strong></span></p></p>" +
                                 "<p>&nbsp;</p>" +
                                 "<p><span style='color: #808080;'><strong>Nota: Este mensaje es generado por un sistema autom&aacute;tico, agradecemos que no respondan a esta direcci&oacute;n.</strong></span></p>" +
                                 "<p><span style='color: #808080;'><strong>Si necesita ayuda, por favor dirigirse a las diferentes direcciones regionales seg&uacute;n corresponda.</strong></span></p>" +
                                 "</td>" +
                                 "   </tr>" +
                                 "</tbody>" +
                                 "</table>"

            Dim htmlView As AlternateView
            htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html)

            ' Configurar una imagen en el correo
            Dim img As LinkedResource
            Dim path As String = ""
            Dim rutaTMP As String = ConfigurationManager.AppSettings("RutaImagenes")
            rutaTMP = System.IO.Path.Combine(rutaTMP, "Logo-230x80px.jpg")
            img = New LinkedResource(rutaTMP, MediaTypeNames.Image.Jpeg)
            img.ContentId = "imagen"
            htmlView.LinkedResources.Add(img)

            ' Agregar las vistas (texto y HTML) al correo
            Mail.AlternateViews.Add(plainView)
            Mail.AlternateViews.Add(htmlView)

            ' Configurar el servidor SMTP y enviar el correo
            smtp.Host = host
            smtp.Port = port
            smtp.Credentials = New NetworkCredential(userMail, claveUserMail)
            smtp.EnableSsl = True
            smtp.Send(Mail)

            Return True
        Catch ex As Exception
            ' Si hay un error al enviar el correo, se retorna False
            Return False
        End Try
    End Function
End Class
