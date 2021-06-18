<%@ Page Title="Detalle del Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Quilicura.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="Quilicura.Models.Producto" SelectMethod="GetProducto" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1 style="color: #f2620e;"><%#:Item.ProductoNombre %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <a style="color: #f2620e;" href="/Catalogo/Imagenes/<%#:Item.ImagePath%>" alt="<%#:Item.ProductoNombre %>">
                            <img src="/Catalogo/Imagenes/<%#:Item.ImagePath %>" style="border: solid; height: 300px" alt="<%#:Item.ProductoNombre %>" />
                        </a>
                        
                    </td>
                    <td></td>
                    
                    <td style="vertical-align: top; text-align: left; color: black"><b>Descripción:</b><br />                        
                        <%#:Item.Descripcion %>
                        <br />
                        <span>
                            <b>Precio Desde:</b>&nbsp;<%#: String.Format("{0:C0}", Item.Precio) %></span><br /><span><b>Número de Producto:</b>&nbsp;<%#:Item.ProductoID %></span><br /><span><b>Modelo: </b>&nbsp; <%#: Item.Modelo %>
                        </span>
                        <br />
                        <span>
                            <b>SKU: </b>&nbsp; <%#: Item.CodigoSKU %>
                        </span>
                        <br />
                        <a href="/AddToCart.aspx?productID=<%#:Item.ProductoID %>">
                            <span class="ProductListItem">
                                <b class="btn btn-orange btn-xs">Agregar al Carro</b>
                            </span>
                        </a>
                    </td>
                    
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
