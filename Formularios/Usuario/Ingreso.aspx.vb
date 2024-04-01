Imports BackEnd

Public Class Ingreso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Verifica si la página se carga por primera vez
        If Not IsPostBack Then
            ' Oculta los elementos de error y pregunta de seguridad
            txtError.Visible = False
            rowPregunta.Visible = False
            btnIngresar.Visible = False
            idTerminos.Visible = False

            ' Comprueba si se ha enviado el parámetro "Registro" en la URL y muestra un mensaje si es así
            If Request.Params.Get("Registro") = "True" Then
                txtError.InnerText = " ● Su cuenta ha sido creada exitosamente, revise su correo de confirmación antes de iniciar sesión"
                txtError.Visible = True
            End If

            ' Comprueba si se ha enviado el parámetro "Registro" en la URL y muestra un mensaje si es así
            If Request.Params.Get("Password") = "True" Then
                txtError.InnerText = " ● ¡Su contraseña ha sido modificada exitosamente!"
                txtError.Visible = True
            End If
        End If
    End Sub

    Protected Sub btnValidarSesion_ServerClick(sender As Object, e As EventArgs)
        ' Limpia el mensaje de error y oculta el campo de error
        txtError.InnerText = ""
        txtError.Visible = False
        txtCedula.Style("border-color") = "empty"
        txtPass.Style("border-color") = "empty"


        ' Realiza la validación del ingreso
        validarIngreso()
    End Sub

    Sub cargarPreguntas()

        ' Obtiene una lista de preguntas de seguridad
        Dim preguntas = UsuarioNegocio.Instancia.buscarPreguntas()

        ' Genera un número aleatorio para seleccionar una pregunta
        Dim numeroAleatorio = New Random().Next(0, preguntas.Count)

        ' Muestra la pregunta seleccionada en la página
        lblPregunta.InnerText = preguntas(numeroAleatorio).detalle
        lblValorPregunta.InnerText = preguntas(numeroAleatorio).codigo

    End Sub

    Function verificarRespuestaPregunta(ByVal cedula As String,  ByVal codigo As String, ByVal respuesta As String) As Boolean
        ' Verifica si la respuesta a la pregunta de seguridad es correcta
        Return UsuarioNegocio.Instancia.verificarRespuestaPregunta(cedula, codigo, respuesta)
    End Function

    Protected Sub validarIngreso()
        ' Comprueba que se hayan ingresado la cédula y la contraseña
        If txtCedula.Value <> "" And txtPass.Value <> "" Then
            ' Verifica si la cédula es un número válido
            If Regex.IsMatch(txtCedula.Value.Trim, "^[0-9]+$") Then
                ' Verifica si la cédula y la contraseña son válidas
                If UsuarioNegocio.Instancia.validarCedulaUsuario(txtCedula.Value.Trim) Then
                    Dim modelo As New Usuario
                    modelo.cedula = txtCedula.Value.Trim
                    modelo.pass = txtPass.Value.Trim

                    ' Verifica si la contraseña es válida
                    If UsuarioNegocio.Instancia.validarPassword(modelo) Then
                        ' Desactiva los campos de cédula y contraseña
                        txtCedula.Disabled = True
                        txtPass.Disabled = True
                        btnValidar.Visible = False
                        txtError.Visible = True
                        rowPregunta.Visible = True
                        btnIngresar.Visible = True
                        txtError.InnerText = ""
                        txtError.Visible = False
                        divAgente.Visible = False
                        divContra.Visible = False
                        ' Carga una pregunta de seguridad
                        idTerminos.Visible = True
                        cargarPreguntas()
                    Else
                        txtError.InnerText = " ● Cédula o contraseña incorrectos"
                        txtError.Visible = True
                        txtCedula.Value = ""
                        txtPass.Value = ""
                        txtCedula.Style("border-color") = "red"
                        txtPass.Style("border-color") = "red"
                    End If
                Else
                    txtError.InnerText = " ● Cédula o contraseña incorrectos"
                    txtError.Visible = True
                    txtCedula.Value = ""
                    txtPass.Value = ""
                    txtCedula.Style("border-color") = "red"
                    txtPass.Style("border-color") = "red"
                End If
            Else
                txtError.InnerText &= " ● Digite un número de cédula válido (dígitos numéricos, sin guiones)"
                txtError.Visible = True
                txtCedula.Style("border-color") = "red"
            End If
        Else
            txtError.InnerText = " ● Existen campos vacíos"
            txtError.Visible = True
            txtCedula.Style("border-color") = "red"
            txtPass.Style("border-color") = "red"
        End If
    End Sub

    Protected Sub btnIngresarSesion_ServerClick(sender As Object, e As EventArgs)
        If txtRespuesta.Value <> "" Then
            ' Verifica si la respuesta a la pregunta de seguridad es correcta
            If verificarRespuestaPregunta(txtCedula.Value, lblValorPregunta.InnerText, txtRespuesta.Value) Then
                ' Almacena la cédula del usuario en la sesión
                Session("Cedula") = txtCedula.Value
                If chkAceptarTerminos.Checked Then
                    ' Redirige a otra página
                    Response.Redirect("Selector_Formulario.aspx", False)
                Else
                    txtError.InnerText = " ● Por favor, acepte los términos y condiciones"
                    txtError.Visible = True
                End If
            Else
                txtRespuesta.Style("border-color") = "red"
                txtError.InnerText = " ● Respuesta incorrecta, inténtelo de nuevo "
                txtError.Visible = True
            End If
        Else
            txtError.InnerText = " ● Por favor, conteste la pregunta de seguridad que se le solicita"
            txtError.Visible = True
        End If
    End Sub

    Protected Sub btnCrearCuenta_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("Registro.aspx", False)
    End Sub
End Class
