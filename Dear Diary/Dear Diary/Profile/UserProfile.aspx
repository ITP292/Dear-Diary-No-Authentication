<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Dear_Diary.Profile.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
            font-family: Century Gothic, sans-serif;
        }

        .auto-style1 {
            margin-left: 0px;
        }
    </style>
    <br />
    <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" EnableTheming="True" />
    <br />

    <div style="float-left">
        <asp:Label ID="userName" CssClass="userInfo" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="userEmail" CssClass="userInfo" runat="server" Text="Label"></asp:Label>
    </div>
    <asp:ImageButton ID="noOfPosts" runat="server" ImageUrl="~/Pictures/Style/Picture1.png" OnClick="noOfPosts_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="noOfFriends" runat="server" CssClass="auto-style1" ImageUrl="~/Pictures/Style/friendicon.png" OnClick="noOfFriends_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="newsFeed" runat="server" ImageUrl="~/Pictures/Style/Message_chat_text_bubble_phone.png" OnClick="newsFeed_Click" />
    <br />
    <asp:Label ID="lblPosts" runat="server" Text="Posts so far: "></asp:Label>
    <asp:Label ID="lblPostsCount" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblFriends" runat="server" Text="Friends since joined: "></asp:Label>
    <asp:Label ID="lblFriendsCount" runat="server" Text="Label"></asp:Label>
    <br />

</asp:Content>
