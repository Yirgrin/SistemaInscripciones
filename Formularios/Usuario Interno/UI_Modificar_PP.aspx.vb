Imports BackEnd
Public Class UI_Modificar_PP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtError.Visible = False
        txtError.InnerText = ""

        If Not IsPostBack Then
            cargarDatos()
        End If

    End Sub

    Sub cargarDatos()
        cargarDiscapacidad()
        cargarCategoria()
        cargarProductosHorto()
        cargarUnidadesMedida()
        cargarTipoCertificado()
        cargarFrecuencia()
    End Sub

    Protected Sub cargarDiscapacidad()
        ' Carga el elemento desplegable de discapacidades con opciones predefinidas
        Dim lista = InformacionGralNegocio.Instancia.buscarDiscapacidad()
        If lista.Count > 0 Then
            cbTipoDiscapacidad.DataSource = lista
            cbTipoDiscapacidad.DataTextField = "detalle"
            cbTipoDiscapacidad.DataValueField = "codigo"
            cbTipoDiscapacidad.DataBind()
        End If
        cbTipoDiscapacidad.ClearSelection()
    End Sub

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

    ' Subrutina para cargar los tipos de certificado desde el backend y enlazarlos con un control ComboBox.
    Protected Sub cargarTipoCertificado()
        Dim tiposCertificado = InformacionGralNegocio.Instancia.buscarTipoCertificacion()
        If tiposCertificado.Count > 0 Then
            cbTipoCertificacion.DataSource = tiposCertificado
            cbTipoCertificacion.DataTextField = "detalle"
            cbTipoCertificacion.DataValueField = "codigo"
            cbTipoCertificacion.DataBind()
        End If
        cbTipoCertificacion.SelectedValue = Nothing
    End Sub

    Protected Sub btnDiscapacidad_ServerClick(sender As Object, e As EventArgs)
        ' Carga el elemento desplegable de estados civiles con opciones predefinidas
        InformacionGralNegocio.Instancia.agregarDiscapacidad(txtDiscapacidad.Value)
        txtDiscapacidad.Value = ""
        cargarDiscapacidad()
    End Sub

    Protected Sub btnLineaAb_ServerClick(sender As Object, e As EventArgs)
        LinAbastecimientoNegocio.Instancia.nuevaLineaAb(txtLineaAb.Value)
        txtLineaAb.Value = ""
        cargarCategoria()
    End Sub

    Protected Sub btnProductoHorto_ServerClick(sender As Object, e As EventArgs)
        LinAbastecimientoNegocio.Instancia.nuevoProductoHorto(txtProductoHorto.Value)
        txtProductoHorto.Value = ""
        cargarProductosHorto()
    End Sub

    Protected Sub btnUnidadMedida_ServerClick(sender As Object, e As EventArgs)
        LinAbastecimientoNegocio.Instancia.nuevaUnidadMedida(txtUnidadMedida.Value)
        txtUnidadMedida.Value = ""
        cargarUnidadesMedida()
    End Sub

    Protected Sub btnFrecuencia_ServerClick(sender As Object, e As EventArgs)
        LinAbastecimientoNegocio.Instancia.nuevaFrecuencia(txtFrecuencia.Value)
        txtFrecuencia.Value = ""
        cargarFrecuencia()
    End Sub

    Protected Sub btnCertificacion_ServerClick(sender As Object, e As EventArgs)
        InformacionGralNegocio.Instancia.nuevoTipoCertificacion(txtCertificacion.Value)
        txtCertificacion.Value = ""
        cargarTipoCertificado()
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/UI_Pendientes_PP.aspx", False)
    End Sub
End Class