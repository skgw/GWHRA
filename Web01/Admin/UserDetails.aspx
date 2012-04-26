<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="UserDetails.aspx.cs" Inherits="Admin_UserDetails" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid_24 alpha">
        <div class="grid_24 alpha">
            <div class="grid_12 alpha">
                <dl>
                    <dt>
                        <asp:Label ID="UserNameLabel" runat="server">
                        User Name:</asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="UserDetails">*</asp:RequiredFieldValidator>
                    </dd>
                    <dt>
                        <asp:Label ID="PasswordLabel" runat="server">
                        Password:</asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="UserDetails">*</asp:RequiredFieldValidator></dd>
                    <dt>
                        <asp:Label ID="ConfirmPasswordLabel" runat="server">
                        Confirm Password:</asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                            ValidationGroup="UserDetails">*</asp:RequiredFieldValidator>
                    </dd>
                    <dd>
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" ErrorMessage="The Password and Confirmation Password must match."
                            ValidationGroup="UserDetails"></asp:CompareValidator>
                    </dd>
                    <dt>
                        <asp:Label ID="QuestionLabel" runat="server">
                        Security Question:</asp:Label></dt>
                    <dd>
                        <asp:DropDownList ID="ddlQuestion" runat="server">
                            <asp:ListItem Value="1">What is your first car name?</asp:ListItem>
                            <asp:ListItem Value="2">What is your first school name?</asp:ListItem>
                            <asp:ListItem Value="3">What is your birth place?</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="ddlQuestion"
                            ErrorMessage="Security question is required." ToolTip="Security question is required."
                            ValidationGroup="UserDetails">*</asp:RequiredFieldValidator></dd>
                    <dt>
                        <asp:Label ID="AnswerLabel" runat="server">
                        Security Answer:</asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="txtAnswer"
                            ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                            ValidationGroup="UserDetails">*</asp:RequiredFieldValidator></dd>
                </dl>
            </div>
            <div class="grid_12 omega">
                <dl>
                    <dt>
                        <asp:Label ID="Label2" runat="server">
                        First Name:</asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="First Name is required." ToolTip="First Name is required." ValidationGroup="UserDetails">*</asp:RequiredFieldValidator></dd>
                    <dt>
                        <asp:Label ID="Label3" runat="server">
                        Middle Name:</asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox></dd>
                    <dt>
                        <asp:Label ID="Label1" runat="server">
                        Last Name:</asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName"
                            ErrorMessage="Last Name is required." ToolTip="Last Name is required." ValidationGroup="UserDetails">*</asp:RequiredFieldValidator></dd>
                    <dt>
                        <asp:Label ID="EmailLabel" runat="server">
                        E-mail:</asp:Label></dt>
                    <dd>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="UserDetails">*</asp:RequiredFieldValidator></dd>
                </dl>
            </div>
        </div>
        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
        <div class="grid_24">
            <div class="grid_12 alpha">
                <asp:Button ID="btnCreateUser" runat="server" Text="Create User" OnClick="btnCreateUser_Click"
                    ValidationGroup="UserDetails" />
            </div>
            <div class="grid_12 omega">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
