<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PP_Consultar_Historial.aspx.vb" Inherits="Formularios.Consultar_Historial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Historial de Inscripciones</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../Content/General.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <div class="container-fluid">
            <asp:Image ID="Encabezado" runat="server" ImageUrl="../images/master/Seleccion%20de%20formulario.jpg" Width="100%" />
            <hr />

            <h2 class="sombra-texto">Historial de inscripciones Productor Primario</h2>
            <h2 class="sombra-texto"></h2>
            
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
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">
                    Aquí van los mensajes de Error o Alerta!
                </div>
            </div>
            <br />
            <div id="divInfo" class="row" runat="server">
                <p>
                    Estados en los qué se puede encontrar su última inscripción:
                <br />
                    <br />
                    <b>Trámite:</b> Su inscripción aún no se ha completado ni enviado.
                <br />
                    <b>Validación:</b> Usted ya envió su inscripción, por lo tanto no podrá editarla ni consultarla hasta que un funcionario cambie este estado.
                <br />
                    <b>Subsanación:</b> Usted puede modificar los datos de su inscripción previamente enviados.
                <br />
                    <b>Rechazado:</b> Su inscripción fue rechazada. Debe completar nuevamente el formulario. 
                <br />
                    <b>Aceptado:</b> Su inscripción fue aceptada, por lo tanto no podrá editarla ni consultarla.
                </p>
                <br />
                <telerik:radgrid
                    id="rghistorial"
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
							<telerik:GridBoundColumn DataField="codigo" HeaderText="Número de Inscripción" UniqueName="codigo"></telerik:GridBoundColumn>
							<telerik:GridBoundColumn DataField="fecha_envio" HeaderText="Fecha de envío o última edición" UniqueName="fecha_envio"></telerik:GridBoundColumn>
							<telerik:GridBoundColumn DataField="estado_form" HeaderText="Estado" UniqueName="estado_form"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fecha_devolucion" HeaderText="Fecha de devolución" UniqueName="fecha_devolucion"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="observaciones" HeaderText="Observaciones" UniqueName="observaciones"></telerik:GridBoundColumn>
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
            </div>
        </div>
    </form>
</body>
</html>
