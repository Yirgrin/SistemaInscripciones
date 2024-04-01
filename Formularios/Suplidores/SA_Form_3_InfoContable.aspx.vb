Imports BackEnd
Imports Telerik.Web.UI

Public Class SA_Form_3_InfoContable
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtError.InnerText = ""
        txtError.Visible = False

        If Not IsPostBack Then
            'Comprobar si la variable de sesión "Inscripcion" está establecida.
            If Session("Inscripcion") Is Nothing Then
                'Si no está establecida, redirigir a la página de error.
                Response.Redirect("/Productor Primario/Error.aspx", False)
            Else
                cargaDatosInicial()

            End If
        End If
    End Sub

    Sub cargaDatosInicial()
        cargarLineasProduccion()
        preCargarActividades()
        cargarProvincia()
        preCargaDatos()
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

    Sub cargarLineasProduccion()
        ' trae las líneas de producción desde la base de datos, y las carga en un combobox
        Dim lista = InformacionContableNegocio.Instancia.cargarLineasProduccion()

        If lista.Count > 0 Then
            cbCategoriaPrincipal.DataSource = lista
            cbCategoriaPrincipal.DataTextField = "categoria"
            cbCategoriaPrincipal.DataValueField = "codigo"
            cbCategoriaPrincipal.DataBind()

            cbCategoriaSecundaria.DataSource = lista
            cbCategoriaSecundaria.DataTextField = "categoria"
            cbCategoriaSecundaria.DataValueField = "codigo"
            cbCategoriaSecundaria.DataBind()
        End If
        cbCategoriaPrincipal.SelectedValue = Nothing
        cbCategoriaPrincipal.EmptyMessage = "-- Seleccione --"

        cbCategoriaSecundaria.SelectedValue = Nothing
        cbCategoriaSecundaria.EmptyMessage = "-- Seleccione --"
    End Sub

    Function validarEntradas() As Boolean
        ' Esta función se utiliza para validar los datos ingresados por el usuario.
        ' Comprueba que se ingresen datos válidos en varios campos y muestra mensajes de error si es necesario.
        ' Si todas las validaciones son exitosas, devuelve True; de lo contrario, devuelve False.
        ' También se establecen estilos de borde rojo en los campos con errores.

        txtError.InnerText = ""
        txtError.Visible = False

        txtActivosFijos.Attributes("Style") = ""
        txtVentasNetas.Attributes("Style") = ""
        txtActivosTotales.Attributes("Style") = ""
        txtCantEmpleados.Attributes("Style") = ""
        cbCategoriaPrincipal.Attributes("Style") = ""
        cbProvincia.Attributes("Style") = ""
        cbCanton.Attributes("Style") = ""
        cbDistrito.Attributes("Style") = ""
        txtDireccion.Attributes("Style") = ""
        txtActivosFijos.Style("border-color") = "empty"
        txtVentasNetas.Style("border-color") = "empty"
        txtActivosTotales.Style("border-color") = "empty"
        txtCantEmpleados.Style("border-color") = "empty"
        cbCategoriaPrincipal.Style("border-color") = "empty"
        cbProvincia.Style("border-color") = "empty"
        cbCanton.Style("border-color") = "empty"
        cbDistrito.Style("border-color") = "empty"
        txtDireccion.Style("border-color") = "empty"

        validarEntradas = True

        ' Validar cantón
        If cbCategoriaPrincipal.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione la categoría principal que desarrolla en su empresa"
            txtError.Visible = True
            cbCategoriaPrincipal.Attributes("Style") = "border: 1px solid red;"
            validarEntradas = False
        End If

        ' Valida la cantidad de empleados.
        If txtCantEmpleados.Value = "" Then
            txtError.InnerText &= " ● Digite la cantidad cantidad de empleados"
            txtError.Visible = True
            validarEntradas = False
            txtCantEmpleados.Attributes("Style") = "border: 1px solid red;"
        Else
            'valida que el número no sea negativo
            Dim cantidadEmpleados As Integer

            If Integer.TryParse(txtCantEmpleados.Value, cantidadEmpleados) Then
                If cantidadEmpleados < 0 Then
                    txtError.InnerText &= " ● La cantidad de empleados no puede ser negativa"
                    txtError.Visible = True
                    validarEntradas = False
                    txtCantEmpleados.Attributes("Style") = "border: 1px solid red;"
                End If
            Else
                txtError.InnerText &= " ● Ingrese un valor válido para la cantidad de empleados"
                txtError.Visible = True
                validarEntradas = False
                txtCantEmpleados.Attributes("Style") = "border: 1px solid red;"
            End If
        End If


        ' Valida las ventas netas anuales
        If txtVentasNetas.Value = "" Then
            txtError.InnerText &= " ● Digite la cantidad de ventas netas anuales"
            txtError.Visible = True
            validarEntradas = False
            txtVentasNetas.Attributes("Style") = "border: 1px solid red;"
        Else
            'valida que el número no sea negativo
            Dim ventasNetas As Integer

            If Integer.TryParse(txtVentasNetas.Value, ventasNetas) Then
                If ventasNetas < 0 Then
                    txtError.InnerText &= " ● La cantidad de empleados no puede ser negativa"
                    txtError.Visible = True
                    validarEntradas = False
                    txtVentasNetas.Attributes("Style") = "border: 1px solid red;"
                End If
            Else
                txtError.InnerText &= " ● Ingrese un valor válido para la cantidad de empleados"
                txtError.Visible = True
                validarEntradas = False
                txtVentasNetas.Attributes("Style") = "border: 1px solid red;"
            End If
        End If

        ' Valida las ventas fijas anuales
        If txtActivosFijos.Value = "" Then
            txtError.InnerText &= " ● Digite la cantidad de ventas fijas anuales"
            txtError.Visible = True
            validarEntradas = False
            txtActivosFijos.Attributes("Style") = "border: 1px solid red;"
        Else
            'valida que el número no sea negativo
            Dim activosFijos As Integer

            If Integer.TryParse(txtActivosFijos.Value, activosFijos) Then
                If activosFijos < 0 Then
                    txtError.InnerText &= " ● La cantidad de empleados no puede ser negativa"
                    txtError.Visible = True
                    validarEntradas = False
                    txtActivosFijos.Attributes("Style") = "border: 1px solid red;"
                End If
            Else
                txtError.InnerText &= " ● Ingrese un valor válido para la cantidad de empleados"
                txtError.Visible = True
                validarEntradas = False
                txtActivosFijos.Attributes("Style") = "border: 1px solid red;"
            End If
        End If

        ' Valida las ventas totales anuales
        If txtActivosTotales.Value = "" Then
            txtError.InnerText &= " ● Digite la cantidad de ventas totales anuales"
            txtError.Visible = True
            validarEntradas = False
            txtActivosTotales.Attributes("Style") = "border: 1px solid red;"
        Else
            'valida que el número no sea negativo
            Dim activosTotales As Integer

            If Integer.TryParse(txtActivosTotales.Value, activosTotales) Then
                If activosTotales < 0 Then
                    txtError.InnerText &= " ● La cantidad de empleados no puede ser negativa"
                    txtError.Visible = True
                    validarEntradas = False
                    txtActivosTotales.Attributes("Style") = "border: 1px solid red;"
                End If
            Else
                txtError.InnerText &= " ● Ingrese un valor válido para la cantidad de empleados"
                txtError.Visible = True
                validarEntradas = False
                txtActivosTotales.Attributes("Style") = "border: 1px solid red;"
            End If
        End If

        ' Validar provincia
        If cbProvincia.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione la provincia"
            txtError.Visible = True
            cbProvincia.Attributes("Style") = "border: 1px solid red;"
            validarEntradas = False
        End If

        ' Validar cantón
        If cbCanton.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione el cantón"
            txtError.Visible = True
            cbCanton.Attributes("Style") = "border: 1px solid red;"
            validarEntradas = False
        End If

        ' Validar distrito
        If cbDistrito.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione el distrito"
            txtError.Visible = True
            cbDistrito.Attributes("Style") = "border: 1px solid red;"
            validarEntradas = False
        End If

        ' Validar dirección
        If txtDireccion.Value = "" Then
            txtError.InnerText &= " ● Digite una dirección exacta"
            txtError.Visible = True
            validarEntradas = False
            txtDireccion.Attributes("Style") = "border: 1px solid red;"
        End If

        Return validarEntradas
    End Function

    Sub preCargaDatos()
        ' Precarga los datos de Información Contable que el usuario emitió en el formulario.
        Dim modelo = InformacionContableNegocio.Instancia.cargarDatosContables(Session("Inscripcion"))

        Session("Datos") = modelo.actividadPrincipal
        txtActivosFijos.Value = modelo.activosFijos
        txtVentasNetas.Value = modelo.ventasNetas
        txtActivosTotales.Value = modelo.activosTotales
        txtCantEmpleados.Value = modelo.cantidadEmpleados
        cbCategoriaPrincipal.SelectedValue = modelo.actividadPrincipal
        cbProvincia.SelectedValue = modelo.codProvincia

        'carga el canton de acuerdo a la selección de la provincia que viene desde la base de datos
        cargarCanton(cbProvincia.SelectedValue)
        cbCanton.Enabled = True

        cbCanton.SelectedValue = modelo.codCanton

        'carga el distrito de acuerdo a la selección del cantón que viene desde la base de datos
        cargarDistrito(cbCanton.SelectedValue)
        cbDistrito.Enabled = True

        cbDistrito.SelectedValue = modelo.codDistrito
        txtDireccion.Value = modelo.direcExacta

    End Sub

    Sub limpiarEntradas()
        cbCategoriaSecundaria.ClearSelection()
    End Sub

    ' Subrutina para pre-cargar información de las lineas de abastecimiento agregadas relacionados con la inscripción.
    Sub preCargarActividades()
        rgActividadComercial.DataSource = ActividadComercialNegocio.Instancia.preCargarActividades(Session("Inscripcion"))
        rgActividadComercial.DataBind()
    End Sub

    ' Función que valida que se esté tomando un valor del combobox de actividad secundaria
    Function validarActSecundaria() As Boolean
        validarActSecundaria = True
        If cbCategoriaSecundaria.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Debe seleccionar una categoría"
            txtError.Visible = True
            cbCategoriaSecundaria.Attributes("Style") = "border: 1px solid red;"
            validarActSecundaria = False
        End If
        Return validarActSecundaria
    End Function

    ' Evento que se ejecuta cuando se le da al botón agregar actividades
    Protected Sub btnAgregarActividad_ServerClick(sender As Object, e As EventArgs)

        ' Valida si la actividad secundaria si se seleccionó
        If validarActSecundaria() Then

            'asigna un 2 si la actividad es de tipo Comercio (sólo los abarrotes son de esta categoría)
            Dim clasificacionProd = 1
            If cbCategoriaSecundaria.SelectedValue = 1 Then
                clasificacionProd = 2
            End If

            ' Ingresa los datos en la db
            ActividadComercialNegocio.Instancia.InsertarActividadComercial(Session("Inscripcion"), cbCategoriaSecundaria.SelectedValue,
                                                                                clasificacionProd)

            limpiarEntradas()
            preCargarActividades()
        End If
    End Sub


    Protected Sub btnEliminarActividad_Click1(sender As Object, e As EventArgs)
        Try
            Dim lnk As LinkButton = DirectCast(sender, LinkButton)
            Dim data As GridDataItem = DirectCast(lnk.NamingContainer, GridDataItem)
            Dim codigo As String = data.GetDataKeyValue("codigo").ToString()
            ' Eliminar una línea seleccionada del backend.
            ActividadComercialNegocio.Instancia.eliminarActividadComercial(codigo)
            ' Actualizar la información de la tabla
            preCargarActividades()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub


    Protected Sub btnSiguiente_ServerClick(sender As Object, e As EventArgs)

        ' valida si todos las entradas se llenaron
        If validarEntradas() Then
            'asigna un 2 si la actividad es de tipo Comercio (sólo los abarrotes son de esta categoría)
            Dim clasificacionProd = 1
            If cbCategoriaPrincipal.SelectedValue = 1 Then
                clasificacionProd = 2
            End If

            If Session("Datos") = Nothing Then
                ' inserta los datos en la base de datos
                InformacionContableNegocio.Instancia.InsertarInfoContable(Session("Inscripcion"), cbCategoriaPrincipal.SelectedValue,
                                                                          txtCantEmpleados.Value, txtVentasNetas.Value, txtActivosFijos.Value,
                                                                          txtActivosTotales.Value, clasificacionProd, cbProvincia.SelectedValue,
                                                                          cbCanton.SelectedValue, cbDistrito.SelectedValue, txtDireccion.Value,
                                                                          buscarRegion(cbDistrito.SelectedValue))

                Response.Redirect("/Suplidores/SA_Form_4_Cert.aspx", False)
            Else
                ' actualiza la información que ya está en la base de datos
                InformacionContableNegocio.Instancia.ActualizarInfoContable(Session("Inscripcion"), cbCategoriaPrincipal.SelectedValue,
                                                                          txtCantEmpleados.Value, txtVentasNetas.Value, txtActivosFijos.Value,
                                                                          txtActivosTotales.Value, clasificacionProd, cbProvincia.SelectedValue,
                                                                          cbCanton.SelectedValue, cbDistrito.SelectedValue, txtDireccion.Value,
                                                                          buscarRegion(cbDistrito.SelectedValue))
                Response.Redirect("/Suplidores/SA_Form_4_Cert.aspx", False)
            End If

        End If
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        ' direcciona a la página anterior
        Response.Redirect("/Suplidores/SA_Form_2_RL.aspx", False)
    End Sub
End Class