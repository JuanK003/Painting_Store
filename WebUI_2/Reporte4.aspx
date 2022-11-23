<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte4.aspx.cs" Inherits="WebUI_2.Reporte4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Reporte #4</h2>
    <div class="jumbotron">
        <asp:Label ID="Label1" runat="server" Text="Label">Introduzca la Factura:</asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click"/>
            <br /><br />
        <asp:panel ID="Grid3" runat="server">
            
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Label ID="Label5" runat="server" Text="Recuerde Introducir el ID de la Factura para buscar"></asp:Label>
            </asp:Panel><br />
            <asp:Label ID="Label2" runat="server" Text="Label">Factura</asp:Label>
            <br />
            <asp:GridView ID="ContentGrid1" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label">Detalle de Factura</asp:Label>
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label">Pago de Factura</asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
        </asp:panel>
    </div>
</asp:Content>
