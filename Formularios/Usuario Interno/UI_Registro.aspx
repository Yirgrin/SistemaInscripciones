<%@ Page MaintainScrollPositionOnPostback="true" Language="vb" AutoEventWireup="false" CodeBehind="UI_Registro.aspx.vb" Inherits="Formularios.UI_Registro" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Registro</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="../Content/General.css" rel="stylesheet" />
</head>
<body>
    <form id="form" runat="server" class="justify-content-center">
        <telerik:radscriptmanager id="RadScriptManager1" runat="server"></telerik:radscriptmanager>
        <div class="container-fluid">
            <asp:Image ID="Encabezado" runat="server" ImageUrl="../images/master/registro%20de%20usuario.jpg" Width="100%" />
            <hr />
            <h2 class="sombra-texto"></h2>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert">Aqui van los mensajes de Error o Alerta!</div>
            </div>

            <div class="row">
                <div class="col-izq-espacio">
                    <button id="btnIniciarSesion" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnIniciarSesion_ServerClick">Iniciar Sesión</button>
                </div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas"></div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Número de cédula</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCedula" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                    <div class="form-text">
                        * Ingrese su cédula sin guiones ni espacios. Asegúrese de incluir todos los ceros necesarios
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbGenero">Seleccione el género</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbGenero" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                </div>
                <div class="col-der-espacio"></div>
            </div>


            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtNombre">Nombre</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtNombre" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                    <div class="form-text" id="infoNombre">
                        * Ingrese su nombre completo. Incluya sus dos nombres y dos apellidos. 
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtUsuario">Usuario</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtUsuario" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                    <div class="form-text" id="infoUsuario">
                        * Ingrese su usuario CNP. 
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtEmail">Correo electrónico</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtEmail" runat="server" type="email" class="form-control sombra-caja" aria-describedby="infoEmail" placeholder="-- Digite --" />
                    <div class="form-text" id="infoEmail">
                        * Ingrese su correo CNP. 
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbRol">Rol</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbRoles" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                    <div class="form-text" id="cbRol">
                    </div>
                </div>
                <div class="col-der-espacio"></div>

            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="cbRegion">Región</label>
                </div>
                <div class="col-centro-entradas">
                    <telerik:radcombobox id="cbRegiones" runat="server" autopostback="True" width="100%" rendermode="Auto" cssclass="sombra-caja" emptymessage="-- Seleccione --"></telerik:radcombobox>
                    <div class="form-text" id="cbRegion">
                        * Seleccione la región en la que se encuentra su sede CNP. 
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>

            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtPass1">Digite su contraseña</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtPass1" runat="server" type="password" class="form-control sombra-caja" aria-describedby="infoPass" placeholder="-- Digite --" />
                    <div class="form-text" id="infoPass">* Debe ingresar una contraseña de entre 7 y 15 carácteres que contenga al menos un dígito numérico, mayúsculas, minúsculas y un carácter especial (!@#$%^&*()_+{}\[\]:;<>,.?~\\/-).</div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtPass2">Repita su contraseña</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtPass2" runat="server" type="password" class="form-control sombra-caja" placeholder="-- Digite --" />
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label>Preguntas de seguridad</label>
                </div>
                <div class="col-centro-entradas">

                    <div id="carouselExample" class="carousel carousel-dark slide" aria-describedby="infoPreguntas">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <div class="form-floating mb-3">
                                    <input runat="server" autopostback="True" type="text" class="form-control sombra-caja" id="txtPregunta1" placeholder="txtPregunta1" />
                                    <label id="lblPregunta1" runat="server" autopostback="True" for="txtPregunta1"></label>
                                </div>
                                <div class="form-text" id="infoPreguntas">
                                    *Para continuar con el proceso de registro de su usuario, responda las siguientes 5 preguntas de seguridad. 
                                     Haga clic en el botón "Siguiente" después de responder cada una de ellas.
                                </div>

                                <div class="d-flex justify-content-end">
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="next">Siguiente</button>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <div class="form-floating mb-3" style="text-align: left">
                                    <input runat="server" autopostback="True" type="text" class="form-control sombra-caja" id="txtPregunta2" placeholder="txtPregunta2" />
                                    <label id="lblPregunta2" runat="server" autopostback="True" for="txtPregunta2"></label>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">Anterior</button>
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="next">Siguiente</button>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <div class="form-floating mb-3" style="text-align: left">
                                    <input runat="server" autopostback="True" type="text" class="form-control sombra-caja" id="txtPregunta3" placeholder="txtPregunta3" />
                                    <label id="lblPregunta3" runat="server" autopostback="True" for="txtPregunta3"></label>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">Anterior</button>
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="next">Siguiente</button>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <div class="form-floating mb-3" style="text-align: left">
                                    <input runat="server" autopostback="True" type="text" class="form-control sombra-caja" id="txtPregunta4" placeholder="txtPregunta4" />
                                    <label id="lblPregunta4" runat="server" autopostback="True" for="txtPregunta4"></label>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">Anterior</button>
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="next">Siguiente</button>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <div class="form-floating mb-3" style="text-align: left">
                                    <input runat="server" autopostback="True" type="text" class="form-control sombra-caja" id="txtPregunta5" placeholder="txtPregunta5" />
                                    <label id="lblPregunta5" runat="server" autopostback="True" for="txtPregunta5"></label>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">Anterior</button>
                                    <button class="btn sombra-caja" id="btnRegistrar" runat="server" type="button" onserverclick="btnRegistrar_ServerClick">Registrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>

