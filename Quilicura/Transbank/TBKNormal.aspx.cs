using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webpay.Transbank.Library;
using Webpay.Transbank.Library.Wsdl.Normal;
using Webpay.Transbank.Library.Wsdl.Nullify;
using Quilicura.Models;


namespace Quilicura.Transbank
{
    public partial class TBKNormal : System.Web.UI.Page
    {
        private string message;
        string buyOrder;        
        //private Dictionary<string, string> certificado = Transbank. CertNormal.Certificate();
        private Dictionary<string, string> request = new Dictionary<string, string>();
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                #region Region de Configuraciones y diccionario
                var logFileNameWithPath = HttpContext.Current.Server.MapPath(@"~\Content\597020000541\");
                Configuration configuration = new Configuration
                {
                    Environment = "INTEGRACION",
                    CommerceCode = "597020000541",
                    PublicCert = logFileNameWithPath+ "tbk.pem",
                    WebpayCert = logFileNameWithPath + "597020000541.pfx",
                    Password = "transbank123",
                    
                };               

                Webpay.Transbank.Library.Webpay webpay = new Webpay.Transbank.Library.Webpay(configuration);
                String httpHost = HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
                String selfURL = HttpContext.Current.Request.ServerVariables["URL"].ToString();               
                string action = !String.IsNullOrEmpty(HttpContext.Current.Request.QueryString["action"]) ? HttpContext.Current.Request.QueryString["action"] : "init";

                /** Crea URL de Aplicación */
                string sample_baseurl = "https://" + httpHost + selfURL;
               
                /** Crea Dictionary con descripción */
                Dictionary<string, string> description = new Dictionary<string, string>();

                description.Add("VD", "Venta Deb&iacute;to");
                description.Add("VN", "Venta Normal");
                description.Add("VC", "Venta en cuotas");
                description.Add("SI", "cuotas sin inter&eacute;s");
                description.Add("S2", "2 cuotas sin inter&eacute;s");
                description.Add("NC", "N cuotas sin inter&eacute;s");

                /** Crea Dictionary con codigos de resultado */
                Dictionary<string, string> codes = new Dictionary<string, string>();

                codes.Add("0", "Transacci&oacute;n aprobada");
                codes.Add("-1", "Rechazo de transacci&oacute;n");
                codes.Add("-2", "Transacci&oacute;n debe reintentarse");
                codes.Add("-3", "Error en transacci&oacute;n");
                codes.Add("-4", "Rechazo de transacci&oacute;n");
                codes.Add("-5", "Rechazo por error de tasa");
                codes.Add("-6", "Excede cupo m&aacute;ximo mensual");
                codes.Add("-7", "Excede l&iacute;mite diario por transacci&oacute;n");
                codes.Add("-8", "Rubro no autorizado");

                HttpContext.Current.Response.Write("<p style='font-weight: bold; font-size: 200%;'>Webpay - Transacci&oacute;n Normal</p>");
                #endregion

                using (var context = new ProductoContext())
                {
                    var id = context.Database.SqlQuery<decimal>("select IDENT_CURRENT ('dbo.Orders')+1").First();
                    buyOrder = id.ToString();
                }
                string tx_step = "";
                switch (action)
                {
                    default:
                        tx_step = "Init";
                        try
                        {
                            decimal amount = 0;
                            //HttpContext.Current.Response.Write("<p style='font-weight: bold; font-size: 150%;'>Step: " + tx_step + "</p>");                           

                            /** Monto de la transacción */
                            if (Session["payment_amt"] != null)
                            {
                                amount = Convert.ToDecimal(Session["payment_amt"]);
                            }                          

                            string sessionId = User.Identity.Name;
                            string urlReturn = sample_baseurl + "?action=result";
                            string urlFinal = sample_baseurl + "?action=end";                                                      

                            request.Add("amount", amount.ToString());
                            request.Add("buyOrder", buyOrder.ToString());
                            request.Add("sessionId", sessionId.ToString());
                            request.Add("urlReturn", urlReturn.ToString());
                            request.Add("urlFinal", urlFinal.ToString());

                            /** Ejecutamos metodo initTransaction desde Libreria */
                            wsInitTransactionOutput result = webpay.getNormalTransaction().initTransaction(amount, buyOrder, sessionId, urlReturn, urlFinal);
                            
                            /** Verificamos respuesta de inicio en webpay */
                            if (result.token != null && result.token != "")
                            {
                                message = "<br/><div class='alert alert-success' role='alert'>Sesion iniciada con exito en Webpay</div>";
                            }
                            else
                            {
                                message = "<br/><div class='alert alert-success' role='alert'>Webpay no disponible</div>";
                            }
                           
                            //HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightyellow;'><strong>request</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(request) + "</p>");
                            //HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightgrey;'><strong>result</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(result) + "</p>");                       
                            

                            //Formulario de accion!!!
                            HttpContext.Current.Response.Write("<div id='TitleContent' style='text-align:center'>" +
                            "<img id='Image1' src ='../img/LOGOS-04.png' BorderStyle='None' Width='300' /></ div >");
                            HttpContext.Current.Response.Write("" + message + "</br></br>");

                            HttpContext.Current.Response.Write("<form action=" + result.url + " method='post'><input type='hidden' name='token_ws' value=" + result.token + "><input type='submit' class='btn btn-dark' value='Ir a portal de pagos &raquo;'></form>");


                        }
                        catch (Exception ex)
                        {
                            
                            HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightyellow;'><strong>request</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(request) + "</p>");
                            HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightgrey;'><strong>result</strong></br></br> Ocurri&oacute; un error en la transacci&oacute;n (Validar correcta configuraci&oacute;n de parametros). " + ex.Message + "</p>");
                            
                            Logica.ExceptionUtility.LogException(ex, "TBK Normal en cs");
                        }

                        break;

                    case "result":
                        tx_step = "Get Result";
                        try
                        {
                            //HttpContext.Current.Response.Write("<p style='font-weight: bold; font-size: 150%;'>Step: " + tx_step + "</p>");

                            /** Obtiene Información POST */
                            string[] keysPost = Request.Form.AllKeys;
                            /** Token de la transacción */
                            string token = Request.Form["token_ws"];
                            request.Add("token", token.ToString());
                            transactionResultOutput result = webpay.getNormalTransaction().getTransactionResult(token);

                            //HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightyellow;'><strong>request</strong></br></br> " + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(request) + "</p>");
                            //HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightgrey;'><strong>result</strong></br></br> " + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(result) + "</p>");
                            #region SAVE BD
                            //Empiezo a grabar en base de datos
                            var oc = new OrderTBK
                            {
                                OrderId = int.Parse(buyOrder),
                                AccountingDate = result.accountingDate,
                                SessionID = result.sessionId,
                                TransactionDate = result.transactionDate,
                                CardNumber = result.cardDetail.cardNumber,
                                CardExpirationDate = result.cardDetail.cardExpirationDate,
                                VCI = result.VCI,
                                CommerceCode = result.detailOutput[0].commerceCode,
                                PaymentTypeCode = result.detailOutput[0].paymentTypeCode,
                                AuthorizationCode = result.detailOutput[0].authorizationCode,
                                ResponseCode = result.detailOutput[0].responseCode,
                                Total =  (double)result.detailOutput[0].amount
                            };

                            ProductoContext _db = new ProductoContext();
                            _db.OrdenesTBK.Add(oc);
                            _db.SaveChanges();

                            //luego añado el detalle

                            using (Logica.ShoppingCartActions usersShoppingCart = new Logica.ShoppingCartActions())
                            {
                                List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

                                // Add OrderDetail information to the DB for each product purchased.
                                for (int i = 0; i < myOrderList.Count; i++)
                                {
                                    // Create a new OrderDetail object.
                                    var myOrderDetail = new OrderDetailTBK();
                                    myOrderDetail.OrderId = oc.OrderId;
                                    myOrderDetail.Username = User.Identity.Name;
                                    myOrderDetail.ProductId = myOrderList[i].ProductoID;
                                    myOrderDetail.Quantity = myOrderList[i].Cantidad;
                                    myOrderDetail.UnitPrice = myOrderList[i].Producto.Precio;

                                    // Add OrderDetail to DB.
                                    _db.OrderDetailsTBK.Add(myOrderDetail);
                                    _db.SaveChanges();
                                }                              

                                // Display Order information.
                                List<OrderTBK> orderList = new List<OrderTBK>();
                                orderList.Add(oc);                               

                            }

                            #endregion

                            if (result.detailOutput[0].responseCode == 0)
                            {
                                HttpContext.Current.Response.Write("<div id='TitleContent' style='text-align:center'>" +
                                "<img id='Image1' src ='../img/LOGOS-04.png' BorderStyle='None' Width='300' /></ div >");
                                message = "<div class='alert alert-success' role='alert'>Pago ACEPTADO por webpay</div>";

                                HttpContext.Current.Response.Write("<script>localStorage.setItem('authorizationCode', " + result.detailOutput[0].authorizationCode + ")</script>");
                                HttpContext.Current.Response.Write("<script>localStorage.setItem('commercecode', " + result.detailOutput[0].commerceCode + ")</script>");
                                HttpContext.Current.Response.Write("<script>localStorage.setItem('amount', " + result.detailOutput[0].amount + ")</script>");
                                HttpContext.Current.Response.Write("<script>localStorage.setItem('buyOrder', " + result.detailOutput[0].buyOrder + ")</script>");

                            }
                            else
                            {
                                HttpContext.Current.Response.Write("<div id='TitleContent' style='text-align:center'>" +
                                "<img id='Image1' src ='../img/LOGOS-04.png' BorderStyle='None' Width='300' /></ div >");
                                message = "<div class='alert alert-danger' role='alert'>Pago RECHAZADO por webpay)</div> [Codigo]=> " + result.detailOutput[0].responseCode + " [Descripcion]=> " + codes[result.detailOutput[0].responseCode.ToString()];
                            }

                            HttpContext.Current.Response.Write(message + "</br></br>");
                            HttpContext.Current.Response.Write("<form action=" + result.urlRedirection + " method='post'><input type='hidden' name='token_ws' value=" + token + "><input type='submit' class='btn btn-dark' value='Ver Voucher &raquo;'></form>");
                        }
                        catch (Exception ex)
                        {
                            //HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightyellow;'><strong>request</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(request) + "</p>");
                            //HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightgrey;'><strong>result</strong></br></br> Ocurri&oacute; un error en la transacci&oacute;n (Validar correcta configuraci&oacute;n de parametros). " + ex.Message + "</p>");
                            Logica.ExceptionUtility.LogException(ex, "On catch de Estado de Pago");
                        }

                        break;

                    case "end":
                        tx_step = "End";
                        try
                        {

                            //HttpContext.Current.Response.Write("<p style='font-weight: bold; font-size: 150%;'>Step: " + tx_step + "</p>");

                            request.Add("", "");

                            //HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightyellow;'><strong>request</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(request) + "</p>");
                            //HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightgrey;'><strong>result</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Request.Form["token_ws"]) + "</p>");

                            message = "<div class='alert alert-info' role='alert'>Transacci&oacute;n Finalizada</div>";
                            HttpContext.Current.Response.Write(message + "</br></br>");

                            //string next_page = "?action=nullify";
                            /*
                                                        HttpContext.Current.Response.Write("<form action=" + next_page + " method='post'><input type='hidden' name='commercecode' id='commercecode' value=''><input type='hidden' name='authorizationCode' id='authorizationCode' value=''><input type='hidden' name='amount' id='amount' value=''><input type='hidden' name='buyOrder' id='buyOrder' value=''><input type='submit' value='Anular Transacci&oacute;n &raquo;'></form>");
                                                        HttpContext.Current.Response.Write("<script>var commercecode = localStorage.getItem('commercecode');document.getElementById('commercecode').value = commercecode;</script>");
                                                        HttpContext.Current.Response.Write("<script>var authorizationCode = localStorage.getItem('authorizationCode');document.getElementById('authorizationCode').value = authorizationCode;</script>");
                                                        HttpContext.Current.Response.Write("<script>var amount = localStorage.getItem('amount');document.getElementById('amount').value = amount;</script>");
                                                        HttpContext.Current.Response.Write("<script>var buyOrder = localStorage.getItem('buyOrder');document.getElementById('buyOrder').value = buyOrder;</script>");
                                                        */
                            HttpContext.Current.Response.Write("<a class='btn btn-primary' href='../Default.aspx'>Volver al Outlet</a>");
                        }
                        catch (Exception ex)
                        {
                            HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightyellow;'><strong>request</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(request) + "</p>");
                            HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightgrey;'><strong>result</strong></br></br> Ocurri&oacute; un error en la transacci&oacute;n (Validar correcta configuraci&oacute;n de parametros). " + ex.Message + "</p>");
                        }

                        break;

                    case "nullify":

                        tx_step = "nullify";

                        try
                        {

                            HttpContext.Current.Response.Write("<p style='font-weight: bold; font-size: 150%;'>Step: " + tx_step + "</p>");

                            /** Obtiene Información POST */
                            string[] keysNullify = Request.Form.AllKeys;

                            /** Codigo de Comercio */
                            string commercecode = Request.Form["commercecode"];

                            /** Código de autorización de la transacción que se requiere anular */
                            string authorizationCode = Request.Form["authorizationCode"];

                            /** Monto autorizado de la transacción que se requiere anular */
                            decimal authorizedAmount = Int64.Parse(Request.Form["amount"]);

                            /** Orden de compra de la transacción que se requiere anular */
                            buyOrder = Request.Form["buyOrder"];

                            /** Monto que se desea anular de la transacción */
                            decimal nullifyAmount = 3;

                            request.Add("authorizationCode", authorizationCode.ToString());
                            request.Add("authorizedAmount", authorizedAmount.ToString());
                            request.Add("buyOrder", buyOrder.ToString());
                            request.Add("nullifyAmount", nullifyAmount.ToString());
                            request.Add("commercecode", commercecode.ToString());

                            nullificationOutput resultNullify = webpay.getNullifyTransaction().nullify(authorizationCode, authorizedAmount, buyOrder, nullifyAmount, commercecode);

                            HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightyellow;'><strong>request</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(request) + "</p>");
                            HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightgrey;'><strong>result</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(resultNullify) + "</p>");

                            message = "Transacci&oacute;n Finalizada";
                            HttpContext.Current.Response.Write(message + "</br></br>");

                        }
                        catch (Exception ex)
                        {
                            HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightyellow;'><strong>request</strong></br></br>" + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(request) + "</p>");
                            HttpContext.Current.Response.Write("<p style='font-size: 100%; background-color:lightgrey;'><strong>result</strong></br></br> Ocurri&oacute; un error en la transacci&oacute;n (Validar correcta configuraci&oacute;n de parametros). " + ex.Message + "</p>");
                        }

                        break;
                }
            }
            else
                Response.Redirect("~/Account/Login.aspx");
        }

    }
}