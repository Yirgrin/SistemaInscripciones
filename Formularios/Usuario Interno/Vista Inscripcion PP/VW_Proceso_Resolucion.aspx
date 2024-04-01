<%@ page language="vb" autoeventwireup="false" codebehind="VW_Proceso_Resolucion.aspx.vb" inherits="Formularios.VW_Proceso_Resolucion" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Proceso de Resolución</title>
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
            <h2 class="sombra-texto">Proceso de Resolución</h2>
            
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aquí van los mensajes de Error o Alerta!</div>
            </div>
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_ServerClick">Atrás</button>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Resolución N°:</div>
                <div class="col-centro-entradas">
                    <input id="txtNumResolucion" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Fecha:</div>
                <div class="col-centro-entradas">
                    <telerik:raddatepicker id="dtFechaResolucion" runat="server" width="100%" cssclass="sombra-caja">
							<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" Culture="es-ES" FastNavigationNextText="&amp;lt;&amp;lt;"></Calendar>
							<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%">
								<EmptyMessageStyle Resize="None"></EmptyMessageStyle>
								<ReadOnlyStyle Resize="None"></ReadOnlyStyle>
								<FocusedStyle Resize="None"></FocusedStyle>
								<DisabledStyle Resize="None"></DisabledStyle>
								<InvalidStyle Resize="None"></InvalidStyle>
								<HoveredStyle Resize="None"></HoveredStyle>
								<EnabledStyle Resize="None"></EnabledStyle>
							</DateInput>
							<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
						</telerik:raddatepicker>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbCondicion">Condición: </label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbCondicion" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --">
                        <Items>
                            <telerik:RadComboBoxItem Text="Aceptado" Value="5" />
                            <telerik:RadComboBoxItem Text="Rechazado" Value="4" />
                        </Items>
                    </telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtObservaciones">Observaciones: </label>
                </div>
                <div class="col-centro-entradas">
                    <textarea id="txtObservaciones" runat="server" type="text" class="form-control sombra-caja" placeholder="" style="height: 100px; resize: none"></textarea>
                    <div class="form-text">* Campo opcional</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button id="btnFinalizar" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnFinalizar_ServerClick">Finalizar</button>
                    <button id="btnInicio" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnInicio_ServerClick">Inicio</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <br />
            <hr />
    </form>
</body>
</html>
