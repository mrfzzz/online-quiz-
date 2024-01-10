<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/masterpage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="projectdotnetquiz.Masterpage.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentpage" runat="server">
    <table>
        <tr>
            <td>&nbsp;</td>
            <td>
                <h2>Register</h2>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>Username</strong></td>
            <td>&nbsp;<asp:TextBox id="txtbox_username" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtbox_username" ErrorMessage="Enter Username" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>IC</strong></td>
            <td>&nbsp;<asp:TextBox ID="txtbox_ic" runat="server"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfID" runat="server" ControlToValidate="txtbox_ic" ErrorMessage="Enter IC" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>Password</strong></td>
            <td>&nbsp;<asp:TextBox ID="textbox_password" runat="server"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfpassword" runat="server" ControlToValidate="textbox_password" ErrorMessage="Enter password" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonSave" Text="Save" runat="server" OnClick="ButtonSave_Click" />&nbsp;
                <asp:Button ID="ButtonCancel" Text="Cancel" runat="server" OnClick="ButtonCancel_Click" />&nbsp;
            </td>
            <td>&nbsp;<asp:Label id="lblStatus" ForeColor="Red" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
           <td>
                <asp:label ForeColor="black" runat="server" for="login"><a href="login.aspx">Login </a> Now?</asp:label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>