<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Dear_Diary.Account.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Reset your password"></asp:Label>
    <br />
    <asp:Label runat="server" Text="Enter your new password. " ID="Label2"></asp:Label>
    <hr />
    <br />


    <asp:Label Font-Size="20px" ID="Label3" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="180px" TextMode="Password"></asp:TextBox>
    

</asp:Content>
