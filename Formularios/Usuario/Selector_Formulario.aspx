<%@ page maintainscrollpositiononpostback="true" language="vb" autoeventwireup="false" codebehind="Selector_Formulario.aspx.vb" inherits="Formularios.Selector_Formularios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Selector Formulario</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../Content/General.css" rel="stylesheet" />
</head>
<body>
    <form id="form" runat="server" class="justify-content-center">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <div class="container-fluid">
            <asp:image id="Encabezado" runat="server" imageurl="../images/master/Seleccion%20de%20formulario.jpg" width="100%" />
            <hr />
            <h2 class="sombra-texto">Selección de formulario</h2>
            <p>
                Seleccione el formulario que necesite completar
            </p>
            <h2 class="sombra-texto"></h2>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aqui van los mensajes de Error o Alerta!</div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCedula">Productor Primario</label>
                </div>
                <div class="col-centro-entradas">
                    <button class="btn sombra-caja" id="btn_ProducPrimario" runat="server" type="button" style="width: 100%" onserverclick="btn_ProducPrimarioServerClick">Formulario</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
                <br />
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtPass">Suplidor de Acopio, Procesamiento y Agroindustria</label>
                </div>
                <div class="col-centro-entradas">
                    <button class="btn sombra-caja" id="btn_Suplidores" runat="server" type="button" style="width: 100%" onserverclick="btn_Suplidores_ServerClick">Formulario</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtPass">Historial de inscripciones Productor Primario</label>
                </div>
                <div class="col-centro-entradas">
                    <button class="btn sombra-caja" id="btnConsultar" runat="server" type="button" style="width: 100%" onserverclick="btnConsultar_ServerClick">Consultar</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtPass">Historial de inscripciones Suplidor</label>
                </div>
                <div class="col-centro-entradas">
                    <button class="btn sombra-caja" id="btnConsultarS" runat="server" type="button" style="width: 100%" onserverclick="btnConsultarS_ServerClick">Consultar</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
                <br />
                <br />
                <br />  
            <hr />
       </div>
    </form>
</body>
</html>
