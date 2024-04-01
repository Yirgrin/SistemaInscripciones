Imports BackEnd
Imports Telerik.Web.UI

Public Class PP_Form_1_Info
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

    Sub cargaDatosInicial()
        cargarTipoCedula()
        cargarGenero()
        cargarCCSS()
        cargarTipoProductor()
        cargarCCSS()
        cargarEtnias()
        cargarEstadoCivil()
        cargarEscolaridad()
        cargarDiscapacidad()
        cargarProvincia()
        sessionInscripcion()
    End Sub

    Sub sessionInscripcion()
        ' Obtiene estados de inscripción para un usuario
        Dim estados = ProductorNegocio.Instancia.buscarEstadosInscripcion(Session("Cedula"))

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
                    preCargaDatosProductor()
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
    Sub preCargaDatosUsuario()
        ' Precarga datos de usuario en la página utilizando la variable de sesión "Cedula".
        Dim modeloUsuario = UsuarioNegocio.Instancia.traerDatosUsuario(Session("Cedula").ToString())

        Session("modeloUsuario") = modeloUsuario
        cbTipoCedula.SelectedValue = modeloUsuario.tipoCedula
        txtCedula.Value = modeloUsuario.cedula
        txtNombre.Value = modeloUsuario.nombre
        cbGenero.SelectedValue = modeloUsuario.genero
        txtEmail.Value = modeloUsuario.correo
    End Sub

    Sub preCargaDatosProductor()
        ' Precarga datos de productor en la página utilizando la variable de sesión "Inscripcion".
        Dim modeloProductor = ProductorNegocio.Instancia.traerDatosProductor(Session("Inscripcion").ToString())

        txtTelefonoFijo.Value = modeloProductor.telefonoFijo
        txtCelular.Value = modeloProductor.telefonoMovil
        cbTipoProductor.SelectedValue = modeloProductor.tipoProductor
        txtEmpresaA.Value = modeloProductor.empresaAsociada
        txtDireccion.Value = modeloProductor.direccionResidencia
        cbEtnia.SelectedValue = modeloProductor.etnia
        cbIngresosPropios.SelectedValue = Integer.Parse(modeloProductor.IngresosPropios)
        cbSoloAgricola.SelectedValue = Integer.Parse(modeloProductor.SoloAgricola)
        txtDependientesIngresos.Value = modeloProductor.Dependientes
        cbEstadoCivil.SelectedValue = modeloProductor.EstadoCivil
        txtHijosMenores.Value = modeloProductor.HijosMenores
        cbEscolaridad.SelectedValue = modeloProductor.Escolaridad
        cbTipoDiscapacidad.SelectedValue = modeloProductor.Discapacidad
        cbCCSS.SelectedValue = modeloProductor.ccss
        cbCarnetConapdis.SelectedValue = Integer.Parse(modeloProductor.Conapdis)
        cbProvincia.SelectedValue = modeloProductor.codProvincia

        'carga el canton de acuerdo a la selección de la provincia que viene desde la base de datos
        cargarCanton(cbProvincia.SelectedValue)
        cbCanton.Enabled = True

        cbCanton.SelectedValue = modeloProductor.codCanton

        'carga el distrito de acuerdo a la selección del cantón que viene desde la base de datos
        cargarDistrito(cbCanton.SelectedValue)
        cbDistrito.Enabled = True
        cbDistrito.SelectedValue = modeloProductor.codDistrito

        If modeloProductor.checkMH = "True" Then
            chkMH.Checked = True
        Else
            chkMH.Checked = False
        End If
        If modeloProductor.checkMAG = "True" Then
            chkMAG.Checked = True
        Else
            chkMAG.Checked = False
        End If

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

    Protected Sub cargarTipoProductor()
        '    Carga el elemento desplegable de tipo de productor desde una fuente de datos
        Dim lista = InformacionGralNegocio.Instancia.buscarTipoProductorColeccion()
        If lista.Count > 0 Then
            cbTipoProductor.DataSource = lista
            cbTipoProductor.DataTextField = "detalle"
            cbTipoProductor.DataValueField = "codigo"
            cbTipoProductor.DataBind()
        End If
        cbTipoProductor.ClearSelection()
    End Sub

    Protected Sub cargarCCSS()
        '    Carga el elemento desplegable de tipo de estados CCSS desde una fuente de datos
        Dim lista = InformacionGralNegocio.Instancia.buscarEstadosCCSS()
        If lista.Count > 0 Then
            cbCCSS.DataSource = lista
            cbCCSS.DataTextField = "detalle"
            cbCCSS.DataValueField = "codigo"
            cbCCSS.DataBind()
        End If
        cbCCSS.ClearSelection()
    End Sub

    Protected Sub cargarEtnias()
        ' Carga el elemento desplegable de tipos de discapacidades con opciones predefinidas
        Dim lista = InformacionGralNegocio.Instancia.buscarEtnias()
        If lista.Count > 0 Then
            cbEtnia.DataSource = lista
            cbEtnia.DataTextField = "detalle"
            cbEtnia.DataValueField = "codigo"
            cbEtnia.DataBind()
        End If
        cbEtnia.ClearSelection()
    End Sub

    Protected Sub cargarEstadoCivil()
        ' Carga el elemento desplegable de estados civiles con opciones predefinidas
        Dim lista = InformacionGralNegocio.Instancia.buscarEstadoCivil()
        If lista.Count > 0 Then
            cbEstadoCivil.DataSource = lista
            cbEstadoCivil.DataTextField = "detalle"
            cbEstadoCivil.DataValueField = "codigo"
            cbEstadoCivil.DataBind()
        End If
        cbEstadoCivil.ClearSelection()
    End Sub

    Protected Sub cargarEscolaridad()
        ' Carga el elemento desplegable de estados civiles con opciones predefinidas
        Dim lista = InformacionGralNegocio.Instancia.buscarEscolaridad()
        If lista.Count > 0 Then
            cbEscolaridad.DataSource = lista
            cbEscolaridad.DataTextField = "detalle"
            cbEscolaridad.DataValueField = "codigo"
            cbEscolaridad.DataBind()
        End If
        cbEscolaridad.ClearSelection()
    End Sub

    Protected Sub cargarDiscapacidad()
        ' Carga el elemento desplegable de estados civiles con opciones predefinidas
        Dim lista = InformacionGralNegocio.Instancia.buscarDiscapacidad()
        If lista.Count > 0 Then
            cbTipoDiscapacidad.DataSource = lista
            cbTipoDiscapacidad.DataTextField = "detalle"
            cbTipoDiscapacidad.DataValueField = "codigo"
            cbTipoDiscapacidad.DataBind()
        End If
        cbTipoDiscapacidad.ClearSelection()
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

    Sub mostrarMensaje(ByVal mensaje As String)
        ' Este método se utiliza para mostrar mensajes de error en un elemento de la página con el ID "txtError".
        txtError.InnerText = mensaje
        txtError.Visible = True
    End Sub

    Sub cambioTipoProductor()
        ' Este método se utiliza para cambiar el comportamiento de la página
        ' según el tipo de productor seleccionado.

        If cbTipoProductor.SelectedValue = "1" Then
            ' Si el tipo de productor es 1 (asociado), se habilita el campo de la empresa asociada
            txtEmpresaA.Disabled = False
            txtEmpresaA.Value = ""
            txtEmpresaA.Attributes("placeholder") = "-- Digite --"
        Else
            ' Si el tipo de productor no es 1, se deshabilita el campo de la empresa asociada
            txtEmpresaA.Disabled = True
            txtEmpresaA.Value = ""
            txtEmpresaA.Attributes("placeholder") = "-- No aplica --"
        End If
    End Sub

    'Busca la region con el codigo del distrito
    Function buscarRegion(ByVal distrito As String) As String
        Return InformacionGralNegocio.Instancia.buscarRegion(distrito)
    End Function

    Protected Sub btnSiguiente_Click(sender As Object, e As EventArgs)
        ' Este evento se activa cuando se hace clic en el botón "Siguiente".
        ' Se llama a la función validación() para verificar la entrada del usuario.
        ' Si la validación es exitosa, se realiza una acción específica (como redireccionar a otra página).
        Dim fecha = DateTime.Now
        If txtEmpresaA.Value = "" Then
            txtEmpresaA.Value = "--No aplica--"
        End If

        If validacion() Then
            If Session("Inscripcion") = Nothing Then
                ' Si no hay inscripción existente, se crea una nueva y se redirige a la siguiente página
                Session("Inscripcion") = ProductorNegocio.Instancia.insertarInscripcionProductor(cbTipoCedula.SelectedValue, txtCedula.Value.Trim,
                                                                                                 txtNombre.Value, cbGenero.SelectedValue,
                                                                                                 txtTelefonoFijo.Value, txtCelular.Value,
                                                                                                 txtEmail.Value, cbDistrito.SelectedValue,
                                                                                                 buscarRegion(cbDistrito.SelectedValue),
                                                                                                 txtDireccion.Value, cbTipoProductor.SelectedValue,
                                                                                                 txtEmpresaA.Value, cbCCSS.SelectedValue,
                                                                                                 cbEtnia.SelectedValue, cbIngresosPropios.SelectedValue,
                                                                                                 cbSoloAgricola.SelectedValue, txtDependientesIngresos.Value,
                                                                                                 cbEstadoCivil.SelectedValue, txtHijosMenores.Value,
                                                                                                 cbEscolaridad.SelectedValue, cbTipoDiscapacidad.SelectedValue,
                                                                                                 cbCarnetConapdis.SelectedValue, cbProvincia.SelectedValue,
                                                                                                 cbCanton.SelectedValue, chkMAG.Checked, chkMAG.Checked, fecha)
                sessionInscripcion()
                Response.Redirect("/Productor Primario/PP_Form_2_RL.aspx", False)
            Else
                ' Si existe una inscripción, se actualiza y se redirige a la siguiente página
                ProductorNegocio.Instancia.actualizarInscripcionProductor(Session("Inscripcion"), cbTipoCedula.SelectedValue,
                                                                          txtCedula.Value.Trim, txtNombre.Value,
                                                                          cbGenero.SelectedValue, txtTelefonoFijo.Value,
                                                                          txtCelular.Value, txtEmail.Value,
                                                                          cbDistrito.SelectedValue, buscarRegion(cbDistrito.SelectedValue),
                                                                          txtDireccion.Value, cbTipoProductor.SelectedValue,
                                                                          txtEmpresaA.Value, cbCCSS.SelectedValue,
                                                                          cbEtnia.SelectedValue, cbIngresosPropios.SelectedValue,
                                                                          cbSoloAgricola.SelectedValue, txtDependientesIngresos.Value,
                                                                          cbEstadoCivil.SelectedValue, txtHijosMenores.Value,
                                                                          cbEscolaridad.SelectedValue, cbTipoDiscapacidad.SelectedValue,
                                                                          cbCarnetConapdis.SelectedValue, cbProvincia.SelectedValue,
                                                                          cbCanton.SelectedValue, chkMAG.Checked, chkMAG.Checked, fecha)
                sessionInscripcion()
                Response.Redirect("/Productor Primario/PP_Form_2_RL.aspx", False)
            End If
        End If
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

    Protected Sub cbTipoProductor_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cbTipoProductor.SelectedIndexChanged
        ' Este evento se activa cuando se selecciona un tipo de productor y llama al método cambioTipoProductor().
        cambioTipoProductor()
    End Sub

    Function validacion() As Boolean
        ' Esta función se utiliza para validar los datos ingresados por el usuario.
        ' Comprueba que se ingresen datos válidos en varios campos y muestra mensajes de error si es necesario.
        ' Si todas las validaciones son exitosas, devuelve True; de lo contrario, devuelve False.
        ' También se establecen estilos de borde rojo en los campos con errores.

        txtError.InnerText = ""
        txtError.Visible = False

        txtCedula.Attributes("Style") = ""
        txtNombre.Attributes("Style") = ""
        txtTelefonoFijo.Attributes("Style") = ""
        txtCelular.Attributes("Style") = ""
        txtEmail.Attributes("Style") = ""
        txtDireccion.Attributes("Style") = ""
        txtEmpresaA.Attributes("Style") = ""
        chkMH.Attributes("Style") = ""
        chkMAG.Attributes("Style") = ""
        cbCCSS.Attributes("Style") = ""
        cbEtnia.Attributes("Style") = ""
        cbIngresosPropios.Attributes("Style") = ""
        cbSoloAgricola.Attributes("Style") = ""
        txtDependientesIngresos.Attributes("Style") = ""
        cbEstadoCivil.Attributes("Style") = ""
        txtHijosMenores.Attributes("Style") = ""
        cbEscolaridad.Attributes("Style") = ""
        cbTipoDiscapacidad.Attributes("Style") = ""
        cbCarnetConapdis.Attributes("Style") = ""
        cbProvincia.Attributes("Style") = ""
        cbCanton.Attributes("Style") = ""
        cbDistrito.Attributes("Style") = ""

        validacion = True

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

        ' Validar tipo de productor
        If cbTipoProductor.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione el tipo de productor"
            txtError.Visible = True
            cbTipoProductor.Attributes("Style") = "border: 1px solid red;"
            validacion = False
        End If

        ' Validar empresa asociada si el tipo de productor es 1
        If cbTipoProductor.SelectedValue = 1 Then
            If txtEmpresaA.Value = "" Then
                txtError.InnerText &= " ● Digite el nombre de la empresa a la que está usted asociado"
                txtError.Visible = True
                validacion = False
                txtEmpresaA.Attributes("Style") = "border: 1px solid red;"
            End If
        End If

        ' Validar si se esta inscrito en el MH
        If Not chkMH.Checked Then
            txtError.InnerText &= " ● La inscripción en el Ministerio de Hacienda es obligatoria"
            txtError.Visible = True
            validacion = False
            chkMH.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar si se esta inscrito en el MAG
        If Not chkMAG.Checked Then
            txtError.InnerText &= " ● La inscripción en el Ministerio Agricultura y Ganadería es obligatoria"
            txtError.Visible = True
            validacion = False
            chkMAG.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar si se esta inscrito en CCSS
        If cbCCSS.SelectedValue.ToString = "1" Or cbCCSS.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● La inscripción en C.C.S.S. es obligatoria"
            txtError.Visible = True
            validacion = False
            cbCCSS.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar si selecciono etnias
        If cbEtnia.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione alguna opción étnica"
            txtError.Visible = True
            validacion = False
            cbEtnia.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar si selecciono ingresos del hogar
        If cbIngresosPropios.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione alguna opción en ingresos del hogar"
            txtError.Visible = True
            validacion = False
            cbIngresosPropios.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar si selecciono si su actividad es agricola
        If cbSoloAgricola.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione alguna opción en la pregunta de actividad agrícola"
            txtError.Visible = True
            validacion = False
            cbSoloAgricola.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar cantidad de dependientes
        If txtDependientesIngresos.Value = "" Then
            txtError.InnerText &= " ● Digite la cantidad de personas dependientes"
            txtError.Visible = True
            validacion = False
            txtDependientesIngresos.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar seleccion de estados civil
        If cbEstadoCivil.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione su estado civil"
            txtError.Visible = True
            validacion = False
            cbEstadoCivil.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar hijos menores
        If txtHijosMenores.Value = "" Then
            txtError.InnerText &= " ● Digite la cantidad de hijos menores"
            txtError.Visible = True
            validacion = False
            txtHijosMenores.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar seleccion de escolaridad
        If cbEscolaridad.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione su estado civil"
            txtError.Visible = True
            validacion = False
            cbEscolaridad.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar seleccion de discapacidad
        If cbTipoDiscapacidad.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione una opción en el tipo de discapacidad"
            txtError.Visible = True
            validacion = False
            cbTipoDiscapacidad.Attributes("Style") = "border: 1px solid red;"
        End If

        ' Validar seleccion de carnet conapdis
        If cbCarnetConapdis.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione una opción en el carnet de CONAPDIS"
            txtError.Visible = True
            validacion = False
            cbCarnetConapdis.Attributes("Style") = "border: 1px solid red;"
        End If

        Return validacion
    End Function

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario/Selector_Formulario.aspx", False)
    End Sub
End Class
