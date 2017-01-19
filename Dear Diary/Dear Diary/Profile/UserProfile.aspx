<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Dear_Diary.Profile.WebForm2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

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
        .auto-style1 {
            margin-left: 0px;
        }
        .auto-style2 {
            margin-left: 0;
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
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Pictures/Style/Message_chat_text_bubble_phone.png" OnClick="ImageButton1_Click" />
    <br />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2" Height="208px" ReadOnly="True" TextMode="MultiLine" Width="1086px"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style2" Height="208px" ReadOnly="True" TextMode="MultiLine" Width="1086px"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style2" Height="208px" ReadOnly="True" TextMode="MultiLine" Width="1086px"></asp:TextBox>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
