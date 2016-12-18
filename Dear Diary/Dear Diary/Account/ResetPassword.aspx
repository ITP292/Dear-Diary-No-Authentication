<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Dear_Diary.Account.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Reset your password"></asp:Label>
    <br />
    <asp:Label runat="server" Text="Enter your new password. " ID="Label2"></asp:Label>
    <hr />
    <br />


    <asp:Label Font-Size="20px" ID="Label3" runat="server" Text="New Password: "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="180px" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
        CssClass="text-danger" ErrorMessage="The password field is required." />


    <br />


    <asp:Label Font-Size="20px" ID="Label4" runat="server" Text="Confirm Password: "></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="180px" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2"
        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
    <asp:CompareValidator runat="server" ControlToCompare="TextBox1" ControlToValidate="TextBox2"
        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />

    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Reset" />
    

</asp:Content>
