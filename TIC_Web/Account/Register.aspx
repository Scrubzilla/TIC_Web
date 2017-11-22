<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TIC_Web.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <h2 class="centralized"><%: Title %></h2>
    <p class="text-danger centralized">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <h4 class="centralized">Create a new account</h4>
    <hr />
    <div class="top">
        <div class="left">
            &nbsp;
        </div>
        <div class="center">
            <asp:ValidationSummary runat="server" CssClass="text-danger" />
        </div>
        <div class="right">
            &nbsp;
        </div>
    </div>
    <div class="form-horizontal centralized">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="control-label">Email</asp:Label>
            <asp:TextBox runat="server" ID="Email" CssClass="form-control center_div" TextMode="Email" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
        </div>
        <div class="form-group centralized">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control center_div" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control center_div" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
        </div>
        <br />
        <div class="form-group">
            <div class="centralized">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn modBootBtn" />
            </div>
        </div>
    </div>
</asp:Content>
