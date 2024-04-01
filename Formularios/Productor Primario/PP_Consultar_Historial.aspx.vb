Imports BackEnd
Imports Telerik.Web.UI

Public Class Consultar_Historial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Configuración inicial cuando se carga la página.
        If Not IsPostBack Then
            'Comprobar si la variable de sesión "Inscripcion" está establecida.
            If Session("Cedula") Is Nothing Then
                'Si no está establecida, redirigir a la página de error.
                txtError.InnerText = "El usuario no tiene historial de inscripciones"
                txtError.Visible = True
            Else
                txtError.InnerText = ""
                txtError.Visible = False
                preCargaHistorial()
            End If
        End If

    End Sub


    ' Subrutina para pre-cargar información de las lineas de abastecimiento agregadas relacionados con la inscripción.
    Sub preCargaHistorial()
        Dim historial As List(Of Productor) = ProductorNegocio.Instancia.traerHistorial(Session("Cedula"))

        If historial IsNot Nothing Then
            rghistorial.DataSource = historial
            rghistorial.DataBind()
        Else
            ' No hay datos, muestra un mensaje o realiza otra acción.
            txtError.InnerText = "No se encontraron datos en el historial."
            txtError.Visible = True
            divInfo.Visible = False
        End If
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        ' Redirige a la página anterior.
        Response.Redirect("/Usuario/Selector_Formulario.aspx", False)
    End Sub
End Class