<%@ page maintainscrollpositiononpostback="true" language="vb" autoeventwireup="false" codebehind="SA_Form_4_Cert.aspx.vb" inherits="Formularios.SA_Form_5_Cert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Certificaciones y documentación</title>
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
            <h2 class="sombra-texto">Información de Certificaciones</h2>
            <p id="pInfo" runat="server">Agregue de uno en uno los documentos, certificaciones y los datos específicos que se le solicitan a continuación</p>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aquí van los mensajes de Error o Alerta!</div>
            </div>
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_ServerClick">Atrás</button>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                </div>
                <div class="col-der-espacio">
                    <button id="btn_ayuda" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btn_ayuda_ServerClick">Ayuda</button>
                    <button id="btnOcultar" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnOcultar_ServerClick">Ocultar</button>
                </div>
            </div>
            <br />

            <div class="row" id="divAyuda" runat="server">

                <div class="row">
                    <div class="col-izq-espacio">Machote Carta de Compromiso (Suplidor Acopio)</div>
                    <div class="col-izq-etiquetas">
                        <a href="../Content/Documentos/Carta%20de%20compromiso%20suplidor%20de%20acopio.pdf" class="btn sombra-caja" download>Descargar</a>
                    </div>
                    <div class="col-centro-entradas"></div>
                    <div class="col-der-espacio"></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-izq-espacio">Machote Carta de Compromiso (Agroindustria)</div>
                    <div class="col-izq-etiquetas">
                        <a href="../Content/Documentos/CARTA%20DE%20COMPROMISOS%20PARA%20INGRESAR%20COMO%20AGROINDUSTRIA.pdf" class="btn sombra-caja" download>Descargar</a>
                    </div>
                    <div class="col-centro-entradas"></div>
                    <div class="col-der-espacio"></div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-izq-espacio">Machote Declaración Jurada</div>
                    <div class="col-izq-etiquetas">
                        <a href="../Content/Documentos/DECLARACION%20JURADA%20SUPLIDOR%20DE%20ACOPIO%20Y%20PROCESAMIENTO.pdf" class="btn sombra-caja" download>Descargar</a>
                    </div>
                    <div class="col-centro-entradas"></div>
                    <div class="col-der-espacio"></div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div id="divTabla" class="justify-content-center">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Certificación</th>
                                <th scope="col">Detalle</th>
                                <th scope="col">¿Quién lo emite?</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><b>Solicitud escrita del proponente a la Dirección Regional del CNP</b></td>
                                <td>Incluye dirección, número de teléfono, celular, correo electrónico y descripción de la actividad.</td>
                                <td>Solicitante</td>
                            </tr>
                            <tr>
                                <td><b>Certificación de Personería Jurídica</b></td>
                                <td>Debe mostrar la naturaleza y propiedad de las acciones, con una vigencia no mayor a tres meses de emitida.</td>
                                <td>Persona jurídica</td>
                            </tr>
                            <tr>
                                <td><b>Cédula de identidad del interesado o Representante Legal </b></td>
                                <td>Documento de identificación personal.</td>
                                <td>Registro Civil</td>
                            </tr>
                            <tr>
                                <td><b>Lista de afiliados, asociados o accionistas</b></td>
                                <td>Lista de personas relacionadas con la empresa.</td>
                                <td>Solicitante</td>
                            </tr>
                            <tr>
                                <td><b>Certificación de Contador Público Autorizado (CPA)</b></td>
                                <td>Debe incluir información financiera clave de la empresa. Incluyendo último periodo fiscal.</td>
                                <td>Contador Público</td>
                            </tr>
                            <tr>
                                <td><b>Declaración del impuesto sobre las utilidades.</b></td>
                                <td>Opción alternativa al CPA para demostrar la situación financiera de la empresa.</td>
                                <td>Contador Público</td>
                            </tr>
                            <tr>
                                <td><b>Estados Financieros recientes firmados por un CPI.</b></td>
                                <td>Opción alternativa al CPA para demostrar la situación financiera de la empresa.</td>
                                <td>Contador Público</td>
                            </tr>
                            <tr>
                                <td><b>Última planilla presentada a la CCSS</b></td>
                                <td>Opción alternativa al CPA para demostrar la situación financiera de la empresa.</td>
                                <td>CCSS</td>
                            </tr>
                            <tr>
                                <td><b>Declaración jurada</b></td>
                                <td>Declaraciones sobre el cumplimiento de diversas obligaciones legales y fiscales.</td>
                                <td>Solicitante. Machote</td>
                            </tr>
                            <tr>
                                <td><b>Permiso Sanitario de Funcionamiento</b></td>
                                <td>Documento emitido por autoridades de salud, según sea necesario.</td>
                                <td>Ministerio de Salud</td>
                            </tr>
                            <tr>
                                <td><b>Patente Comercial</b></td>
                                <td>Documento emitido por autoridades municipales, según sea necesario.</td>
                                <td>Municipalidad</td>
                            </tr>
                            <tr>
                                <td><b>Documento bancario que indique el número de cuenta IBAN</b></td>
                                <td>Documento proporcionado por el banco con el número de cuenta IBAN.</td>
                                <td>Banco</td>
                            </tr>
                            <tr>
                                <td><b>CVO Producción Primaria</b></td>
                                <td>Certificado vigente para actividades pecuarias.</td>
                                <td>SENASA</td>
                            </tr>
                            <tr>
                                <td><b>CVO Distribución</b></td>
                                <td>Certificado vigente para actividades pecuarias.</td>
                                <td>SENASA</td>
                            </tr>
                            <tr>
                                <td><b>CVO Comercialización</b></td>
                                <td>Certificado vigente para actividades pecuarias.</td>
                                <td>SENASA</td>
                            </tr>
                            <tr>
                                <td><b>CVO Transformación</b></td>
                                <td>Certificado vigente para actividades pecuarias.</td>
                                <td>SENASA</td>
                            </tr>
                            <tr>
                                <td><b>Certificación extendida por el INCOPESCA</b></td>
                                <td>Certificación relacionada con productos acuícolas y pesqueros.</td>
                                <td>INCOPESCA</td>
                            </tr>
                            <tr>
                                <td><b>Nota firmada por el apoderado general o propietario de la planta</b></td>
                                <td>Documento que confirma la relación entre un productor individual y una planta de terceros.</td>
                                <td>Propietario instalaciones</td>
                            </tr>
                            <tr>
                                <td><b>Contrato de arrendamiento</b></td>
                                <td>Documento de contrato de arrendamiento, si aplica.</td>
                                <td>Propietario instalaciones</td>
                            </tr>
                            <tr>
                                <td><b>Carta de compromisos</b></td>
                                <td>Documento de compromiso para cumplir con las obligaciones del CNP como suplidor.</td>
                                <td>Solicitante. Machote</td>
                            </tr>
                            <tr>
                                <td><b>Póliza del INS</b></td>
                                <td>Recibo del ultimo periodo.</td>
                                <td>INS</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <br />

            <div class="row" id="divInfo" runat="server">
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">
                        <label for="cbBanco">Banco:</label>
                    </div>
                    <div class="col-centro-entradas">
                        <telerik:radcombobox id="cbBanco" runat="server" autopostback="True" width="100%" rendermode="Auto"  cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">Cuenta IBAN</div>
                    <div class="col-centro-entradas">
                        <input id="txtCuentaIBAN" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                    </div>
                    <div class="col-der-espacio"></div>
                </div>

                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">Tipo de Certificado</div>
                    <div class="col-centro-entradas">
                        <telerik:radcombobox id="cbTipoCertificacion" runat="server" autopostback="True" width="100%" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                        <div class="form-text">Seleccione "Ayuda" para descargar el pdf editable de la Carta de Compromiso y la Declaración Jurada</div>
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
                            <asp:label runat="server" id="lblPesoArchivo"></asp:label>
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
                            style="width: 100%; display: flex; align-items: center; justify-content: space-between;" onserverclick="btnAgregarCert_ServerClick">
                            <i class="bi bi-plus-circle-dotted" style="font-size: 1.5rem"></i>Agregar Certificado</button>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
                <br />
                <br />
                <br />
                <br />

                <telerik:radgrid
                    id="rgCertSuplidores"
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
								
								<telerik:GridTemplateColumn UniqueName="LinkTemplateColumn"  HeaderText="Eliminar">
									<ItemTemplate>
                                        <asp:LinkButton ID="eliminarCertificado" runat="server" CommandName="Select" CssClass="btn sombra-caja" OnClick="eliminarCertificado_Click1">
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
                <br />
                <br />
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas"></div>
                    <div class="col-centro-entradas">
                        <button id="btnSiguiente" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnSiguiente_ServerClick">Continuar</button>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <hr />
            </div>
        </div>
    </form>
</body>
</html>
