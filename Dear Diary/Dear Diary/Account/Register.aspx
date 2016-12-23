<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Dear_Diary.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Register. "></asp:Label>
    <br />
    <asp:Label runat="server" Text="Create a new account. " ID="Label2"></asp:Label>
    <hr />
    <br />

    <%--FirstName--%>
    <asp:Label Font-Size="20px" ID="Label3" runat="server" Text="First Name"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="180px"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
        CssClass="text-danger" ErrorMessage="The name field is required." />

    <br />
    <br />

    <%--LastName--%>
    <asp:Label Font-Size="20px" ID="Label4" runat="server" Text="Last Name"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="180px"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2"
        CssClass="text-danger" ErrorMessage="The name field is required." />
    <br />
    <br />

    <%--Email--%>
    <asp:Label Font-Size="20px" ID="Label5" runat="server" Text="Email"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="180px" TextMode="Email"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox3"
        CssClass="text-danger" ErrorMessage="The email field is required." />
    <br />
    <br />

    <%--Password--%>
    <asp:Label Font-Size="20px" ID="Label6" runat="server" Text="Password"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="180px" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox4"
        CssClass="text-danger" ErrorMessage="The password field is required." />
    <br />
    <br />

    <%--Confirm Password--%>
    <asp:Label Font-Size="20px" ID="Label7" runat="server" Text="Confirm Password" EnableTheming="True"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="180px" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox5"
        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
    <asp:CompareValidator runat="server" ControlToCompare="TextBox4" ControlToValidate="TextBox5"
        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
    <br />
    <br />

    <%--Phone Number--%>
    <asp:Label Font-Size="20px" ID="Label8" runat="server" Text="Phone Number"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server" Height="30px" Width="180px" TextMode="Phone"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox6"
        CssClass="text-danger" ErrorMessage="The phone number field is required." />


    <br />
    <asp:Label ID="Label9" runat="server" CssClass="text-danger"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Register_Click" />


</asp:Content>
