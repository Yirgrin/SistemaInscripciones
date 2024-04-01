<%@ page maintainscrollpositiononpostback="true" language="vb" autoeventwireup="false" codebehind="PP_Form_1_Info.aspx.vb" inherits="Formularios.PP_Form_1_Info" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Informacion General</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../Content/General.css" rel="stylesheet" />

</head>
<body>
    <form id="form" runat="server" class="justify-content-center">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <div class="container-fluid">
            <asp:image id="Encabezado" runat="server" imageurl="../images/master/Ingreso%20de%20usuario.jpg" width="100%" />
            <hr />
            <h2 class="sombra-texto">Información General</h2>
            <p>Complete los siguientes datos con sus información personal y de contacto.</p>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aquí van los mensajes de Error o Alerta! </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_ServerClick">Atrás</button>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbTipoCedula">Tipo de cédula</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbTipoCedula" runat="server" autopostback="True" width="100%" rendermode="Auto" enabled="False" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCedula">Número de cédula</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCedula" runat="server" type="text" class="form-control sombra-caja" placeholder="Digite su cédula con ceros y sin guiones" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbGenero">Género</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbGenero" runat="server" autopostback="True" width="100%" rendermode="Auto" enabled="False" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtNombre">Nombre de Empresa o Persona</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtNombre" runat="server" type="text" class="form-control sombra-caja" placeholder="Digite su nombre físico o Jurídico" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtEmail">Correo Electrónico</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtEmail" runat="server" type="email" class="form-control sombra-caja" placeholder="ejemplo@ejemplo.com" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtTelefonoFijo">Teléfono Fijo</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtTelefonoFijo" runat="server" type="tel" class="form-control sombra-caja" placeholder="Ingrese solamente números">
                    <div class="form-text">* Si no tiene rellene con: 00000000</div>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCelular">Teléfono Celular</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCelular" runat="server" type="tel" class="form-control sombra-caja" placeholder="Ingrese solamente números">
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbTipoProductor">Seleccione el Tipo de Productor</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbTipoProductor" runat="server" autopostback="True" width="100%" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtEmpresaA">Empresa Asociada</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtEmpresaA" runat="server" type="text" placeholder="-- Digite --" class="form-control sombra-caja">
                    <div class="form-text">* Nombre completo de empresa asociada</div>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Está usted registrado en el Ministerio de Hacienda?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcheckbox id="chkMH" runat="server" text="" font-bold="True" ></telerik:radcheckbox>
                    <div class="form-text">* Este es un requisito obligatorio y será validado por funcionarios del CNP</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Está usted registrado en el Ministerio de Agricultura y Ganadería?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcheckbox id="chkMAG" runat="server" text="" font-bold="True"></telerik:radcheckbox>
                    <div class="form-text">* Este es un requisito obligatorio y será validado por funcionarios del CNP</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Cuál es su estado actual con la CCSS?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbCCSS" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Se identifica con alguna de las siguientes etnias?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbEtnia" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Es usted quién genera la mayor parte de los ingresos del hogar?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbIngresosPropios" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="No" Value="0" />
                            <telerik:RadComboBoxItem runat="server" Text="Sí" Value="1" />
                        </Items>
                    </telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿La actividad agrícola es la única fuente de ingresos de su hogar/familia?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbSoloAgricola" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" culture="es-ES" emptymessage="-- Seleccione --">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="No" Value="0" />
                            <telerik:RadComboBoxItem runat="server" Text="Sí" Value="1" />
                        </Items>
                    </telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Cantidad de personas que depende de sus ingresos</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtDependientesIngresos" runat="server" type="number" max="30" min="0" class="form-control sombra-caja" placeholder="Ingrese solamente numeros">
                    <div class="form-text">* 0 para ninguno</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Estado civil</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbEstadoCivil" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Cantidad de hijos MENORES de edad</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtHijosMenores" runat="server" type="number" max="30" min="0" class="form-control sombra-caja" placeholder="Ingrese solamente numeros">
                    <div class="form-text">* 0 para ninguno</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Nivel de escolaridad</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbEscolaridad" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Tiene alguna discapacidad?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbTipoDiscapacidad" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Cuenta con carnet de CONAPDIS?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbCarnetConapdis" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --" culture="es-ES">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="No" Value="0" />
                            <telerik:RadComboBoxItem runat="server" Text="Sí" Value="1" />
                        </Items>
                    </telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbProvincia">Provincia donde reside</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbProvincia" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                    </telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbCanton">Cantón donde reside</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbCanton" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" enabled="false" emptymessage="-- Seleccione --"></telerik:radcombobox>
                    </telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbDistrito">Distrito donde reside</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbDistrito" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" enabled="false" emptymessage="-- Seleccione --"></telerik:radcombobox>
                    </telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtDireccion">Dirección exacta de residencia</label>
                </div>
                <div class="col-centro-entradas">
                    <textarea id="txtDireccion" runat="server" type="text" class="form-control sombra-caja" placeholder="[Referencia principal]  [Distancia desde la referencia] [Descripcion adicional] [Nombre del barrio, caserío o localidad]" style="height: 100px; resize: none"></textarea>
                    <div class="form-text">Ejemplo: De la Escuela Gabriel Brenes Robles, 225 metros al norte, casa azul de portón blanco, a mano izquierda, San Gabriel de Aserrí</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button id="btnSiguiente" runat="server" autopostback="True" class="btn sombra-caja" style="width: 100%" onserverclick="btnSiguiente_Click">Continuar</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>
