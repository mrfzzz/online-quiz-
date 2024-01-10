<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/masterPage.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="projectdotnetquiz.Masterpage.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Homepage</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
        }

        #main-content {
            max-width: 800px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #333;
        }

        .menu-item {
            display: inline-block;
            margin-right: 10px;
        }

        .btn {
            padding: 10px;
            font-size: 16px;
            border: none;
            background-color: #4caf50;
            color: #fff;
            cursor: pointer;
            border-radius: 5px;
        }

        .btn:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentpage" runat="server">
    <div id="main-content">
        <h2>Welcome to the Homepage</h2>

        <div class="menu-item">
            <asp:Label ForeColor="black" runat="server" for="login"><a href="login.aspx">Login</a></asp:Label>
        </div>

        <div class="menu-item">
            <asp:Label ForeColor="black" runat="server" for="Register"><a href="register.aspx">Register</a></asp:Label>
        </div>

        <div class="menu-item">
            <asp:Button ID="btnCreateQuiz" runat="server" Text="Create Quiz" CssClass="btn" OnClick="btnStartQuiz_Click" />
        </div>

        <div class="menu-item">
            <asp:Button ID="btnPlayQuiz" runat="server" Text="Play Quiz" CssClass="btn" OnClick="btnPlayQuiz_Click" />
        </div>

        <div class="menu-item">
            <asp:Button ID="btnCheckResult" runat="server" Text="Check Result" CssClass="btn" OnClick="btnCheckResult_Click" />
        </div>

        <div class="menu-item">
            <asp:Button ID="btnLogout" runat="server" Text="Log Out" CssClass="btn" OnClick="btnLogout_Click" />
        </div>
    </div>
</asp:Content>