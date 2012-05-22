<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="Narrative.aspx.cs" Inherits="Narrative" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divNarrative" runat="server">
    </div>
    <asp:Button ID="btnBack" runat="server" Text="Return to Member Dashboard" OnClick="btnBack_click"
        CssClass="btn btn-inverse" />
</asp:Content>
