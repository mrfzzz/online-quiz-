<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/masterpage.Master" AutoEventWireup="true" CodeBehind="quizgame.aspx.cs" Inherits="projectdotnetquiz.Masterpage.quizgame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentpage" runat="server">
     <div>
            <h2>Select Quiz</h2>
            <asp:DropDownList ID="comboBoxQuiz" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboBoxQuiz_SelectedIndexChanged">
            </asp:DropDownList>

            <br />

            <h3>Question</h3>
            <asp:Label ID="labelQuestion" runat="server" Text=""></asp:Label>

            <br />

            <h3>Options</h3>
            <asp:RadioButton ID="radioButtonOption1" runat="server" GroupName="options" />
            <asp:Label ID="labelOption1" runat="server" AssociatedControlID="radioButtonOption1"></asp:Label>
            <br />

            <asp:RadioButton ID="radioButtonOption2" runat="server" GroupName="options" />
            <asp:Label ID="labelOption2" runat="server" AssociatedControlID="radioButtonOption2"></asp:Label>
            <br />

            <asp:RadioButton ID="radioButtonOption3" runat="server" GroupName="options" />
            <asp:Label ID="labelOption3" runat="server" AssociatedControlID="radioButtonOption3"></asp:Label>

            <br />

            <asp:Button ID="buttonNext" runat="server" Text="Next Question" OnClick="buttonNext_Click" />
        </div>
</asp:Content>
