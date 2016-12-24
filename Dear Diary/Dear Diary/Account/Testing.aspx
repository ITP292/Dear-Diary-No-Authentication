<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="Dear_Diary.Account.Testing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Phone  "></asp:Label>

    <asp:TextBox ID="TextBox1" runat="server" TextMode="Phone"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" />

    <br />
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>

</asp:Content>
