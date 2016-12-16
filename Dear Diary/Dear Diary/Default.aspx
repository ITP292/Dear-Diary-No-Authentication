<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dear_Diary._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Dear Diary</h1>
        <p class="lead">Dear Diary is a Web Application which allows people to turn their physical diary into a virtual diary that they can access from anywhere and share with anyone.</p>
        <p><a href="Account/Login.aspx" class="btn btn-primary btn-lg">Get Started &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Our Company</h2>
            <p>
                Joanne Programming is a startup company with the vision of integrating technology with our lives. Our debut product Dear Diary is the start of our vision to adopt a technology savvy lifestyle.
            </p>
        </div>

        <div class="col-md-4">
            <h2>Contact Us</h2>
            <p>
                Joanne Programming Pte Ltd.<br />
                53 Ubi Avenue 1<br />
                Paya Ubi Industrial Park<br />
                Singapore 408934
            </p>
            <p>
                Email: JoanneLim@joanneprogramming.com.sg<br />
                Tel No.: +6598521467
            </p>
            <p>
                Operating Hours (Mon - Fri): 9am - 9pm
            </p>
        </div>

        <div class="col-md-4">
            <h2>About Dear Diary</h2>
            <p>
                Dear Diary is a website where you can express your feelings towards your friends without the worry about
                security. To register for a new account, click <a href="Account/Register.aspx">here</a>!
            </p>
        </div>
    </div>

</asp:Content>
