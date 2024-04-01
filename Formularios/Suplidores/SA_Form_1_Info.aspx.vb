Imports BackEnd
Imports Telerik.Web.UI
Public Class SA_Form_1_Info

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Se oculta y limpia un mensaje de error en la página
        txtError.Visible = False
        txtError.InnerText = ""

        ' Verifica si la página se está cargando por primera vez
        If Not IsPostBack Then
            ' Carga varios elementos desplegables con datos de fuentes de datos
            cargaDatosInicial()
        End If
    End Sub

    Sub sessionInscripcion()
        ' Obtiene estados de inscripción para un usuario
        Dim estados = SuplidorNegocio.Instancia.buscarEstadosInscripcion(Session("Cedula"))

        If estados.Count > 0 Then
            For Each i As EstadosInscripcion In estados
                If i.estado.ToString = "2" OrElse i.estado.ToString = "5" Then
                    ' Si el estado es 2 o 5, redirige a una página de error
                    Response.Redirect("/Usuario/Error.aspx", False)
                    Exit For
                ElseIf i.estado.ToString = "1" OrElse i.estado.ToString = "3" Then
                    ' Si el estado es 1 o 3, se establece la variable de sesión "Inscripcion" y se precargan datos
                    Session("Inscripcion") = i.inscripcion.ToString
                    preCargaDatosUsuario()
                    preCargaInfoSuplidor()
                    Exit For
                ElseIf i.estado.ToString = "4" Then
                    ' Si el estado es 4, se borra la variable de sesión "Inscripcion" y se precargan datos de usuario
                    Session("Inscripcion") = Nothing
                    preCargaDatosUsuario()
                    Exit For
                End If
            Next
        Else
            ' Si no hay estados de inscripción, se asume una inscripción nueva
            Session("Inscripcion") = Nothing
            preCargaDatosUsuario()
        End If
    End Sub

    Sub cargaDatosInicial()
        cargarTipoCedula()
        cargarGenero()
        cargarProvincia()
        sessionInscripcion()
    End Sub

    Sub preCargaDatosUsuario()
        ' Precarga datos de usuario en la página utilizando la variable de sesión "Cedula".
        Dim modeloUsuario = UsuarioNegocio.Instancia.traerDatosUsuario(Session("Cedula").ToString())

        cbGenero.SelectedValue = ""
        Session("modeloUsuario") = modeloUsuario
        cbTipoCedula.SelectedValue = modeloUsuario.tipoCedula
        txtCedula.Value = modeloUsuario.cedula
        txtNombre.Value = modeloUsuario.nombre
        cbGenero.SelectedValue = modeloUsuario.genero
        txtEmail.Value = modeloUsuario.correo

    End Sub

    Sub preCargaInfoSuplidor()
        ' Precarga datos de productor en la página utilizando la variable de sesión "Inscripcion".
        Dim modeloSuplidor = SuplidorNegocio.Instancia.cargarDatosSuplidor(Session("Inscripcion").ToString())

        txtTelefonoFijo.Value = modeloSuplidor.telefonoFijo
        txtCelular.Value = modeloSuplidor.telefonoMovil
        txtDireccion.Value = modeloSuplidor.direccionResidencia
        txtActividadMH.Value = modeloSuplidor.ActividadHM
        cbProvincia.SelectedValue = modeloSuplidor.codProvincia

        'carga el canton de acuerdo a la selección de la provincia que viene desde la base de datos
        cargarCanton(cbProvincia.SelectedValue)
        cbCanton.Enabled = True

        cbCanton.SelectedValue = modeloSuplidor.codCanton

        'carga el distrito de acuerdo a la selección del cantón que viene desde la base de datos
        cargarDistrito(cbCanton.SelectedValue)
        cbDistrito.Enabled = True
        cbDistrito.SelectedValue = modeloSuplidor.codDistrito

    End Sub

    Protected Sub cargarTipoCedula()
        ' Carga el elemento desplegable de tipo de cédula desde una fuente de datos
        Dim lista = InformacionGralNegocio.Instancia.buscarTipoCedulaColeccion()
        If lista.Count > 0 Then
            cbTipoCedula.DataSource = lista
            cbTipoCedula.DataTextField = "detalle"
            cbTipoCedula.DataValueField = "codigo"
            cbTipoCedula.DataBind()
        End If
    End Sub

    Protected Sub cargarGenero()
        ' Carga el elemento desplegable de género con opciones predefinidas
        Dim item1 = New RadComboBoxItem()
        Dim item2 = New RadComboBoxItem()
        Dim item3 = New RadComboBoxItem()
        item1.Text = "Masculino"
        item1.Value = "M"
        item2.Text = "Femenino"
        item2.Value = "F"
        item3.Text = "Indefinido"
        item3.Value = "X"
        cbGenero.Items.Add(item1)
        cbGenero.Items.Add(item2)
        cbGenero.Items.Add(item3)
    End Sub

    Protected Sub cargarProvincia()
        ' Carga el elemento desplegable de provincias desde una fuente de datos
        Dim lista = InformacionGralNegocio.Instancia.buscarProvincias()
        If lista.Count > 0 Then
            cbProvincia.DataSource = lista
            cbProvincia.DataTextField = "desProvincia"
            cbProvincia.DataValueField = "codProvincia"
            cbProvincia.DataBind()
        End If
        cbProvincia.SelectedValue = Nothing
    End Sub

    Protected Sub cargarCanton(ByVal provincia As String)
        ' Carga el elemento desplegable de cantones desde una fuente de datos
        Dim lista = InformacionGralNegocio.Instancia.buscarCantones(provincia)
        If lista.Count > 0 Then
            cbCanton.DataSource = lista
            cbCanton.DataTextField = "desCanton"
            cbCanton.DataValueField = "codCanton"
            cbCanton.DataBind()
        End If
        cbCanton.SelectedValue = Nothing
    End Sub

    Protected Sub cargarDistrito(ByVal canton As String)
        ' Carga el elemento desplegable de distritos desde una fuente de datos
        Dim lista = InformacionGralNegocio.Instancia.buscarDistritos(canton)
        If lista.Count > 0 Then
            cbDistrito.DataSource = lista
            cbDistrito.DataTextField = "desDistrito"
            cbDistrito.DataValueField = "codDistrito"
            cbDistrito.DataBind()
        End If
        cbDistrito.SelectedValue = Nothing
    End Sub

    Protected Sub radcmbProvincia_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbProvincia.SelectedIndexChanged
        ' Cuando se selecciona una provincia, se cargan los cantones correspondientes
        cargarCanton(cbProvincia.SelectedValue)
        cbCanton.Enabled = True
    End Sub

    Protected Sub radcmbCanton_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbCanton.SelectedIndexChanged
        ' Cuando se selecciona un cantón, se cargan los distritos correspondientes
        cargarDistrito(cbCanton.SelectedValue)
        cbDistrito.Enabled = True
    End Sub

    'Busca la region con el codigo del distrito
    Function buscarRegion(ByVal distrito As String) As String
        Return InformacionGralNegocio.Instancia.buscarRegion(distrito)
    End Function

    Function validarRespuestas() As Boolean
        ' Esta función se utiliza para validar los datos ingresados por el usuario.
        ' Comprueba que se ingresen datos válidos en varios campos y muestra mensajes de error si es necesario.
        ' Si todas las validaciones son exitosas, devuelve True; de lo contrario, devuelve False.
        ' También se establecen estilos de borde rojo en los campos con errores.

        Dim validacion = True
        txtError.InnerText = ""
        txtError.Visible = False

        txtCedula.Attributes("Style") = ""
        txtNombre.Attributes("Style") = ""
        txtTelefonoFijo.Attributes("Style") = ""
        txtCelular.Attributes("Style") = ""
        txtEmail.Attributes("Style") = ""
        txtActividadMH.Attributes("Style") = ""
        cbTipoCedula.Attributes("Style") = ""
        txtDireccion.Attributes("Style") = ""
        cbProvincia.Attributes("Style") = ""
        cbCanton.Attributes("Style") = ""
        cbDistrito.Attributes("Style") = ""

        ' Valida el teléfono fijo
        If txtTelefonoFijo.Value = "" Then
            txtError.InnerText &= " ● Digite su teléfono fijo"
            txtError.Visible = True
            validacion = False
            txtTelefonoFijo.Attributes("Style") = "border: 1px solid red;"
        ElseIf Not Regex.IsMatch(txtTelefonoFijo.Value, "^[0-9]{8}$") Then
            txtError.InnerText &= " ● Verifique los dígitos de su teléfono fijo (8 dígitos numéricos)"
            txtError.Visible = True
            validacion = False
            txtTelefonoFijo.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Valida el celular
        If txtCelular.Value = "" Then
            txtError.InnerText &= " ● Digite su celular"
            txtError.Visible = True
            validacion = False
            txtCelular.Style("border-color") = "red"
        ElseIf Not Regex.IsMatch(txtCelular.Value, "^[0-9]{8}$") Then
            txtError.InnerText &= " ● Verifique los dígitos de su celular (8 dígitos numéricos)"
            txtError.Visible = True
            validacion = False
            txtCelular.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar provincia
        If cbProvincia.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione la provincia"
            txtError.Visible = True
            cbProvincia.Attributes("Style") = "border: 1px solid red;"
            validacion = False
        End If

        ' Validar cantón
        If cbCanton.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione el cantón"
            txtError.Visible = True
            cbCanton.Attributes("Style") = "border: 1px solid red;"
            validacion = False
        End If

        ' Validar distrito
        If cbDistrito.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione el distrito"
            txtError.Visible = True
            cbDistrito.Attributes("Style") = "border: 1px solid red;"
            validacion = False
        End If

        ' Validar dirección
        If txtDireccion.Value = "" Then
            txtError.InnerText &= " ● Digite una dirección exacta"
            txtError.Visible = True
            validacion = False
            txtDireccion.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar actividad registrada en el Ministerio de Hacienda
        If txtActividadMH.Value = "" Then
            txtError.InnerText &= " ● Digite la actividad registrada en el Ministerio de Hacienda"
            txtError.Visible = True
            validacion = False
            txtActividadMH.Attributes("Style") = "border: 1px solid red;"
        End If

        Return validacion
    End Function

    Protected Sub btnContinuar_ServerClick(sender As Object, e As EventArgs)
        ' Este evento se activa cuando se hace clic en el botón "Siguiente".
        ' Se llama a la función validación() para verificar la entrada del usuario.
        ' Si la validación es exitosa, se realiza una acción específica (como redireccionar a otra página).
        Dim fecha = DateTime.Now

        If validarRespuestas() Then
            If Session("Inscripcion") = Nothing Then
                ' Si no hay inscripción existente, se crea una nueva y se redirige a la siguiente página
                Dim inscripcion = SuplidorNegocio.Instancia.insertarInscripcionSuplidor(txtCedula.Value.Trim, txtNombre.Value,
                                                                                               cbTipoCedula.SelectedValue, cbGenero.SelectedValue,
                                                                                               txtEmail.Value, txtTelefonoFijo.Value,
                                                                                               txtCelular.Value, txtActividadMH.Value,
                                                                                               txtDireccion.Value, cbDistrito.SelectedValue,
                                                                                               buscarRegion(cbDistrito.SelectedValue), fecha,
                                                                                               cbProvincia.SelectedValue, cbCanton.SelectedValue)
                sessionInscripcion()
                Response.Redirect("/Suplidores/SA_Form_2_RL.aspx", False)
            Else
                ' Si existe una inscripción, se actualiza y se redirige a la siguiente página
                SuplidorNegocio.Instancia.actualizarInscripcionSuplidor(Session("Inscripcion"), txtCedula.Value.Trim, txtNombre.Value,
                                                                                               cbTipoCedula.SelectedValue, cbGenero.SelectedValue,
                                                                                               txtEmail.Value, txtTelefonoFijo.Value,
                                                                                               txtCelular.Value, txtActividadMH.Value,
                                                                                               txtDireccion.Value, cbDistrito.SelectedValue,
                                                                                               buscarRegion(cbDistrito.SelectedValue), fecha,
                                                                                               cbProvincia.SelectedValue, cbCanton.SelectedValue)
                sessionInscripcion()
                Response.Redirect("/Suplidores/SA_Form_2_RL.aspx", False)
            End If
        End If
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario/Selector_Formulario.aspx", False)
    End Sub
End Class
