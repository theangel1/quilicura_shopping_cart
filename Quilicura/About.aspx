<%@ Page Title="Nosotros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Quilicura.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hr /> 
    <h2><%: Title %></h2>
    <p>
        Somos una empresa del grupo Santa María SPA. Llevamos dos años ofreciendo productos de excelente calidad.

Contamos con una gran variedad de juegos, juguetes y vestuario. Nuestra forma de venta de productos marca la diferencia con otras empresas.

Visítanos en nuestras amplias bodegas ubicadas en San Ignacio 801, Comuna de Quilicura.

¡Te esperamos!
    </p>

    <asp:Panel ID="panelRRSS" runat="server">
       <div class="text-center">
           <h4 style="color:black">Nuestras Redes Sociales</h4> 
           <ul class="list-unstyled list-inline">
                <li class="list-inline-item"><a href="https://www.facebook.com/Importadora-Santa-Maria-172631436718103/" class="btn-floating  btn-fb mx-1"><i class="fa fa-facebook"></i></a></li>
                <li class="list-inline-item"><a href="https://www.instagram.com/importadora_santamaria/?hl=es-la" class="btn-floating  btn-tw mx-1"><i class="fa fa-instagram"></i></a></li>                
                <li class="list-inline-item"><a href="mailto:info@importadorasantamaria.com" class="btn-floating  btn-tw mx-1"><i class="fa fa-envelope"></i></a></li>                
            </ul>
        </div>

    </asp:Panel>

    <div id="googleMap" style="width: 100%; height: 400px;"></div>
</asp:Content>
