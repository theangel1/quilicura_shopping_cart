<%@ Page Title="Lista de Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Quilicura.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="CategoryMenu" style="text-align: center;">
        <asp:ListView ID="ListaCategorias" runat="server" ItemType="Quilicura.Models.Categoria" SelectMethod="GetCategorias">
            <ItemTemplate>
                <b style="font-size: large; font-style: normal;">
                    <a href="<%#: GetRouteUrl("ProductsByCategoryRoute", new {categoryName = Item.NombreCategoria}) %>">
                        <%#: Item.NombreCategoria %>
                    </a>
                </b>
            </ItemTemplate>
            <ItemSeparatorTemplate>|  </ItemSeparatorTemplate>
        </asp:ListView>
    </div>
    <section>
        <div>
            <hr />
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:ListView ID="productList" runat="server" DataKeyNames="ProductoID" GroupItemCount="4" ItemType="Quilicura.Models.Producto" SelectMethod="GetProductos">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No hemos encontrado ningún producto.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.ProductoNombre}) %>">
                                        <img src="/Catalogo/Imagenes/<%#:Item.ImagePath%>" width="200" height="150" style="border: solid; color: #f2620e;" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.ProductoNombre}) %>">
                                        <span><%#:Item.ProductoNombre%></span>
                                    </a>
                                    <br />
                                    <span style="color: black">
                                        <b>Precio: </b><%#:String.Format("{0:C0}", Item.Precio)%> 
                                    </span>
                                    <br />
                                    <a href="/AddToCart.aspx?productID=<%#:Item.ProductoID %>">
                                        <span class="ProductListItem">
                                            <b class="btn btn-orange btn-xs">Agregar al Carro</b>
                                        </span>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p> </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
            <blockquote class="blockquote text-center">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ProductList" PageSize="18">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                            ShowPreviousPageButton="True" ButtonCssClass="btn btn-outline-warning" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="True"
                            ShowPreviousPageButton="False" ButtonCssClass="btn btn-outline-warning" />
                    </Fields>
                </asp:DataPager>
            </blockquote>
        </div>
    </section>

</asp:Content>
