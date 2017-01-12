<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Dear_Diary.Profile.UserProfile" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />

    <hr />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick ="Save" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="Cancel" />
    </asp:Panel>

</asp:Content>
