<%@ Page MaintainScrollPositionOnPostback="true" Language="vb" AutoEventWireup="false" CodeBehind="PP_Form_4_Cert.aspx.vb" Inherits="Formularios.PP_Form_4_Cert" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Certificados</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../Content/General.css" rel="stylesheet" />

</head>
<body>
    <form id="form" runat="server" class="justify-content-center">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <div class="container-fluid">
            <asp:Image ID="Encabezado" runat="server" ImageUrl="../images/master/Ingreso%20de%20usuario.jpg" Width="100%" />
            <hr />
            <h2 class="sombra-texto">Información de Certificaciones</h2>
            <p>Agregue de uno en uno los documentos, certificaciones y los datos específicos que se le solicitan a continuación</p>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aquí van los mensajes de Error o Alerta!</div>
            </div>
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_Click">Atrás</button>
                </div>
                <div class="col-izq-etiquetas">
                    <p class="hover-text" style="font-family: 'Henderson Sans Basic Light'; text-align: left; color: #282c54; font-weight: bold;">
                        <span style="vertical-align: middle; margin-right: 20px;">Ayuda</span>
                        <i class="bi bi-question-circle-fill" style="font-size: 2rem; vertical-align: middle;"></i>
                        <span class="tooltip-text fuente-especial" id="bottom">Tenga en cuenta lo siguiente 
                            <br />
                            <br />
                            ● Si se inscribió como persona física, debe adjuntar una fotocopia de su cédula por ambos lados.
                            <br />
                            <br />
                            ● Si se inscribió como empresa, debe adjuntar su certificación de personería jurídica y propiedad de las acciones con vista en el libro de accionistas.
                            <br />
                            <br />
                            ● Si es persona física, debe adjuntar el curso de Buenas Prácticas Agrícolas del Servicio Fitosanitario del Estado.
                            <br />
                            <br />
                            ● Si sus actividades requieren Certificados Veterinarios de Operación de SENASA (CVO's), debe adjuntarlos.
                            <br />
                            <br />
                            ● Si su actividad necesita certificación de INCOPESCA, debe adjuntarlo.
                        </span>
                    </p>
                </div>

                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio">
                    <a href="../Content/Documentos/Carta%20de%20compromiso%20Productor%20Primario.pdf" class="btn sombra-caja" download>Descargar machote Carta de Compromiso</a>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Tipo de Certificado</div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbTipoCertificacion" runat="server" autopostback="True" width="100%" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Número o código de Certificado</div>
                <div class="col-centro-entradas">
                    <input id="txtNumeroCert" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Fecha de Emisión</div>
                <div class="col-centro-entradas">
                    <telerik:raddatepicker id="dtFechaEmision" runat="server" width="100%" cssclass="sombra-caja">
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
                <div class="col-izq-etiquetas">Fecha de Vencimiento</div>
                <div class="col-centro-entradas">
                    <telerik:raddatepicker id="dtFechaVence" runat="server" width="100%" cssclass="sombra-caja">
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
                <div class="col-izq-etiquetas">Archivo del certificado</div>
                <div class="col-centro-entradas">
                    <telerik:radasyncupload
                        id="AsyncUploadCertificado"
                        runat="server"
                        allowedfileextensions="pdf"
                        chunksize="1048576"
                        maxfileinputscount="1"
                        tooltip="Aquí debe subir su archivo digitalizado"
                        width="100%"
                        rendermode="Lightweight">
							<Localization Select="Buscar Archivo" />
						</telerik:radasyncupload>
                    <div class="form-text">
                        <span>El formato permitido es PDF y su peso no puede sobrepasar los</span>
                        <asp:Label runat="server" ID="lblPesoArchivo"></asp:Label>
                        <span>MB</span>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button
                        id="btnAgregarCert"
                        runat="server"
                        autopostback="True"
                        class="btn sombra-caja"
                        style="width: 100%; display: flex; align-items: center; justify-content: space-between;"
                        onserverclick="btnAgregarCert_Click">
                        <i class="bi bi-plus-circle-dotted" style="font-size: 1.5rem"></i>Agregar Certificado</button>
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
								<telerik:GridBoundColumn DataField="desCertifica" HeaderText="Certificación" UniqueName="desCertifica">
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridBoundColumn DataField="desInstitucion" HeaderText="Institución" UniqueName="desInstitucion">
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridBoundColumn DataField="numero" HeaderText="Número" UniqueName="numero">
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridBoundColumn UniqueName="fechaEmision" HeaderText="Emisión" DataField="fechaEmision" DataFormatString="{0:d}">
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridBoundColumn UniqueName="fechaVencimiento" HeaderText="Vencimiento" DataField="fechaVencimiento" DataFormatString="{0:d}">
									<HeaderStyle HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" />
								</telerik:GridBoundColumn>
								<telerik:GridTemplateColumn UniqueName="LinkTemplateColumn"  HeaderText="Eliminar">
									<ItemTemplate>
                                        <asp:LinkButton ID="eliminarCertificado" runat="server" CommandName="Select" OnClick="eliminarCertificado_Click" CssClass="btn sombra-caja">
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
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button id="btnSiguiente" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnSiguiente_Click">Continuar</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>
