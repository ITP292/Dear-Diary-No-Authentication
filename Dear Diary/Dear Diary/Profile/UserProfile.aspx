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
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Pictures/Style/Message_chat_text_bubble_phone.png" OnClick="ImageButton1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand"></asp:Repeater>
    <itemtemplate>
                           <a class="draft-post-link" href="/NewEntry/PostDetails.aspx?Post_Id=<%# Eval("Post_Id") %>">
                        <div class="main_dtaft">
                            <div class="img_draft left">
                                <asp:Image ImageUrl='<%# Eval("Picture") %>' ID="img" runat="server" />
                            </div>
                            <div class="draft-content right">
                                <p>
                                    <asp:Label ID="lblpostEntrytext" runat="server" Text='<%# Eval("Post_Text") %>' />
                                </p>
                            </div>
                        </div>
                        <div class="clear"></div>
                    </a>
        <div class="post-footer">
                        Posted on :
                        <asp:Label ID="lblPostEntryOn" runat="server" Text='<%# Eval("Date_Added","{0:dd MMM yyyy}") %>' />
                        <asp:LinkButton CssClass="draft-post-delete" CommandName="Delete" CommandArgument='<%# Eval("Post_Id") %>' Text="Delete Post" ID="lnkPostDelete" runat="server" />
                    </div>
    </itemtemplate>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localdbConnectionString1 %>" SelectCommand="SELECT [Permission_Status], [Date_Added], [Post_Text], [Picture] FROM [Post] WHERE ([Permission_Status] = @Permission_Status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="public" Name="Permission_Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
