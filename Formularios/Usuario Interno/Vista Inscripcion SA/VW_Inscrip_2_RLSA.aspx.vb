Imports BackEnd
Public Class VW_Inscrip_2_RLSA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            preCargaDatos()
        End If
    End Sub

    Sub preCargaDatos()
        ' Precarga los datos del Representante Legal en el formulario.
        Dim modeloRepLegal = RepLegalNegocio.Instancia.cargarRLSuplidor(Session("codigoInscrip"))
        txtCedula.Value = modeloRepLegal.cedula
        txtNombre.Value = modeloRepLegal.nombre

        If modeloRepLegal.genero = "F" Then
            txtGenero.Value = "Femenino"
        ElseIf modeloRepLegal.genero = "M" Then
            txtGenero.Value = "Masculino"
        Else
            txtGenero.Value = ""
        End If

        txtTelefonoFijo.Value = modeloRepLegal.telefonoFijo
        txtCelular.Value = modeloRepLegal.telefonoMovil
        txtEmail.Value = modeloRepLegal.email

        If modeloRepLegal.sinRepLegal = "True" Then
            divSinRL.Visible = False
            txtSinRL.Visible = True
            txtSinRL.InnerText = "El usuario no cuenta con un Representante Legal"

        Else
            divSinRL.Visible = True
            txtSinRL.Visible = False
        End If

    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inscrip_1_InfoSA.aspx", False)
    End Sub

    Protected Sub btnSiguiente_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inscrip_3_InfoContaSA.aspx", False)
    End Sub
End Class