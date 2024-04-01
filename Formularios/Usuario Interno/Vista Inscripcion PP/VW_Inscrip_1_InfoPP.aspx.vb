Imports BackEnd
Imports Telerik.Web.UI

Public Class VW_Inscrip_1_InfoPP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Se oculta y limpia un mensaje de error en la página
        txtError.Visible = False
        txtError.InnerText = ""

        If Not IsPostBack Then
            preCargaDatosProductor()

        End If
    End Sub

    Sub preCargaDatosProductor()
        ' Precarga datos de productor en la página utilizando la variable de sesión "Inscripcion".
        Dim modeloProductor = VistaInscripcionPPNegocio.Instancia.traerDatosProductor(Session("codigoInscrip").ToString())

        txtTipoCedula.Value = modeloProductor.tipoCedula
        txtCedula.Value = modeloProductor.cedula
        txtNombre.Value = modeloProductor.nombre

        If modeloProductor.genero = "F" Then
            txtGenero.Value = "Femenino"
        ElseIf modeloProductor.genero = "M" Then
            txtGenero.Value = "Masculino"
        Else
            txtGenero.Value = "Indefinido"
        End If

        txtEmail.Value = modeloProductor.email
        txtTelefonoFijo.Value = modeloProductor.telefonoFijo
        txtCelular.Value = modeloProductor.telefonoMovil
        txtTipoProductor.Value = modeloProductor.tipoProductor
        txtEmpresaA.Value = modeloProductor.empresaAsociada
        txtDireccion.Value = modeloProductor.direccionResidencia
        txtEtnia.Value = modeloProductor.etnia

        If modeloProductor.IngresosPropios = 1 Then
            txtIngresos.Value = "Sí"
        Else
            txtIngresos.Value = "No"
        End If

        If modeloProductor.SoloAgricola = 1 Then
            txtSoloAgricola.Value = "Sí"
        Else
            txtSoloAgricola.Value = "No"
        End If

        txtDependientesIngresos.Value = modeloProductor.Dependientes
        txtEstadoCivil.Value = modeloProductor.EstadoCivil
        txtHijosMenores.Value = modeloProductor.HijosMenores
        txtEscolaridad.Value = modeloProductor.Escolaridad
        txtDiscapacidad.Value = modeloProductor.Discapacidad
        txtCCSS.Value = modeloProductor.ccss

        If modeloProductor.Conapdis = 1 Then
            txtCarnetConapdis.Value = "Sí"
        Else
            txtCarnetConapdis.Value = "No"
        End If
        txtProvincia.Value = modeloProductor.codProvincia
        txtCanton.Value = modeloProductor.codCanton
        txtDistrito.Value = modeloProductor.codDistrito

        If modeloProductor.checkMH = "True" Then
            chkMH.Checked = True
            chkMH.Enabled = False
        End If
        If modeloProductor.checkMAG = "True" Then
            chkMAG.Checked = True
            chkMAG.Enabled = False
        End If
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/UI_Pendientes_PP.aspx", False)
    End Sub

    Protected Sub btnSiguiente_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion PP/VW_Inscrip_2_RLPP.aspx", False)
    End Sub
End Class