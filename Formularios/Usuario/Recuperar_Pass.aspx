<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Recuperar_Pass.aspx.vb" Inherits="Formularios.Recuperar_Pass" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Recuperar Contraseña</title>
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
            <h2 class="sombra-texto">Recuperar Contraseña</h2>
            <p>Para configurar una nueva contraseña, por favor complete todos los pasos que se le solicitan</p>
            <div class="row">
                <div id="txtError" runat="server" class="alert alert-danger sombra-caja" role="alert"></div>
            </div>
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
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">
                    <label for="txtCedula">Número de cédula</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtCedula" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" />
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
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
                                    <label id="lblValorPregunta1" runat="server" autopostback="True" hidden></label>
                                </div>
                                <div class="form-text" id="infoPreguntas">
                                    *Para continuar con el proceso recuperación de contraseña, responda las siguientes 5 preguntas de seguridad con la misma 
                                    información que proporcionó cuando registró su usuario.
                                     Haga clic en el botón "Siguiente" después de responder cada pregunta.
                                </div>

                                <div class="d-flex justify-content-end">
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="next">Siguiente</button>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <div class="form-floating mb-3" style="text-align: left">
                                    <input runat="server" autopostback="True" type="text" class="form-control sombra-caja" id="txtPregunta2" placeholder="txtPregunta2" />
                                    <label id="lblPregunta2" runat="server" autopostback="True" for="txtPregunta2"></label>
                                    <label id="lblValorPregunta2" runat="server" autopostback="True" hidden></label>
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
                                    <label id="lblValorPregunta3" runat="server" autopostback="True" hidden></label>
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
                                    <label id="lblValorPregunta4" runat="server" autopostback="True" hidden></label>
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
                                    <label id="lblValorPregunta5" runat="server" autopostback="True" hidden></label>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button class="btn sombra-caja" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">Anterior</button>
                                    <button class="btn sombra-caja" id="btnVerificar" runat="server" type="button" onserverclick="btnVerificar_ServerClick">Registrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row" id="divNuevaPass" runat="server">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Nueva Contraseña</div>
                <div class="col-centro-entradas">
                    <input id="txtNuevaPass" runat="server" autopostback="True" type="text" class="form-control sombra-caja" />
                    <div class="form-text" id="infoPass">* Debe ingresar una contraseña de entre 7 y 15 carácteres que contenga al menos un dígito numérico, mayúsculas, minúsculas y un carácter especial (!@#$%^&*()_+{}\[\]:;<>,.?~\\/-).</div>
                </div>

                <div class="col-der-espacio"></div>
                <br />
                <br />
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas">Repita su contraseña</div>
                <div class="col-centro-entradas">
                    <input id="txtRepitePass" runat="server" autopostback="True" type="text" class="form-control sombra-caja" />
                </div>
                <div class="col-der-espacio"></div>
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-izq-espacio"></div>
                    <div class="col-izq-etiquetas"></div>
                    <div class="col-centro-entradas">
                        <button class="btn sombra-caja" id="btnConfirmar" runat="server" type="button" style="width: 100%" onserverclick="btnConfirmar_ServerClick">Confirmar</button>
                    </div>
                    <div class="col-der-espacio"></div>
                </div>
            </div>
            <hr />
    </form>
</body>
</html>
