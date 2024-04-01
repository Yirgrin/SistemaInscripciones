Imports BackEnd
Imports Telerik.Web.UI

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Oculta el mensaje de error y lo inicializa vacío
        txtError.Visible = False
        txtError.InnerText = ""

        ' Verifica si la página se carga por primera vez
        If Not IsPostBack Then
            ' Carga los tipos de cédula, géneros y preguntas de seguridad
            cargarTipoCedula()
            cargarGenero()
            cargarPreguntas()
        End If
    End Sub

    Protected Sub cargarTipoCedula()
        ' Obtiene la lista de tipos de cédula desde la capa de negocio
        Dim tiposCedula = InformacionGralNegocio.Instancia.buscarTipoCedulaColeccion()

        ' Verifica si hay tipos de cédula disponibles
        If tiposCedula.Count > 0 Then
            ' Configura el control desplegable con los datos obtenidos
            cbTipoCedula.DataSource = tiposCedula
            cbTipoCedula.DataTextField = "detalle"
            cbTipoCedula.DataValueField = "codigo"
            cbTipoCedula.DataBind()
        End If
    End Sub

    Protected Sub cargarGenero()
        ' Crea los elementos de género y los agrega al control desplegable
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

    Sub cargarPreguntas()
        ' Obtiene la lista de preguntas de seguridad desde la capa de negocio
        Dim preguntas = UsuarioNegocio.Instancia.buscarPreguntas()

        ' Asigna el texto de las preguntas a las etiquetas correspondientes en la página
        lblPregunta1.InnerText = preguntas(0).detalle
        lblPregunta2.InnerText = preguntas(1).detalle
        lblPregunta3.InnerText = preguntas(2).detalle
        lblPregunta4.InnerText = preguntas(3).detalle
        lblPregunta5.InnerText = preguntas(4).detalle
    End Sub

    Protected Sub cbTipoCedula_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cbTipoCedula.SelectedIndexChanged
        ' Verifica si se seleccionó un tipo de cédula específico
        If cbTipoCedula.SelectedValue = 2 Then
            ' Deshabilita el control de género y establece su valor en "No Aplica"
            cbGenero.Enabled = False
            cbGenero.SelectedValue = "X"
        Else
            ' Habilita el control de género
            cbGenero.Enabled = True
        End If
    End Sub

    Function validarEntradas() As Boolean
        Dim bandera As Boolean = True
        Dim repetidas As Boolean = True

        txtError.InnerText = ""
        txtError.Visible = False

        ' Validar cédula
        If cbTipoCedula.SelectedValue = 2 Then
            If txtCedula.Value = "" OrElse Not Regex.IsMatch(txtCedula.Value.Trim, "^[0-9]{10}$") Then
                txtError.InnerText &= " ● Digite un número de cédula jurídica válido (10 dígitos numéricos, con ceros y sin guiones)"
                txtError.Visible = True
                bandera = False
                txtCedula.Style("border-color") = "red"
            End If
        ElseIf cbTipoCedula.SelectedValue = 1 Then
            If txtCedula.Value = "" OrElse Not Regex.IsMatch(txtCedula.Value.Trim, "^[0-9]{9}$") Then
                txtError.InnerText &= " ● Digite un número de cédula físico válido (9 dígitos numéricos, con ceros y sin guiones)"
                txtError.Visible = True
                bandera = False
                txtCedula.Style("border-color") = "red"
            End If
        ElseIf cbTipoCedula.SelectedValue = 3 Then
            If txtCedula.Value = "" OrElse Not Regex.IsMatch(txtCedula.Value.Trim, "^[0-9]{12}$") Then
                txtError.InnerText &= " ● Digite un número de Dimex válido (12 dígitos numéricos, con ceros y sin guiones)"
                txtError.Visible = True
                bandera = False
                txtCedula.Style("border-color") = "red"
            End If
        End If

        ' Validar nombre
        If txtNombre.Value = "" Then
            txtError.InnerText &= " ● Digite un nombre"
            txtError.Visible = True
            bandera = False
            txtNombre.Style("border-color") = "red"
        End If

        ' Validar correo
        If txtEmail.Value = "" Then
            txtError.InnerText &= " ● Campo de correo vacío"
            txtError.Visible = True
            bandera = False
            txtEmail.Style("border-color") = "red"
        ElseIf Not Regex.IsMatch(txtEmail.Value.Trim(), "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$") Then
            txtError.InnerText &= " ● Formato de correo inválido"
            txtError.Visible = True
            bandera = False
            txtEmail.Style("border-color") = "red"
        End If

        ' Validar contraseña
        Dim password As String = txtPass1.Value
        Dim confirmPassword As String = txtPass2.Value
        Dim chars As New Regex("^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-])")

        If password = "" OrElse confirmPassword = "" Then
            txtError.InnerText &= " ● Campos de contraseña vacíos"
            txtError.Visible = True
            bandera = False
            txtPass1.Style("border-color") = "red"
            txtPass2.Style("border-color") = "red"
        ElseIf password <> confirmPassword Then
            txtError.InnerText &= " ● Las contraseñas no coinciden"
            txtError.Visible = True
            bandera = False
            txtPass1.Style("border-color") = "red"
            txtPass2.Style("border-color") = "red"
        ElseIf Not chars.IsMatch(password) Then
            txtError.InnerText &= " ● La contraseña ingresada no cumple con el formato válido."
            txtError.Visible = True
            bandera = False
            txtPass1.Style("border-color") = "red"
            txtPass2.Style("border-color") = "red"
        End If

        ' Validar preguntas de seguridad
        If txtPregunta1.Value = "" OrElse txtPregunta2.Value = "" OrElse txtPregunta3.Value = "" OrElse txtPregunta4.Value = "" OrElse txtPregunta5.Value = "" Then
            txtError.InnerText &= " ● Quedan preguntas de seguridad sin responder"
            txtError.Visible = True
            bandera = False

        End If


        If txtPregunta1.Value = txtPregunta2.Value Or txtPregunta1.Value = txtPregunta3.Value Or txtPregunta1.Value = txtPregunta4.Value Or txtPregunta1.Value = txtPregunta5.Value Then
            repetidas = False
            bandera = False
        ElseIf txtPregunta2.Value = txtPregunta1.Value Or txtPregunta2.Value = txtPregunta5.Value Or txtPregunta2.Value = txtPregunta3.Value Or txtPregunta2.Value = txtPregunta4.Value Then
            repetidas = False
            bandera = False
        ElseIf txtPregunta3.Value = txtPregunta1.Value Or txtPregunta3.Value = txtPregunta2.Value Or txtPregunta3.Value = txtPregunta4.Value Or txtPregunta3.Value = txtPregunta5.Value Then
            repetidas = False
            bandera = False
        ElseIf txtPregunta4.Value = txtPregunta1.Value Or txtPregunta4.Value = txtPregunta2.Value Or txtPregunta4.Value = txtPregunta3.Value Or txtPregunta4.Value = txtPregunta5.Value Then
            repetidas = False
            bandera = False
        ElseIf txtPregunta5.Value = txtPregunta1.Value Or txtPregunta5.Value = txtPregunta2.Value Or txtPregunta5.Value = txtPregunta3.Value Or txtPregunta5.Value = txtPregunta4.Value Then
            repetidas = False
            bandera = False
        End If

        If repetidas = False Then
            txtError.InnerText &= " ● No pueden existir respuestas repetidas en las preguntas de seguridad"
            txtError.Visible = True
            bandera = False
        End If

        Return bandera
    End Function

    Function validarCedula() As Boolean
        If UsuarioNegocio.Instancia.validarCedulaUsuario(txtCedula.Value.Trim) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function validarCorreo() As Boolean
        If UsuarioNegocio.Instancia.validarCorreoUsuario(txtEmail.Value.Trim) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function listaRespuestas() As List(Of String)
        Dim lista As New List(Of String)
        lista.Add(txtPregunta1.Value.ToUpper)
        lista.Add(txtPregunta2.Value.ToUpper)
        lista.Add(txtPregunta3.Value.ToUpper)
        lista.Add(txtPregunta4.Value.ToUpper)
        lista.Add(txtPregunta5.Value.ToUpper)
        Return lista
    End Function


    Protected Sub btnRegistrar_ServerClick(sender As Object, e As EventArgs)
        ' Limpia el mensaje de error y oculta el control
        txtError.InnerText = ""
        txtError.Visible = False

        ' Restaura el color de los bordes de los campos
        txtCedula.Style("border-color") = "empty"
        txtNombre.Style("border-color") = "empty"
        txtEmail.Style("border-color") = "empty"
        txtPass1.Style("border-color") = "empty"
        txtPass2.Style("border-color") = "empty"

        ' Realiza la validación de las entradas
        If validarEntradas() Then
            ' Valida si la cédula ya existe en el sistema
            If validarCedula() Then
                txtError.InnerText &= " ● La cédula ingresada ya existe en el sistema"
                txtError.Visible = True
                txtCedula.Style("border-color") = "red"
            ElseIf validarCorreo() Then
                txtError.InnerText &= " ● El correo ingresado ya existe en el sistema"
                txtError.Visible = True
                txtEmail.Style("border-color") = "red"
                txtEmail.Value = ""
            Else
                ' Registra al usuario en el sistema
                UsuarioNegocio.Instancia.guardarUsuarioNuevo(cbTipoCedula.SelectedValue, txtCedula.Value, cbGenero.SelectedValue, txtNombre.Value.ToUpper(), txtEmail.Value, txtPass1.Value)
                UsuarioNegocio.Instancia.guardarRespuestas(txtCedula.Value, listaRespuestas())

                ' Redirecciona a la página de inicio de sesión con un parámetro de registro exitoso
                Response.Redirect("Ingreso.aspx?Registro=" & True, False)
            End If
        End If
    End Sub

    Protected Sub btnIniciarSesion_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("Ingreso.aspx", False)
    End Sub
End Class
