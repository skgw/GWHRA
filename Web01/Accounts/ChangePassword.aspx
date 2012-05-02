<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="Accounts_ChangePassword" %>
<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid_24 alpha">
            <div class="grid_14 alpha">
                                <asp:ChangePassword ID="ChangePassword1" runat="server" OnChangedPassword="ChangePassword1_ChangedPassword">
                                    <ChangePasswordTemplate>
                                        <dl>
                                            <dt>Password </dt>
                                            <dd>
                                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </dd>
                                            <dt>New Password </dt>
                                            <dd>
                                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                    ErrorMessage="New Password is required." ToolTip="New Password is required." ValidationGroup="ChangePassword1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </dd>
                                            <dt>Confirm New Password </dt>
                                            <dd>
                                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                    ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
                                                    ValidationGroup="ChangePassword1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                    ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                                    ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                            </dd>
                            
                                        </dl>
                        
                                    </ChangePasswordTemplate>
                                </asp:ChangePassword>
                <dl>
                        <dt>&nbsp;</dt>
                        <dd><asp:Literal ID="ErrorMessage" runat="server"></asp:Literal></dd>
                        <dt >
                            
                        </dt>
                        <dd >
                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                Text="Change Password" ValidationGroup="ChangePassword1" OnClick="ChangePasswordPushButton_Click" />
                            <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel" OnClick="Cancel_Click" />
                        </dd>
                </dl>
           </div>
    </div>
</asp:Content>
