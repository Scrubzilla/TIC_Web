<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="TIC_Web.Account.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage roles & users.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <br />
        <h4>Add a new role</h4>
        <hr />
        <div class="form-group">
            <div class="col-md-10">
                <asp:Label runat="server" ID="RoleLabel" AssociatedControlID="RoleNameBox" CssClass="col-md-2 control-label">Role name</asp:Label>
                <asp:TextBox runat="server" ID="RoleNameBox" TextMode="SingleLine" />
                <br />
                <asp:Label runat="server" ID="StatusLabel"></asp:Label>
                <br />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateRole" Text="Create" CssClass="btn btn-default" />
            </div>
        </div>
        <hr />
        <h4>Change a users role</h4>
        <div class="form-group">
            <div class="col-md-10">
                <asp:Label runat="server" AssociatedControlID="DropDownList1" CssClass="col-md-2 control-label">User</asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="GetAllUsersAndId" DataTextField="UserName" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="GetAllUsersAndId" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [UserName], [Id] FROM [AspNetUsers]"></asp:SqlDataSource>
                <br />
                <br />
                <asp:Label runat="server" AssociatedControlID="DropDownList2" CssClass="col-md-2 control-label">Role</asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="GetAllRoles" DataTextField="Name" DataValueField="Name"></asp:DropDownList>
                <asp:SqlDataSource ID="GetAllRoles" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name] FROM [AspNetRoles]"></asp:SqlDataSource>
                <br />
                <asp:Label runat="server" ID="StatusLabel2"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="ChangeUserRole" Text="Submit" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <h2>Change data</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="Literal1" />
        </p>
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" href="#collapse1">Add</a>
                    </h4>
                </div>
                <div id="collapse1" class="panel-collapse collapse">
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:DropDownList ID="TableList" runat="server" OnIndexSelected="LoadDynContent">
                                    <asp:ListItem Value="Characters">Characters</asp:ListItem>
                                    <asp:ListItem Value="Moves"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button runat="server" OnClick="LoadDynContent" Text="Begin" CssClass="btn modBootBtn" CausesValidation="True" />
                                <asp:Panel ID="Panel4" runat="server">
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="panel-footer">Panel Footer</div>
                </div>
            </div>
        </div>
        <br />
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" href="#collapse2">Modify</a>
                    </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse">
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownList3" runat="server" OnIndexSelected="LoadDynContent">
                                    <asp:ListItem Value="Characters">Characters</asp:ListItem>
                                    <asp:ListItem Value="Moves"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button runat="server" OnClick="LoadDynContent" Text="Begin" CssClass="btn modBootBtn" CausesValidation="True" />
                                <asp:Panel ID="Panel1" runat="server">
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="panel-footer">Panel Footer</div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
