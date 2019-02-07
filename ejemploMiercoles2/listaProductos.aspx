<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="listaProductos.aspx.cs" Inherits="ejemploMiercoles2.listaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="productList" runat="server" 
                DataKeyNames="ProductoID" GroupItemCount="4"
                ItemType="Contexto.Productos" SelectMethod="GetProductos">
                <EmptyDataTemplate>
                    <%-- Plantilla si no hay datos --%>
                    <div class="row">
                      No hay datos
                   <div class="row">
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <%-- Plantilla para elemento o item vacío --%>
                    <div class="col-lg-3">

                    </div>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <%-- Plantilla de contenedor de grupo --%>
                     <div class="row">
                         <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                </GroupTemplate>
                <ItemTemplate>
                    <%-- Plantilla del contenedor de item de datos --%>
                     <div class="col-lg-3">
                    <div class="card text-white bg-secondary mb-3">
                         <asp:HyperLink ID="HyperLink1"
                            runat="server"
                            CssClass="card-header"
                            NavigateUrl='<%# Eval("ProductoID","~/detalleProducto.aspx?id={0}") %>'>
                            <%#:Item.ProductoNombre%>
                        </asp:HyperLink>
                       
                        <%-- <%# Eval("ImagenPath")%> --%>
                       <asp:Image ID="Image1" ImageUrl='<%# Eval("ImagenPath","~/Imagenes/Thumbs/{0}") %>'
                                      Height="200px"  ImageAlign="Middle" runat="server" />
                        
                        <div class="card-body">
                            <p class="card-text"> <b>Precio</b><%#: String.Format("{0:c}",Item.PrecioUnitario)%></p>
                        </div>
                        <div class="card-footer text-muted">
                            <asp:HiddenField ID="hfProductoID" Value='<%#: Item.ProductoID %>' runat="server" />
                            <asp:LinkButton ID="linkAgregar" CssClass="btn btn-success" runat="server" >Agregar al carrito</asp:LinkButton>
                        </div>
                    </div>
                     </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <%-- Plantilla de contenedor raíz --%>
                     <div class="container">
                         <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
</asp:Content>
