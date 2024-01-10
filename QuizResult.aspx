<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/masterpage.Master" AutoEventWireup="true" CodeBehind="QuizResult.aspx.cs" Inherits="projectdotnetquiz.Masterpage.QuizResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentpage" runat="server">

      <asp:Label runat="server">Choose Quiz:</asp:Label>
       <asp:DropDownList ID="quizddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="quizddl_choose"></asp:DropDownList>

    <div id="markinfo" runat="server" visible="false">
        <br />
        <asp:Label ID="lblmarktxt" runat="server">Your Marks:</asp:Label>
        <asp:Label ID="lblmark" runat="server"></asp:Label>
        <asp:Label ID="slash" runat="server"> / </asp:Label>
        <asp:Label ID="lblfullmark" runat="server"></asp:Label>
    </div>
    
        <br />
       <asp:GridView ID="gvquizresult" runat ="server" AutoGenerateColumns="false">

           <Columns> 
               <asp:BoundField DataField="quiznum" HeaderText="Number" />
                <asp:BoundField DataField="youranswer" HeaderText="Your Answer" />
                <asp:BoundField DataField="correctanswer" HeaderText="Correct Answer" />
                <asp:BoundField DataField="iscorrect" HeaderText="Your Result" />
           </Columns>
       </asp:GridView>
        
    <br />
    
    <!-- <asp:BoundField DataField="question" HeaderText="Question" /> //if want to display question in table -->

</asp:Content>
