﻿Imports BackEnd
Imports Telerik.Web.UI
Public Class UI_Archivo_PP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Usuario") = "yaguilar"
        If Not IsPostBack Then
            cargarRolUI()

        End If
    End Sub

    Sub cargarRolUI()
        'Obtiene el rol del usuario interno
        Dim rolUsuario = UsuarioInternoNegocio.Instancia.cargarRolUI(Session("Usuario").ToString())
        Session("AreaVerificacionPP") = rolUsuario.rol

        ' Obtiene si se debe filtrar o no por region
        Dim filtrarRegion = UsuarioInternoNegocio.Instancia.RolRegion(rolUsuario.rol)

        If filtrarRegion.filtrarRegion = "NO" Then
            'si el rol indica que la información no debe filtrarse por región, se muestran todas las inscripciones disponibles
            cargarInscripciones()
        Else
            traerRegionUI()
            cargarInscripFiltradas()
        End If
    End Sub

    Sub traerRegionUI()
        ' Busca cuál es la región del usuario dependiendo de su usuario cnp
        Dim regionUsuario = UsuarioInternoNegocio.Instancia.traerRegionUI(Session("Usuario").ToString())
        Session("Region") = regionUsuario.codigo
    End Sub

    Sub cargarInscripFiltradas()
        ' Precarga las inscripciones rechazadas o aceptadas que se encuentren en la misma región que la del funcionario cnp 
        rgArchivoPP.DataSource = NuevosFormsPPNegocio.Instancia.RegArchivoPP(Session("Region").ToString())
        rgArchivoPP.DataBind()
    End Sub

    Sub cargarInscripciones()
        ' Precarga las inscripciones rechazadas o aceptadas
        rgArchivoPP.DataSource = NuevosFormsPPNegocio.Instancia.ArchivosPP()
        rgArchivoPP.DataBind()
    End Sub

    ' Cuando se carga la tabla, agrega texto en cada fila usando la propiedad DataBound
    Protected Sub rgArchivoPP_ItemDataBound(sender As Object, e As GridItemEventArgs)
        If TypeOf e.Item Is GridDataItem Then
            Dim dataItem As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim codigo As String = dataItem("codigo").Text

            ' Agregar el prefijo "Inscripción No." al valor de la columna "codigo"
            dataItem("codigo").Text = "INSCRIPCIÓN NO. " & codigo

            ' Aplicar formato de texto en negrita a la columna "codigo"
            dataItem("codigo").Font.Bold = True
        End If
    End Sub

    Protected Sub revisarActividad_Click(sender As Object, e As EventArgs)
        Try
            Dim lnk As LinkButton = DirectCast(sender, LinkButton)
            Dim data As GridDataItem = DirectCast(lnk.NamingContainer, GridDataItem)
            ' Toma el codigo de la inscripción seleccionada y la guarda en una sesión 
            Session("codigoInscrip") = data.GetDataKeyValue("codigo").ToString()
            Session("archivoPP") = data.GetDataKeyValue("codigo").ToString()

            Response.Redirect("/Usuario Interno/Vista Inscripcion PP/VW_Inscrip_1_InfoPP.aspx", False)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub btnbuscar_ServerClick(sender As Object, e As EventArgs)
        ' busca en la base de datos las coincidencias de información que desea buscar el funcionario
        rgArchivoPP.DataSource = NuevosFormsPPNegocio.Instancia.buscarArchivoPP(txtbusqueda.Value)
        rgArchivoPP.DataBind()
        txtbusqueda.Value = ""
    End Sub
End Class