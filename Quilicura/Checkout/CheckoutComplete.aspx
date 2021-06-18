<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutComplete.aspx.cs" Inherits="Quilicura.Checkout.CheckoutComplete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Checkout Completado</h1>
    <p></p>
    <h3>ID Transacción de Pago:</h3> <asp:Label ID="TransactionId" runat="server"></asp:Label>
    <p></p>
    <h3>Gracias!</h3>
    <p></p>
    <hr />
    <asp:Button ID="Continue" runat="server" Text="Continuar la compra" OnClick="Continue_Click" />
</asp:Content>