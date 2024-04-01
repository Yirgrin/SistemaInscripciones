<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SA_Form_6_Final.aspx.vb" Inherits="Formularios.SA_Form_6_Final" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Inscripción finalizada</title>
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
            <h2 class="sombra-texto"></h2>
            <br />
            <h3>Ha finalizado su inscripción con éxito</h3>
            <hr />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-centro-50">
                        <span>La solicitud de inscripción se realizó bajo el siguiente número de referencia # </span>
                        <asp:label id="lblInscripcion" runat="server" style="font-weight:bold" text="#"></asp:label>
                        <span>y será traslada a los agentes de servicio del Consejo Nacional de Producción para su debida validación.</span>
                        <p></p>
                        <p>Cualquier consulta o duda del proceso favor comunicarse al 2257-9355</p>
                        <hr />
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button class="btn sombra-caja" id="btn_regresarCNP" runat="server" type="button" style="width: 100%" onserverclick="btn_regresarCNP_ServerClick">Volver a la página principal</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
        </div>
    </form>
</body>
</html>

