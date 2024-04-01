Imports BackEnd
Imports Telerik.Web.UI

Public Class PP_Form_3_LineaAb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Configuración inicial cuando se carga la página.
        If Not IsPostBack Then
            'Comprobar si la variable de sesión "Inscripcion" está establecida.
            If Session("Inscripcion") Is Nothing Then
                'Si no está establecida, redirigir a la página de error.
                Response.Redirect("/Productor Primario/Error.aspx", False)
            Else
                txtError.InnerText = ""
                txtError.Visible = False
                cargarProvincia()
                ocultarDivs()
                cargarProductosHorto()
                cargarUnidadesMedida()
                cargarFrecuencia()
                preCargaLineasAb()
            End If

        End If
    End Sub

    Protected Sub ocultarDivs()
        divGanLeche.Visible = False
        divGanCarne.Visible = False
        divGanCerdo.Visible = False
        divProdPollo.Visible = False
        divProdHuevos.Visible = False
        divProdAgricola.Visible = False
        divProdPescado.Visible = False
        divAreaTotal.Visible = False
        txtError.InnerText = ""
        txtError.Visible = False
    End Sub

    ' Función para cargar información de provincias desde el backend y enlazarla con un control ComboBox.
    Protected Sub cargarProvincia()
        Dim lista = InformacionGralNegocio.Instancia.buscarProvincias()
        If lista.Count > 0 Then
            cbProvincia.DataSource = lista
            cbProvincia.DataTextField = "desProvincia"
            cbProvincia.DataValueField = "codProvincia"
            cbProvincia.DataBind()
        End If
        cbProvincia.SelectedValue = Nothing
        cbProvincia.EmptyMessage = "-- Seleccione --"
    End Sub

    ' Evento que se dispara cuando se selecciona una provincia en el ComboBox de provincias.
    Protected Sub cbProvincia_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbProvincia.SelectedIndexChanged
        ' Cargar la información de los cantones y habilitar el ComboBox de cantones.
        cargarCanton(cbProvincia.SelectedValue)
        cbCanton.Enabled = True
    End Sub

    ' Función para cargar información de cantones desde el backend y enlazarla con un control ComboBox.
    Protected Sub cargarCanton(ByVal provincia As String)
        Dim lista = InformacionGralNegocio.Instancia.buscarCantones(provincia)
        If lista.Count > 0 Then
            cbCanton.DataSource = lista
            cbCanton.DataTextField = "desCanton"
            cbCanton.DataValueField = "codCanton"
            cbCanton.DataBind()
        End If
        cbCanton.SelectedValue = Nothing
        cbCanton.EmptyMessage = "-- Seleccione --"
    End Sub

    ' Evento que se dispara cuando se selecciona un cantón en el ComboBox de cantones.
    Protected Sub cbCanton_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbCanton.SelectedIndexChanged
        ' Cargar la información de los distritos y habilitar el ComboBox de distritos.
        cargarDistrito(cbCanton.SelectedValue)
        cbDistrito.Enabled = True
    End Sub

    ' Función para cargar información de distritos desde el backend y enlazarla con un control ComboBox.
    Protected Sub cargarDistrito(ByVal canton As String)
        Dim lista = InformacionGralNegocio.Instancia.buscarDistritos(canton)
        If lista.Count > 0 Then
            cbDistrito.DataSource = lista
            cbDistrito.DataTextField = "desDistrito"
            cbDistrito.DataValueField = "codDistrito"
            cbDistrito.DataBind()
        End If
        cbDistrito.SelectedValue = Nothing
        cbDistrito.EmptyMessage = "-- Seleccione --"
    End Sub

    ' Evento que se dispara cuando se selecciona un distrito en el ComboBox de distritos.
    Protected Sub radcmbDistrito_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cbDistrito.SelectedIndexChanged
        ' Habilitar la entrada de dirección, cargar información sobre la tenencia y habilitar el ComboBox de tenencia.
        txtDireccion.Disabled = False
        cargarCategoria()
        cbLineaAb.Enabled = True

    End Sub

    ' Función para cargar las categorías de productos desde el backend y enlazarlas con un control ComboBox.
    Protected Sub cargarCategoria()
        Dim lista = LinAbastecimientoNegocio.Instancia.buscarCategoriasProducto()
        If lista.Count > 0 Then
            cbLineaAb.DataSource = lista
            cbLineaAb.DataTextField = "desClasificacion"
            cbLineaAb.DataValueField = "codClasificacion"
            cbLineaAb.DataBind()

            cbLineaAb.SelectedValue = Nothing
            cbLineaAb.EmptyMessage = "-- Seleccione --"
        End If
    End Sub

    ' Función para cargar la lista de productos desde el backend y enlazarlas con un control ComboBox.
    Protected Sub cargarProductosHorto()
        Dim lista = LinAbastecimientoNegocio.Instancia.buscarProductosHorto()
        If lista.Count > 0 Then
            cbProductoHorto.DataSource = lista
            cbProductoHorto.DataTextField = "desClasificacion"
            cbProductoHorto.DataValueField = "codClasificacion"
            cbProductoHorto.DataBind()

            cbProductoHorto.SelectedValue = Nothing
            cbProductoHorto.EmptyMessage = "-- Seleccione --"
        End If
    End Sub

    ' Función para cargar la lista de productos desde el backend y enlazarlas con un control ComboBox.
    Protected Sub cargarUnidadesMedida()
        Dim lista = LinAbastecimientoNegocio.Instancia.cargarUnidadesMedida()
        If lista.Count > 0 Then
            cbUnidadMedida.DataSource = lista
            cbUnidadMedida.DataTextField = "desClasificacion"
            cbUnidadMedida.DataValueField = "codClasificacion"
            cbUnidadMedida.DataBind()

            cbUnidadMedida.SelectedValue = Nothing
            cbUnidadMedida.EmptyMessage = "-- Seleccione --"
        End If
    End Sub

    ' Evento que se dispara cuando se selecciona un producto en el ComboBox de productosHorto.
    Protected Sub cbProductoHorto_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbProductoHorto.SelectedIndexChanged
        ' Habilitar el ComboBox de unidades, frecuencia y txt cantidad.
        cbUnidadMedida.Enabled = True
        cbFrecuencia.Enabled = True
        txtCantidad.Disabled = False
    End Sub

    ' Función para cargar la lista de productos desde el backend y enlazarlas con un control ComboBox.
    Protected Sub cargarFrecuencia()
        Dim lista = LinAbastecimientoNegocio.Instancia.cargarFrecuencia()
        If lista.Count > 0 Then
            cbFrecuencia.DataSource = lista
            cbFrecuencia.DataTextField = "desClasificacion"
            cbFrecuencia.DataValueField = "codClasificacion"
            cbFrecuencia.DataBind()

            cbFrecuencia.SelectedValue = Nothing
            cbFrecuencia.EmptyMessage = "-- Seleccione --"
        End If
    End Sub

    ' Evento que se dispara al seleccionar una categoría en el ComboBox de LineaAb.
    Protected Sub cbCategoria_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cbLineaAb.SelectedIndexChanged
        'Se ocultan los divs para que cuando se cambie de opción se limpien
        ocultarDivs()

        'Se muestran los divs con las opciones específicas de cada categoría. 
        'Se llamam desde el web.config
        If cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codGanLeche") Then
            divGanLeche.Visible = True
            divAreaTotal.Visible = True
        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codGanCarne") Then
            divGanCarne.Visible = True
            divAreaTotal.Visible = True
        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdCerdo") Then
            divGanCerdo.Visible = True
            divAreaTotal.Visible = True
        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdPollo") Then
            divProdPollo.Visible = True
            divAreaTotal.Visible = True
        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdHuevos") Then
            divProdHuevos.Visible = True
            divAreaTotal.Visible = True
        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdPescado") Then
            divProdPescado.Visible = True
            divAreaTotal.Visible = False
        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdAgricola") Then
            divProdAgricola.Visible = True
            divAreaTotal.Visible = True
        End If
    End Sub

    ' Función para validar las entradas de una nueva linea de abastecimiento.
    Function validarEntradasLineaAb() As Boolean

        'quita los bordes rojos y el estilo de un error.
        txtError.InnerText = ""
        txtError.Style("border-color") = "empty"
        txtError.Visible = False
        txtAreatotal.Style("border-color") = "empty"
        txtDireccion.Style("border-color") = "empty"
        txtLecheDia.Style("border-color") = "empty"
        txtTotalCabezas.Style("border-color") = "empty"
        txtCabezasSemana.Style("border-color") = "empty"
        txtTotalUnidades.Style("border-color") = "empty"
        txtUnidadesSemana.Style("border-color") = "empty"
        txtTotalPicos.Style("border-color") = "empty"
        txtKgDíaP.Style("border-color") = "empty"
        txtCartonesDiarios.Style("border-color") = "empty"
        txtHuevosDia.Style("border-color") = "empty"
        txtKgTilapia.Style("border-color") = "empty"
        txtKgOtros.Style("border-color") = "empty"
        cbProductoHorto.Style("border-color") = "empty"
        cbUnidadMedida.Style("border-color") = "empty"
        cbFrecuencia.Style("border-color") = "empty"

        Dim valido = True
        ' Validar provincia.
        If cbProvincia.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione la provincia"
            txtError.Visible = True
            valido = False
        End If
        ' Validar cantón.
        If cbCanton.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione el cantón"
            txtError.Visible = True
            valido = False
        End If
        ' Validar distrito.
        If cbDistrito.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione el distrito"
            txtError.Visible = True
            valido = False
        End If
        ' Validar dirección.
        If txtDireccion.Value = "" Then
            txtError.InnerText &= " ● Digite una dirección exacta"
            txtError.Visible = True
            valido = False
            txtDireccion.Style("border-color") = "red"
        End If



        ' Validar tipo de linea.
        If cbLineaAb.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione un tipo de línea de abastecimiento"
            txtError.Visible = True
            valido = False
        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codGanLeche") Then
            'Validaciones de la línea ganadería de leche
            ' Validar área total
            If String.IsNullOrEmpty(txtAreatotal.Value) OrElse Not Regex.IsMatch(txtAreatotal.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un área total válida (En hectáreas)"
                txtError.Visible = True
                valido = False
                txtAreatotal.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim areaTotal As Integer

                If Integer.TryParse(txtAreatotal.Value, areaTotal) Then
                    If areaTotal < 0 Then
                        txtError.InnerText &= " ● El área total no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtAreatotal.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

            ' Validar área productiva.
            If String.IsNullOrEmpty(txtLecheDia.Value) OrElse Not Regex.IsMatch(txtLecheDia.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtLecheDia.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim lecheDia As Integer

                If Integer.TryParse(txtLecheDia.Value, lecheDia) Then
                    If lecheDia < 0 Then
                        txtError.InnerText &= " ● La cantidad de leche diaria no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtLecheDia.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codGanCarne") Then
            ' Validaciones de la línea ganadería de carne
            ' Validar área total
            If String.IsNullOrEmpty(txtAreatotal.Value) OrElse Not Regex.IsMatch(txtAreatotal.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un área total válida (En hectáreas)"
                txtError.Visible = True
                valido = False
                txtAreatotal.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim areaTotal As Integer

                If Integer.TryParse(txtAreatotal.Value, areaTotal) Then
                    If areaTotal < 0 Then
                        txtError.InnerText &= " ● El área total no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtAreatotal.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If
            ' Validar total de cabezas.
            If String.IsNullOrEmpty(txtTotalCabezas.Value) OrElse Not Regex.IsMatch(txtTotalCabezas.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtTotalCabezas.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim totalCabezas As Integer

                If Integer.TryParse(txtTotalCabezas.Value, totalCabezas) Then
                    If totalCabezas < 0 Then
                        txtError.InnerText &= " ● El total de cabezas no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtTotalCabezas.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If
            ' Validar total de cabezas a la semana.
            If String.IsNullOrEmpty(txtCabezasSemana.Value) OrElse Not Regex.IsMatch(txtCabezasSemana.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtCabezasSemana.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim cabezasSemana As Integer

                If Integer.TryParse(txtCabezasSemana.Value, cabezasSemana) Then
                    If cabezasSemana < 0 Then
                        txtError.InnerText &= " ● El total de cabezas semanal no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtCabezasSemana.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdCerdo") Then
            ' Validaciones de la línea ganadería de cerdo
            ' Validar área total
            If String.IsNullOrEmpty(txtAreatotal.Value) OrElse Not Regex.IsMatch(txtAreatotal.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un área total válida (En hectáreas)"
                txtError.Visible = True
                valido = False
                txtAreatotal.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim areaTotal As Integer

                If Integer.TryParse(txtAreatotal.Value, areaTotal) Then
                    If areaTotal < 0 Then
                        txtError.InnerText &= " ● El área total no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtAreatotal.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

            ' Validar total de unidades.
            If String.IsNullOrEmpty(txtTotalUnidades.Value) OrElse Not Regex.IsMatch(txtTotalUnidades.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtTotalUnidades.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim totalUnidades As Integer

                If Integer.TryParse(txtTotalUnidades.Value, totalUnidades) Then
                    If totalUnidades < 0 Then
                        txtError.InnerText &= " ● El total de unidades no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtTotalUnidades.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

            ' Validar total de unidades a la semana.
            If String.IsNullOrEmpty(txtUnidadesSemana.Value) OrElse Not Regex.IsMatch(txtUnidadesSemana.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtUnidadesSemana.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim unidadesSemana As Integer

                If Integer.TryParse(txtUnidadesSemana.Value, unidadesSemana) Then
                    If unidadesSemana < 0 Then
                        txtError.InnerText &= " ● El total de unidades no puede ser negativo"
                        txtError.Visible = True
                        valido = False
                        txtUnidadesSemana.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdPollo") Then
            ' Validaciones de la línea producción de pollo
            ' Validar área total
            If String.IsNullOrEmpty(txtAreatotal.Value) OrElse Not Regex.IsMatch(txtAreatotal.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un área total válida (En hectáreas)"
                txtError.Visible = True
                valido = False
                txtAreatotal.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim areaTotal As Integer

                If Integer.TryParse(txtAreatotal.Value, areaTotal) Then
                    If areaTotal < 0 Then
                        txtError.InnerText &= " ● El área total no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtAreatotal.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

            ' Validar total de picos.
            If String.IsNullOrEmpty(txtTotalPicos.Value) OrElse Not Regex.IsMatch(txtTotalPicos.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtTotalPicos.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim totalPicos As Integer

                If Integer.TryParse(txtTotalPicos.Value, totalPicos) Then
                    If totalPicos < 0 Then
                        txtError.InnerText &= " ● El total de picos no puede ser negativ"
                        txtError.Visible = True
                        valido = False
                        txtTotalPicos.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If
            ' Validar total de kg a la semana.
            If String.IsNullOrEmpty(txtKgDíaP.Value) OrElse Not Regex.IsMatch(txtKgDíaP.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtKgDíaP.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim kgDia As Integer

                If Integer.TryParse(txtKgDíaP.Value, kgDia) Then
                    If kgDia < 0 Then
                        txtError.InnerText &= " ● El total de kg no puede ser negativo"
                        txtError.Visible = True
                        valido = False
                        txtKgDíaP.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdHuevos") Then
            ' Validaciones de la línea producción de huevos
            ' Validar área total
            If String.IsNullOrEmpty(txtAreatotal.Value) OrElse Not Regex.IsMatch(txtAreatotal.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un área total válida (En hectáreas)"
                txtError.Visible = True
                valido = False
                txtAreatotal.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim areaTotal As Integer

                If Integer.TryParse(txtAreatotal.Value, areaTotal) Then
                    If areaTotal < 0 Then
                        txtError.InnerText &= " ● El área total no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtAreatotal.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

            ' Validar total de cartones diarios.
            If String.IsNullOrEmpty(txtCartonesDiarios.Value) OrElse Not Regex.IsMatch(txtCartonesDiarios.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtCartonesDiarios.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim cartones As Integer

                If Integer.TryParse(txtCartonesDiarios.Value, cartones) Then
                    If cartones < 0 Then
                        txtError.InnerText &= " ● El total de cartones diarios no puede ser negativo"
                        txtError.Visible = True
                        valido = False
                        txtCartonesDiarios.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

            ' Validar total de kg a la semana.
            If String.IsNullOrEmpty(txtHuevosDia.Value) OrElse Not Regex.IsMatch(txtHuevosDia.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtHuevosDia.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim huevosDia As Integer

                If Integer.TryParse(txtHuevosDia.Value, huevosDia) Then
                    If huevosDia < 0 Then
                        txtError.InnerText &= " ● El total de huevos diario no puede ser negativo"
                        txtError.Visible = True
                        valido = False
                        txtHuevosDia.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdPescado") Then
            ' Validaciones de la línea producción de pescado
            ' Validar total de kg de tilapia semanal.
            If String.IsNullOrEmpty(txtKgTilapia.Value) OrElse Not Regex.IsMatch(txtKgTilapia.Value, "^[0-9]\d*(\.\d+)?$") Then

                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtKgTilapia.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim tilapia As Integer

                If Integer.TryParse(txtKgTilapia.Value, tilapia) Then
                    If tilapia < 0 Then
                        txtError.InnerText &= " ● El total de kg de tilapia no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtKgTilapia.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

            ' Validar total de kg de otros semanal.
            If String.IsNullOrEmpty(txtKgOtros.Value) OrElse Not Regex.IsMatch(txtKgOtros.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un número válido"
                txtError.Visible = True
                valido = False
                txtKgOtros.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim otros As Integer

                If Integer.TryParse(txtKgOtros.Value, otros) Then
                    If otros < 0 Then
                        txtError.InnerText &= " ● El dato no puede ser negativo"
                        txtError.Visible = True
                        valido = False
                        txtKgOtros.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If

        ElseIf cbLineaAb.SelectedValue = ConfigurationManager.AppSettings("codProdAgricola") Then
            ' Validar producto hortofruticulas.
            If cbProductoHorto.SelectedItem Is Nothing Then
                txtError.InnerText &= " ● Seleccione un producto"
                txtError.Visible = True
                valido = False
            End If

            ' Validar unidad de medida.
            If cbUnidadMedida.SelectedItem Is Nothing Then
                txtError.InnerText &= " ● Seleccione la unidad de medida"
                txtError.Visible = True
                valido = False
            End If

            ' Validar frecuencia.
            If cbFrecuencia.SelectedItem Is Nothing Then
                txtError.InnerText &= " ● Seleccione la frecuencia"
                txtError.Visible = True
                valido = False
            End If

            If String.IsNullOrEmpty(txtAreatotal.Value) OrElse Not Regex.IsMatch(txtAreatotal.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un área total válida (En hectáreas)"
                txtError.Visible = True
                valido = False
                txtAreatotal.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim areaTotal As Integer

                If Integer.TryParse(txtAreatotal.Value, areaTotal) Then
                    If areaTotal < 0 Then
                        txtError.InnerText &= " ● El área total no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtAreatotal.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If
            If String.IsNullOrEmpty(txtCantidad.Value) OrElse Not Regex.IsMatch(txtCantidad.Value, "^[0-9]\d*(\.\d+)?$") Then
                txtError.InnerText &= " ● Digite un área total válida (En hectáreas)"
                txtError.Visible = True
                valido = False
                txtCantidad.Style("border-color") = "red"
            Else
                'valida que el número no sea negativo
                Dim cantidad As Integer

                If Integer.TryParse(txtCantidad.Value, cantidad) Then
                    If cantidad < 0 Then
                        txtError.InnerText &= " ● El área total no puede ser negativa"
                        txtError.Visible = True
                        valido = False
                        txtCantidad.Attributes("Style") = "border: 1px solid red;"
                    End If
                End If
            End If
        End If
        Return valido
    End Function

    ' Subrutina para limpiar las entradas de los inputs cuando ya se agregó la información.
    Sub limpiarEntradas()
        txtAreatotal.Value = ""
        txtLecheDia.Value = ""
        txtTotalCabezas.Value = ""
        txtCabezasSemana.Value = ""
        txtTotalUnidades.Value = ""
        txtUnidadesSemana.Value = ""
        txtTotalPicos.Value = ""
        txtKgDíaP.Value = ""
        txtCartonesDiarios.Value = ""
        txtHuevosDia.Value = ""
        txtKgTilapia.Value = ""
        txtKgOtros.Value = ""
        txtCantidad.Value = ""
        cbLineaAb.ClearSelection()
        cbProductoHorto.ClearSelection()
        cbFrecuencia.ClearSelection()
        cbUnidadMedida.ClearSelection()
    End Sub

    ' Evento que se dispara cuando se hace clic en el botón "Agregar Linea de abastecimiento".
    Protected Sub btnAgregarLinea_ServerClick(sender As Object, e As EventArgs)
        'valida las entradas y si alguna entrada viene vacía le agrega un 0
        If validarEntradasLineaAb() Then
            Dim verificacionCampo = "INCOMPLETA"

            ' Insertar un nuevo terreno en el backend con la información proporcionada.
            LinAbastecimientoNegocio.Instancia.insertarLineaAB(Session("Inscripcion"), cbLineaAb.SelectedValue, cbProvincia.SelectedValue, cbCanton.SelectedValue,
                                                         cbDistrito.SelectedValue, txtDireccion.Value, txtAreatotal.Value, txtLecheDia.Value,
                                                         txtTotalCabezas.Value, txtCabezasSemana.Value, txtTotalUnidades.Value,
                                                         txtUnidadesSemana.Value, txtTotalPicos.Value, txtKgDíaP.Value, txtCartonesDiarios.Value,
                                                         txtHuevosDia.Value, txtKgTilapia.Value, txtKgOtros.Value, cbProductoHorto.SelectedValue,
                                                         cbUnidadMedida.SelectedValue, txtCantidad.Value, cbFrecuencia.SelectedValue, verificacionCampo)

            'Se limpian las entradas y se actualiza la información de la tabla
            limpiarEntradas()
            preCargaLineasAb()
            ocultarDivs()
        End If
    End Sub

    ' Subrutina para pre-cargar información de las lineas de abastecimiento agregadas relacionados con la inscripción.
    Sub preCargaLineasAb()
        'carga la info en una tabla
        rglineasAb.DataSource = LinAbastecimientoNegocio.Instancia.traerLineasAb(Session("Inscripcion"))
        rglineasAb.DataBind()
    End Sub

    ' Subrutina para mostrar un mensaje en el elemento HTML.
    Sub mostrarMensaje(ByRef mensaje As String)
        txtError.InnerText = mensaje
        txtError.Visible = True
    End Sub

    ' Evento que se dispara cuando se hace clic en el enlace "Eliminar" en la tabla que muestra las entradas.
    Protected Sub eliminarLineaAb_Click(sender As Object, e As EventArgs)
        Try
            Dim lnk As LinkButton = DirectCast(sender, LinkButton)
            Dim data As GridDataItem = DirectCast(lnk.NamingContainer, GridDataItem)
            Dim codigoLineaAb As String = data.GetDataKeyValue("codigo").ToString()
            ' Eliminar una línea seleccionada del backend.
            LinAbastecimientoNegocio.Instancia.eliminarLineaAb(codigoLineaAb)
            ' Actualizar la información de la tabla
            preCargaLineasAb()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub btnSiguiente_ServerClick(sender As Object, e As EventArgs)
        ' Verifica si el RadGrid tiene al menos una fila de datos
        If rglineasAb.MasterTableView.Items.Count > 0 Then
            ' Puedes redirigir a la siguiente pantalla aquí
            Response.Redirect("/Productor Primario/PP_Form_4_Cert.aspx")
        Else
            ' Si no hay datos en el RadGrid, muestra un mensaje de error o realiza alguna otra acción
            mostrarMensaje(" ●  Debes ingresar al menos una actividad antes de continuar.")
        End If
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        ' Redirige a la página anterior.
        Response.Redirect("/Productor Primario/PP_Form_2_RL.aspx", False)
    End Sub

End Class