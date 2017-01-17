<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostEntryList.aspx.cs" Inherits="Dear_Diary.NewEntry.PostEntryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="main-wrapper draft">
            <div class="new-entry">
                <div>
                    <h1>Post Entry</h1>
                </div>

                <%--this is for search post --%>
                <div class="post-search">
                    Search :
                <asp:TextBox runat="server" Style="color:black" ID="txtSearchPostEntry" Width="200px" />
                    &nbsp;&nbsp; 
                    <asp:Button Text="Search" Style="color:black" ID="btnSearchPostEntry" OnClick="btnSearchPostEntry_Click" runat="server" />
                </div>
            </div>

            <%-- this is for display list of post entry, this is repeater control for repeat post entry details --%>
            <asp:Repeater ID="rptPostEntryList" runat="server" OnItemCommand="rptPostEntryList_ItemCommand">
                <ItemTemplate>
                    <a class="draft-post-link" href="PostDetails.aspx?Post_Id=<%# Eval("Post_Id") %>">
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
        </div>
</asp:Content>
