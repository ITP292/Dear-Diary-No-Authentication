<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Dear_Diary.Friends.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ooops!</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server">Our hamsters have detected that the person that you searched for is already in your friends list!</asp:Label>
                    </div>
                   
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Go Back" CssClass="btn btn-default" OnClick="Unnamed2_Click" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>