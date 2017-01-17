<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostDraftList.aspx.cs" Inherits="Dear_Diary.NewEntry.PostDraftList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="main-wrapper draft">
            <div class="new-entry">
                <h1>Drafts</h1>
            </div>

            <%--this is for display all post which has save as draft (draft list) display--%>
            <%--first display image and post details which has save as draft--%>
            <asp:Repeater ID="rptPostList" runat="server" OnItemCommand="rptPostList_ItemCommand">
                <ItemTemplate>
                    <a class="draft-post-link" href="NewEntry.aspx?Post_Id=<%# Eval("Post_Id") %>">
                        <div class="main_dtaft">
                            <div class="img_draft left">
                                <asp:Image ImageUrl='<%# Eval("Picture") %>' ID="img" runat="server" />
                            </div>
                            <div class="draft-content right">
                                <p>
                                    <asp:Label ID="lblposttext" runat="server" Text='<%# Eval("Post_Text") %>' />
                                </p>
                            </div>
                        </div>
                        <div class="clear"></div>
                    </a>
                    <div class="post-footer">
                        Save as Draft on :
                        <asp:Label ID="lblPostDraftOn" runat="server" Text='<%# Eval("Date_Added","{0:dd MMM yyyy}") %>' />
                        <asp:LinkButton CssClass="draft-post-delete" CommandName="Delete" CommandArgument='<%# Eval("Post_Id") %>' Text="Delete Post" ID="lnkDraftDelete" runat="server" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
