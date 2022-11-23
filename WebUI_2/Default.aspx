<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUI_2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Reporte #1</h2>
    <div class="jumbotron">
        <asp:TextBox placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false" ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false" ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button OnClick="Button1_Click" ID="Button1" runat="server" Text="Buscar" />
        <br /><br />
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Label ID="Label1" runat="server" Text="Recuerde seleccionar las fechas"></asp:Label>
        </asp:Panel>
        <asp:panel ID="Grid" runat="server">
            <asp:GridView ID="ContentGrid" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
        </asp:panel>
    </div>

</asp:Content>
