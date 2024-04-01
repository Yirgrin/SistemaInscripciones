Public Class Selector_Formularios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Ocultar mensajes de error al principio.
        txtError.InnerText = ""
        txtError.Visible = False
    End Sub

    Protected Sub btn_ProducPrimarioServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Productor Primario/PP_Form_1_Info.aspx", False)
    End Sub

    Protected Sub btnConsultar_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Productor Primario/PP_Consultar_Historial.aspx", False)
    End Sub

    Protected Sub btn_Suplidores_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Suplidores/SA_Form_1_Info.aspx", False)
    End Sub

    Protected Sub btnConsultarS_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Suplidores/SA_Consultar_Historial.aspx", False)
    End Sub
End Class