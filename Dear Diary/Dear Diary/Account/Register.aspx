<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Dear_Diary.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Register. "></asp:Label>
    <br />
    <asp:Label runat="server" Text="Create a new account. " ID="Label2"></asp:Label>
    <hr />
    <br />

    <%--SERI--%> <div class="col-md-12 text-center"> 
         <%--SERI--%> <div class="form-horizontal col-md-6 col-xs-offset-3">
        
  
    <%--FirstName--%>   
    <%--SERI MADE CHANGES HERE LIKE MAJOR ALOT HAHA--%> 
   <div class="form-group"> 
   <asp:Label ID="Label3" class="col-xs-3 control-label" Font-Size="20px" runat="server" Text="First Name"></asp:Label>
   <div class="col-xs-8">
     <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
     <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
        CssClass="text-danger" ErrorMessage="The name field is required." />
                </div>
            </div>


    <%--LastName--%>
    <%--SERI MADE CHANGES HERE LIKE MAJOR ALOT HAHA--%> 
    <div class="form-group">
    <asp:Label class="col-xs-3 control-label" Font-Size="20px"  ID="Label4" runat="server" Text="Last Name"></asp:Label>
    <div class="col-xs-8">
       <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
       <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2"
         CssClass="text-danger" ErrorMessage="The name field is required." />
                </div>
            </div>

    <%--Email--%>
    <%--SERI MADE CHANGES HERE LIKE MAJOR ALOT HAHA--%> 
    <div class="form-group">
    <asp:Label ID="Label5" class="col-xs-3 control-label" Font-Size="20px" runat="server" Text="Email"></asp:Label>
    <div class="col-xs-8">
        <asp:TextBox ID="TextBox3" runat="server" class="form-control" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox3"
        CssClass="text-danger" ErrorMessage="The email field is required." />
                </div>
            </div>

    <%--Password--%>
    <%--SERI MADE CHANGES HERE LIKE MAJOR ALOT HAHA--%> 
   <div class="form-group">
   <asp:Label class="col-xs-3 control-label" Font-Size="20px" ID="Label6" runat="server" Text="Password"></asp:Label>
   <div class="col-xs-8">
        <asp:TextBox ID="TextBox4" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox4"
        CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
            </div>

    <%--Confirm Password--%>
    <%--SERI MADE CHANGES HERE LIKE MAJOR ALOT HAHA--%> 
    <div class="form-group">
   
         <asp:Label ID="Label7" class="col-xs-3 control-label" Font-Size="20px" Style="padding-left: 0; padding-right: 0;" runat="server" Text="Confirm Password" EnableTheming="True"></asp:Label>
    
         <div class="col-xs-8">
         <asp:TextBox ID="TextBox5" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
         <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox5"
              CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
         <asp:CompareValidator runat="server" ControlToCompare="TextBox4" ControlToValidate="TextBox5"
              CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
         <asp:Label ID="Label10" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <br />

    <%--Phone Number--%>
    <%--SERI MADE CHANGES HERE LIKE MAJOR ALOT HAHA--%> 
     <div class="form-group">
                <asp:Label class="col-xs-3 control-label" Font-Size="20px" ID="Label8" runat="server" Text="Phone Number"></asp:Label>
                <div class="col-xs-8">
                    <asp:TextBox ID="TextBox6" runat="server" class="form-control" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox6"
                        CssClass="text-danger" ErrorMessage="The phone number field is required." />
                </div>
            </div>


     <div class="form-group">
                <asp:Label ID="Label9" runat="server" CssClass="text-danger"></asp:Label>
                <asp:Label ID="Label12" runat="server" CssClass="text-danger"></asp:Label>

         <%--JOANNE THIS LABEL FOR WHAT AH????--%> 
                <%--<asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>--%>
            </div>

             <div class="form-group">
                <div class="col-xs-8 col-xs-offset-3">
                      <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Register" OnClick="Register_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
