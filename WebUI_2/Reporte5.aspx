<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte5.aspx.cs" Inherits="WebUI_2.Reporte5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Reporte #5</h2>
    <div class="jumbotron">
        <asp:panel ID="Grid3" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="X-Large">Productos</asp:Label>
            <asp:GridView ID="ContentGrid1" runat="server" AutoGenerateColumns="true">

            </asp:GridView>
            
        </asp:panel>
    </div>
</asp:Content>
