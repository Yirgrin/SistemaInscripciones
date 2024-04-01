<%@ page maintainscrollpositiononpostback="true" language="vb" autoeventwireup="false" codebehind="PP_Form_3_LineaAb.aspx.vb" inherits="Formularios.PP_Form_3_LineaAb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Línea de Abastecimiento</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../Content/General.css" rel="stylesheet" />
</head>

<body>
    <form id="form" runat="server" class="justify-content-center">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <div class="container-fluid">
            <asp:image id="Encabezado" runat="server" imageurl="../images/master/Ingreso%20de%20usuario.jpg" width="100%" />
            <hr />
            <h2 class="sombra-texto">Información de Línea de Abastecimiento</h2>
            <p>
                Complete toda la información que se le solicita a continuación con respecto a sus actividades productivas
                <br />
            </p>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">
                    Aquí van los mensajes de Error o Alerta!
                </div>
            </div>
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
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <div class="form-text">* Ubicación del terreno</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Provincia</div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbProvincia" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Cantón</div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbCanton" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" enabled="False" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Distrito</div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbDistrito" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" enabled="False" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Dirección exacta de la propiedad</div>
                <div class="col-centro-entradas">
                    <textarea id="txtDireccion" runat="server" type="text" class="form-control sombra-caja" style="height: 100px; resize: none" disabled placeholder="[Referencia principal]  [Distancia desde la referencia] [Descripcion adicional] [Nombre del barrio, caserío o localidad]"></textarea>
                    <div class="form-text">Ejemplo: De la Escuela Gabriel Brenes Robles, 225 metros al norte, contiguo a puente de rio amarillo, a mano derecha, San Gabriel de Aserrí</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Línea de abastecimiento</div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbLineaAb" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" enabled="False" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divAreaTotal" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Área total (Héctareas)</div>
                <div class="col-centro-entradas">
                    <input id="txtAreatotal" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divGanLeche" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Litros de leche por día</div>
                <div class="col-centro-entradas">
                    <input id="txtLecheDia" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divGanCarne" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Total de cabezas</div>
                <div class="col-centro-entradas">
                    <input id="txtTotalCabezas" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Cabezas por semana</div>
                <div class="col-centro-entradas">
                    <input id="txtCabezasSemana" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divGanCerdo" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Total de unidades</div>
                <div class="col-centro-entradas">
                    <input id="txtTotalUnidades" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Unidades por semana</div>
                <div class="col-centro-entradas">
                    <input id="txtUnidadesSemana" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divProdPollo" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Total de picos</div>
                <div class="col-centro-entradas">
                    <input id="txtTotalPicos" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Kg por día</div>
                <div class="col-centro-entradas">
                    <input id="txtKgDíaP" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divProdHuevos" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Cantidad de cartones diarios</div>
                <div class="col-centro-entradas">
                    <input id="txtCartonesDiarios" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Kg de huevos diarios</div>
                <div class="col-centro-entradas">
                    <input id="txtHuevosDia" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divProdPescado" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Tilapia. Kg semanal</div>
                <div class="col-centro-entradas">
                    <input id="txtKgTilapia" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Otros. Kg diarios</div>
                <div class="col-centro-entradas">
                    <input id="txtKgOtros" runat="server" autopostback="True" type="number" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divProdAgricola" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Producto</div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbProductoHorto" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Cantidad de Producción</div>
                <div class="col-centro-entradas">
                     <input id="txtCantidad" runat="server" autopostback="True" type="number" class="form-control sombra-caja" disabled/>
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Unidad de Medida</div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbUnidadMedida" runat="server" autopostback="True" width="100%" rendermode="Auto" enabled="False" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>

                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Frecuencia de Producción</div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbFrecuencia" runat="server" autopostback="True" width="100%" rendermode="Auto" enabled="False" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>


            </div>


            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button
                        id="btnAgregarLinea"
                        runat="server"
                        autopostback="True"
                        class="btn sombra-caja"
                        style="width: 100%; display: flex; align-items: center; justify-content: space-between;" onserverclick="btnAgregarLinea_ServerClick">
                        <i class="bi bi-plus-circle-dotted" style="font-size: 1.5rem"></i>Agregar Línea de Abastecimiento
                    </button>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <br />
            <telerik:radgrid
                id="rglineasAb"
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
							<telerik:GridBoundColumn DataField="direccionGr" HeaderText="Dirección" UniqueName="direccionGr" ItemStyle-Width="500px"></telerik:GridBoundColumn>
							<telerik:GridTemplateColumn UniqueName="LinkTemplateColumn" HeaderText="Eliminar">
								<ItemTemplate>
									<asp:LinkButton ID="eliminarLineaAb" runat="server" CommandName="Select" CssClass="btn sombra-caja" OnClick="eliminarLineaAb_Click">
										<i class="bi bi-trash" style="font-size: 1rem"></i>
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

            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                </div>
                <div class="col-der-espacio">
                    <button id="btnSiguiente" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnSiguiente_ServerClick">Continuar</button>
                </div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>

