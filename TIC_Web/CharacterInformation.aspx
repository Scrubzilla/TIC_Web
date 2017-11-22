<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CharacterInformation.aspx.cs" Inherits="TIC_Web.CharacterInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Character Information</h2>
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/CharacterSelect?section=charinfo" CssClass="custLinkButton">Back to character select</asp:LinkButton>
    <br />
    <br />
    <div class="charInfoLeft">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/CharacterPortraits/asuka_off.png" />

        <div class="charInfoMenu">
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Punishers" Value="Punishers"></asp:MenuItem>
                    <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                    <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </div>
    </div>

    <div class="charInfoRight">
        <h2>Asuka</h2>
        <hr />
        <div class="charInfoDesc">
            <p>

            </p>
        </div>
        <div class="charInfoContent">
            <p class="charInfoText">
                Testing some textitext.
            </p>
        </div>

        <asp:label runat="server" ID="test"></asp:label>

    </div>
    <div class="charInfoBotSpacing"></div>
</asp:Content>
