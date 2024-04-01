<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VW_Inscrip_2_RLSA.aspx.vb" Inherits="Formularios.VW_Inscrip_2_RLSA" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Representante Legal</title>
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
            <h2 class="sombra-texto">Información del Representante Legal</h2>
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
            <br />
            <div class="row">
                <div id="txtSinRL" runat="server" class="p-3 text-secondary-emphasis bg-secondary-subtle border border-secondary-subtle rounded-3">Aquí van los mensajes de Error o Alerta! </div>
            </div>

            <div id="divSinRL" runat="server">
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">
                        <label for="txtCedula">Número de Cédula</label>
                    </div>
                    <div class="col-centro-entradas">
                        <input id="txtCedula" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">
                        <label for="cbGenero">Seleccione el Género</label>
                    </div>
                    <div class="col-centro-entradas">
                        <input id="txtGenero" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">
                        <label for="txtNombre">Nombre Completo</label>
                    </div>
                    <div class="col-centro-entradas">
                        <input id="txtNombre" runat="server" type="text" class="form-control sombra-caja" placeholder="" disabled>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">
                        <label for="txtEmail">Correo Electrónico</label>
                    </div>
                    <div class="col-centro-entradas">
                        <input id="txtEmail" runat="server" type="email" class="form-control sombra-caja" placeholder="" disabled>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">
                        <label for="txtTelefonoFijo">Teléfono Fijo</label>
                    </div>
                    <div class="col-centro-entradas">
                        <input id="txtTelefonoFijo" runat="server" type="tel" class="form-control sombra-caja" placeholder="" disabled>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas">
                        <label for="txtCelular">Teléfono Celular</label>
                    </div>
                    <div class="col-centro-entradas">
                        <input id="txtCelular" runat="server" type="tel" class="form-control sombra-caja" placeholder="" disabled>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button id="btnSiguiente" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnSiguiente_ServerClick">Siguiente Página</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>


