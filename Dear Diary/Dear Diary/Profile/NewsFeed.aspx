<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsFeed.aspx.cs" Inherits="Dear_Diary.Profile.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
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
            </ItemTemplate>
        </asp:Repeater>
        
    </p>

</asp:Content>
