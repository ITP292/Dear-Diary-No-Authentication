﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewFriend.aspx.cs" Inherits="Dear_Diary.Friends.viewFriend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .mydatagrid
{
	width: 80%;
	border: solid 2px black;
	min-width: 80%;
}
.header
{
	background-color: #646464;
	font-family: Arial;
	color: White;
	border: none 0px transparent;
	height: 25px;
	text-align: center;
	font-size: 16px;
}

.rows
{
	background-color: #fff;
	font-family: Arial;
	font-size: 14px;
	color: #000;
	min-height: 25px;
	text-align: left;
	border: none 0px transparent;
}
.rows:hover
{
	background-color: #ff8000;
	font-family: Arial;
	color: #fff;
	text-align: left;
}
.selectedrow
{
	background-color: #ff8000;
	font-family: Arial;
	color: #fff;
	font-weight: bold;
	text-align: left;
}
.mydatagrid a /** FOR THE PAGING ICONS  **/
{
	background-color: Transparent;
	padding: 5px 5px 5px 5px;
	color: #fff;
	text-decoration: none;
	font-weight: bold;
}

.mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/
{
	background-color: #000;
	color: #fff;
}
.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
{
	background-color: #c9c9c9;
	color: #000;
	padding: 5px 5px 5px 5px;
}
.pager
{
	background-color: #646464;
	font-family: Arial;
	color: White;
	height: 30px;
	text-align: left;
}

.mydatagrid td
{
	padding: 5px;
}
.mydatagrid th
{
	padding: 5px;
}
    </style>

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
                            &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." Width="770px" DataKeyNames="User2_Email" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                                <Columns>
                                    <asp:BoundField DataField="User2_Email" HeaderText="Email Address" SortExpression="User2_Email" />
                                    <asp:BoundField DataField="Date_Added" HeaderText="Date Added" SortExpression="Date_Added" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                    <asp:ButtonField Text="Select" CommandName="Select" ControlStyle-BackColor="LightBlue" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localdbConnectionString1 %>" DeleteCommand="DELETE FROM [Friendship] WHERE [User1_Email] = @User1_Email AND [User2_Email] = @User2_Email" InsertCommand="INSERT INTO [Friendship] ([User1_Email], [User2_Email], [Date_Added], [Status], [Read]) VALUES (@User1_Email, @User2_Email, @Date_Added, @Status, @Read)" SelectCommand="SELECT [User2_Email], [Date_Added], [Status] FROM [Friendship] WHERE User1_Email = @email" UpdateCommand="UPDATE [Friendship] SET [Date_Added] = @Date_Added, [Status] = @Status, [Friendship_id] = @Friendship_id, [Read] = @Read WHERE [User1_Email] = @User1_Email AND [User2_Email] = @User2_Email">
                                <DeleteParameters>
                                    <asp:Parameter Name="User1_Email" Type="String" />
                                    <asp:Parameter Name="User2_Email" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="User1_Email" Type="String" />
                                    <asp:Parameter Name="User2_Email" Type="String" />
                                    <asp:Parameter Name="Date_Added" Type="String" />
                                    <asp:Parameter Name="Status" Type="String" />
                                    <asp:Parameter Name="Read" Type="String" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:SessionParameter Name="email" SessionField="email" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Date_Added" Type="String" />
                                    <asp:Parameter Name="Status" Type="String" />
                                    <asp:Parameter Name="Friendship_id" Type="Int32" />
                                    <asp:Parameter Name="Read" Type="String" />
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