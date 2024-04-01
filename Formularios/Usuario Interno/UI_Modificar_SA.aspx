<%@ page language="vb" autoeventwireup="false" codebehind="UI_Modificar_SA.aspx.vb" inherits="Formularios.UI_Modificar_SA" %>

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
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aquí van los mensajes de Error o Alerta! </div>
            </div>
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja">Atrás</button>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <h4 class="sombra-texto">Información Contable</h4>
            <br />
            <div class="row">
                <div class="col-izq-espacio">Categoría de actividad principal</div>
                <div class="col-izq-etiquetas">
                    <telerik:radcombobox id="cbCategoriaPrincipal" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCategoriaPrincipal" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                    <div class="form-text">* Ingrese la nueva opción y presione agregar</div>
                </div>
                <div class="col-der-espacio">
                    <button id="btnCategoriaPrincipal" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick ="btnCategoriaPrincipal_ServerClick">Agregar</button>
                </div>
            </div>

            <br />
            <hr />
            <h4 class="sombra-texto">Certificaciones</h4>
            <br />
            <div class="row">
                <div class="col-izq-espacio">Banco</div>
                <div class="col-izq-etiquetas">
                    <telerik:radcombobox id="cbBanco" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtBanco" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                    <div class="form-text">* Ingrese la nueva opción y presione agregar</div>
                </div>
                <div class="col-der-espacio">
                    <button id="btnBanco" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnBanco_ServerClick">Agregar</button>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio">Tipo Certificado</div>
                <div class="col-izq-etiquetas">
                    <telerik:radcombobox id="cbTipoCertificacion" runat="server" autopostback="True" width="100%" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCertificacion" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                    <div class="form-text">* Ingrese la nueva opción y presione agregar</div>
                </div>
                <div class="col-der-espacio">
                    <button id="btnCertificacion" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" onserverclick="btnCertificacion_ServerClick">Agregar</button>
                </div>
            </div>
            <br />
            <br />
            <hr />
        </div>
    </form>
</body>
</html>

