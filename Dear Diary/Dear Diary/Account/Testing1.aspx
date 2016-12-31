<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing1.aspx.cs" Inherits="Dear_Diary.Account.Testing1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
            align-content: center;
        }

        .buttonClose {
            margin-top: 5px;
            margin-right: 20px;
        }

        .buttonPress {

        }

        .box {
            margin-top:80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:Button ID="Button1" runat="server" Text="Show ajax modal"/>
            <asp:Label ID="Label1" runat="server" Text="Answer"></asp:Label>

            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="2FA answer: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Confirm" />

            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                PopupControlID="Panel1" TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Results"></asp:Label>
            <br />
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="box" placeholder ="enter text"></asp:TextBox> <br />
                <asp:Button ID="Button2" runat="server" Text="Close" CssClass="buttonClose"/>
                <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button_Confirm"/>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
