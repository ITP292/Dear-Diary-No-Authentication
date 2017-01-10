﻿<%@ Page Title="Notifications" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="Dear_Diary.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%:Title %></h1>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="10000">
            </asp:Timer>
            <asp:Label ID="Label1" runat="server" Text="Panel not refreshed yet."></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>