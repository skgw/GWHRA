<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" CodeFile="MemberHRA.aspx.cs" Inherits="MemberHRA" %>
<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="Common/Scripts/MemberHRA.js" type="text/javascript"></script>

<script type="text/javascript">
    
</script>
<asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_click"/>
<input type="submit" id="btnSubmit" value="Submit" />
<asp:Button ID="btnNext" runat="server" Text="Next" />
<div id="dvQuetionaire" class="grid_24">
    
</div>


</asp:Content>

