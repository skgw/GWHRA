<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="MemberHRA.aspx.cs" Inherits="MemberHRA" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="Common/Scripts/MemberHRA.js" type="text/javascript"></script>
    <asp:Button ID="btnBack" runat="server" Text="Return to Family HRA" OnClick="btnBack_click"
        CssClass="btn btn-inverse " />
    <input type="submit" id="btnSubmit" value="Save" class="btn btn-primary" />
    <asp:Button ID="btnNext" runat="server" Text="Next" Visible="false" />
    <asp:Button ID="btnFinishMemberHRA" runat="server" Text="Finish" CssClass="btn btn-success" />
    <div id="dvQuetionaire" class="grid_24">
    </div>
</asp:Content>
