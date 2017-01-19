<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Dear_Diary.Profile.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
    <br />
    <center>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    </center>
    <br />
    <asp:TextBox ID="userName" runat="server" ReadOnly="True" OnTextChanged="userName_TextChanged"></asp:TextBox>
    <br />
    <asp:TextBox ID="userEmail" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
</asp:Content>
