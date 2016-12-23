<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Dear_Diary.Account.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Forgot your password?"></asp:Label>
    <br />
    <asp:Label runat="server" Text="Enter your email, we will sent you a link to reset your password." ID="Label2"></asp:Label>
    <br />
    <br />
    <asp:Label Font-Size="20px" ID="Label3" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="180px" TextMode="Email"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" CssClass="text-danger"></asp:Label>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
        CssClass="text-danger" ErrorMessage="The email field is required." />

    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Email me" Width="98px" OnClick="EmailMe_Click" />

</asp:Content>
