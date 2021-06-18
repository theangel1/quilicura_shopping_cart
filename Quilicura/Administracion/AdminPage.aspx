<%@ Page Title="Administración" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Quilicura.Administracion.AdminPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Administración</h1>
    <hr />
    <h3>Agregar Producto:</h3>
    <table class="table">
        <tr>
            <td>
                <asp:Label ID="LabelAddCategory" runat="server">Categoría:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownAddCategory" runat="server" ItemType="Quilicura.Models.Categoria" SelectMethod="GetCategories" DataTextField="NombreCategoria" DataValueField="CategoriaID"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddName" runat="server">Nombre:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Debes ingresar el nombre del producto." ControlToValidate="AddProductName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddDescription" runat="server">Descripción:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Se requiere descripción." ControlToValidate="AddProductDescription" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddPrice" runat="server">Precio:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Precio requerido." ControlToValidate="AddProductPrice" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Debe ser un precio valido sin $." ControlToValidate="AddProductPrice" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelModelo" runat="server">Modelo:</asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="AddModelo"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelSKU" runat="server">SKU: </asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="AddSKU"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddImageFile" runat="server">Archivo de Imagen:</asp:Label></td>
            <td>
                <asp:FileUpload ID="ProductImage" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Se requiere el path de la imagen." ControlToValidate="ProductImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p>
        <asp:Label ID="miLabel" runat="server" Text=""></asp:Label>
    </p>
    <p></p>
    <asp:Button ID="AddProductButton" runat="server" Text="Agregar Producto" OnClick="AddProductButton_Click" CausesValidation="true" CssClass="btn btn-default" />
    <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
    <p></p>
    <h3>Eliminar Producto:</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="LabelRemoveProduct" runat="server">Producto:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownRemoveProduct" runat="server" ItemType="Quilicura.Models.Producto" SelectMethod="GetProducts" AppendDataBoundItems="true" DataTextField="ProductoNombre" DataValueField="ProductoID"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <p></p>
    <asp:Button ID="RemoveProductButton" runat="server" Text="Eliminar Producto" OnClick="RemoveProductButton_Click" CausesValidation="false" CssClass="btn btn-default" />
    <asp:Label ID="LabelRemoveStatus" runat="server" Text=""></asp:Label>

</asp:Content>
