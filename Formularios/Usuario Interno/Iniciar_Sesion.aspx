<%@ Page MaintainScrollPositionOnPostback="true" Language="vb" AutoEventWireup="false" CodeBehind="Iniciar_Sesion.aspx.vb" Inherits="Formularios.Iniciar_Sesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Inicio Sesión</title>
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
            <h2 class="sombra-texto">Iniciar Sesión</h2>
            <p>Iniciar sesión como funcionario CNP</p>
            <h2 class="sombra-texto"></h2>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aquí van los mensajes de Error o Alerta!</div>
            </div>
            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnCrearCuenta" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnCrearCuenta_ServerClick">Crear Cuenta</button>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCedula">Usuario</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtUsuario" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtPass">Contraseña</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtPass" runat="server" type="password" class="form-control sombra-caja" placeholder="-- Digite --" />
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row" id="divContra" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <p><a href="../Usuario/Recuperar_Pass.aspx" class="link-underline-primary link-offset-3">¿Olvidó su contraseña?</a></p>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row" id="rowPregunta" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtrespuesta">Pregunta de seguridad</label>
                </div>
                <div class="col-centro-entradas">
                    <div class="form-floating mb-3">
                        <input runat="server" autopostback="True" type="text" class="form-control sombra-caja" id="txtRespuesta" placeholder="txtPregunta" />
                        <label id="lblValorPregunta" runat="server" autopostback="True" hidden></label>
                        <label id="lblPregunta" runat="server" autopostback="True" for="txtPregunta"></label>
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <div class="d-flex justify-content-end">
                        <button class="btn sombra-caja" id="btnValidar" runat="server" type="button" style="width: 100%" onserverclick="btnValidar_ServerClick">Validar</button>
                        <button class="btn sombra-caja" id="btnIngresar" runat="server" type="button" style="width: 100%" onserverclick="btnIngresar_ServerClick">Ingresar</button>
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <br />
            
            <div class="row" id="divUsuario" runat="server">
                <div class="col-izq-espacio">
                    <label for="txtrespuesta">Ingresar como usuario</label>
                    <p><a href="../Usuario/Ingreso.aspx" class="link-underline-primary link-offset-3"><b>Acceda aquí</b></a></p>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <hr />
        </div>
    </form>
</body>
</html>
