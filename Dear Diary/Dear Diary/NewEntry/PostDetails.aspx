<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostDetails.aspx.cs" Inherits="Dear_Diary.NewEntry.PostDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="main-wrapper comment">
            <div class="comment-heading">
                <h1>Post Entry Details</h1>
            </div>

            <%--this is for display post details--%>
            <div class="comment-body">
                <div class="comment-img left">
                    <asp:Image ImageUrl="imageurl" ID="img" Width="150" Height="150" runat="server" />
                </div>
                <div class="comment-content right">
                    <div class="date">
                    </div>
                    <%--<textarea id="ta" class="comment-content-cust" visible="false" runat="server" clientidmode="Static"></textarea>--%>
                    <p id="ta" runat="server"></p>
                    <div class="mode">
                    </div>
                </div>
                <div class="comment-on right">
                    <div class="left">
                        <span>Post By :
                            <asp:Label Text="" ID="lblPostBy" runat="server" /></span>
                    </div>
                    <span><asp:Label Text="" ID="lblPermission" runat="server" /></span>
                    <div class="right">
                        <span>Post On :
                            <asp:Label Text="" ID="lblPostOn" runat="server" /></span>
                    </div>
                </div>
                <div class="clear"></div>

                <%--this is for display list of comments on this post --%>
                <asp:Repeater ID="rptCommentList" runat="server" OnItemCommand="rptCommentList_ItemCommand">
                    <ItemTemplate>
                        <div class="comment-post right">
                            <div class="comment-box">
                                <span><%# Eval("Comment_Text") %></span>
                            </div>
                            <div>
                                <asp:Label ID="lblComment_Id" runat="server" Text='<%# Eval("Comment_Id") %>' Visible = "false" />
                                <asp:ImageButton ImageUrl="~/Content/img/delete.jpg" Visible='<%# Eval("isMyComment").ToString() == "true" %>' OnClick="OnDelete" CssClass="delete-comment" ID="btnCommentDelete" runat="server" />
                            </div>
                            <div class="comment-posted">
                                <span class="left">Comment By : 
                                    <asp:Label Text='<%# Eval("Comment_By") %>' ID="lblCommentBy" runat="server" />
                                </span>
                                <span class="right">Comment On :
                                    <asp:Label Text='<%# Eval("Date_Added", "{0:dd MMM yyyy}") %>' ID="lblCommentOn" runat="server" />
                                </span>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <%--this is for add new commnet on post --%>    
                <div class="comment-text right">
                    <div class="comment-sign-img left">
                        <img src="/Content/img/comment-sign.png" />
                    </div>
                    <div class="comment-input left">
                        <input type="text" name="comment" id="txtComment" onkeydown = "return (event.keyCode!=13);" runat="server" />
                    </div>
                    <div class="right comment-btn">
                        <asp:Button Text="Post" ID="btnPost" OnClick="btnPost_Click" runat="server" />
                    </div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
</asp:Content>
