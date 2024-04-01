Imports BackEnd
Imports Telerik.Web.UI

Public Class VW_Inscrip_3_LineaAbPP
    Inherits System.Web.UI.Page
    Protected WithEvents chkverifCampo As CheckBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            preCargaLineasAb()
        End If
    End Sub

    Sub preCargaLineasAb()
        'carga la info en una tabla
        rglineasAb.DataSource = LinAbastecimientoNegocio.Instancia.traerLineasAb(Session("codigoInscrip"))
        rglineasAb.DataBind()

        If Session("AreaVerificacionPP") <> 1 Then
            ' Carga las observaciones agregadas por un AEO sobre la verificación en campo
            Dim modelo = VistaInscripcionPPNegocio.Instancia.traerObservaciones(Session("codigoInscrip"))
            txtObservaciones.Value = modelo.observaciones
            txtObservaciones.Disabled = True
        End If
    End Sub

    Protected Sub chkverifCampo_Click(sender As Object, e As EventArgs)
        Try
            ' Establece una variable "chkverifCampo" con el valor "COMPLETA"
            Dim chkverifCampo = "COMPLETA"
            ' Convierte el objeto sender a un LinkButton
            Dim lnk As LinkButton = DirectCast(sender, LinkButton)
            ' Obtiene el elemento de datos asociado al LinkButton
            Dim data As GridDataItem = DirectCast(lnk.NamingContainer, GridDataItem)
            ' Obtiene el valor del campo "codigo" del elemento de datos
            Dim codigo As String = data.GetDataKeyValue("codigo").ToString()

            VistaInscripcionPPNegocio.Instancia.verificacionCampo(chkverifCampo, codigo)

            ' Llama al método "preCargaLineasAb()"
            preCargaLineasAb()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub rglineasAb_ItemDataBound(sender As Object, e As GridItemEventArgs)
        If TypeOf e.Item Is GridDataItem Then
            Dim dataItem As GridDataItem = DirectCast(e.Item, GridDataItem)

            ' Obtiene el valor de la columna "verificacionCampo" para el elemento de datos actual
            Dim verificacionCampo As String = dataItem("verificacionCampo").Text

            ' Encuentra el control LinkButton dentro de la celda de la columna "Verificación"
            Dim linkButton As LinkButton = TryCast(dataItem("LinkTemplateColumn").FindControl("verifCampo"), LinkButton)

            If Session("AreaVerificacionPP") <> 1 Then
                'Si el área de verificación es diferente a 1, no va a dar la opción de que aparezca el botón
                linkButton.Visible = False
            Else
                ' Verifica el valor de la columna "verificacionCampo" y establece la visibilidad del botón
                If verificacionCampo = "COMPLETA" Then
                    linkButton.Visible = False
                Else
                    linkButton.Visible = True
                End If
            End If
        End If
    End Sub


    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion PP/VW_Inscrip_2_RLPP.aspx", False)
    End Sub

    Protected Sub btnSiguiente_ServerClick(sender As Object, e As EventArgs)
        If txtObservaciones.Value IsNot "" Then
            VistaInscripcionPPNegocio.Instancia.agregarObservaciones(txtObservaciones.Value, Session("codigoInscrip"))
        End If
        Response.Redirect("/Usuario Interno/Vista Inscripcion PP/VW_Inscrip_4_CertPP.aspx", False)
    End Sub
End Class