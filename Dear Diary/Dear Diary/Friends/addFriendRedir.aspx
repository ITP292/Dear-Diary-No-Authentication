<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addFriendRedir.aspx.cs" Inherits="Dear_Diary.Friends.addFriendRedir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Friend Name Here</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <div class="form-group">
                        <div class="col-md-10">Profile Picture:</div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">Email Address:</div>
                        <asp:TextBox runat="server" ID="FriendEmail" CssClass="form-control" ReadOnly="True" />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Accept" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="Deny" />
                        <br />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>