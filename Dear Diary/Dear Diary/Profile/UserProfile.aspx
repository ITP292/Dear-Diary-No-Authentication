<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Dear_Diary.Profile.WebForm2" %>

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

        .userInfo {
            display: inline-block;
            font-family:  Century Gothic, sans-serif;
        }
    </style>
    <br />
    <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" EnableTheming="True" />
    <br />
    <div style="float-left">
            <center>
            <!-- allow only certain file extension to be uploaded -->
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ErrorMessage="Only image extensions of .png , and .jpg are allowed!"
                ValidationExpression="^.+(.png|.PNG|.jpg|.JPG)$"
                ControlToValidate="FileUpload1"> 
            </asp:RegularExpressionValidator>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
            </center>
    </div>

    <div style="float-left">
        <asp:Label ID="userName" CssClass="userInfo" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="userEmail" CssClass="userInfo" runat="server" Text="Label"></asp:Label>
    </div>
    <br />
</asp:Content>
