<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Testing2.aspx.cs" Inherits="Dear_Diary.Account.Testing2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="2FA input:       "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Results of 2FA"></asp:Label>


    <br />
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get time now" />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Time"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Generate Code" />
&nbsp;<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Confirm code" />
&nbsp;<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Time Difference" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Answer"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
    <br />


</asp:Content>
