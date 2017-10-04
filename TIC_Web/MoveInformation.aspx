<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoveInformation.aspx.cs" Inherits="TIC_Web.MoveInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="centralized">
        <asp:Image ID="Image1" runat="server" />
    </div>
    <br />
    <br />
    <div>
        <asp:Label ID="Label1" runat="server" Text="Command:" CssClass="moveLabel"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Hit Level:" CssClass="moveLabel"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Damage:" CssClass="moveLabel"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Start-up frame:" CssClass="moveLabel"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="Block frame:" CssClass="moveLabel"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Hit Frame:" CssClass="moveLabel"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Counter-hit frame:" CssClass="moveLabel"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Notes:" CssClass="moveLabel"></asp:Label>
    </div>
</asp:Content>
