<%@ page maintainscrollpositiononpostback="true" language="vb" autoeventwireup="false" codebehind="UI_Pendientes_SA.aspx.vb" inherits="Formularios.UI_Pendientes_SA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Pendientes Suplidor Acopio</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/boxicons@latest/css/boxicons.min.css" />
    <link href="../Content/sidebar.css" rel="stylesheet" />
    <script src="../Scripts/sidebar.js"></script>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../Content/General.css" rel="stylesheet" />

</head>


<body id="body-pd">
    <form id="form1" runat="server">

        <header class="header" id="header">
            <div class="header_toggle">
                <i class='bx bx-menu' id="header-toggle"></i>
            </div>
            <div class="container-fluid">
                <asp:image id="Encabezado" runat="server" imageurl="../images/master/Ingreso%20de%20usuario.jpg" width="100%" />
            </div>
        </header>

        <div class="l-navbar" id="nav-bar">
            <nav class="nav">
                <div>
                    <%--<a href="#" class="nav_logo">
                    <i class='bx bx-layer nav_logo-icon'></i>
                    <span class="nav_logo-name"></span>
                </a>--%>
                    <div class="nav_list">
                        <a href="UI_Pendientes_PP.aspx" class="nav_link active">
                            <i class='bx bx-layer nav_logo-icon'></i>
                            <span class="nav_name">Nuevos 
                            <br />
                                Productor Primario</span>
                        </a>
                        <a href="UI_Pendientes_SA.aspx" class="nav_link">
                            <i class='bx bx-layer nav_logo-icon'></i>
                            <span class="nav_name">Nuevos 
                            <br />
                                Suplidor de Acopio</span>
                        </a>
                        <a href="UI_Modificar_PP.aspx" class="nav_link">
                            <i class='bx bx-message-square-detail nav_icon'></i>
                            <span class="nav_name">Modificar 
                            <br />
                                formulario PP</span>
                        </a>
                        <a href="#" class="nav_link">
                            <i class='bx bx-message-square-detail nav_icon'></i>
                            <span class="nav_name">Modificar 
                            <br />
                                formulario SA</span>
                        </a>
                        <a href="UI_Archivo_PP.aspx" class="nav_link">
                            <i class='bx bx-folder nav_icon'></i>
                            <span class="nav_name">Archivo 
                            <br />
                                Inscripciones PP</span>
                        </a>
                        <a href="UI_Archivo_SA.aspx" class="nav_link">
                            <i class='bx bx-folder nav_icon'></i>
                            <span class="nav_name">Archivos
                            <br />
                                Inscripciones SA</span>
                        </a>
                        <a href="#" class="nav_link">
                            <i class='bx bx-bar-chart-alt-2 nav_icon'></i>
                            <span class="nav_name">Bitácora 
                            <br />
                                de Auditoría</span>
                        </a>
                    </div>
                </div>
                <%--<a href="#" class="nav_link">
                <i class='bx bx-log-out nav_icon'></i>
                <span class="nav_name">SignOut</span>
            </a>--%>
            </nav>
        </div>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div style="text-align: center;">
            <li class="nav-item" style="display: inline-block; margin-right: 20px;">
                <input id="txtbusqueda" runat="server" class="form-control me-2" type="search" placeholder="Buscar" aria-label="Search" style="width: 200px; font-size: 14px;">
            </li>
            <li class="nav-item" style="display: inline-block;">
                <button id="btnBuscar" runat="server" autopostback="True" style="width: 100%; font-size: 14px;" class="btn sombra-caja" onserverclick="btnBuscar_ServerClick">Buscar</button>
            </li>
        </div>

        <br />

        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <telerik:radgrid
            id="rgInscripcionesSA"
            runat="server"
            onitemdatabound="rgInscripcionesSA_ItemDataBound"
            allowautomaticupdates="True"
            allowmultirowselection="True"
            allowpaging="True"
            allowsorting="True"
            autogeneratecolumns="False"
            cellspacing="-1"
            culture="es-ES"
            gridlines="Both"
            grouppanelposition="Top"
            rendermode="Lightweight"
            resolvedrendermode="Classic"
            showfooter="True"
            showstatusbar="True"
            style="font-family: 'Henderson Sans Basic Light', Arial, sans-serif; text-align: center"
            cssclass="sombra-caja">
					<mastertableview commanditemdisplay="Top" datakeynames="codigo" width="100%">
						<rowindicatorcolumn visible="False"></rowindicatorcolumn>
						<expandcollapsecolumn created="True"></expandcollapsecolumn>
						<CommandItemSettings AddNewRecordText="Agregar Actividad Comercial" CancelChangesText="" RefreshText="" SaveChangesText="" ShowAddNewRecordButton="False" ShowRefreshButton="False" />
						<Columns>
						    <telerik:GridBoundColumn DataField="codigo" HeaderText="Inscripción" UniqueName="codigo"> </telerik:GridBoundColumn>
						    <telerik:GridBoundColumn DataField="nombre" HeaderText="Nombre" UniqueName="nombre"> </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="cedula" HeaderText="Cédula" UniqueName="cedula"> </telerik:GridBoundColumn>
							<telerik:GridBoundColumn DataField="fecha_envio" HeaderText="Fecha de Envío" UniqueName="fecha_envio"> </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="LinkTemplateColumn" HeaderText="Revisar">
								<ItemTemplate>
									<asp:LinkButton ID="revisarActividad" runat="server" CommandName="Select" CssClass="btn sombra-caja" Onclick="revisarActividad_Click">
										<i class="bi bi-eye"  style="font-size: 1rem"></i>
									</asp:LinkButton>
								</ItemTemplate>
							</telerik:GridTemplateColumn>
						</Columns>
					</mastertableview>
					<clientsettings>
						<selecting allowrowselect="true" useclientselectcolumnonly="True" />
					</clientsettings>
					<filtermenu rendermode="Lightweight"></filtermenu>
					<headercontextmenu rendermode="Lightweight"></headercontextmenu>
				</telerik:radgrid>

    </form>
</body>
</html>
