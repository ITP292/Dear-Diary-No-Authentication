﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Testing2.aspx.cs" Inherits="Dear_Diary.Account.Testing2" %>
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


</asp:Content>
