<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordSucccess.aspx.cs" Inherits="Dear_Diary.Account.ResetPasswordSucccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /> 
    <br /> 
    <asp:Label runat="server" Text="Your password has been resetted. Click " ID="Label2"></asp:Label>
    <a href="/Account/Login">here</a>
    <asp:Label runat="server" Text=" to login. " ID="Label3"></asp:Label>
</asp:Content>
