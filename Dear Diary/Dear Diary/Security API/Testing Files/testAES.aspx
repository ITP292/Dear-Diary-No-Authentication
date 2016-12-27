<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testAES.aspx.cs" Inherits="Dear_Diary.Security_API.Testing_Files.testAES" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>AES Encryption &amp; Decryption Test (FOR INTERNAL USE)</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <div class="form-group">
                        <br />
                        <h3>ENCRYPTION</h3>
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Plaintext</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="plaintext" CssClass="form-control" />
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                        </div>
                    </div>
                </div>
                <p>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Encrypted Text</asp:Label>
                    <asp:TextBox runat="server" ID="encryptedtext" CssClass="form-control" ReadOnly="True" Height="150px" />
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                            <asp:Button runat="server" Text="Encrypt" CssClass="btn btn-default" OnClick="runencrypt" />
                </p>
                <p>
                    &nbsp;</p>
                <p>
                    <h3>DECRYPTION</h3>&nbsp;</p>
                <p>
                    <asp:Label runat="server" CssClass="col-md-2 control-label" ID="Label1">Encrypted Text</asp:Label>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="encryptedtextinput" CssClass="form-control" Height="150px" />
                </p>
                <p>
                    &nbsp;</p>
                <p>
                        <asp:Label runat="server" CssClass="col-md-2 control-label" ID="Label2">Plaintext</asp:Label>
                        </p>
                <p>
                            <asp:TextBox runat="server" ID="plaintextoutput" ReadOnly="True" CssClass="form-control" />
                </p>
                <p>
                            <asp:Button runat="server" Text="Decrypt" CssClass="btn btn-default" OnClick="rundecrypt" ID="Button1" />
                </p>
            </section>
        </div>
    </div>
</asp:Content>