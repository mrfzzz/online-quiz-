<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/masterpage.Master" AutoEventWireup="true" CodeBehind="addquiz.aspx.cs" Inherits="projectdotnetquiz.Masterpage.addquiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentpage" runat="server">
        <table>
    <tr><td>&nbsp;</td>
        <td>
        <H2>Update quiz</H2>
        </td>    
        <td>&nbsp;</td>
    </tr>
    <tr><td>&nbsp;</td>
        <td>
        <H3></H3>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr><td>&nbsp;</td>
        <td><strong>Number Question</strong></td>
        <td>&nbsp;<asp:TextBox id="txtbox_Id"  runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="NumQ" runat="server" ControlToValidate="txtbox_Id" ErrorMessage="Enter Number question" ForeColor="Red">

            </asp:RequiredFieldValidator>
        </td>                     
    </tr>
    <tr><td>&nbsp;</td>
        <td><strong>Quiz Name</strong></td>
        <td>&nbsp;<asp:DropDownList runat="server" ID="Name_quiz">
            <asp:ListItem Text="Bahasa Melayu" Value="1"></asp:ListItem>
            <asp:ListItem Text="English" Value="2"></asp:ListItem>
            <asp:ListItem Text="Math" Value="3"></asp:ListItem>
            <asp:ListItem Text="Science" Value="4"></asp:ListItem>
            </asp:DropDownList>&nbsp;
        </td>
    </tr>
    <tr><td>&nbsp;</td>
        <td><strong>Question</strong></td>
        <td>&nbsp;<asp:TextBox ID="txtbox_Qna" runat="server"></asp:TextBox>&nbsp;
           <asp:RequiredFieldValidator ID="Qna" runat="server" ControlToValidate="txtbox_Qna" ErrorMessage="Enter Question" ForeColor="Red">
            </asp:RequiredFieldValidator>
       </td>
    </tr>
    <tr><td>&nbsp;</td>
        <td><strong>Correct Answer</strong></td>
        <td>&nbsp;<asp:TextBox ID="txtbox_Ans" runat="server"></asp:TextBox>&nbsp;
           <asp:RequiredFieldValidator ID="CorrAns" runat="server" ControlToValidate="txtbox_Ans" ErrorMessage="Enter Correct Answer" ForeColor="Red">
            </asp:RequiredFieldValidator>
       </td>
    </tr>
      <tr><td>&nbsp;</td>
        <td><strong>Option Answer 1</strong></td>
        <td>&nbsp;<asp:TextBox ID="txtbox_Oa1" runat="server"></asp:TextBox>&nbsp;
           <asp:RequiredFieldValidator ID="Op1" runat="server" ControlToValidate="txtbox_Oa1" ErrorMessage="Enter Answer Option1" ForeColor="Red">
            </asp:RequiredFieldValidator>
       </td>
    </tr>
      <tr><td>&nbsp;</td>
        <td><strong>Option Answer 2</strong></td>
        <td>&nbsp;<asp:TextBox ID="txtbox_Oa2" runat="server"></asp:TextBox>&nbsp;
           <asp:RequiredFieldValidator ID="Op2" runat="server" ControlToValidate="txtbox_Oa2" ErrorMessage="Enter Answer Option2" ForeColor="Red">
            </asp:RequiredFieldValidator>
       </td>
    </tr>
      <tr><td>&nbsp;</td>
        <td><strong>Option Answer 3</strong></td>
        <td>&nbsp;<asp:TextBox ID="txtbox_Oa3" runat="server"></asp:TextBox>&nbsp;
           <asp:RequiredFieldValidator ID="Op3" runat="server" ControlToValidate="txtbox_Oa3" ErrorMessage="Enter Answer Option3" ForeColor="Red">
            </asp:RequiredFieldValidator>
       </td>
    </tr>        
    <tr><td>&nbsp;</td>
        <td>
        <asp:Button ID="ButtonSave" Text="Save" runat="server" OnClick="ButtonSave_Click" />&nbsp;
        <asp:Button ID="ButtonCancel" Text="Cancel" runat="server" OnClick="ButtonCancel_Click" />&nbsp;
        </td>
        <td>&nbsp;<asp:Label id="lblStatus" ForeColor="Red" runat="server"></asp:Label></td>
    </tr>    
    <tr><td>&nbsp;</td>
        <td>
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>    
</table>
</asp:Content>
