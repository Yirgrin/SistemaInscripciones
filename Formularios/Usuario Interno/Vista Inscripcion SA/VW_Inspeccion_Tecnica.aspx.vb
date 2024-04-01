Imports BackEnd
Public Class VW_Inspeccion_Tecnica
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            txtError.InnerText = ""
            txtError.Visible = False
            btnEditar.Visible = False
            btnGuardarCambios.Visible = False
            cargarInspeccion()
            cargarResolucion()

        End If
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inscrip_4_CertSA.aspx", False)
    End Sub

    ' valida las entradas de la Inspección Técnica
    Function validarInspeccion() As Boolean
        Dim bandera = True
        txtError.InnerText = ""
        txtError.Visible = False
        txtNumSolicitud.Attributes("Style") = ""
        txtNumInforme.Attributes("Style") = ""
        txtResultadoMayor.Attributes("Style") = ""
        txtResultadoMenor.Attributes("Style") = ""
        dtFechaInspeccion.Attributes("Style") = ""
        dtFechaSolicitud.Attributes("Style") = ""
        dtFechaInforme.Attributes("Style") = ""
        txtRealizadoPor.Attributes("Style") = ""

        'verifica espacio de número de solicitud
        If Not txtNumSolicitud.Disabled Then
            If txtNumSolicitud.Value = "" Then
                txtError.InnerText &= " ● Digite el Número de Solicitud de Oficio"
                txtError.Visible = True
                bandera = False
                txtNumSolicitud.Attributes("Style") = "border: 1px solid red;"
            ElseIf Not Regex.IsMatch(txtNumSolicitud.Value, "^[a-zA-Z0-9]+$") Then
                txtError.InnerText &= " ● El Número de Solicitud de Oficio contiene símbolos no permitidos, digite sólo letras o números"
                txtError.Visible = True
                bandera = False
                txtNumSolicitud.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        'verifica espacio de número de informe
        If Not txtNumInforme.Disabled Then
            If txtNumInforme.Value = "" Then
                txtError.InnerText &= " ● Digite el Número de Oficio"
                txtError.Visible = True
                bandera = False
                txtNumInforme.Attributes("Style") = "border: 1px solid red;"
            ElseIf Not Regex.IsMatch(txtNumInforme.Value, "^[a-zA-Z0-9]+$") Then
                txtError.InnerText &= " ● El Número de Oficio contiene símbolos no permitidos, digite sólo letras o números"
                txtError.Visible = True
                bandera = False
                txtNumInforme.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        'verifica espacio de resultado de cumplimiento mayor
        If Not txtResultadoMayor.Disabled Then
            If txtResultadoMayor.Value = "" Then
                txtError.InnerText &= " ● Digite el resultado de cumplimiento mayor"
                txtError.Visible = True
                bandera = False
                txtResultadoMayor.Attributes("Style") = "border: 1px solid red;"
            ElseIf Not Regex.IsMatch(txtResultadoMayor.Value, "^[a-zA-Z0-9]+$") Then
                txtError.InnerText &= " ● El cumplimiento mayor contiene símbolos no permitidos, digite sólo letras o números"
                txtError.Visible = True
                bandera = False
                txtResultadoMayor.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        'verifica espacio de resultado de cumplimiento menor
        If Not txtResultadoMenor.Disabled Then
            If txtResultadoMenor.Value = "" Then
                txtError.InnerText &= " ● Digite el resultado de cumplimiento menor"
                txtError.Visible = True
                bandera = False
                txtResultadoMenor.Attributes("Style") = "border: 1px solid red;"
            ElseIf Not Regex.IsMatch(txtResultadoMenor.Value, "^[a-zA-Z0-9]+$") Then
                txtError.InnerText &= " ● El cumplimiento menor contiene símbolos no permitidos, digite sólo letras o números"
                txtError.Visible = True
                bandera = False
                txtResultadoMenor.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        ' valida espacio de inspección técnica realizada por 
        If Not txtRealizadoPor.Disabled Then
            If txtRealizadoPor.Value = "" Then
                txtError.InnerText &= " ● Digite el Número de Solicitud de Oficio"
                txtError.Visible = True
                bandera = False
                txtRealizadoPor.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        ' Valida la fecha de inspección
        If dtFechaInspeccion.Enabled Then
            If dtFechaInspeccion.SelectedDate Is Nothing Then
                txtError.InnerText &= " ● Seleccione la fecha de Inspección Técnica"
                txtError.Visible = True
                bandera = False
                dtFechaInspeccion.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        ' Valida la fecha de solicitud
        If dtFechaSolicitud.Enabled Then
            If dtFechaSolicitud.SelectedDate Is Nothing Then
                txtError.InnerText &= " ● Seleccione la fecha de solicitud de Oficio"
                txtError.Visible = True
                bandera = False
                dtFechaSolicitud.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        ' Valida la fecha de oficio
        If dtFechaInforme.Enabled Then
            If dtFechaInforme.SelectedDate Is Nothing Then
                txtError.InnerText &= " ● Seleccione la fecha de Oficio"
                txtError.Visible = True
                bandera = False
                dtFechaInforme.Attributes("Style") = "border: 1px solid red;"
            End If
        End If

        Return bandera
    End Function

    ' valida las entradas del Proceso de resolución
    Function validarProcesoResolucion() As Boolean
        Dim bandera = True
        txtError.InnerText = ""
        txtError.Visible = False
        txtNumResolucion.Attributes("Style") = ""
        dtFechaResolucion.Attributes("Style") = ""
        cbCondicion.Attributes("Style") = ""

        'verifica espacio de número de resolución
        If Not txtNumResolucion.Disabled Then
            If txtNumResolucion.Value = "" Then
                txtError.InnerText &= " ● Digite el Número de Resolución"
                txtError.Visible = True
                bandera = False
                txtNumResolucion.Attributes("Style") = "border: 1px solid red;"
            ElseIf Not Regex.IsMatch(txtNumResolucion.Value, "^[a-zA-Z0-9]+$") Then
                txtError.InnerText &= " ● El Número de Resolución contiene símbolos no permitidos, digite sólo letras o números"
                txtError.Visible = True
                bandera = False
                txtNumResolucion.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        ' Valida la fecha de resolución
        If dtFechaResolucion.Enabled Then
            If dtFechaResolucion.SelectedDate Is Nothing Then
                txtError.InnerText &= " ● Seleccione la fecha de Resolución"
                txtError.Visible = True
                bandera = False
                dtFechaResolucion.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        ' Valida la selección de una condición
        If cbCondicion.SelectedItem Is Nothing Then
            txtError.InnerText &= " ● Seleccione una condición"
            txtError.Visible = True
            bandera = False
            cbCondicion.Attributes("Style") = "border: 1px solid red;"
        End If

        Return bandera
    End Function

    Protected Sub btnGuardarInspeccion_ServerClick(sender As Object, e As EventArgs)
        'guarda los datos de la Inspección técnica
        If validarInspeccion() Then
            VistaInscripcionSANegocio.Instancia.guardarInspeccion(Session("codigoInscrip"), txtRealizadoPor.Value, dtFechaInspeccion.SelectedDate,
                                                             txtNumSolicitud.Value, dtFechaSolicitud.SelectedDate, txtNumInforme.Value,
                                                             dtFechaInforme.SelectedDate, txtResultadoMayor.Value, txtResultadoMenor.Value)
            deshabilitarEntradas()
            btnEditar.Visible = True
            btnEditar.Disabled = False
            btnInicio.Visible = False

        End If
    End Sub

    Protected Sub btnFinalizar_ServerClick(sender As Object, e As EventArgs)
        ' actualiza los datos de la resolución de un suplidor
        If validarProcesoResolucion() Then

            VistaInscripcionSANegocio.Instancia.actualizarInscripSA(Session("codigoInscrip"), txtNumResolucion.Value, dtFechaResolucion.SelectedDate, cbCondicion.SelectedValue, txtObservaciones.Value)
            Response.Redirect("/Usuario Interno/UI_Pendientes_SA.aspx", False)
        End If
    End Sub

    Protected Sub btnEditar_ServerClick(sender As Object, e As EventArgs)
        btnGuardarInspeccion.Visible = False
        btnGuardarCambios.Visible = True
        btnGuardarCambios.Disabled = False

        txtNumSolicitud.Disabled = False
        txtNumInforme.Disabled = False
        txtResultadoMayor.Disabled = False
        txtResultadoMenor.Disabled = False
        txtRealizadoPor.Disabled = False
        dtFechaInspeccion.Enabled = True
        dtFechaSolicitud.Enabled = True
        dtFechaInforme.Enabled = True
    End Sub

    Sub deshabilitarEntradas()
        txtNumSolicitud.Disabled = True
        txtNumInforme.Disabled = True
        txtResultadoMayor.Disabled = True
        txtResultadoMenor.Disabled = True
        txtRealizadoPor.Disabled = True
        dtFechaInspeccion.Enabled = False
        dtFechaSolicitud.Enabled = False
        dtFechaInforme.Enabled = False

    End Sub

    Protected Sub btnGuardarCambios_ServerClick(sender As Object, e As EventArgs)
        VistaInscripcionSANegocio.Instancia.actualizarInspeccion(Session("codigoInscrip"), txtRealizadoPor.Value, dtFechaInspeccion.SelectedDate,
                                                             txtNumSolicitud.Value, dtFechaSolicitud.SelectedDate, txtNumInforme.Value,
                                                             dtFechaInforme.SelectedDate, txtResultadoMayor.Value, txtResultadoMenor.Value)

        btnGuardarCambios.Visible = False
        deshabilitarEntradas()
        btnEditar.Visible = True
        btnEditar.Disabled = False
    End Sub

    ' carga la información de la inspección técnica de un suplidor
    Sub cargarInspeccion()
        Dim modelo = VistaInscripcionSANegocio.Instancia.cargarInspeccion(Session("codigoInscrip").ToString())

        If modelo.fechaInspeccion <> "" Then
            txtRealizadoPor.Value = modelo.realizadaPor
            dtFechaInspeccion.SelectedDate = modelo.fechaInspeccion
            txtNumSolicitud.Value = modelo.numSolicitud
            dtFechaSolicitud.SelectedDate = modelo.fechaSolicitud
            txtNumInforme.Value = modelo.numOficio
            dtFechaInforme.SelectedDate = modelo.fechaOficio
            txtResultadoMayor.Value = modelo.cumplimientoMayor
            txtResultadoMenor.Value = modelo.cumplimientoMenor

            deshabilitarEntradas()
        End If
        If Session("archivoSA") IsNot Nothing Then
            btnEditar.Visible = False
            btnGuardarInspeccion.Visible = False
            btnFinalizar.Visible = False
            btnInicio.Visible = True
        End If
    End Sub

    Sub cargarResolucion()
        Dim modelo = VistaInscripcionSANegocio.Instancia.cargarResolucion(Session("codigoInscrip").ToString())

        If modelo.fecha_devolucion <> "" Then
            txtNumResolucion.Value = modelo.numResolucion
            dtFechaResolucion.SelectedDate = modelo.fecha_devolucion
            cbCondicion.SelectedValue = modelo.estado_form
            txtObservaciones.Value = modelo.observaciones

            txtNumResolucion.Disabled = True
            cbCondicion.Enabled = False
            txtObservaciones.Disabled = True
            dtFechaResolucion.Enabled = False
        End If
    End Sub

    Protected Sub btnInicio_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/UI_Archivo_SA.aspx", False)
    End Sub


    'Sub inscripRechazada()
    '    VistaInscripcionSANegocio.Instancia.borrarInfoSA(Session("codigoInscrip"))
    '    VistaInscripcionSANegocio.Instancia.borrarRLSA(Session("codigoInscrip"))
    '    VistaInscripcionSANegocio.Instancia.borrarInfoContaSA(Session("codigoInscrip"))
    '    VistaInscripcionSANegocio.Instancia.borrarCertSA(Session("codigoInscrip"))
    'End Sub
End Class