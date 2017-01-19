<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadPicture.aspx.cs" Inherits="Dear_Diary.Profile.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
    <br />
    <asp:Image ID="Image1" runat="server" Height="118px" Width="104px" />
</asp:Content>
