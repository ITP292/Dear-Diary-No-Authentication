<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="PostDraftList.aspx.cs" Inherits="Dear_Diary.NewEntry.PostDraftList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <div class="main-wrapper draft">
            <div class="new-entry">
                <h1>Drafts</h1>
            </div>
             <asp:Repeater ID="rptPostList" runat="server">
                <ItemTemplate>
            <div class="draft-content">
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sit amet laoreet elit. Aliquam commodo lacus elit, nec faucibus purus ullamcorper eget. Vestibulum aliquam, nibh eget laoreet tempor, arcu nunc posuere nisl, eget elementum est enim eu leo. In vitae faucibus velit. Nunc augue leo, pretium quis orci nec, sollicitudin finibus ante. Maecenas velit purus, ornare a suscipit vitae, scelerisque nec arcu. Cras in nunc at lorem commodo vestibulum. Nullam nibh lacus, pulvinar vel nisi sit amet, tempus ultrices nisi. Phasellus sollicitudin sollicitudin ligula, at ultricies augue euismod a. Maecenas sed mattis lectus. Fusce a blandit nibh. Vivamus ac erat id nulla dignissim mattis. Vivamus faucibus, lacus quis facilisis cursus, libero orci rutrum ex, fermentum tincidunt nibh lorem sit amet dolor. </p>
            </div>
            </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>
