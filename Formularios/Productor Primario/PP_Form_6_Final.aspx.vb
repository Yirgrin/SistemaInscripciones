Imports BackEnd

Public Class PP_Form_6_Final
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Actualizar el estado de la inscripción en el backend.
            ProductorNegocio.Instancia.actualizarEstadoInscripcion(Session("Inscripcion"))

            'envía un correo de confirmación del envío del formulario
            lblInscripcion.Text = Session("Inscripcion")
            Dim modeloUsuario As Usuario = Session("modeloUsuario")
            Dim asunto As String = ConfigurationManager.AppSettings("CorreoAsunto")
            CorreoNegocio.Instancia.enviarCorreoFinInscripcion(modeloUsuario.correo, asunto, IpAddressHelper.Instancia.GetIpAddress(), modeloUsuario.nombre, Session("Inscripcion"))
            Session("Inscripcion") = ""
            Session("modeloUsuario") = ""
            modeloUsuario = Nothing
        End If
    End Sub

    Protected Sub btn_regresarCNP_ServerClick(sender As Object, e As EventArgs)
        ' Maneja el evento de clic en el botón "Regresar a la página principal".
        Response.Redirect("https://www.cnp.go.cr/", False)
    End Sub
End Class