Imports System.IO
Imports BackEnd
Imports Telerik.Web.UI

Public Class PP_Form_4_Cert
    Inherits System.Web.UI.Page

    Protected Sub Page_cargar(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            pesoDelArchivo()
            If Session("Inscripcion") Is Nothing Then
                ' Redirigir a la página de error si la sesión no está configurada.
                Response.Redirect("/Productor Primario/Error.aspx", False)
            Else
                txtError.InnerText = ""
                txtError.Visible = False
                ' Cargar el tipo de certificado y los certificados existentes al cargar la página por primera vez.
                cargarTipoCertificado()
                cargarCertificados()
                buscarCamposDocumento()
            End If
        End If
    End Sub

    'Subrutina que configura la visualización del los campos necesarios para cada documento
    Sub buscarCamposDocumento()
        'desde la base de datos, trae un valor 1 o 0, los campos con 1 van a habilitar los campos de texto
        Dim campos = CertificadoNegocio.Instancia.buscarCamposDocumento(cbTipoCertificacion.SelectedValue)
        If Not campos.campoNumero Then
            txtNumeroCert.Disabled = True
        Else
            txtNumeroCert.Disabled = False
        End If
        If Not campos.campoFechaEmision Then
            dtFechaEmision.Enabled = False
        Else
            dtFechaEmision.Enabled = True
        End If
        If Not campos.campoFechaVencimiento Then
            dtFechaVence.Enabled = False
        Else
            dtFechaVence.Enabled = True
        End If
    End Sub

    'Subrutina que define el peso maximo del archivo en base a lo insertado en web.config
    Sub pesoDelArchivo()
        Dim pesoMaxStr As String = ConfigurationManager.AppSettings("MaxFileSizeInMB")
        lblPesoArchivo.Text = pesoMaxStr
        ' Intenta convertir el valor a bytes y asignarlo a la propiedad
        Try
            AsyncUploadCertificado.MaxFileSize = Integer.Parse(pesoMaxStr) * 1024 * 1024
        Catch ex As FormatException
            AsyncUploadCertificado.MaxFileSize = 3 * 1024 * 1024
        End Try
    End Sub

    ' Evento que se dispara al hacer clic en el botón "Atrás".
    Protected Sub btnAtras_Click(sender As Object, e As EventArgs)
        ' Redirigir a la página anterior del proceso.
        Response.Redirect("/Productor Primario/PP_Form_3_LineaAb.aspx", False)
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

    ' Función para validar las entradas del formulario.
    Function validarEntrada() As Boolean

        Dim bandera = True
        txtError.InnerText = ""
        txtError.Visible = False

        txtNumeroCert.Attributes("Style") = ""
        dtFechaEmision.Attributes("Style") = ""
        dtFechaVence.Attributes("Style") = ""
        AsyncUploadCertificado.Attributes("Style") = ""

        ' Valida si se ha subido algún archivo.
        If AsyncUploadCertificado.UploadedFiles.Count = 0 Then
            txtError.InnerText &= " ● No se ha subido ningún archivo adjunto o este no cumple con la extensión o tamaño establecidos"
            AsyncUploadCertificado.Attributes("Style") = "border: 1px solid red;"
            txtError.Visible = True
            bandera = False
        End If

        ' Valida el número de certificado.
        If Not txtNumeroCert.Disabled Then
            If txtNumeroCert.Value = "" Then
                txtError.InnerText &= " ● Digite el número de certificado"
                txtError.Visible = True
                bandera = False
                txtNumeroCert.Attributes("Style") = "border: 1px solid red;"
            ElseIf Not Regex.IsMatch(txtNumeroCert.Value, "^[a-zA-Z0-9]+$") Then
                txtError.InnerText &= " ● El número de certificado contiene símbolos no permitidos, digite sólo letras o números"
                txtError.Visible = True
                bandera = False
                txtNumeroCert.Attributes("Style") = "border: 1px solid red;"
            End If
        End If

        ' Valida la fecha de emisión.
        If dtFechaEmision.Enabled Then
            If dtFechaEmision.SelectedDate Is Nothing Then
                txtError.InnerText &= " ● Seleccione la fecha de emisión del certificado"
                txtError.Visible = True
                bandera = False
                dtFechaEmision.Attributes("Style") = "border: 1px solid red;"
            ElseIf dtFechaEmision.SelectedDate > DateTime.Now Then
                'si la fecha de emisión es mayor que la actual, muestra un error.
                txtError.InnerText = " ● La fecha de emisión del documento no puede ser mayor a la fecha actual"
                txtError.Visible = True
                dtFechaEmision.Attributes("Style") = "border: 1px solid red;"
            End If
        End If


        ' Valida la fecha de vencimiento.
        If dtFechaVence.Enabled Then
            If dtFechaVence.SelectedDate Is Nothing Then
                txtError.InnerText &= " ● Seleccione la fecha de vencimiento del certificado"
                txtError.Visible = True
                bandera = False
                dtFechaVence.Attributes("Style") = "border: 1px solid red;"
            Else
                ' Compara la fecha de vencimiento con la fecha actual.
                Dim fechaVencimiento As DateTime = dtFechaVence.SelectedDate.Value
                Dim fechaActual As DateTime = DateTime.Now
                If fechaVencimiento < fechaActual Then
                    ' Considera que el documento está vencido.
                    txtError.InnerText &= " ● El documento está vencido."
                    txtError.Visible = True
                    bandera = False
                    dtFechaVence.Attributes("Style") = "border: 1px solid red;"
                End If
            End If
        End If

        Return bandera

    End Function

    ' Subrutina para cargar los certificados existentes desde el backend y mostrarlos en un control GridView.
    Protected Sub cargarCertificados()
        'muestra los datos en la tabla
        rgCertificacion.DataSource = CertificadoNegocio.Instancia.buscarCertificacionInscripcion(Session("Inscripcion"))
        rgCertificacion.DataBind()
    End Sub

    ' Subrutina para limpiar los datos del formulario de certificación.
    Sub limpiarDatosCertif()
        cbTipoCertificacion.ClearSelection()
        cbTipoCertificacion.SelectedValue = Nothing
        txtNumeroCert.Value = ""
        dtFechaEmision.Clear()
        dtFechaVence.Clear()
        AsyncUploadCertificado.UploadedFiles.Clear()
    End Sub

    ' Evento que se dispara al hacer clic en el enlace "Eliminar Certificado" en la lista de certificados.
    Protected Sub eliminarCertificado_Click(sender As Object, e As EventArgs)
        Try
            Dim codigoCertificado = DirectCast(DirectCast(DirectCast(sender, LinkButton).NamingContainer, GridDataItem).GetDataKeyValue("codigo"), String)
            ' Eliminar un certificado seleccionado del backend.
            CertificadoNegocio.Instancia.eliminarCertificadoInscripcion(codigoCertificado)
            ' Recargar la lista de certificados.
            cargarCertificados()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    ' Evento que se dispara al hacer clic en el botón "Agregar Certificado".
    Protected Sub btnAgregarCert_Click(sender As Object, e As EventArgs)

        If validarEntrada() Then
            ' Ruta donde se guardarán los archivos adjuntos (configurada en el archivo de configuración).
            Dim ruta = System.Configuration.ConfigurationManager.AppSettings("RutaDocumentosAdjuntos")
            Dim fileName As String = ""
            Dim fileExt As String = ""

            If Directory.Exists(ruta) Then
                For Each files As UploadedFile In AsyncUploadCertificado.UploadedFiles
                    fileName = files.GetName()
                    fileExt = files.GetExtension
                    'se crea un nombre único para cada documento
                    Dim nuevoNombre = DateTime.Now.ToString("yyyyMMdd_HHmmss") & "_" & Session("Inscripcion") & "_" & cbTipoCertificacion.SelectedValue.ToString ' Función para generar un nombre único
                    fileName = Path.Combine(ruta, nuevoNombre + fileExt)
                    files.SaveAs(fileName)
                Next
            End If

            ' Insertar el certificado en el backend.
            Dim inscripcion As String
            Dim tipoCertificacion As String
            Dim numeroCert As String
            Dim nombreArchivo As String
            Dim extencionArchivo As String
            Dim fechaEmision As String
            Dim fechaVence As String

            inscripcion = Session("Inscripcion")
            tipoCertificacion = cbTipoCertificacion.SelectedValue
            numeroCert = txtNumeroCert.Value
            nombreArchivo = fileName
            extencionArchivo = fileExt

            If dtFechaEmision.SelectedDate Is Nothing Then
                fechaEmision = ""
            Else
                fechaEmision = dtFechaEmision.SelectedDate
            End If

            If dtFechaVence.SelectedDate Is Nothing Then
                fechaVence = ""
            Else
                fechaVence = dtFechaVence.SelectedDate
            End If

            CertificadoNegocio.Instancia.insertarCertificado(
                    inscripcion,
                    tipoCertificacion,
                    numeroCert,
                    nombreArchivo,
                    extencionArchivo,
                    fechaEmision,
                    fechaVence, 1)

                ' Recargar la lista de certificados.
                cargarCertificados()
                ' Limpiar los datos del formulario de certificación.
                limpiarDatosCertif()
            End If
    End Sub

    ' Subrutina para mostrar un mensaje en el elemento HTML.
    Sub mostrarMensaje(ByRef mensaje As String)
        txtError.InnerText = mensaje
        txtError.Visible = True
    End Sub

    ' Evento que se dispara al hacer clic en el botón "Siguiente".
    Protected Sub btnSiguiente_Click(sender As Object, e As EventArgs)
        ' Verifica si el RadGrid tiene al menos una fila de datos
        If rgCertificacion.MasterTableView.Items.Count > 0 Then
            ' Puedes redirigir a la siguiente pantalla aquí
            Response.Redirect("/Productor Primario/PP_Form_5_Aviso.aspx")
        Else
            ' Si no hay datos en el RadGrid, muestra un mensaje de error o realiza alguna otra acción
            mostrarMensaje(" ●  Debe ingresar al menos un certificado antes de continuar.")
        End If
    End Sub


    ' Evento que se dispara al hacer seleccionar algo de la lista desplegable de tipos de certificados.
    Protected Sub cbTipoCertificado_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cbTipoCertificacion.SelectedIndexChanged
        buscarCamposDocumento()
    End Sub
End Class
