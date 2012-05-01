<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="SearchMembers.aspx.cs" Inherits="SearchMembers" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid_24 alpha">
        <div class="grid_12 alpha">
            <dl>
                <dt>First name</dt>
                <dd>
                    <asp:TextBox ID="tbFirstname" runat="server"></asp:TextBox>
                </dd>
                <dt>Last name</dt>
                <dd>
                    <asp:TextBox ID="tbLastname" runat="server"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <div class="grid_12 omega">
            <dl>
                <dt>HICN</dt>
                <dd>
                    <asp:TextBox ID="tbHICN" runat="server"></asp:TextBox></dd>
                <dt>MemberID</dt>
                <dd>
                    <asp:TextBox ID="tbMemberID" runat="server"></asp:TextBox>
                </dd>
            </dl>
        </div>
    </div>
    <div class="grid_24 alpha">
    </div>
    <div class="grid_24 alpha">
    </div>
</asp:Content>
