<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Quilicura.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr style="border-color:orange" />
    <div id="ShoppingCartTitle" runat="server" class="ContentHead">
        <h2>Carro de Compras(En Desarrollo)</h2>
    </div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="Quilicura.Models.CartItem" SelectMethod="GetShoppingCartItems"
        CssClass="table table-hover table-bordered">
        <Columns>
            <asp:BoundField DataField="ProductoID" HeaderText="ID" SortExpression="ProductoID" />
            <asp:BoundField DataField="Producto.ProductoNombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Producto.Precio" HeaderText="Precio (c/u)" DataFormatString="{0:C0}" />
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" ClientIDMode="Static" Width="40" runat="server" Text="<%#: Item.Cantidad %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Item">
                <ItemTemplate>
                    <%#: String.Format("{0:C0}", ((Convert.ToInt32(Item.Cantidad)) *  Convert.ToInt32(Item.Producto.Precio)))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar Item">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server"></asp:CheckBox>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:Button ID="UpdateBtn" runat="server" Text="Actualizar Carrito" OnClick="UpdateBtn_Click" CssClass="btn btn-orange" />
        <a href="ProductList.aspx" class="btn btn-orange">Seguir comprando</a>
    </div>
    <h3><strong>
        <asp:Label ID="LabelTotalText" runat="server" Text="Total Orden: "></asp:Label>
        <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
    </strong></h3>
    <hr style="border-color:orange" />
    <h5>Nuestros Metodos de Pago</h5>
    <table class="table">        
        <tr>
            <td>
                <asp:ImageButton ID="CheckoutImageBtn" runat="server" ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif"
                    Width="150" AlternateText="Check out con PayPal" OnClick="CheckoutBtn_Click" BackColor="Transparent" BorderWidth="0" />
            </td>
            <td>
                <asp:ImageButton runat="server" ImageUrl="~/img/webpay-456x200.png" Width="250" AlternateText="Check out WebPay" ID="BotonWebP" OnClick="BotonWebP_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
