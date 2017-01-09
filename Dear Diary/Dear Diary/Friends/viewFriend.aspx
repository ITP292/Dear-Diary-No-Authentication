<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewFriend.aspx.cs" Inherits="Dear_Diary.Friends.viewFriend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>View Your Friends!</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <div class="col-md-10">
                            Pull data from database and display here.<asp:Repeater ID="rptTable" runat="server">
    <HeaderTemplate>
        <table class="table">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td width="50%"><%# Eval("identifier") %></td>
            <td width="*"><%# Eval("value") %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localdbConnectionString1 %>" DeleteCommand="DELETE FROM [Friendship] WHERE [User1_Email] = @User1_Email AND [User2_Email] = @User2_Email" InsertCommand="INSERT INTO [Friendship] ([User1_Email], [User2_Email], [Date_Added]) VALUES (@User1_Email, @User2_Email, @Date_Added)" SelectCommand="SELECT [User1_Email], [User2_Email], [Date_Added] FROM [Friendship]" UpdateCommand="UPDATE [Friendship] SET [Date_Added] = @Date_Added WHERE [User1_Email] = @User1_Email AND [User2_Email] = @User2_Email">
                                <DeleteParameters>
                                    <asp:Parameter Name="User1_Email" Type="String" />
                                    <asp:Parameter Name="User2_Email" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="User1_Email" Type="String" />
                                    <asp:Parameter Name="User2_Email" Type="String" />
                                    <asp:Parameter DbType="Date" Name="Date_Added" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter DbType="Date" Name="Date_Added" />
                                    <asp:Parameter Name="User1_Email" Type="String" />
                                    <asp:Parameter Name="User2_Email" Type="String" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>