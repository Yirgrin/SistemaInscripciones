﻿Imports BackEnd
Imports Telerik.Web.UI

Public Class UI_Pendientes_SA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("Usuario") = "YAGUILAR"
        If Not IsPostBack Then
            cargarRolUI()
        End If
    End Sub

    Sub cargarRolUI()
        'Obtiene el rol del usuario interno
        Dim rolUsuario = UsuarioInternoNegocio.Instancia.cargarRolUI(Session("Usuario").ToString())
        Session("AreaVerificacionSA") = rolUsuario.rol

        ' Obtiene si se debe filtrar o no por region
        Dim filtrarRegion = UsuarioInternoNegocio.Instancia.RolRegion(rolUsuario.rol)

        If filtrarRegion.filtrarRegion = "NO" Then
            'si el rol indica que la información no debe filtrarse por región, se muestran todas las inscripciones disponibles
            'dependiendo si el rol es de Dirección de mercadeo o comercialización

            If rolUsuario.rol = 3 Then
                'se cargan sólo las inscripciones para el rol de dirección de mercadeo
                InscripcionesDirecMercadeo()
            ElseIf rolUsuario.rol = 4 Then
                'se cargan sólo las inscripciones para el rol de comercialización
                InscripcionesComercializacion()
            End If
        Else
            traerRegionUI()
            If rolUsuario.rol = 1 Then
                'se cargan sólo las inscripciones para el rol es de AEO 
                cargarInscripcionesAEO()
            ElseIf rolUsuario.rol = 2 Then
                'se cargan sólo las inscripciones PARA el rol de dirección regional
                InscripcionesDirecRegional()
            End If
        End If

    End Sub

    Sub traerRegionUI()
        ' Busca cuál es la región del usuario dependiendo de su usuario cnp
        Dim regionUsuario = UsuarioInternoNegocio.Instancia.traerRegionUI(Session("Usuario").ToString())
        Session("Region") = regionUsuario.codigo
    End Sub

    Sub cargarInscripcionesAEO()
        ' Precarga las inscripciones que se encuentren en la misma región que la del funcionario AEO 
        rgInscripcionesSA.DataSource = NuevosFormsSANegocio.Instancia.AEOcargarInscripSA(Session("Region").ToString())
        rgInscripcionesSA.DataBind()
    End Sub

    Sub InscripcionesDirecRegional()
        ' Precarga las inscripciones que se encuentren en la misma región que la del funcionario Director Regional 
        rgInscripcionesSA.DataSource = NuevosFormsSANegocio.Instancia.DirecRegCargarInscripSA(Session("Region").ToString())
        rgInscripcionesSA.DataBind()
    End Sub

    Sub InscripcionesDirecMercadeo()
        ' Precarga las inscripciones que se encuentren en la misma región que la del funcionario Director Mercadeo
        rgInscripcionesSA.DataSource = NuevosFormsSANegocio.Instancia.DirecMercCargarInscripSA()
        rgInscripcionesSA.DataBind()
    End Sub

    Sub InscripcionesComercializacion()
        ' Precarga las inscripciones que se encuentren en la misma región que la del funcionario Comercialización 
        rgInscripcionesSA.DataSource = NuevosFormsSANegocio.Instancia.ComerCargarInscripSA()
        rgInscripcionesSA.DataBind()
    End Sub

    ' Cuando se carga la tabla, agrega texto en cada fila usando la propiedad DataBound
    Protected Sub rgInscripcionesSA_ItemDataBound(sender As Object, e As GridItemEventArgs)
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

            Response.Redirect("/Usuario Interno/Vista Inscripcion SA/VW_Inscrip_1_InfoSA.aspx", False)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub btnBuscar_ServerClick(sender As Object, e As EventArgs)
        ' busca en la base de datos las coincidencias de información que desea buscar el funcionario
        rgInscripcionesSA.DataSource = NuevosFormsSANegocio.Instancia.buscarInscripcionSA(txtbusqueda.Value)
        rgInscripcionesSA.DataBind()
        txtbusqueda.Value = ""
    End Sub
End Class