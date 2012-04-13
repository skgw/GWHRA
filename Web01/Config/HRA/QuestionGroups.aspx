<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="QuestionGroups.aspx.cs" Inherits="Config_HRA_QuestionGroups" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
[Use this screeb to add/edit question groups]
    <div class="grid_24 alpha">
        <dl>
            <dt>Name</dt>
            <dd>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </dd>
            <dt>Description</dt>
            <dd>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </dd>
            <dt>IsActive</dt>
            <dd><asp:CheckBox ID="chkIsActive" runat="server" /></dd>
        </dl>
        
    </div>
    <div class="grid_24 alpha">
        <asp:LinkButton ID="lbSave" runat="server" OnClick="lbSave_Click">Save</asp:LinkButton>
        <asp:LinkButton ID="lbAddNew" runat="server" OnClick="lbAddNew_Click">Add New</asp:LinkButton>

    </div>
</asp:Content>
