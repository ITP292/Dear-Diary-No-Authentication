<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dear_Diary.Account.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <%--<div style="font-size: 30px">--%>
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Log in. "></asp:Label>
    <br />
    <%--</div>--%>

    <asp:Label runat="server" Text="Log in to your account. "></asp:Label>
    <hr />
    <%--Email--%>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label Font-Size="20px" ID="Label2" runat="server" Text="Email"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="180px" TextMode="Email"></asp:TextBox>

    <asp:Label ID="Label4" runat="server" CssClass="text-danger"></asp:Label>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
        CssClass="text-danger" ErrorMessage="The email field is required." />

    <br />
    <br />

    <%--Password--%>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label Font-Size="20px" ID="Label3" runat="server" Text="Password"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="180px" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2" 
        CssClass="text-danger" ErrorMessage="The password field is required." />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" CssClass="text-danger"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="CheckBox1" runat="server" Text="      Remember Me?" />

    <%--Login Button--%>
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" BackColor="#999999" Text="Log in" OnClick="Login_Click" />

    <br />
    <br />
    <%--Insert link of /Account/Register (register page) here--%>
    <a href="/Account/Register">Register as a new user</a>
    <br />
    <%--Insert link of /Account/ForgotPassword (forgot password page) here--%>
    <a href="/Account/ForgotPassword">Forgot password</a>

<%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        popupcontrolid="Panel1" targetcontrolid="Button1" cancelcontrolid="Button2" backgroundcssclass="modalBackground"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <asp:TextBox ID="TextBox3" runat="server" CssClass="box" placeholder="enter text"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Close" CssClass="buttonClose" />
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button_Confirm" />
    </asp:Panel>--%>
</asp:Content>
