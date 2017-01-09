<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="NewEntry.aspx.cs" Inherits="Dear_Diary.NewEntry.NewEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
        <div class="main-wrapper diary">
            <div class="new-entry">
                <h1>New Entry</h1>
            </div>
            <div class="main left">
                <div class="contant-diary">
                    <textarea id="ta" class="text-line" runat="server" maxlength="1800" onkeypress="coutrows(event)" cols="65">dear dairy,</textarea>
                </div>
            </div>
            <div class="button right">
                <div class="top-btn">
                    <asp:Button class='drafts' ID="btnDraftList" Text="DRAFTS" runat="server" OnClick="btnDraftList_Click" />
                </div>
                <div class="option">
                    <div id="setting" class="setting left">
                        <img src="../Content/img/setting.png" />
                    </div>
                    <div class="select open right">
                        <asp:DropDownList class="open" ID="ddlSetting" OnSelectedIndexChanged="ddlSetting_OnSelectedIndexChanged" runat="server">
                            <asp:ListItem Value="Private" Text="Private" />
                            <asp:ListItem Value="Public" Text="Public" />
                        </asp:DropDownList>
                     </div>
                    <div class="clear"></div>
                </div>
                <div class="bottom-btn">
                    <asp:Button class='save' ID="tblDraft" Text="Save as drafts" runat="server" OnClick="tblDraft_Click" />
                    <asp:Button class='done' ID="btnPost" Text="I'm done" runat="server" OnClick="btnPost_Click" />
                </div>
            </div>
            <div class="clear"></div>
        </div>
    </form>
    <script>
        function coutrows(event) {
            var rows = document.getElementById('ta').value.split("\n").length;
            var count = document.getElementById('ta').value.length;
            var keycode = event.which || event.keyCode;
            if (rows > 29 && keycode == 13) {
                document.getElementById("ta").maxLength = count;
            }
            if (keycode != 13) {
                document.getElementById("ta").maxLength = "1800";
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
