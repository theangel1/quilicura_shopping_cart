using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Quilicura.CheckoutTBK.Certificados
{
    public class CertNormal
    {

        internal static Dictionary<string, string> Certificate()
        {

            Dictionary<string, string> certificate = new Dictionary<string, string>();
            String certFolder = HttpContext.Current.Server.MapPath(".");            
            certificate.Add("environment", "INTEGRACION");            
            certificate.Add("public_cert", certFolder + "\\Certificados\\tbk.pem");
            var cert = new X509Certificate2(certFolder + "\\Certificados\\597020000541.pfx", "transbank123", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);                       
            certificate.Add("webpay_cert", certFolder + "\\Certificados\\597020000541.pfx");            
            certificate.Add("password", "transbank123");            
            certificate.Add("commerce_code", "597020000541");
          

            return certificate;

        }
    }
}