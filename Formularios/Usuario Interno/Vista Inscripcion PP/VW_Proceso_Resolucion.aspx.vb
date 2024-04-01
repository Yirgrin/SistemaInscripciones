Imports BackEnd
Public Class VW_Proceso_Resolucion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            btnInicio.Visible = False
            txtError.InnerText = ""
            txtError.Visible = False
            cargarResolucion()
        End If
    End Sub

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

    ' Último paso del proceso de revisión. Actualiza los datos como el Num.Resolución y el estado final de la inscripción
    Protected Sub btnFinalizar_ServerClick(sender As Object, e As EventArgs)
        ' actualiza los datos de la resolución de un suplidor
        If validarProcesoResolucion() Then
            VistaInscripcionPPNegocio.Instancia.actualizarInscripPP(Session("codigoInscrip"), txtNumResolucion.Value, dtFechaResolucion.SelectedDate, cbCondicion.SelectedValue, txtObservaciones.Value)
            Response.Redirect("/Usuario Interno/UI_Pendientes_SA.aspx", False)

        End If
    End Sub

    'Sub inscripRechazada()
    '    VistaInscripcionPPNegocio.Instancia.borrarInfoPP(Session("codigoInscrip"))
    '    VistaInscripcionPPNegocio.Instancia.borrarRLPP(Session("codigoInscrip"))
    '    VistaInscripcionPPNegocio.Instancia.borrarLineaAbPP(Session("codigoInscrip"))
    '    VistaInscripcionPPNegocio.Instancia.borrarCertPP(Session("codigoInscrip"))
    'End Sub
    Sub cargarResolucion()
        Dim modelo = VistaInscripcionPPNegocio.Instancia.cargarResolucion(Session("codigoInscrip").ToString())

        If modelo.fecha_devolucion <> "" Then
            txtNumResolucion.Value = modelo.numResolucion
            dtFechaResolucion.SelectedDate = modelo.fecha_devolucion
            cbCondicion.SelectedValue = modelo.estado_form
            txtObservaciones.Value = modelo.observaciones

            If Session("archivoPP") IsNot Nothing Then
                btnInicio.Visible = True
                btnFinalizar.Visible = False
            End If

            txtNumResolucion.Disabled = True
            cbCondicion.Enabled = False
            txtObservaciones.Disabled = True
            dtFechaResolucion.Enabled = False
        End If
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion PP/VW_Inscrip_4_CertPP.aspx", False)
    End Sub

    Protected Sub btnInicio_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/UI_Archivo_PP.aspx", False)
    End Sub
End Class