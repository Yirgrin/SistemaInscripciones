<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VW_Inscrip_3_InfoContaSA.aspx.vb" Inherits="Formularios.VW_Inscrip_3_InfoContaSA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Información Contable</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../../Content/General.css" rel="stylesheet" />
</head>
<body>
    <form id="form" runat="server" class="justify-content-center">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <div class="container-fluid">
            <asp:image id="Encabezado" runat="server" imageurl="../../images/master/Ingreso%20de%20usuario.jpg" width="100%" />
            <hr />
            <h2 class="sombra-texto">Categorización por tamaño de empresa</h2>
            <br />
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_ServerClick">Atrás</button>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCategoriaPrincipal">Categoría de actividad principal</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCategoriaPrincipal" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>                    
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCantEmpleados">Cantidad de empleados</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCantEmpleados" runat="server" type="number" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>
            
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtVentasNetas">Ventas netas anuales</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtVentasNetas" runat="server" type="number" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>
            
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtActivosFijos">Activos fijos anuales</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtActivosFijos" runat="server" type="number" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtActivosTotales">Activos totales anuales</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtActivosTotales" runat="server" type="number" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbProvincia">Provincia</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtProvincia" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbCanton">Cantón</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCanton" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbDistrito">Distrito</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtDistrito" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtDireccion">Dirección exacta</label>
                </div>
                <div class="col-centro-entradas">
                    <textarea id="txtDireccion" runat="server" type="text" class="form-control sombra-caja" placeholder="" style="height: 100px; resize: none" disabled></textarea>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtClasiEmpresa">Tamaño de Empresa</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtClasiEmpresa" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <br />
            <p><b>Actividad(es) comercial(es) secundaria(s) </b> </p>
            <br />

            <telerik:radgrid
                id="rgActividadComercial"
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
						<CommandItemSettings AddNewRecordText="Agregar Actividad Comercial" CancelChangesText="" RefreshText="" SaveChangesText="" ShowAddNewRecordButton="False" ShowRefreshButton="False" />
						<Columns>
							<telerik:GridBoundColumn DataField="codigo" HeaderText="#" UniqueName="codigo" Visible="False"></telerik:GridBoundColumn>
							<telerik:GridBoundColumn DataField="categoria" HeaderText="Categoría de Actividad" UniqueName="categoria"></telerik:GridBoundColumn>
							<telerik:GridBoundColumn DataField="codigoProduccion" HeaderText="Clasificación" UniqueName="codigoProduccion"></telerik:GridBoundColumn>
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
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                   <button id="btnSiguiente" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnSiguiente_ServerClick"> Página Siguiente</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>


