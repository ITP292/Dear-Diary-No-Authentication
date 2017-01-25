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
    <asp:TextBox ID="editFName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label>
    <asp:TextBox ID="editLName" runat="server"></asp:TextBox>
    <br />
    <hr />
    <br />

</asp:Content>
