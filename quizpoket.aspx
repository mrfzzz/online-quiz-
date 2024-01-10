<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/masterpage.Master" AutoEventWireup="true" CodeBehind="quizpoket.aspx.cs" Inherits="projectdotnetquiz.Masterpage.quizpoket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentpage" runat="server">
      <div class="style-set">
     <h2>Question list</h2>
     <asp:Button ID="AddNew" Text="Add New Question" runat="server" OnClick="ButtonAddNew_Click" />&nbsp;<br /><br />
     <div>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
    <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="white" />
    <Columns>
        <asp:BoundField DataField="quizid" HeaderText="Question No." />
        <asp:BoundField DataField="quizname" HeaderText="Quiz Name" />
        <asp:BoundField DataField="question" HeaderText="Question" />
        <asp:BoundField DataField="option1" HeaderText="Option Answer 1" />
        <asp:BoundField DataField="option2" HeaderText="Option Answer 2" />
        <asp:BoundField DataField="option3" HeaderText="Option Answer 3" />
        <asp:BoundField DataField="answer" HeaderText="Correct Answer" />
        <asp:CommandField ShowSelectButton="true" SelectText="Select" ItemStyle-Width="40" />
    </Columns>
</asp:GridView>
         <br />
     <asp:Label ID="msg" runat="server" Text=""></asp:Label>

     </div>
 </div>
</asp:Content>
