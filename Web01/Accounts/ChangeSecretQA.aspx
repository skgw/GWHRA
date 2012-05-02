

<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="ChangeSecretQA.aspx.cs" Inherits="ChangeSecretQA" %>
<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid_24 alpha">
            <div class="grid_14 alpha">
                    <dl>
                        <dt>Password</dt>
                        <dd>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqvCurrentPassword" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="Password is required." ToolTip="" ValidationGroup="ChangeSecretQA" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </dd>
                        <dt>Secret Question </dt>
                        <dd>
                            <asp:DropDownList ID="ddlQuestion" runat="server">
                        
                            </asp:DropDownList>
                            <span style="padding-right: 5px;">&nbsp;&nbsp;&nbsp;&nbsp;</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlQuestion"
                                InitialValue="0" ErrorMessage="Secret Question is required." ToolTip=""
                                ValidationGroup="ChangeSecretQA"  ForeColor="Red">*</asp:RequiredFieldValidator>
                        </dd>
                        <dt>Answer </dt>
                        <dd>
                            <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqvAnswer" runat="server" ControlToValidate="txtAnswer"
                                ErrorMessage="Verification Answer is required." ToolTip=""
                                ValidationGroup="ChangeSecretQA"  ForeColor="Red">*</asp:RequiredFieldValidator>
                        </dd>
                        <dt></dt>
                        <dd><asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False" ></asp:Literal></dd>
                        <dt>
                            
                        </dt>
                        <dd>
                           <asp:Button ID="btnChangeSecretQA" runat="server" CommandName="ChangeSecretQA" Text="Change Secret Q & A"
                                OnClick="btnSubmit_Click" ValidationGroup="ChangeSecretQA" />
                                <asp:Button ID="CancelPushButton" runat="server" CausesValidation="true" CommandName="Cancel"
                                Text="Cancel" OnClick="Cancel_Click" />
                        </dd>
                    </dl>
            </div>
    </div>
</asp:Content>
