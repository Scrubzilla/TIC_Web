<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrameData.aspx.cs" Inherits="TIC_Web.FrameData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Frame Data</h2>
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/CharacterSelect.aspx">Back to character select</asp:LinkButton>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Set filter:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Search text:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:ListView ID="ListView1" runat="server">
    </asp:ListView>
    <br />
</asp:Content>
