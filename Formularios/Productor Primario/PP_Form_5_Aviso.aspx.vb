Public Class PP_Form_5_Aviso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAtras_Click(sender As Object, e As EventArgs)
        ' Redirige a la página anterior (PP_Form_4_Cert.aspx).
        Response.Redirect("/Productor Primario/PP_Form_4_Cert.aspx", False)
    End Sub

    Protected Sub btnSiguiente_Click(sender As Object, e As EventArgs)
        ' Maneja el evento de clic en el botón "Siguiente".
        Response.Redirect("/Productor Primario/PP_Form_6_Final.aspx", False)
    End Sub

    Protected Sub chkAceptarTerminos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAceptarTerminos.CheckedChanged
        'sólo si selecciona el check de aceptar términos se habilita el botón de siguiente
        If chkAceptarTerminos.Checked Then
            btnSiguiente.Disabled = False
        Else
            btnSiguiente.Disabled = True
        End If
    End Sub
End Class