<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutReview.aspx.cs" Inherits="Quilicura.Checkout.CheckoutReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Revisión de Orden</h1>
    <p></p>
    <h3 style="padding-left: 33px">Productos:</h3>
    <asp:GridView ID="OrderItemList" runat="server" AutoGenerateColumns="False" GridLines="Both" CellPadding="10" Width="500" BorderColor="#efeeef" BorderWidth="33">              
        <Columns>
            <asp:BoundField DataField="ProductoID" HeaderText=" ID Producto" />        
            <asp:BoundField DataField="Producto.ProductoNombre" HeaderText=" Nombre Producto" />        
            <asp:BoundField DataField="Producto.Precio" HeaderText="Precio (c/u)"/>     
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />        
        </Columns>    
    </asp:GridView>
    <asp:DetailsView ID="ShipInfo" runat="server" AutoGenerateRows="false" GridLines="None" CellPadding="10" BorderStyle="None" CommandRowStyle-BorderStyle="None">
        <Fields>
        <asp:TemplateField>
            <ItemTemplate>
                <h3>Dirección de envío:</h3>
                <br />
                <asp:Label ID="FirstName" runat="server" Text='<%#: Eval("FirstName") %>'></asp:Label>  
                <asp:Label ID="LastName" runat="server" Text='<%#: Eval("LastName") %>'></asp:Label>
                <br />
                <asp:Label ID="Address" runat="server" Text='<%#: Eval("Address") %>'></asp:Label>
                <br />
                <asp:Label ID="City" runat="server" Text='<%#: Eval("City") %>'></asp:Label>
                <asp:Label ID="State" runat="server" Text='<%#: Eval("State") %>'></asp:Label>
                <asp:Label ID="PostalCode" runat="server" Text='<%#: Eval("PostalCode") %>'></asp:Label>
                <p></p>
                <h3>Total de la Orden:</h3>
                <br />
                <asp:Label ID="Total" runat="server" Text='<%#: Eval("Total") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
          </Fields>
    </asp:DetailsView>
    <p></p>
    <hr />
    <asp:Button ID="CheckoutConfirm" runat="server" Text="Orden Completada" OnClick="CheckoutConfirm_Click" />
</asp:Content>