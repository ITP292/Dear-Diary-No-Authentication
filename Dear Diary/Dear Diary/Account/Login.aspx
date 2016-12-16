<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dear_Diary.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <%--<div style="font-size: 30px">--%>
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Log in. "></asp:Label>
    <br />

    <%--</div>--%>

    <asp:Label runat="server" Text="Log in to your account. "></asp:Label>
    <hr />
    <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    
</asp:Content>
