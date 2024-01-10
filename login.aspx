<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/masterpage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="projectdotnetquiz.Masterpage.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentpage" runat="server">
      <table>
        <tr>
            <td>&nbsp;</td>
            <td>
                <h2>Login</h2>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>Username</strong></td>
            <td>&nbsp;<asp:TextBox ID="txtbox_username" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>Password</strong></td>
            <td>&nbsp;<asp:TextBox ID="textbox_password" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonLogin" Text="Login" runat="server" OnClick="ButtonLogin_Click" />
                &nbsp;
                <asp:Button ID="ButtonCancel" Text="Cancel" runat="server" OnClick="ButtonCancel_Click" />
            </td>
            <td>&nbsp;<asp:Label ID="lblLoginStatus" ForeColor="Red" runat="server"></asp:Label></td>
        </tr>
           <tr>
     <td>&nbsp;</td>
    <td>
         <asp:label ForeColor="black" runat="server" for="Register"><a href="register.aspx">register </a> Now?</asp:label>
     </td>
     <td>&nbsp;</td>
 </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
