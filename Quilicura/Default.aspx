<%@ Page Title="Outlet Quilicura" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Quilicura._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="PanelContenido" runat="server">
        <!--Main layout-->
        <div class="container">
            <div class="row mt-4">

                <!--Sidebar-->
                <div class="col-lg-4 wow fadeIn" data-wow-delay="0.2s">

                    <div class="widget-wrapper" style="background-color: white">
                        <br />
                        
                        <h4 class="h4-responsive font-bold mb-3" style="color: black">Categorías<img src="img/Home-Depot.jpg" width="50" /></h4>

                        <div class="list-group">
                            <asp:ListView ID="ListaCategorias" runat="server" ItemType="Quilicura.Models.Categoria" SelectMethod="GetCategorias">
                                <ItemTemplate>
                                    <a class="list-group-item" href="<%#: GetRouteUrl("ProductsByCategoryRoute", new {categoryName = Item.NombreCategoria}) %>">
            <%#: Item.NombreCategoria %>
        </a>
                                </ItemTemplate>
                                <ItemSeparatorTemplate>
                                </ItemSeparatorTemplate>
                            </asp:ListView>
                        </div>
                    </div>

                    <!--Comento por si despues hay que usar esto
                    <div class="widget-wrapper">
                        <h4 class="h4-responsive font-bold mb-3 mt-4">Price:</h4>
                        <br>
                        <div class="list-group">
                            <a href="#" class="list-group-item active">100$ - 399$</a>
                            <a href="#" class="list-group-item">400$ - 899$</a>
                            <a href="#" class="list-group-item">900$ - 1599$</a>
                            <a href="#" class="list-group-item">1600$ - 7999$</a>
                        </div>
                    </div>
                          -->
                    <div class="widget-wrapper wow fadeIn" data-wow-delay="0.4s">
                        <h4 class="h4-responsive font-bold">Subscripción:</h4>
                        <br>
                        <div class="card">
                            <div class="card-body">
                                <p>
                                    <strong>Subscribete a nuestro newsletter</strong>
                                </p>
                                <p>Una vez a la semana le enviaremos un catalogo con nuestras mejores ofertas</p>
                                <div class="md-form">
                                    <i class="fa fa-user prefix grey-text"></i>
                                    <input type="text" id="form1" class="form-control">
                                    <label for="form1">Su nombre</label>
                                </div>
                                <div class="md-form">
                                    <i class="fa fa-envelope prefix grey-text"></i>
                                    <input type="text" id="form2" class="form-control">
                                    <label for="form2">Su email</label>
                                </div>
                                <button class="btn btn-warning" runat="server">Enviar</button>

                            </div>
                        </div>
                    </div>

                </div>
                <!--/.Sidebar-->

                <!--Main column-->
                <div class="col-lg-8">

                    <!--First row-->
                    <div class="row wow fadeIn" data-wow-delay="0.4s">
                        <div class="col-lg-12">                          

                            <!--Carousel Wrapper-->
                            <div id="carousel-example-1z" class="carousel slide carousel-fade" data-ride="carousel">
                                <!--Indicators-->
                                <ol class="carousel-indicators">
                                    <li data-target="#carousel-example-1z" data-slide-to="0" class="active"></li>
                                    <li data-target="#carousel-example-1z" data-slide-to="1"></li>
                                    <li data-target="#carousel-example-1z" data-slide-to="2"></li>

                                </ol>
                                <!--/.Indicators-->
                                <!--Slides-->
                                <div class="carousel-inner" role="listbox">

                                    <!--First slide-->
                                    <div class="carousel-item active">
                                        <div class="view overlay">
                                            <iframe width="800" height="400"
                                                src="https://www.youtube.com/embed/mRSh3jYXaFY?autoplay=1"></iframe>
                                        </div>
                                        <!--
                                    <div class="carousel-caption">
                                        <h3 class="font-bold White-text">
                                            <strong>¡¡¡10% descuento en Juguetes!!!</strong>
                                        </h3>
                                        <br>
                                    </div>
                                        -->
                                    </div>

                                    <!--Second slide-->
                                    <div class="carousel-item">
                                        <div class="view overlay">
                                            <img src="img/Carousel/DSCF6188.jpg" alt="Second slide" class="img-fluid rounded">
                                            <a href="~/ProductList.aspx" runat="server">
                                                <div class="mask flex-center waves-effect waves-light rgba-orange-strong">
                                                    <h3 class="white-text font-bold">Seccion Herramientas Electricas</h3>
                                                </div>
                                            </a>
                                        </div>

                                    </div>
                                    <!--/Second slide-->
                                    <!--Third slide-->
                                    <div class="carousel-item">
                                        <div class="view overlay">
                                            <img src="img/Carousel/DSCF6180.jpg" alt="First slide" class="img-fluid rounded">
                                            <a href="#" runat="server">
                                                <div class="mask flex-center waves-effect waves-light rgba-orange-strong">
                                                    <h3 class="white-text font-bold">¡¡¡Herramientras de alta Calidad!!!</h3>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                    <!--/Third slide-->


                                </div>
                                <!--/.Slides-->
                                <!--Controls-->
                                <a class="carousel-control-prev" href="#carousel-example-1z" role="button" data-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="carousel-control-next" href="#carousel-example-1z" role="button" data-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                                <!--/.Controls-->
                            </div>
                            <!--/.Carousel Wrapper-->
                        </div>
                    </div>
                    <!--/.First row-->
                    <br>
                    <hr class="extra-margins">

                    <!--Second row-->
                     <h2 class="h2-responsive font-bold mb-5" style="color: black">Productos Destacados</h2>
                    <div class="row">
                        <!--First columnn-->
                        <div class="col-lg-4">
                            <!--Card-->
                            <div class="card mb-r wow fadeIn" data-wow-delay="0.2s">

                                <!--Card image-->
                                <img class="img-fluid" src="Catalogo/Imagenes/ESMERILADORA ANGULAR DE 15mm EMPAÑADURA CIL.jpg" alt="Card image cap">

                                <!--Card content-->
                                <div class="card-body">
                                    <!--Title-->
                                    <h5 class="font-bold">
                                        <strong>ESMERILADORA ANGULAR</strong>
                                        <span class="badge badge-danger">Ultimas unidades</span>
                                    </h5>
                                    <hr>
                                    <h4>
                                        <strong>$17.487</strong>
                                    </h4>
                                    <!--Text-->
                                    <p class="card-text mt-4">
                                        ESMERILADORA ANGULAR DE 15mm EMPAÑADURA CIL
                                    </p>

                                    <a href="http://quilicura.importadorasantamaria.com/ProductDetails?productID=2" class="btn btn-info btn-sm">Ver más</a>
                                </div>

                            </div>
                            <!--/.Card-->
                        </div>
                        <!--First columnn-->

                        <!--Second columnn-->
                        <div class="col-lg-4">
                            <!--Card-->
                            <div class="card mb-r wow fadeIn" data-wow-delay="0.4s">

                                <!--Card image-->
                                <img class="img-fluid" src="Catalogo/Imagenes/GLAC BAY WHT DUALFLSH TOILET 2PC.png" alt="Card image cap">

                                <!--Card content-->
                                <div class="card-body">
                                    <!--Title-->
                                    <h5 class="font-bold">
                                        <strong>Sanitario</strong>
                                        <span class="badge badge-info">Nuevo</span>
                                    </h5>
                                    <hr>
                                    <h4>
                                        <strong>$65.664</strong>
                                    </h4>
                                    <!--Text-->
                                    <p class="card-text mt-4">
                                        GLAC BAY WHT DUALFLSH TOILET 2PC
                                    </p>
                                    <a href="http://quilicura.importadorasantamaria.com/ProductDetails?productID=4" class="btn btn-info btn-sm">Ver más </a>
                                </div>

                            </div>
                            <!--/.Card-->
                        </div>
                        <!--Second columnn-->


                    </div>
                    <!--/.Second row-->

                    <!--Third row-->
                    <div class="row">
                        <!--First columnn-->
                        <div class="col-lg-4">
                            <!--Card-->
                            <div class="card mb-r wow fadeIn" data-wow-delay="0.2s">

                                <!--Card image-->
                                <img class="img-fluid" src="Catalogo/Imagenes/GRIFO COCINA RETRACTIL.jpg" alt="Card image cap">

                                <!--Card content-->
                                <div class="card-body">
                                    <!--Title-->
                                    <h5 class="font-bold">
                                        <strong>GRIFO COCINA RETRACTIL</strong>
                                        <span class="badge badge-danger">Ultimas unidades</span>
                                    </h5>
                                    <hr>
                                    <h4>
                                        <strong>$71.154</strong>
                                    </h4>
                                    <!--Text-->
                                    <p class="card-text mt-4">
                                        GRIFO COCINA RETRACTIL a sólo $71.154
                                    </p>
                                    <br />
                                    <a href="http://quilicura.importadorasantamaria.com/ProductDetails?productID=1" class="btn btn-info btn-sm">Ver Más</a>
                                </div>

                            </div>
                            <!--/.Card-->
                        </div>
                        <!--First columnn-->

                        <!--Second columnn-->
                        <div class="col-lg-4">
                            <!--Card-->
                            <div class="card mb-r wow fadeIn" data-wow-delay="0.4s">

                                <!--Card image-->
                                <img class="img-fluid" src="Catalogo/Imagenes/REPISA ESQUINERA VIDRIO EXTEN16-BN.jpg" alt="Card image cap">

                                <!--Card content-->
                                <div class="card-body">
                                    <!--Title-->
                                    <h5 class="font-bold">
                                        <strong>REPISA ESQUINERA</strong>
                                        <span class="badge badge-danger">Ultimas unidades</span>
                                    </h5>
                                    <hr>
                                    <h4>
                                        <strong>$18.090</strong>
                                    </h4>
                                    <!--Text-->
                                    <p class="card-text mt-4">
                                        REPISA ESQUINERA VIDRIO EXTEN16-BN
                                    </p>

                                    <a href="http://quilicura.importadorasantamaria.com/ProductDetails?productID=3" class="btn btn-info btn-sm">Ver Más </a>
                                </div>

                            </div>
                            <!--/.Card-->
                        </div>
                        <!--Second columnn-->


                    </div>
                    <!--/.Third row-->

                </div>

                <!--/.Main column-->

            </div>
        </div>
        <!--/.Main layout-->


    </asp:Panel>
    -<hr />
    <h4 style="color: darkgray; text-align: center">¿Como llegar?</h4>

    <div class="row mt-4">
        <div class="containerMaria">

            <div class="col-lg-7 col-md-4">
                <p>
                    <b>Visítanos en nuestras amplias
                bodegas ubicadas en: </b>
                    <br />
                    San Ignacio 801, Comuna de Quilicura
                    <br />
                    <br />

                </p>
            </div>
            <div class="col-lg-12 col-md-6 ml-auto">
                <div id="googleMap" style="width: 100%; height: 400px;"></div>
            </div>
        </div>
    </div>
</asp:Content>
