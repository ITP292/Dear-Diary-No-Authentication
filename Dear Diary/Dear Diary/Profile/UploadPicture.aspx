<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadPicture.aspx.cs" Inherits="Dear_Diary.Profile.WebForm3" %>
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
    <label class="file-upload"><asp:FileUpload ID="FileUpload1" runat="server" /></label>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" Style="text-align: center;"/>
    <br />
    <asp:Image ID="Image1" runat="server" Height="118px" Width="104px" />
</asp:Content>
