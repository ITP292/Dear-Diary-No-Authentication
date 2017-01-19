<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Dear_Diary.Profile.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        <style > 
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
    <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
    <br />
    <center>
    <label class="file-upload"><asp:FileUpload ID="FileUpload1" runat="server" /></label>
    </center>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <asp:TextBox ID="userName" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:TextBox ID="userEmail" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
</asp:Content>
