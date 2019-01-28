<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ejemploMiercoles2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= ConfigurationManager.AppSettings["nombreApp"] %></title>
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/sticky-footer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1 class="display-3">Bienvenid@</h1>
            <p class="lead">App Producto</p>
            <hr class="my-4" />
           <p class="lead">
               <asp:HyperLink ID="HyperLink1" 
                   CssClass="btn btn-primary btn-lg" 
                   NavigateUrl="~/mantenimientoProducto.aspx"
                   runat="server">Ingresar</asp:HyperLink>
             </p>
        </div>
    </form>
    <footer class="footer">
        <div class="container">
            <asp:Label ID="lblCopyright" runat="server" 
                Text="<%$appSettings: copyright  %>"></asp:Label>
            <br />
            I Cuatrimestre 2019
        </div>
    </footer>
</body>
</html>
