<%@ page language="vb" autoeventwireup="false" codebehind="VW_Inscrip_3_LineaAbPP.aspx.vb" inherits="Formularios.VW_Inscrip_3_LineaAbPP" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Línea de Abastecimiento</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../../Content/General.css" rel="stylesheet" />
</head>

<body>
    <form id="form" runat="server" class="justify-content-center">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <div class="container-fluid">
            <asp:image id="Encabezado" runat="server" imageurl="../../images/master/Ingreso%20de%20usuario.jpg" width="100%" />
            <hr />
            <h2 class="sombra-texto">Información de Línea de Abastecimiento</h2>
            <br />

            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_ServerClick">
                        Atras
                    </button>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
       
            <br />
            <br />
            <telerik:radgrid
                id="rglineasAb"
                OnItemDataBound="rglineasAb_ItemDataBound"
                runat="server"
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
						<CommandItemSettings AddNewRecordText="Agregar Terreno" CancelChangesText="" RefreshText="" SaveChangesText="" ShowAddNewRecordButton="False" ShowRefreshButton="False" />
						<Columns>

							<telerik:GridBoundColumn DataField="codigo" HeaderText="#" UniqueName="codigo" Visible="False"></telerik:GridBoundColumn>
							<telerik:GridBoundColumn DataField="codLinea" HeaderText="Línea de Abastecimiento" UniqueName="codLinea" ItemStyle-Width="150px"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="areaTotal" HeaderText="Área Total (Hectáreas)" UniqueName="areaTotal" ItemStyle-Width="50px"></telerik:GridBoundColumn>
							<telerik:GridBoundColumn DataField="descripcionLinea" HeaderText="Descripción" UniqueName="descripcionLinea"></telerik:GridBoundColumn>
							<telerik:GridBoundColumn DataField="direccionGr" HeaderText="Dirección" UniqueName="direccionGr" ItemStyle-Width="450px"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="verificacionCampo" HeaderText="Verificación en Campo" UniqueName="verificacionCampo" ItemStyle-Width="100px"></telerik:GridBoundColumn>
							
                            <telerik:GridTemplateColumn UniqueName="LinkTemplateColumn" HeaderText="Verificación">
							
                                <ItemTemplate>
									<asp:LinkButton ID="verifCampo" runat="server" CommandName="Select" OnClick="chkverifCampo_Click">Completar</asp:LinkButton>
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
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtDireccion">Observaciones</label>
                </div>
                <div class="col-centro-entradas">
                    <textarea id="txtObservaciones" runat="server" type="text" class="form-control sombra-caja" placeholder="" style="height: 100px; resize: none"></textarea>
                    <div class="form-text">* Comentarios sobre la verificación en campo. Realizadas por un AEO</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                </div>
                <div class="col-der-espacio">
                    <button id="btnSiguiente" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnSiguiente_ServerClick">Siguiente Página</button>
                </div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>


