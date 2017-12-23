<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="TIC_Web.TestPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <trigger>

               
            </trigger>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:DropDownList ID="DropDownList5" runat="server" OnIndexSelected="LoadDynContent">
                <asp:ListItem Value="Characters">Characters</asp:ListItem>
                <asp:ListItem Value="Moves"></asp:ListItem>
            </asp:DropDownList>

            <asp:Button runat="server" OnClick="LoadDynContent" Text="Begin" CssClass="btn modBootBtn" CausesValidation="True" />


            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
