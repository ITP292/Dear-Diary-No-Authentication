<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPasswordEmailSent.aspx.cs" Inherits="Dear_Diary.Account.ForgetPasswordEmailSent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label runat="server" Text="An email has been sent to you. Check your email to reset your password." ID="Label2"></asp:Label>

    <br />
    <asp:Label runat="server" Text="Click " ID="Label4"></asp:Label>

    <a href="/Account/Login">here</a>
    <asp:Label runat="server" Text=" to login." ID="Label3"></asp:Label>

</asp:Content>
