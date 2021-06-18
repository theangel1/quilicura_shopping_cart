using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quilicura
{
    public partial class Contact : Page
    {
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LimpiaControles()
        {
            boxNombre.Text = string.Empty;
            boxEmail.Text = string.Empty;
            boxMensaje.Text = string.Empty;
        }
       

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6Lc5u0gUAAAAAGms8VpCs3FPMzOcql6ZW_fnhj6A";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (IsReCaptchValid())
            {
                lblMessage.InnerHtml = "<span style='color:green'>Verificacion Correcta</span>";
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("mail.importadorasantamaria.com");

                    mail.From = new MailAddress("info@importadorasantamaria.com");
                    mail.To.Add("info@importadorasantamaria.com");
                    mail.To.Add("angel.pinilla@sisgenchile.cl");
                    mail.Subject = "Contacto desde Sitio Web Quilicura";
                    mail.IsBodyHtml = true;

                    string cuerpoHtml = "<p>Se han contactado con usted mediante el sitio Web de Quilicura</p>" +
                        "<p><strong>Nombre de la Persona: </strong>" + boxNombre.Text.Trim() + "</p>" +
                        "<p><strong>Email: </strong> " + boxEmail.Text.Trim() + "</p>" +
                        "<p><strong> Fecha: </strong> " + DateTime.Now + "</p>" +
                        "<p><strong> Asunto: </strong> " + boxMensaje.Text.Trim() + "</p>" +
                        "<p>Atte.</p>" +
                        "<p><strong>Servicio Web Sisgen Chile Limitada</strong></p>" +
                        "<a href='https://www.sisgenchile.cl'>Visitar Sitio Web Sisgen Chile Limitada</a>";

                    mail.Body = cuerpoHtml;

                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("info@importadorasantamaria.com", "mariaspa2018");

                    SmtpServer.Send(mail);
                    ShowMessage("Mensaje enviado Exitosamente... Limpiando Controles.", MessageType.Success);
                    Response.Write("<script language='javascript'>alert('Mensaje enviado Exitosamente... Limpiando Controles!!!')</script>");
                    LimpiaControles();
                }
                catch (Exception ex)
                {
                    ShowMessage("Error con el mensaje... Limpiando Controles.", MessageType.Error);
                    labelError.Text = ex.ToString();
                }
            }
            else
                lblMessage.InnerHtml = "<span style='color:red'>Captcha verification failed</span>";
        }
    }
}