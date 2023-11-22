<%@ Page Title="  " Language="C#" MasterPageFile="~/inicio.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="rarExamen.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container">
        <h1 class="text-center">Catalogo de Usuarios</h1>
        <div class="container">
        <div class="col-12 p-4">
        <asp:GridView runat="server" ID="dgUsuarios" PageSize="10" HorizontalAlign="Center"
         CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
         RowStyle-CssClass="rows" AllowPaging="True" Width="250px" 
         OnRowEditing="dgUsuarios_RowEditing"
         OnRowUpdating="dgUsuarios_RowUpdating" OnRowDeleting="dgUsuarios_RowDeleting" OnPageIndexChanging="dgUsuarios_PageIndexChanging"/>
         </div>
         <div class="row">
         <div class="col-3 p-2 d-inline-block">
         <label for="id" class="form-label ">Codigo Usuario:</label>
         <asp:TextBox runat="server" ID="txtId" CssClass="form-control"/>
         </div>
         <div class="col-3 p-2 d-inline-block">
         <label for="nombre" class="form-label ">Nombre:</label>
         <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
         </div>
         <div class="col-3 p-2 d-inline-block">
         <label for="correo" class="form-label ">Correo Electronico:</label>
         <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control"/>
         </div>
         <div class="col-3 p-2 d-inline-block">
         <label for="telefono" class="form-label ">Telefono:</label>
         <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"/>
         </div>
         </div>
         <div class="row">
         <div class="btn-group mr-2" role="group" aria-label="Actions group">
         <asp:Button runat="server" ID="BtnAgregar" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" Width="100px"/>
         <asp:Button runat="server" ID="BtnModificar" CssClass="btn btn-primary" Text="Modificar" OnClick="BtnModificar_Click" Width="100px"/>
         <asp:Button runat="server" ID="BtnBorrar" CssClass="btn btn-primary" Text="Borrar" OnClick="btnBorrar_Click" Width="100px"/>
         <asp:Button runat="server" ID="BtnConsultar" CssClass="btn btn-primary" Text="Consultar"  OnClick="BtnConsultar_Click" Width="100px"/>
         <asp:Button runat="server" ID="BtnReset" CssClass="btn btn-primary" Text="Reset"  OnClick="BtnReset_Click" Width="100px"/>
         </div>
         </div>
        </div>
    </section>
</asp:Content>
