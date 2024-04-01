<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Error.aspx.vb" Inherits="Formularios._Error" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Aviso</title>
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

            <div class="row">
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-centro-50">
                        <span><b>Parece que usted ya envió el formulario. </b>
                            <br />
                            <br />
                            Su inscripción pudo ser aceptada o estar en proceso de validación.
                            <br />
                            Puede verificar el estado de su proceso en el apartado de <b>Consultar Historial.</b>
                        </span>
                            <br />
                            <br />
                        <p>Cualquier consulta o duda favor comunicarse al <b>2257-9355</b></p>

                    </div>
                    <div class="col-der-espacio"></div>
                </div>
            </div>
            <hr />
        </div>

    </form>
</body>
</html>
