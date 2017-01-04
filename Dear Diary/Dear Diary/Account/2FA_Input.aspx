<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="2FA_Input.aspx.cs" Inherits="Dear_Diary.Account._2FA_Input" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="2FA"></asp:Label>
    <br />
    <asp:Label runat="server" Text="Please enter the code that has been sent to you. " ID="Label2"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Code: "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" CssClass ="text-danger"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Resend code" OnClick="Button2_Click" />
&nbsp;

</asp:Content>
