Imports BackEnd
Public Class VW_Inscrip_3_InfoContaSA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            preCargaDatos()
            preCargarActividades()
        End If

    End Sub

    Sub preCargaDatos()
        ' Precarga los datos de Información Contable que el usuario emitió en el formulario.
        Dim modelo = VistaInscripcionSANegocio.Instancia.cargarDatosContables(Session("codigoInscrip"))

        txtActivosFijos.Value = modelo.activosFijos
        txtVentasNetas.Value = modelo.ventasNetas
        txtActivosTotales.Value = modelo.activosTotales
        txtCantEmpleados.Value = modelo.cantidadEmpleados
        txtCategoriaPrincipal.Value = modelo.actividadPrincipal
        txtProvincia.Value = modelo.codProvincia
        txtCanton.Value = modelo.codCanton
        txtDistrito.Value = modelo.codDistrito
        txtDireccion.Value = modelo.direcExacta

        Session("codProduccion") = modelo.codigoProduccion
        Session("empleadosPromedio") = modelo.cantidadEmpleados
        Session("ventasNetas") = modelo.ventasNetas
        Session("activosFijos") = modelo.activosFijos
        Session("activosTotales") = modelo.activosTotales

        FormulaClasificacion()

    End Sub

    ' Subrutina para pre-cargar información de las lineas de abastecimiento agregadas relacionados con la inscripción.
    Sub preCargarActividades()
        rgActividadComercial.DataSource = ActividadComercialNegocio.Instancia.preCargarActividades(Session("codigoInscrip"))
        rgActividadComercial.DataBind()
    End Sub


    ' Sub rutina para realizar la fórmula para la clasificación del tamaño de una empresa 
    Sub FormulaClasificacion()
        Dim fpe As Decimal
        Dim fipf As Decimal
        Dim fan As Decimal
        Dim dpe As Decimal
        Dim dinpf As Double
        Dim dan As Double
        Dim PE = Session("empleadosPromedio")
        Dim INPF = Session("ventasNetas")
        Dim an As Decimal
        Dim puntaje

        If Session("codProduccion") = "INDUSTRIA" Then
            ' Los valores para realizar la formula del tipo INDUSTRIA se toman del webConfig
            fpe = ConfigurationManager.AppSettings("IndusFpe")
            fipf = ConfigurationManager.AppSettings("IndusFipf")
            fan = ConfigurationManager.AppSettings("IndusFan")
            dpe = ConfigurationManager.AppSettings("IndusDpe")
            dinpf = ConfigurationManager.AppSettings("IndusDinpf")
            dan = ConfigurationManager.AppSettings("IndusDan")
            an = Session("activosFijos")

            ' Fórmula para realizar la medición del tamaño de la empresa
            puntaje = ((fpe * PE / dpe) + (fipf * INPF / dinpf) + (fan * an / dan)) * 100

            ' clasificación de empresa 
            If puntaje <= 10 Then
                txtClasiEmpresa.Value = "MICRO"
            ElseIf puntaje <= 65 Then
                txtClasiEmpresa.Value = "PEQUEÑA"
            ElseIf puntaje <= 120 Then
                txtClasiEmpresa.Value = "MEDIANA"
            Else
                txtClasiEmpresa.Value = "GRANDE"
            End If

        ElseIf Session("codProduccion") = "COMERCIO" Then
            ' Los valores para realizar la formula del tipo COMERCIO se toman del webConfig
            fpe = ConfigurationManager.AppSettings("ComFpe")
            fipf = ConfigurationManager.AppSettings("ComFipf")
            fan = ConfigurationManager.AppSettings("ComFan")
            dpe = ConfigurationManager.AppSettings("ComDpe")
            dinpf = ConfigurationManager.AppSettings("ComDinpf")
            dan = ConfigurationManager.AppSettings("ComDan")
            an = Session("activosTotales")

            ' Fórmula para realizar la medición del tamaño de la empresa
            puntaje = ((fpe * PE / dpe) + (fipf * INPF / dinpf) + (fan * an / dan)) * 100

            ' clasificación de empresa 
            If puntaje <= 10 Then
                txtClasiEmpresa.Value = "MICRO"
            ElseIf puntaje <= 35 Then
                txtClasiEmpresa.Value = "PEQUEÑA"
            ElseIf puntaje <= 100 Then
                txtClasiEmpresa.Value = "MEDIANA"
            Else
                txtClasiEmpresa.Value = "GRANDE"
            End If

        End If

    End Sub

    Protected Sub btnSiguiente_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inscrip_4_CertSA.aspx", False)
    End Sub

    Protected Sub btnAtras_ServerClick(sender As Object, e As EventArgs)
        Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inscrip_2_RLSA.aspx", False)
    End Sub
End Class