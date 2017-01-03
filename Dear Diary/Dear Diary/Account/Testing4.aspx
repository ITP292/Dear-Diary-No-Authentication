<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Testing4.aspx.cs" Inherits="Dear_Diary.Account.Testing4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Start" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Timer ID="Timer1" runat="server" Interval ="5000">
    </asp:Timer>

</asp:Content>
