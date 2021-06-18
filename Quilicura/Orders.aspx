<%@ Page Title="Ordenes de Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Quilicura.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="DSOC" runat="server" ConnectionString="<%$ ConnectionStrings:AccesoQuilicura %>" SelectCommand="SELECT [OrderId], [OrderDate], [Email], [Total], [PaymentTransactionId] FROM [Orders] WHERE ([Username] = @Username)">
        <SelectParameters>
            <asp:ControlParameter ControlID="labelUserName" Name="Username" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label runat="server" ID="labelUserName" ClientIDMode="Static" Visible="false"></asp:Label>    
    <asp:GridView ID="GVOrdenesCompra" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="OrderId" DataSourceID="DSOC" ForeColor="#333333" GridLines="None" Width="1048px" AllowPaging="True" AllowSorting="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="OrderId" />
            <asp:BoundField DataField="OrderDate" HeaderText="Fecha" SortExpression="OrderDate" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
            <asp:BoundField DataField="PaymentTransactionId" HeaderText="ID Transacción" SortExpression="PaymentTransactionId" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

    </asp:GridView>
</asp:Content>
