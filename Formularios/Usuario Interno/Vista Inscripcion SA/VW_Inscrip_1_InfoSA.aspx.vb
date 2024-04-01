Imports BackEnd
Public Class VW_Inscrip_1_InfoSA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            preCargaInfoSuplidor()

        End If
    End Sub

    Sub preCargaInfoSuplidor()
        ' Precarga datos de productor en la página utilizando la variable de sesión "Inscripcion".
        Dim modeloSuplidor = VistaInscripcionSANegocio.Instancia.traerDatosSuplidor(Session("codigoInscrip").ToString())

        txtCedula.Value = modeloSuplidor.cedula
        txtNombre.Value = modeloSuplidor.nombre
        If modeloSuplidor.genero = "F" Then
            txtGenero.Value = "Femenino"
        ElseIf modeloSuplidor.genero = "M" Then
            txtGenero.Value = "Masculino"
        Else
            txtGenero.Value = "Indefinido"
        End If
        txtEmail.Value = modeloSuplidor.email
        txtTipoCedula.Value = modeloSuplidor.tipoCedula
        txtTelefonoFijo.Value = modeloSuplidor.telefonoFijo
        txtCelular.Value = modeloSuplidor.telefonoMovil
        txtDireccion.Value = modeloSuplidor.direccionResidencia
        txtActividadMH.Value = modeloSuplidor.ActividadHM
        txtProvincia.Value = modeloSuplidor.codProvincia
        txtCanton.Value = modeloSuplidor.codCanton
        txtDistrito.Value = modeloSuplidor.codDistrito

    End Sub

    Protected Sub btnAtras_ServerClick1(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/UI_Pendientes_SA.aspx", False)
    End Sub

    Protected Sub btnContinuar_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inscrip_2_RLSA.aspx", False)
    End Sub
End Class