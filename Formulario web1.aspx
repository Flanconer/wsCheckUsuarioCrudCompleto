<%@ Page async="true" Title="" Language="C#" MasterPageFile="~/mpPrincipal.master" AutoEventWireup="true" CodeBehind="Formulario web1.aspx.cs" Inherits="wsCheckUsuario.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="app_themes\principal\principal.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Reporte de Usuarios Registrados" CssClass="tituloContenido"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagenes/icon_logalum.GIF" />
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" BackColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black">
        <AlternatingRowStyle BackColor="#66FFFF" />
        <FooterStyle BackColor="White" />
        <HeaderStyle BackColor="#66CCFF" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="#CC0000" />
        <RowStyle BackColor="#3399FF" BorderColor="Black" />
    </asp:GridView>

</asp:Content>

