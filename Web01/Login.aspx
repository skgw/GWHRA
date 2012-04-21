<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid_24 alpha" style="background-color : rgb(232, 238, 246); ">
        <div class="grid_8 alpha" style="padding-top:20px">
            <asp:Login ID="Login1" runat="server" LoginButtonText="Login" TitleText="Login">
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Login" ValidationGroup="Login1" />
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
            <div class="alert alert-error" style="text-align: justify;">
                <b>Note</b> If you have already submitted your HRA questionnaire by Mail (Paper
                Copy) and got a confirmation mail from us, you can log-in now and your details will
                be updated here from your paper HRA questionnaire.
            </div>
        </div>
        <div class="grid_8">
           <asp:Image runat="server" ImageUrl="~/Common/Images/center-banner.jpg" />
        </div>
        <div class="grid_8 omega" style="padding-top:20px">
            <b>New user </b>
            <p>
                Take a few minutes to sign up and start enhancing your life! Register now
            </p>
            <b>Benefits</b>
            <p>
                <ul>
                    <li>Discover your risks and strengths with the health assessment. </li>
                    <li>Get motivated with our unique solution </li>
                    <li>Get expert help articles in health risk areas It takes only few minutes to register
                        for your personalized dashboard to relevant, accurate health information </li>
                    <li>Within less than 30 minutes you can assess your health and lifestyle with this online
                        tool </li>
                </ul>
            </p>
            <div class="alert alert-info">
                Your personal health information is safe and confidential with us.</div>
        </div>
    </div>
</asp:Content>
