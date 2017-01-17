<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewEntry.aspx.cs" Inherits="Dear_Diary.NewEntry.NewEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-wrapper diary">
        <div class="new-entry">
            <h1>New Entry</h1>
        </div>
        <%--this is for write post code--%>
        <%--this is left part--%>
        <div class="main left">
            <div class="contant-diary">
                <asp:HiddenField ID="hdPostId" runat="server" />
                <textarea id="ta" class="text-line" runat="server" maxlength="2800" clientidmode="Static" onkeypress="coutrows(event)" cols="65">dear dairy,</textarea>
            </div>
        </div>

        <%--this is right part for dipslay all button (draft, save as draft and i'm done) and file upload control--%>
        <div class="button right">
            <div class="top-btn">
                <asp:Button class='drafts' ID="btnDraftList" Text="DRAFTS" runat="server" OnClick="btnDraftList_Click" />
            </div>
            <div class="option">
                <div id="setting" class="setting left">
                    <img src="/Content/img/setting.png" />
                </div>
                <div class="select open right">
                    <asp:DropDownList class="open" ID="ddlSetting" runat="server">
                        <asp:ListItem Value="Private" Text="Private" />
                        <asp:ListItem Value="Public" Text="Public" />
                    </asp:DropDownList>
                </div>

                <div class="clear"></div>
            </div>
            <div style="padding-top: 50px;">
                <asp:FileUpload ID="FileUpload1" style="color: white;" Width="200px" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
            </div>
            <div style="padding-top: 10px">
                <asp:Image ImageUrl="imageurl" ID="img" Width="150" Height="150" runat="server" />
            </div>
            <div class="bottom-btn">
                <asp:Button class='save' ID="btnDraft" Text="Save as drafts" runat="server" OnClick="btnDraft_Click" />
                <asp:Button class='done' ID="btnPost" Text="I'm done" runat="server" OnClick="btnPost_Click" />
            </div>
        </div>
        <div class="clear"></div>
    </div>

    <%-- this is script for new post entry --%>
    <script>
        function coutrows(event) {
            var rows = document.getElementById('ta').value.split("\n").length;
            var count = document.getElementById('ta').value.length;
            var keycode = event.which || event.keyCode;
            if (rows > 29 && keycode == 13) {
                document.getElementById("ta").maxLength = count;
            }
            if (keycode != 13) {
                document.getElementById("ta").maxLength = "2800";
            }
        }
        $(document).ready(function () {
            $("#menu_open").click(function () {
                $(".menu").toggle(500);
            });
            $("#setting").click(function () {
                $(".open").trigger('click');
            });
        });
    </script>

</asp:Content>
