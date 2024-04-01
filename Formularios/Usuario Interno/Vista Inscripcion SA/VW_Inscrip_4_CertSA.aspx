<%@ page language="vb" autoeventwireup="false" codebehind="VW_Inscrip_4_CertSA.aspx.vb" inherits="Formularios.VW_Inscrip_4_CertSA" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Vista Certificados</title>
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
            <h2 class="sombra-texto">Información de Certificaciones</h2>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aquí van los mensajes de Error o Alerta!</div>
            </div>
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_ServerClick1">Atrás</button>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtBanco">Banco:</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtBanco" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" disabled />
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Cuenta IBAN</div>
                <div class="col-centro-entradas">
                    <input id="txtCuentaIBAN" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" disabled />
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <telerik:radgrid
                id="rgCertificacion"
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
                style="font-family: 'Henderson Sans Basic Light'; text-align: center"
                cssclass="sombra-caja">
						<mastertableview commanditemdisplay="Top" datakeynames="codigo" width="100%">
							<rowindicatorcolumn visible="False"> </rowindicatorcolumn>
							<expandcollapsecolumn created="True"></expandcollapsecolumn>
							<commanditemsettings addnewrecordtext="Agregar Usuario" cancelchangestext="" refreshtext="" savechangestext="" showaddnewrecordbutton="False" showrefreshbutton="False" />
							<Columns>
								<telerik:GridBoundColumn DataField="codigo" HeaderText="#" UniqueName="codigo" Visible="False">
									<HeaderStyle Width="60px" />
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridBoundColumn DataField="tipoCertificado" HeaderText="Certificación" UniqueName="tipoCertificado">
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridBoundColumn DataField="fechaEmision" HeaderText="Fecha de Emisión" UniqueName="fechaEmision">
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridBoundColumn DataField="fechaVencimiento" HeaderText="Fecha de Vencimiento" UniqueName="fechaVencimiento">
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridBoundColumn UniqueName="numero" HeaderText="Código" DataField="numero">
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="LinkTemplateColumn"  HeaderText="Descargar">
									<ItemTemplate>
                                        <asp:LinkButton ID="descargarCert" runat="server" CommandName="Select" Onclick="descargarCert_Click" CssClass="btn sombra-caja">
										<i class="bi bi-file-earmark-arrow-down" style="font-size: 1rem"></i>
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
            <br />

            <div class="row" id="divBotones" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <button id="btnSubsanar" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnSubsanar_ServerClick">Subsanar Solicitud</button>
                </div>
                <div class="col-centro-entradas">
                    <button id="btnEnviar" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnEnviar_ServerClick">Enviar</button>
                    <button id="btnSiguiente" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnSiguiente_ServerClick">Página Siguiente</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <br />
            <div class="row" id="divRechazar" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtNoResolucion">Número de Resolución: </label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtNoResolucion" runat="server" type="text" class="form-control sombra-caja" placeholder="">
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtObservaciones">Observaciones</label>
                </div>
                <div class="col-centro-entradas">
                    <textarea id="txtObservaciones" runat="server" type="text" class="form-control sombra-caja" placeholder="" style="height: 100px; resize: none"></textarea>
                    <div class="form-text">* Comentarios sobre el rechazo de solicitud. Realizadas por un AEO</div>
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <button id="btnCancelar" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnCancelar_ServerClick">Cancelar</button>
                </div>
                <div class="col-centro-entradas">
                    <button id="btnCompletarSubs" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnCompletarSubs_ServerClick">Completar</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>
