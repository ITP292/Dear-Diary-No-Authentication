<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Timer1.aspx.cs" Inherits="Dear_Diary.Account.Timer1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <asp:Button ID="Button1" runat="server" Text="1st" OnClick="Button1_Click" />
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="2nd" />
    <br />
<%--    <asp:Timer ID="Timer1" runat="server"></asp:Timer>--%>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
