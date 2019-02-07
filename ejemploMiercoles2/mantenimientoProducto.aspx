<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="mantenimientoProducto.aspx.cs" Inherits="ejemploMiercoles2.mantenimientoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <div class="row">
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-dismissible alert-warning" Visible="false" Text=""></asp:Label>
        </div>
    </div>        

    <div class="row">
        <div class="col-lg-4 offset-lg-1">
            <!-- Registro -->
            <h2>Registro Productos</h2>
            <div class="form-group row">
                <asp:Label ID="Label1" runat="server" Text="Categoría"></asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" 
                    CssClass="form-control"
                    ItemType="Contexto.Categorias"
                    SelectMethod="getCategoriasWS"
                    DataTextField="CategoriaNombre"
                    DataValueField="CategoriaID"
                    >
                </asp:DropDownList>
            </div>
            <div class="form-group row">
                <label for="txtNombre" class="control-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" 
                    ErrorMessage="*El nombre es requerido"
                    ControlToValidate="txtNombre"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    Display="Dynamic" ValidationGroup="registrar"
                    ></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvNombre" 
                    runat="server" 
                     ErrorMessage="*El nombre debe tener por lo menos 3 caracteres"
                    ControlToValidate="txtNombre"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    Display="Dynamic" 
                    EnableClientScript="false"  
                    ValidateEmptyText="true" 
                    OnServerValidate="cvNombre_ServerValidate" ></asp:CustomValidator>
            </div>
            <div class="form-group row">
                <label for="txtDescripcion" class="control-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" 
                    runat="server" TextMode="MultiLine"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" 
                    ErrorMessage="*La descripción es requerida"
                    ControlToValidate="txtDescripcion"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    Display="Dynamic"  ValidationGroup="registrar"
                    ></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label for="txtPrecio" class="control-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" 
                    ErrorMessage="*El precio es requerido"
                    ControlToValidate="txtPrecio"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    Display="Dynamic"  ValidationGroup="registrar"
                    ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" 
                    ErrorMessage="*El precio debe tener solo números"
                    ControlToValidate="txtPrecio"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    Display="Dynamic"  ValidationGroup="registrar"
                    ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"
                    ></asp:RegularExpressionValidator>
            </div>
            <div class="form-group row">
                <label for="archivoImagen" class="control-label">Imagen</label>
                <asp:FileUpload ID="archivoImagen" CssClass="form-control-file" runat="server" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" 
                    ErrorMessage="*La imagen es requerida"
                    ControlToValidate="archivoImagen"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    Display="Dynamic"  ValidationGroup="registrar"
                    ></asp:RequiredFieldValidator>
            </div>
            <asp:HiddenField ID="hProductoId" runat="server" Value=""/>

            <div class="form-group row">
                <asp:Button ID="btnRegistrar"
                    Onclick="btnRegistrar_Click"
                     CssClass="btn btn-primary" 
                    runat="server"  
                    ValidationGroup="registrar"
                    Text="Registrar"/>
            </div>

            <!-- Registro -->
        </div>


        <div class="col-lg-6 offset-lg-1">
            <!-- Listado -->
            <h2>Listado Productos</h2>
            <asp:GridView ID="grvListado" runat="server" AutoGenerateColumns="False" CssClass="table"
                AutoGenerateSelectButton="true" DataKeyNames="ProductoId"
                OnSelectedIndexChanged="grvListado_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ProductoNombre" HeaderText="Nombre"></asp:BoundField>
                    <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio"></asp:BoundField>
                    <asp:BoundField DataField="Categorias.CategoriaNombre" HeaderText="Categoría"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <!-- Listado -->
        </div>

    </div>
</asp:Content>
