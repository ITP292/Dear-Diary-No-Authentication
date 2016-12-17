<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Dear_Diary.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/AboutStyle.css" rel="stylesheet" type="text/css" />

    <h2>About Us</h2>
    <h3>The Team</h3>

    <div class="abox">
    <h4>Ryan (Server Freak)</h4>
        <p>
            Ryan is the server freak of the team. He is in-charge of the more technical and back-end things of our project. As soon as the project started, he has been really
            enthusiastic about dealing with the server for our project. As a result, he has one server running in his home right now. Thus, if anything happens to the server, 
            it is all his responsibility.
        </p>
    </div>

    <div class="abox">
    <h4>Angie (The Rude and Normal One)</h4>
        <p>
            Supposedly, the most "normal" out of all of the other members, Angie has a plethora of memes in her head and everyday she would say something meme-related. Though she
            can be a bit rude at times, her memes and jokes sometimes help to break away from the stress created from the project and other personal commitments the team might 
            have.
        </p>
    </div>

    <div class="abox">
    <h4>Joanne (The Leader)</h4>
        <p>
            The boss of the project, Joanne always keeps in check of the things we would need to do for the project as we progress through the different phases. She also gives
            great and helpful ideas that really improves the project as a whole as we progress through. Despite having a lack of passion for coding and different technicalities,
            her determination is unmatched in the team which allows her to complete the objectives that she and the team set out to do.
        </p>
    </div>

    <div class="abox">
    <h4>Seri (The "Minah")</h4>
        <p>
            Always sporting a "tudung" and malay clothing, Seri is the poster malay girl of the team. Seri always asks questions regarding the project which helps the team review
            whether are we on the right track or are we drifting away from our default objective. Thus, this prevents the team from adding too much unnecessary stuff that eventhough
            might be beneficial to the project, it is not worth putting extra burden on the team.
        </p>
    </div>

    <div class="abox">
    <h4>Aidil (The Debugger)</h4>
        <p>
            Always the one cracking his head over a line of code that has an error, Aidil spends a crazy amount of time to solve a tiny little problem in the code for the team.
            He spends so much time in Visual Studio that we think that he has an affair with it. Don't tell him I said that.
        </p>
    </div>
   
    <div class="abox">
        <p><%--empty box to push down "2016 - Joanne Programming" sentence--%></p>
    </div>
</asp:Content>
