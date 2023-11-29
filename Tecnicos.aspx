<%@ Page Title="  " Language="C#" MasterPageFile="~/inicio.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="rarExamen.Tecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container">
    <h1 class="text-center">Tecnicos</h1>
    <div class="container">
    <div class="col-12 p-4">
    <asp:GridView runat="server" ID="dgTecnicos" HorizontalAlign="Center"
     CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
     BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
     <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
     <HeaderStyle CssClass="header" BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>
    <PagerStyle CssClass="pager" BackColor="White" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>
    <RowStyle CssClass="rows"></RowStyle>
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
     </asp:GridView>
     </div>
     <div class="row">
     <div class="col-4 p-2 d-inline-block">
     <label for="id" class="form-label ">Codigo Tecnico:</label>
     <asp:TextBox runat="server" ID="txtId" CssClass="form-control"/>
     </div>
     <div class="col-4 p-2 d-inline-block">
     <label for="nombre" class="form-label ">Nombre:</label>
     <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
     </div>
     <dv class="col-4 p-2 d-inline-block">
     <label for="correo" class="form-label ">Especialidad:</label>
     <asp:TextBox runat="server" ID="txtEspecialidad" CssClass="form-control"/>
     </dv>
     </div>
     <div class="row">
     <div class="btn-group mr-2" role="group" aria-label="Actions group">
     <asp:Button runat="server" ID="BtnAgregar" CssClass="btn btn-primary" Text="Agregar" OnClick="BtnAgregar_Click" Width="100px"/>
     <asp:Button runat="server" ID="BtnModificar" CssClass="btn btn-primary" Text="Modificar" OnClick="BtnModificar_Click" Width="100px"/>
     <asp:Button runat="server" ID="BtnBorrar" CssClass="btn btn-primary" Text="Borrar" OnClick="BtnBorrar_Click" Width="100px"/>
     <asp:Button runat="server" ID="BtnConsultar" CssClass="btn btn-primary" Text="Consultar"  OnClick="BtnConsultar_Click" Width="100px"/>
     <asp:Button runat="server" ID="BtnReset" CssClass="btn btn-primary" Text="Reset"  OnClick="BtnReset_Click" Width="101px"/>
     </div>
     </div>
     </div>
   </section>
</asp:Content>
