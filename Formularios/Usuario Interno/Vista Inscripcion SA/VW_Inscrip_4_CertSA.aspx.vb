Imports BackEnd
Imports Telerik.Web.UI

Public Class VW_Inscrip_4_CertSA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            cargarCertificados()
            buscarCuentaIBAN()
            habilitarBotones()
            txtError.InnerText = ""
            txtError.Visible = False
        End If
    End Sub

    ' Subrutina para cargar los certificados existentes desde el backend y mostrarlos en un control GridView.
    Protected Sub cargarCertificados()
        divRechazar.Visible = False
        'muestra los datos en la tabla
        rgCertificacion.DataSource = CertificacionesNegocio.Instancia.buscarCertificacionInscripcion(Session("codigoInscrip"))
        rgCertificacion.DataBind()
    End Sub

    ' Subrutina para cargar la cuenta IBAN del usuario
    Protected Sub buscarCuentaIBAN()
        'muestra los datos en la tabla
        Dim modelo = VistaInscripcionSANegocio.Instancia.buscarCuentaIBAN(Session("codigoInscrip"))
        txtCuentaIBAN.Value = modelo.cuentaIBAN
        txtBanco.Value = modelo.codigoBanco

    End Sub

    ' se ejecuta cuando se pulsa el botón de descargar el certificado
    Protected Sub descargarCert_Click(sender As Object, e As EventArgs)
        Try
            Dim lnk As LinkButton = DirectCast(sender, LinkButton)
            Dim data As GridDataItem = DirectCast(lnk.NamingContainer, GridDataItem)
            Dim codigo As String = data.GetDataKeyValue("codigo").ToString()
            ' Buscar la ruta de un certificado seleccionado del backend.
            Dim ruta = VistaInscripcionSANegocio.Instancia.buscarRutaArchivo(Session("codigoInscrip"))

            ' descarga el archivo pdf
            Dim rutaArchivo = ruta.archivo
            DescargarArchivo(rutaArchivo)

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub DescargarArchivo(rutaArchivo As String)
        ' Prepara la respuesta HTTP para la descarga del archivo
        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("Content-Disposition", $"attachment; filename={System.IO.Path.GetFileName(rutaArchivo)}")
        Response.WriteFile(rutaArchivo)
        Response.End()
    End Sub

    Protected Sub btnAtras_ServerClick1(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inscrip_3_InfoContaSA.aspx", False)
    End Sub

    ' Revisa en que área de verificación se encuentra la inscripción, y habilita los botones dependiendo de eso
    Protected Sub habilitarBotones()
        If Session("AreaVerificacionSA") = 1 Then
            btnSubsanar.Visible = True ' Botón de subsanar
            btnEnviar.Visible = True ' Botón de enviar (pasa a otra área de verificación)
            btnSiguiente.Visible = False ' Botón para continuar a página de Proceso de Resolución (Sólo para área 4)
        Else
            btnSubsanar.Visible = False
            btnEnviar.Visible = True
            btnSiguiente.Visible = False
        End If

        If Session("AreaVerificacionSA") = 4 Then
            btnSiguiente.Visible = True
            btnEnviar.Visible = False
            btnSubsanar.Visible = False
        End If
    End Sub

    Function validarEntrada() As Boolean
        Dim bandera = True
        txtError.InnerText = ""
        txtError.Visible = False
        txtNoResolucion.Attributes("Style") = ""

        If Not txtNoResolucion.Disabled Then
            If txtNoResolucion.Value = "" Then
                txtError.InnerText &= " ● Digite el Número de Resolución"
                txtError.Visible = True
                bandera = False
                txtNoResolucion.Attributes("Style") = "border: 1px solid red;"
            ElseIf Not Regex.IsMatch(txtNoResolucion.Value, "^[a-zA-Z0-9]+$") Then
                txtError.InnerText &= " ● El Número de Resolución contiene símbolos no permitidos, digite sólo letras o números"
                txtError.Visible = True
                bandera = False
                txtNoResolucion.Attributes("Style") = "border: 1px solid red;"
            End If
        End If
        Return bandera
    End Function

    ' Se ejecuta cuando el AEO subsana una inscripción
    Protected Sub btnCompletarSubs_ServerClick(sender As Object, e As EventArgs)
        If validarEntrada() Then
            VistaInscripcionSANegocio.Instancia.subsanarSoliPP(Session("codigoInscrip"))
            VistaInscripcionSANegocio.Instancia.actualizarSuplidorSubs(Session("codigoInscrip"), txtNoResolucion.Value, txtObservaciones.Value)
            Response.Redirect("/Usuario Interno/UI_Pendientes_SA.aspx", False)
        End If
    End Sub

    Protected Sub btnSubsanar_ServerClick(sender As Object, e As EventArgs)
        divBotones.Visible = False
        divRechazar.Visible = True
    End Sub

    Protected Sub btnCancelar_ServerClick(sender As Object, e As EventArgs)
        divBotones.Visible = True
        divRechazar.Visible = False
    End Sub

    ' Se va a ejecuta cuando no sea el último paso de la revisión, envía el formulario al siguiente área de revisión
    Protected Sub btnEnviar_ServerClick(sender As Object, e As EventArgs)
        Dim areaRevision = Session("AreaVerificacionSA")
        Dim enviar = False

        ' verifico en que area de revision se encuentra el formulario
        If areaRevision = 1 Then
            areaRevision += 1
            enviar = True
        ElseIf areaRevision = 2 Then
            areaRevision += 1
            enviar = True
        ElseIf areaRevision = 3 Then
            areaRevision += 1
            enviar = True
        End If

        If enviar = True Then
            VistaInscripcionSANegocio.Instancia.enviarSolicitud(areaRevision, Session("codigoInscrip"))
        End If
        Response.Redirect("/Usuario Interno/UI_Pendientes_SA.aspx", False)
    End Sub

    Protected Sub btnSiguiente_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inspeccion_Tecnica.aspx", False)
    End Sub
End Class