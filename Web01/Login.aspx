<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    $(function () {
        $("#dvMenuCOntainer").css("display", "none");
    });
</script>
    <div class="grid_24 alpha" style="background-color: rgb(232, 238, 246);">
        <div class="grid_8 alpha" style="padding-top: 20px">
            <asp:Login ID="siteLogin" runat="server" OnLoggedIn="siteLogin_LoggedIn">
                <LayoutTemplate>
                    <div>
                        <asp:Label ID="FailureText" runat="server" EnableViewState="False" CssClass="Error"></asp:Label>
                    </div>
                    <dl>
                        <dt>
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label></dt>
                        <dd>
                            <asp:TextBox ID="UserName" runat="server" CssClass="input-large"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                CssClass="Error" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                ValidationGroup="siteLogin">*</asp:RequiredFieldValidator></dd>
                        <dt>
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label></dt>
                        <dd>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input-large"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                CssClass="Error" ErrorMessage="Password is required." ToolTip="Password is required."
                                ValidationGroup="siteLogin">*</asp:RequiredFieldValidator></dd>
                        <dt>
                            <asp:HyperLink ID="hlForgotPassword" runat="server" NavigateUrl="ForgotPassword.aspx">Forgot Password</asp:HyperLink></dt>
                      
                        <dd>
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In &raquo;"
                                ValidationGroup="siteLogin" /></dd>
                    </dl>
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
        <div class="grid_8 omega" style="padding-top: 20px">
            <b>New user </b>
            <p>
                Take a few minutes to sign up and start enhancing your life! Register now
            </p>
            <b>Benefits</b>
            <ul>
                <li>Discover your risks and strengths with the health assessment. </li>
                <li>Get motivated with our unique solution </li>
                <li>Get expert help articles in health risk areas It takes only few minutes to register
                    for your personalized dashboard to relevant, accurate health information </li>
                <li>Within less than 30 minutes you can assess your health and lifestyle with this online
                    tool </li>
            </ul>
            <div class="alert alert-info">
                Your personal health information is safe and confidential with us.</div>
        </div>
    </div>
    
</asp:Content>
