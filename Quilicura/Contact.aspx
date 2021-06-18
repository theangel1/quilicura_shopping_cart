<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Quilicura.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }


        var renderRecaptcha = function () {
            grecaptcha.render('ReCaptchContainer', {
                'sitekey': '6Lc5u0gUAAAAALvzCkIDrNrur46WUtFmQx3MGdMH',
                'callback': reCaptchaCallback,
                theme: 'dark', //light or dark    
                type: 'image',// image or audio    
                size: 'normal'//normal or compact    
            });
        };

        var reCaptchaCallback = function (response) {
            if (response !== '') {
                jQuery('#lblMessage').css('color', 'green').html('Success');
            }
        };

        jQuery('button[type="button"]').click(function (e) {
            var message = 'Please checck the checkbox';
            if (typeof (grecaptcha) != 'undefined') {
                var response = grecaptcha.getResponse();
                (response.length === 0) ? (message = 'Falló la verificación') : (message = 'Success!');
            }
            jQuery('#lblMessage').html(message);
            jQuery('#lblMessage').css('color', (message.toLowerCase() == 'Logrado!') ? "green" : "red");
        });

    </script>
    <hr />
    <h2 style="color:black"><%: Title %></h2>
    <p style="color:black">Para cualquier tipo de dudas o cotizaciones, puedes contactarnos a través del siguiente formulario, número telefónico +56 9 98277611 o Correo Electrónico:<a href="mailto:info@importadorasantamaria.com"> <i class="fa fa-envelope"></i>info@importadorasantamaria.com</a></p>

    <asp:Panel ID="PanelFormulario" runat="server" >
        <table style="width: 100%;">
            <tr>
                <th style="width: 495px;color:black" >Nombre</th>
                <td></td>
            </tr>
            <tr>
                <td style="width: 495px;color:black">
                    <asp:TextBox ID="boxNombre" runat="server" ToolTip="Ingrese su nombre" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Debe ingresar un nombre." ForeColor="Red" ControlToValidate="boxNombre"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <th style="width: 495px;color:black">Email</th>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td style="width: 495px">
                    <asp:TextBox ID="boxEmail" runat="server" CssClass="form-control" ToolTip="Ingresar Email" ></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="boxEmail" Display="Dynamic" ErrorMessage="Debe ingresar Email" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reValEmail" runat="server" ControlToValidate="boxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Static" ErrorMessage="Debe ingresar un email valido" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th style="width: 495px;color:black">Mensaje&nbsp;</th>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td style="width: 495px">
                    <asp:TextBox ID="boxMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" ToolTip="Ingrese su mensaje" placeholder="Escriba su mensaje" MaxLength="30"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar un mensaje" ForeColor="Red" ControlToValidate="boxMensaje"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="boxMensaje" ValidationExpression="^[\s\S]{10,30}$" Display="Dynamic" ErrorMessage="Debe ingresar un mínimo de 10 caracteres y máximo 30" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="ReCaptchContainer"></div>
                    <label id="lblMessage" runat="server" clientidmode="static" cssclass="form-control"></label>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Enviar" CssClass="btn btn-outline-warning" OnClick="Button1_Click1" />
                    <br />
                    <asp:Label ID="labelError" runat="server" Text=""></asp:Label>

                </td>
            </tr>

        </table>
        <asp:Panel ID="alert_container" runat="server" CssClass="messagealert" ClientIDMode="Static"></asp:Panel>
    </asp:Panel>

</asp:Content>
