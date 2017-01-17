<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dear_Diary.Account.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <%--<div style="font-size: 30px">--%>
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Log in. "></asp:Label>
    <br />
    <asp:Label runat="server" Text="Log in to your account. "></asp:Label>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Login with your credential."></asp:Label>
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    <br />

    <div class="col-md-12 text-center">
        <div class="form-horizontal col-md-6 col-xs-offset-3">
            
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" CssClass="text-danger"></asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>

            <div class="form-group">
                <asp:Label Font-Size="20px" ID="Label2" class="col-xs-3 control-label" runat="server" Text="Email"></asp:Label>
                <div class="col-xs-8">
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
            <div class="form-group">
                <asp:Label Font-Size="20px" class="col-xs-3 control-label" ID="Label3" runat="server" Text="Password"></asp:Label>
                <div class="col-xs-8">
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Label ID="Label5" runat="server" CssClass="text-danger"></asp:Label>
                <asp:Label ID="Label8" runat="server" CssClass="text-danger"></asp:Label>
            </div>

            <div class="form-group">
                <div class="col-xs-8 col-xs-offset-3">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text=" Remember Me?" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-8 col-xs-offset-3">
                    <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Log in" OnClick="Login_Click" />
                </div>
            </div>
            <br />
            <br />

            <div class="form-group">
                <div class="col-xs-8 col-xs-offset-3">
    <a href="/Account/Register">Register as a new user</a>
    <br />
    <%--Insert link of /Account/ForgotPassword (forgot password page) here--%>
    <a href="/Account/ForgotPassword">Forgot password</a>

    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="10000" Enabled="False"></asp:Timer>
    <%-- 1000 = 1 second, 10000 = 10 seconds, 300000 = 5 minutes = 300 seconds --%>
                   </div>
            </div>
        </div>
    </div>
<%--    <asp:Timer ID="Timer2" runat="server" ontick="Timer2_Tick" Interval="1000" Enabled="False"></asp:Timer>--%>
</asp:Content>

