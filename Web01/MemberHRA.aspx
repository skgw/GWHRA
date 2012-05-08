<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" CodeFile="MemberHRA.aspx.cs" Inherits="MemberHRA" %>
<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="Common/Scripts/MemberHRA.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        GetQuestionaire();
    });
</script>

<div id="dvQuetionaire" class="grid_24">
    
</div>

<asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_click"/>

</asp:Content>

