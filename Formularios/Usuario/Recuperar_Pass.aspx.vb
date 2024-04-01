Imports BackEnd
Imports Telerik.Web.UI

Public Class Recuperar_Pass
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Verifica si la página se carga por primera vez
        If Not IsPostBack Then
            ' Oculta los elementos de error y pregunta de seguridad
            txtError.Visible = False
            cargarPreguntas()
            divNuevaPass.Visible = False

        End If
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("Ingreso.aspx", False)
    End Sub

    Sub cargarPreguntas()
        ' Obtiene la lista de preguntas de seguridad desde la capa de negocio
        Dim preguntas = UsuarioNegocio.Instancia.buscarPreguntas()

        ' Asigna el texto de las preguntas a las etiquetas correspondientes en la página
        lblPregunta1.InnerText = preguntas(0).detalle
        lblPregunta2.InnerText = preguntas(1).detalle
        lblPregunta3.InnerText = preguntas(2).detalle
        lblPregunta4.InnerText = preguntas(3).detalle
        lblPregunta5.InnerText = preguntas(4).detalle

        lblValorPregunta1.InnerText = preguntas(0).codigo
        lblValorPregunta2.InnerText = preguntas(1).codigo
        lblValorPregunta3.InnerText = preguntas(2).codigo
        lblValorPregunta4.InnerText = preguntas(3).codigo
        lblValorPregunta5.InnerText = preguntas(4).codigo
    End Sub

    Protected Sub btnVerificar_ServerClick(sender As Object, e As EventArgs)
        Dim correctas As Boolean = True

        If txtCedula.Value = "" Or txtPregunta1.Value = "" Or txtPregunta2.Value = "" Or txtPregunta3.Value = "" Or txtPregunta4.Value = "" Or txtPregunta5.Value = "" Then
            txtError.Visible = True
            txtError.InnerText = " ● Existen preguntas vacías o incorrectas"
            correctas = False
        End If

        If txtPregunta1.Value <> "" Then
            ' Verifica si la respuesta a la pregunta de seguridad es correcta
            If verificarRespuestaPregunta(txtCedula.Value, lblValorPregunta1.InnerText, txtPregunta1.Value) Then
                ' Almacena la cédula del usuario en la sesión
                Session("Cedula") = txtCedula.Value
            Else
                txtError.Visible = True
                txtError.InnerText = " ● Existen preguntas vacías o incorrectas"
                correctas = False
            End If
        End If

        If txtPregunta2.Value <> "" Then
            ' Verifica si la respuesta a la pregunta de seguridad es correcta
            If verificarRespuestaPregunta(txtCedula.Value, lblValorPregunta2.InnerText, txtPregunta2.Value) Then
                ' Almacena la cédula del usuario en la sesión
                Session("Cedula") = txtCedula.Value
            Else
                txtError.Visible = True
                txtError.InnerText = " ● Existen preguntas vacías o incorrectas"
                correctas = False
            End If
        End If

        If txtPregunta3.Value <> "" Then
            If verificarRespuestaPregunta(txtCedula.Value, lblValorPregunta3.InnerText, txtPregunta3.Value) Then
                ' Almacena la cédula del usuario en la sesión
                Session("Cedula") = txtCedula.Value
            Else
                txtError.Visible = True
                txtError.InnerText = " ● Existen datos vacíos o incorrectos"
                correctas = False
            End If
        End If
        If txtPregunta4.Value <> "" Then
            If verificarRespuestaPregunta(txtCedula.Value, lblValorPregunta4.InnerText, txtPregunta4.Value) Then
                ' Almacena la cédula del usuario en la sesión
                Session("Cedula") = txtCedula.Value
            Else
                txtError.Visible = True
                txtError.InnerText = " ● Existen datos vacíos o incorrectos"
                correctas = False
            End If
        End If
        If txtPregunta5.Value <> "" Then
            If verificarRespuestaPregunta(txtCedula.Value, lblValorPregunta5.InnerText, txtPregunta5.Value) Then
                ' Almacena la cédula del usuario en la sesión
                Session("Cedula") = txtCedula.Value
            Else
                txtError.Visible = True
                txtError.InnerText = " ● Existen datos vacíos o incorrectos"
                correctas = False
            End If
        End If

        If correctas = True Then
            divNuevaPass.Visible = True
            txtError.Visible = False
        End If
    End Sub

    Function verificarRespuestaPregunta(ByVal cedula As String, ByVal codigo As String, ByVal respuesta As String) As Boolean
        ' Verifica si las respuestas a la preguntas de seguridad son correctas
        Return UsuarioNegocio.Instancia.verificarRespuestaPregunta(cedula, codigo, respuesta)
    End Function

    Protected Sub btnConfirmar_ServerClick(sender As Object, e As EventArgs)
        Dim valido As Boolean = True
        txtError.InnerText = ""
        txtError.Visible = False

        Dim password As String = txtNuevaPass.Value
        Dim confirmPassword As String = txtRepitePass.Value
        Dim chars As New Regex("^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-])")

        ' verifica si las contraseñas ingresadas cumplen con los parámetros necesarios
        If password = "" OrElse confirmPassword = "" Then
            txtError.InnerText &= " ● Campos de contraseña vacíos"
            txtError.Visible = True
            valido = False
            txtNuevaPass.Style("border-color") = "red"
            txtRepitePass.Style("border-color") = "red"
        ElseIf password <> confirmPassword Then
            txtError.InnerText &= " ● Las contraseñas no coinciden"
            txtError.Visible = True
            valido = False
            txtNuevaPass.Style("border-color") = "red"
            txtRepitePass.Style("border-color") = "red"
        ElseIf Not chars.IsMatch(password) Then
            txtError.InnerText &= " ● La contraseña ingresada no cumple con el formato válido."
            txtError.Visible = True
            valido = False
            txtNuevaPass.Style("border-color") = "red"
            txtRepitePass.Style("border-color") = "red"
        End If

        If valido = True Then
            UsuarioNegocio.Instancia.modificarPassword(Session("Cedula"), confirmPassword)
            ' Redirecciona a la página de inicio de sesión con un parámetro de cambio de contraseña exitoso
            Response.Redirect("Ingreso.aspx?Password=" & True, False)
        End If

    End Sub
End Class
