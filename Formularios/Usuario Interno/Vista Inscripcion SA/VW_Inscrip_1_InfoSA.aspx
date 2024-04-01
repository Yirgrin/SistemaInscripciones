<%@ Page maintainscrollpositiononpostback="true" Language="vb" AutoEventWireup="false" CodeBehind="VW_Inscrip_1_InfoSA.aspx.vb" Inherits="Formularios.VW_Inscrip_1_InfoSA" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Vista Información General</title>
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
                <div class="col-izq-espacio">
                    <button id="btnAtras" runat="server" autopostback="True" class="btn sombra-caja" onserverclick="btnAtras_ServerClick1">Atrás</button>
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
                    <input id="txtEmail" runat="server" type="email" class="form-control sombra-caja" placeholder="ejemplo@ejemplo.com" disabled>
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
                    <label for="txtNombre">Actividad registrada en el Ministerio de Hacienda</label>
                </div>
                <div class="col-centro-entradas">
                    <input id="txtActividadMH" runat="server" type="text" class="form-control sombra-caja" placeholder="-- Digite --" disabled>
                </div>
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
                    <textarea id="txtDireccion" runat="server" type="text" class="form-control sombra-caja" placeholder="" style="height: 100px; resize: none" disabled></textarea>
                   
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-izq-espacio"></div>
                <div class="col-izq-etiquetas"></div>
                <div class="col-centro-entradas">
                    <button id="btnContinuar" runat="server" autopostback="True" class="btn sombra-caja" style="width: 100%" onserverclick="btnContinuar_ServerClick"> Siguiente Página</button>
                </div>
                <div class="col-der-espacio"></div>
            </div>
            <hr />
        </div>
    </form>
</body>
</html>

