<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleView.aspx.cs" Inherits="KMWeb.ArticleView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:TextBox ID="txtNaslov" runat="server" Width="372px" Enabled="False"></asp:TextBox>
<asp:TextBox ID="txtDate" runat="server" Enabled="False"></asp:TextBox>
<br />
<br />
<asp:TextBox ID="txtSadrzaj" runat="server" Enabled="False" Height="459px" 
    TextMode="MultiLine" Width="500px"></asp:TextBox>
</asp:Content>
