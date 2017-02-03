<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfileSettings.aspx.cs" Inherits="Dear_Diary.Profile.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .file-upload {
            display: inline-block;
            overflow: hidden;
            text-align: center;
            vertical-align: middle;
            font-family: Arial;
            border: 1px solid #124d77;
            background: #007dc1;
            color: #fff;
            border-radius: 6px;
            -moz-border-radius: 6px;
            cursor: pointer;
            text-shadow: #000 1px 1px 2px;
            -webkit-border-radius: 6px;
        }
    </style>
    <br />
    <asp:Image ID="Image1" runat="server" Height="118px" Width="104px" />

    <label class="file-upload">

        <asp:FileUpload ID="FileUpload1" runat="server" /></label>
    <center>
            <!-- allow only certain file extension to be uploaded -->
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ErrorMessage="Only image extensions of .png , and .jpg are allowed!"
                ValidationExpression="^.+(.png|.PNG|.jpg|.JPG)$"
                ControlToValidate="FileUpload1"> 
            </asp:RegularExpressionValidator>
            </center>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" Style="text-align: center;" />
    <br />
    <br />
    <asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="editFName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="editLName" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="  New Password:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    &nbsp;&nbsp;
    <br />
    <asp:Label ID="lblCfmPassword" runat="server" Text="Confirm Password:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtCfmPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtCfmPassword"
        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
    <asp:Label ID="Label5" runat="server" CssClass="text-danger"></asp:Label>
    <br />

    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
    <br />
    <hr />
    <br />

</asp:Content>
