<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TIC_Web.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <h2 class="centralized"><%: Title %></h2>
    <hr />
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <section id="loginForm">
                <div class="form-horizontal centralized">
                    <div class="form-group">
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                    </div>
                    <div class="form-group centralized">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control center_div" TextMode="Email" placeholder="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
                    </div>
                    <div class="form-group centralized">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control center_div" placeholder="Password" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                    <div class="centralized">
                        <asp:CheckBox runat="server" ID="RememberMe" Font-Bold="False" />
                        <asp:Label runat="server" AssociatedControlID="RememberMe" Font-Bold="False">Remember me?</asp:Label>
                    </div>
                    <div class="centralized">
                        <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn modBootBtn" />
                    </div>
                </div>
            </section>
        </div>
    </div>
    <br />
    <div class="centralized">
        <p>
            <asp:Label runat="server">Don't have an account?</asp:Label>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" CssClass="custLinkButton">Register as a new user</asp:HyperLink>
        </p>
        <p>
            <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
            --%>
        </p>
    </div>

</asp:Content>
