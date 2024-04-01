<%@ page maintainscrollpositiononpostback="true" language="vb" autoeventwireup="false" codebehind="VW_Inscrip_1_InfoPP.aspx.vb" inherits="Formularios.VW_Inscrip_1_InfoPP" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Vista Informacion General</title>
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
            <h2 class="sombra-texto">Información General</h2>
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
                    <input id="txtTipoCedula" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCedula">Número de cédula</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCedula" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbGenero">Género</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtGenero" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtNombre">Nombre de Empresa o Persona</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtNombre" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtEmail">Correo Electrónico</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtEmail" runat="server" type="email" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtTelefonoFijo">Teléfono Fijo</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtTelefonoFijo" runat="server" type="tel" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCelular">Teléfono Celular</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCelular" runat="server" type="tel" class="form-control sombra-caja" placeholder="" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbTipoProductor">Seleccione el Tipo de Productor</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtTipoProductor" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtEmpresaA">Empresa Asociada</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtEmpresaA" runat="server" type="text" placeholder="-- Digite --" class="form-control sombra-caja" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Está usted registrado en el Ministerio de Hacienda?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcheckbox id="chkMH" runat="server" text="" font-bold="True" disabled></telerik:radcheckbox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Está usted registrado en el Ministerio de Agricultura y Ganadería?</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcheckbox id="chkMAG" runat="server" text="" font-bold="True" disabled></telerik:radcheckbox>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Cuál es su estado actual con la CCSS?</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCCSS" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Se identifica con alguna de las siguientes etnias?</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtEtnia" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"> </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Es usted quién genera la mayor parte de los ingresos del hogar?</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtIngresos" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿La actividad agrícola es la única fuente de ingresos de su hogar/familia?</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtSoloAgricola" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Cantidad de personas que depende de sus ingresos</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtDependientesIngresos" runat="server" type="number" max="30" min="0" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Estado civil</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtEstadoCivil" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Cantidad de hijos MENORES de edad</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtHijosMenores" runat="server" type="number" max="30" min="0" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Nivel de escolaridad</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtEscolaridad" runat="server" type="text" max="30" min="0" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Tiene alguna discapacidad?</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtDiscapacidad" runat="server" type="text" max="30" min="0" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>¿Cuenta con carnet de CONAPDIS?</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCarnetConapdis" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbProvincia">Provincia donde reside</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtProvincia" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbCanton">Cantón donde reside</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCanton" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbDistrito">Distrito donde reside</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtDistrito" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtDireccion">Dirección exacta de residencia</label>
                </div>
                <div class="col-centro-entradas">
                    <textarea id="txtDireccion" runat="server" type="text" class="form-control sombra-caja" placeholder="[Referencia principal]  [Distancia desde la referencia] [Descripcion adicional] [Nombre del barrio, caserío o localidad]" style="height: 100px; resize: none" disabled></textarea>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button id="btnSiguiente" runat="server" autopostback="True" class="btn sombra-caja" style="width: 100%" onserverclick="btnSiguiente_ServerClick">Siguiente Página</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>
