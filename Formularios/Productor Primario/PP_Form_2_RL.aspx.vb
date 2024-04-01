Imports BackEnd
Imports Telerik.Web.UI

Public Class PP_Form_2_RL
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Inscripcion") Is Nothing Then
                ' Si no hay datos de Inscripcion en la sesión, redirige a la página de error.
                Response.Redirect("/Productor Primario/Error.aspx", False)
            Else
                txtError.Visible = False
                txtError.InnerText = ""
                cargarGenero()
                preCargaDatos()
                cambiarEntradas()
            End If
        End If
    End Sub

    Protected Sub cargarGenero()
        ' Carga los géneros en el control cbGenero.
        Dim item1 = New RadComboBoxItem()
        Dim item2 = New RadComboBoxItem()
        item1.Text = "Masculino"
        item1.Value = "M"
        item2.Text = "Femenino"
        item2.Value = "F"
        cbGenero.Items.Add(item1)
        cbGenero.Items.Add(item2)
    End Sub

    Function validacion() As Boolean
        ' Realiza la validación de los campos del formulario.
        txtError.InnerText = ""
        txtError.Visible = False
        txtCedula.Style("border-color") = "empty"
        txtNombre.Style("border-color") = "empty"
        txtTelefonoFijo.Style("border-color") = "empty"
        txtCelular.Style("border-color") = "empty"
        txtEmail.Style("border-color") = "empty"
        validacion = True

        ' Valida cédula
        If txtCedula.Value = "" Then
            txtCedula.Style("border-color") = "red"
            txtError.InnerText &= " ● Digite el número de cédula correspondiente"
            txtError.Visible = True
            validacion = False
        ElseIf Not Regex.IsMatch(txtCedula.Value, "^[0-9]{9}$") Then
            txtCedula.Style("border-color") = "red"
            txtError.InnerText &= " ● Revise el formato de la cédula física del representante legal (9 dígitos númericos)"
            txtError.Visible = True
            validacion = False
        End If

        ' Valida nombre
        If txtNombre.Value = "" Then
            txtNombre.Style("border-color") = "red"
            txtError.InnerText &= " ● Digite el nombre completo del representante legal"
            txtError.Visible = True
            validacion = False
        ElseIf Not Regex.IsMatch(txtNombre.Value, "^[A-Za-záéíóúÁÉÍÓÚñÑ ]+$") Then
            txtNombre.Style("border-color") = "red"
            txtError.InnerText &= " ● El nombre no puede contener números o símbolos"
            txtError.Visible = True
            validacion = False
        End If

        ' Valida género
        If cbGenero.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione el género"
            txtError.Visible = True
            validacion = False
        End If

        ' Valida teléfono fijo
        txtTelefonoFijo.Style("border-color") = "red"
        If txtTelefonoFijo.Value = "" Then
            txtError.InnerText &= " ● Digite su teléfono fijo"
            txtError.Visible = True
            validacion = False
        ElseIf Not Regex.IsMatch(txtTelefonoFijo.Value, "^[0-9]{8}$") Then
            txtTelefonoFijo.Style("border-color") = "red"
            txtError.InnerText &= " ● Verifique los dígitos de su teléfono fijo (8 dígitos númericos)"
            txtError.Visible = True
            validacion = False
        End If

        ' Valida celular
        If txtCelular.Value = "" Then
            txtCelular.Style("border-color") = "red"
            txtError.InnerText &= " ● Digite su celular"
            txtError.Visible = True
            validacion = False
        ElseIf Not Regex.IsMatch(txtCelular.Value, "^[0-9]{8}$") Then
            txtCelular.Style("border-color") = "red"
            txtError.InnerText &= " ● Verifique los dígitos de su celular (8 dígitos númericos)"
            txtError.Visible = True
            validacion = False
        End If

        ' Valida el correo
        If txtEmail.Value = "" Then
            txtEmail.Style("border-color") = "red"
            txtError.InnerText &= " ● Digite su correo electrónico"
            txtError.Visible = True
            validacion = False
        ElseIf Not Regex.IsMatch(txtEmail.Value, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") Then
            txtEmail.Style("border-color") = "red"
            txtError.InnerText &= " ● Verifique el formato de su correo (ejemplo: usuario@example.com)"
            txtError.Visible = True
            validacion = False
        End If

        Return validacion
    End Function

    Protected Sub chkTieneRep_CheckedChanged(sender As Object, e As EventArgs) Handles chkTieneRep.CheckedChanged
        ' Maneja el evento de cambio en el checkbox "Tiene Representante Legal" y llama al método cambiarEntradas().
        cambiarEntradas()
    End Sub

    Sub cambiarEntradas()
        ' Cambia la habilitación/deshabilitación de los campos del formulario según si el checkbox "Tiene Representante Legal" está marcado.
        If chkTieneRep.Checked Then
            txtCedula.Disabled = True
            txtNombre.Disabled = True
            cbGenero.Enabled = False
            txtTelefonoFijo.Disabled = True
            txtCelular.Disabled = True
            txtEmail.Disabled = True
        Else
            txtCedula.Disabled = False
            txtNombre.Disabled = False
            cbGenero.Enabled = True
            txtTelefonoFijo.Disabled = False
            txtCelular.Disabled = False
            txtEmail.Disabled = False
        End If
    End Sub

    Sub preCargaDatos()
        ' Precarga los datos del Representante Legal en el formulario.
        Dim modeloRepLegal = RepLegalNegocio.Instancia.traerDatosRepLegal(Session("Inscripcion"))
        txtCedula.Value = modeloRepLegal.cedula
        txtNombre.Value = modeloRepLegal.nombre
        cbGenero.SelectedValue = modeloRepLegal.genero
        txtTelefonoFijo.Value = modeloRepLegal.telefonoFijo
        txtCelular.Value = modeloRepLegal.telefonoMovil
        txtEmail.Value = modeloRepLegal.email

        'si el check viene true desde la base de datos, entonces la selecciona
        If modeloRepLegal.sinRepLegal = "True" Then
            chkTieneRep.Checked = True
        Else
            chkTieneRep.Checked = False
        End If

    End Sub

    Protected Sub btnAtras_Click(sender As Object, e As EventArgs)
        ' Redirige a la página anterior (PP_Form_0_Info.aspx).
        Response.Redirect("/Productor Primario/PP_Form_1_Info.aspx", False)
    End Sub

    Protected Sub btnSiguiente_Click(sender As Object, e As EventArgs)
        ' Maneja el evento de clic en el botón "Siguiente".
        txtError.InnerText = ""
        txtError.Visible = False

        If chkTieneRep.Checked Then

            RepLegalNegocio.Instancia.insertarRepLegal(Session("Inscripcion"), txtCedula.Value, txtNombre.Value.ToUpper(),
                                                           cbGenero.SelectedValue, txtTelefonoFijo.Value, txtCelular.Value, txtEmail.Value, chkTieneRep.Checked)
            ''Inserta en la base de datos que el usuario no tiene representante legal
            'RepLegalNegocio.Instancia.sinRepLegal(Session("Inscripcion"), chkTieneRep.Checked)
            ' Si tiene Representante Legal, redirige a la siguiente página (PP_Form_2_Terr.aspx).
            Response.Redirect("/Productor Primario/PP_Form_3_LineaAb.aspx", False)
        Else
            ' Si no tiene Representante Legal, valida los campos del formulario.
            If validacion() Then
                ' Si la validación es exitosa, inserta los datos del Representante Legal en la base de datos.
                RepLegalNegocio.Instancia.insertarRepLegal(Session("Inscripcion"), txtCedula.Value, txtNombre.Value.ToUpper(),
                                                           cbGenero.SelectedValue, txtTelefonoFijo.Value, txtCelular.Value, txtEmail.Value, chkTieneRep.Checked)
                Response.Redirect("/Productor Primario/PP_Form_3_LineaAb.aspx", False)
            Else
                ' Si la validación falla, muestra un mensaje de error.
                txtError.InnerText &= " ● Revise los campos solicitados para continuar"
                txtError.Visible = True
            End If
        End If
    End Sub

End Class
