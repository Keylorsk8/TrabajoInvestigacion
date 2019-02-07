<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="detalleProducto.aspx.cs" Inherits="ejemploMiercoles2.detalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="FormView1" runat="server"
        ItemType="Contexto.Productos" SelectMethod="ObtenerProducto">
        <ItemTemplate>
            <div class="card mb-3">
                <h3 class="card-header"><%#: Item.ProductoNombre %></h3>
                <div class="card-body">
                    <h5 class="card-title">Descripción</h5>
                    <h6 class="card-subtitle text-muted"><%#: Item.Descripcion %></h6>
                </div>
                <img style="height: 200px; width: 100%; display: block;" 
                    src="/Imagenes/Thumbs/<%#: Item.ImagenPath %>" 
                    alt="<%#: Item.ProductoNombre %>">
                <div class="card-body">
                    <h5 class="card-title">Categorí­a</h5>
                    <p class="card-text"><%#: Item.Categorias.CategoriaNombre %></p>
                </div>
                <div class="card-body">
                    <h5 class="card-title">Precio</h5>
                    <p class="card-text"><%#: String.Format("{0:c}",Item.PrecioUnitario) %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
