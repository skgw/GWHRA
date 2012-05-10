<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" CodeFile="AssessmentGroups.aspx.cs" Inherits="Config_HRA_AssessmentGroups" %>
<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid_24 alpha">
        <dl>
            <dt>Name</dt>
            <dd>
                <asp:TextBox ID="txtName" runat="server" CssClass="grid_10"></asp:TextBox>
            </dd>
            <dt>Description</dt>
            <dd>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="grid_10 textarea_h80" TextMode="MultiLine"></asp:TextBox>
            </dd>
            <dt>IsActive</dt>
            <dd>
                <asp:RadioButtonList runat="server" ID="rblAGroupStatus" RepeatDirection="Horizontal"
                    CssClass="radioButtonList">
                    <asp:ListItem Text="Yes" Value="A"></asp:ListItem>
                    <asp:ListItem Text="No" Value="I"></asp:ListItem>
                </asp:RadioButtonList>
            </dd>
        </dl>
    </div>
    <div class="grid_24 alpha">
        <asp:HyperLink ID="hlReturnToAssessmentGroups" runat="server" Text="Return to search results" NavigateUrl="~/Config/HRA/SearchAGroups.aspx"
            CssClass="btn btn-info"></asp:HyperLink>
       <%-- <asp:Button ID="lbSave" runat="server" OnClick="lbSave_Click" Text="Save" CssClass="btn btn-primary" />
        <asp:Button ID="lbAddNew" runat="server" OnClick="lbAddNew_Click" Text="+ Add New"
            CssClass="btn btn-success" />--%>
    </div>
</asp:Content>

