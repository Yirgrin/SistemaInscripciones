<%@ Page maintainscrollpositiononpostback="true" Language="vb" AutoEventWireup="false" CodeBehind="SA_Form_5_Aviso.aspx.vb" Inherits="Formularios.SA_Form_5_Aviso" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Enviar Solicitud</title>
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
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_ServerClick">Atrás</button>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <h5 style="text-align: center; color: #282c54; font-weight: bold;">Por favor, antes de hacer clic en el botón "Enviar Solicitud".<br />
                Tenga en cuenta lo siguiente:</h5>
            <br />
            <br />
            <h6 style="text-align: left">1. La información proporcionada en este formulario será almacenada y procesada por el CNP 
                de acuerdo con las leyes y regulaciones de protección de datos.</h6>
            <br />
            <h6 style="text-align: left">2. En caso de ser detectada alguna incongruencia o falsedad en la información proporcionada, 
                solicitud puede ser rechazada hasta que se corrijan los datos.</h6>
            <br />
            <h6 style="text-align: left">3. Una vez que haga clic en "Enviar Solicitud", no podrá volver a editar su solicitud hasta que la misma sea aprobada.
                Esta será enviada a los funcionarios del CNP para su revisión y procesamiento.</h6>
            <br />
            <br />
            <div style="text-align: center">
                <telerik:radcheckbox id="chkAceptarTerminos" runat="server" text="He leído y comprendido la información anterior y certifico que la información proporcionada es precisa y veráz."></telerik:radcheckbox>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div style="width: 50%">
                    <button id="btnSiguiente" runat="server" autopostback="True" style="width: 100%" class="btn sombra-caja" disabled onserverclick="btnSiguiente_ServerClick">Enviar Solicitud</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <hr />
        </div>
    </form>
</body>
</html>
