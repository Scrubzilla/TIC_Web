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
                <asp:Menu ID="Menu1" runat="server">
                    <Items>
                        <asp:MenuItem Text="Frame Data" Value="Frame Data"></asp:MenuItem>
                        <asp:MenuItem Text="Learning" Value="Learning">
                            <asp:MenuItem Text="Character Info" Value="Character Info"></asp:MenuItem>
                            <asp:MenuItem Text="Tutorials" Value="Tutorials">
                                <asp:MenuItem Text="Basics" Value="Basics"></asp:MenuItem>
                                <asp:MenuItem Text="Specific" Value="Specific"></asp:MenuItem>
                                <asp:MenuItem Text="Character" Value="Character"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Websites" Value="Websites"></asp:MenuItem>
                            <asp:MenuItem Text="Notes" Value="Notes"></asp:MenuItem>
                            <asp:MenuItem Text="Legend" Value="Legend"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Ranking" Value="Ranking">
                            <asp:MenuItem Text="Ranks" Value="Ranks"></asp:MenuItem>
                            <asp:MenuItem Text="Statistics" Value="Statistics"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Tournaments" Value="Tournaments"></asp:MenuItem>
                        <asp:MenuItem Text="Social" Value="Social">
                            <asp:MenuItem Text="About" Value="About"></asp:MenuItem>
                            <asp:MenuItem Text="Social Media" Value="Social Media"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Technical" Value="Technical">
                            <asp:MenuItem Text="Changelog" Value="Changelog"></asp:MenuItem>
                            <asp:MenuItem Text="Download" Value="Download"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                </asp:Menu>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
