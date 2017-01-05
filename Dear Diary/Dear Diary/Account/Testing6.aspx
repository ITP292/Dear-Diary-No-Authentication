<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Testing6.aspx.cs" Inherits="Dear_Diary.Account.Testing6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Counter"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Message"></asp:Label>
</asp:Content>
