<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrameData.aspx.cs" Inherits="TIC_Web.FrameData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Frame Data</h2>
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/CharacterSelect?section=framedata" CssClass="custLinkButton">Back to character select</asp:LinkButton>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
        <asp:Label ID="Label1" runat="server" Text="Set filter:"></asp:Label>
        <asp:DropDownList ID="characterList" runat="server" DataSourceID="SqlDataSource1" DataTextField="CharacterName" DataValueField="CharacterName" CssClass="smallPadding">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [CharacterName] FROM [Characters] ORDER BY [CharacterName]"></asp:SqlDataSource>
        <asp:DropDownList runat="server" ID="movePropertyList" CssClass="smallPadding">
            <asp:ListItem>Command</asp:ListItem>
            <asp:ListItem Value="HitLevel">Hit Level</asp:ListItem>
            <asp:ListItem>Damage</asp:ListItem>
            <asp:ListItem Value="StartUpFrameDisplay">Start-Up Frame</asp:ListItem>
            <asp:ListItem Value="BlockFrameDisplay">Block Frame</asp:ListItem>
            <asp:ListItem Value="HitFrameDisplay">Hit Frame</asp:ListItem>
            <asp:ListItem Value="CHFrameDisplay">Counter-Hit Frame</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Search text:" CssClass="largePadding"></asp:Label>
        <asp:TextBox ID="searchField" runat="server" KeyDown="SearchFieldKeyDown" CssClass="smallPadding"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="RefreshMoves" CssClass="searchBtn" />
        <br />
        <br />
    </asp:Panel>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Command" HeaderText="Command" />
                <asp:BoundField DataField="HitLevel" HeaderText="Hit Level" />
                <asp:BoundField DataField="Damage" HeaderText="Damage" />
                <asp:BoundField DataField="StartUpFrameDisplay" HeaderText="Start-Up Frame" />
                <asp:BoundField DataField="BlockFrameDisplay" HeaderText="Block-Frame" />
                <asp:BoundField DataField="HitFrameDisplay" HeaderText="Hit-Frame" />
                <asp:BoundField DataField="CHFrameDisplay" HeaderText="Counter-Hit Frame" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
