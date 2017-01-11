<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="requestFriend.aspx.cs" Inherits="Dear_Diary.Friends.requestFriend" %>
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
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Email Address:</asp:Label>
                        <asp:TextBox runat="server" ID="FriendEmail" CssClass="form-control" ReadOnly="True" />
                        <br />
                         <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Accept" CssClass="btn btn-default" OnClick="Button1_Click" />
                            &nbsp;
                            <asp:Button runat="server" Text="Decline" CssClass="btn btn-default" OnClick="Button2_Click" />
                        </div>
                    </div>
                        <br />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>