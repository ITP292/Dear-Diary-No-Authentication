<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewFriendRedir.aspx.cs" Inherits="Dear_Diary.Friends.viewFriendRedir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="Header" runat="server" Text="Friend Name Here"></asp:Label>
    </h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Profile Picture:</asp:Label>
                        <%--Insert Picture Here --%>
                        <br />
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Email Address:</asp:Label>
                        <asp:TextBox runat="server" ID="FriendEmail" CssClass="form-control" ReadOnly="True" />
                        <br />
                         <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Go Back" CssClass="btn btn-default" OnClick="Button1_Click" />
                            &nbsp;
                            </div>
                    </div>
                        <br />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>