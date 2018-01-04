<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrameData.aspx.cs" Inherits="TIC_Web.FrameData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Frame Data</h2>
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/CharacterSelect?section=framedata" CssClass="custLinkButton">Back to character select</asp:LinkButton>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" DefaultButton="SearchBtn">
        <asp:Label ID="Label1" runat="server" Text="Set filter:"></asp:Label>
        <asp:DropDownList ID="characterList" runat="server" DataSourceID="SqlDataSource1" DataTextField="CharacterName" DataValueField="CharacterName" CssClass="smallPadding">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [CharacterName] FROM [Characters] ORDER BY [CharacterName]"></asp:SqlDataSource>
        <asp:DropDownList runat="server" ID="movePropertyList" CssClass="smallPadding" OnIndexSelected="RefreshRegex">
            <asp:ListItem Value="Command">Command</asp:ListItem>
            <asp:ListItem Value="HitLevel">Hit Level</asp:ListItem>
            <asp:ListItem Value="TotalDamage">Damage</asp:ListItem>
            <asp:ListItem Value="StartUpFrame">Start-Up Frame</asp:ListItem>
            <asp:ListItem Value="BlockFrame">Block Frame</asp:ListItem>
            <asp:ListItem Value="HitFrame">Hit Frame</asp:ListItem>
            <asp:ListItem Value="CHFrame">Counter-Hit Frame</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="sortingFilter" CssClass="smallPadding">
            <asp:ListItem Value="noSort">No sorting</asp:ListItem>
            <asp:ListItem Value="Descending">Descending</asp:ListItem>
            <asp:ListItem Value="Ascending">Ascending</asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBox runat="server" ID="specFrame" Font-Bold="False" />
        <asp:Label runat="server" AssociatedControlID="specFrame" Font-Bold="False">Specific Frame</asp:Label>
        <asp:Label ID="searchTxtLbl" runat="server" Text="Search text:" CssClass="largePadding"></asp:Label>
        <asp:TextBox ID="searchField" runat="server" KeyDown="SearchFieldKeyDown" CssClass="smallPadding"></asp:TextBox>
        <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="RefreshMoves" CssClass="searchBtn" />
        <br />
       <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Something went wrong.." ControlToValidate="searchField" OnServerValidate="ValidationOfSearch"></asp:CustomValidator>
        
        <br />
    </asp:Panel>
    <div>
        <asp:GridView ID="MoveList" runat="server" AutoGenerateColumns="False" CssClass="myTable">
            <Columns>
                <asp:BoundField DataField="Command" HeaderText="Command" ItemStyle-CssClass="cellContent" />
                <asp:BoundField DataField="HitLevel" HeaderText="Hit Level" ItemStyle-CssClass="cellContent" />
                <asp:BoundField DataField="Damage" HeaderText="Damage" ItemStyle-CssClass="cellContent" />
                <asp:BoundField DataField="StartUpFrameDisplay" HeaderText="Start-Up Frame" ItemStyle-CssClass="cellContent" />
                <asp:BoundField DataField="BlockFrameDisplay" HeaderText="Block-Frame" ItemStyle-CssClass="cellContent" />
                <asp:BoundField DataField="HitFrameDisplay" HeaderText="Hit-Frame" ItemStyle-CssClass="cellContent" />
                <asp:BoundField DataField="CHFrameDisplay" HeaderText="Counter-Hit Frame" ItemStyle-CssClass="cellContent" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
