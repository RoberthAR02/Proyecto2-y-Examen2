<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="DetallesDeReparacion.aspx.cs" Inherits="rarExamen.DetallesDeReparacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container">
    <h1 class="text-center">Detalles de Reparacion</h1>
    <div class="container">
    <div class="col-12 p-4">
    <asp:GridView runat="server" ID="dgDetalles" PageSize="10" HorizontalAlign="Center"
     CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
     RowStyle-CssClass="rows" AllowPaging="True" OnSelectedIndexChanged="dgDetalles_SelectedIndexChanged" AutoGenerateSelectButton="True"/>
     </div>
     <div class="row">
     <div class="col-3 p-2 d-inline-block">
     <label for="id" class="form-label ">Codigo Detalles de Reparacion:</label>
     <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
     </div>
     <div class="col-3 p-2 d-inline-block">
     <label for="ddUsuario" class="form-label">Reparacion:</label>
     <asp:DropDownList runat="server" ID="ddRepracion" CssClass="form-select" />
     </div>
     <div class="col-6 p-2 d-inline-block">
     <label for="id" class="form-label ">Descripcion:</label>
     <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
     </div>
     <div class="col-3 p-2 d-inline-block">
     <label for="txModelo" class="form-label ">Fecha de Fin:</label>
     <asp:TextBox runat="server" type="date" ID="txtFechaFin" CssClass="form-control" />
     </div>
     </div>
     <div class="row">
     <div class="btn-group mr-2" role="group" aria-label="Actions group">
     <asp:Button runat="server" ID="BtnAgregar" CssClass="btn btn-primary" Text="Agregar" OnClick="BtnAgregar_Click"/>
     <asp:Button runat="server" ID="BtnModificar" CssClass="btn btn-primary" Text="Modificar" OnClick="BtnModificar_Click"/>
     <asp:Button runat="server" ID="BtnBorrar" CssClass="btn btn-primary" Text="Borrar" OnClick="BtnBorrar_Click"/>
     <asp:Button runat="server" ID="BtnConsultar" CssClass="btn btn-primary" Text="Consultar"  OnClick="BtnConsultar_Click"/>
     <asp:Button runat="server" ID="BtnReset" CssClass="btn btn-primary" Text="Reset"  OnClick="BtnReset_Click"/>
     </div>
     </div>
     </div>
  </section>
</asp:Content>
