<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" CodeFile="MemberHRA.aspx.cs" Inherits="MemberHRA" %>
<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--<style>
th { background-color: #001640; color: white; height:50px;padding-bottom: 10px;writing-mode: tb-rl; -webkit-transform: rotate(45deg); -moz-transform: rotate(45deg); width: -moz-fit-content; width: fit-content; }
</style>
<table border="1">
  <tr>
    <th>Position</th>
    <th>Country</th>
    <th>City</th>
  </tr>
  <tr>
    <td>1</th>
    <td>UK</td>
    <td>Inverness</td>
  </tr>
  <tr>
    <td >2</th>
    <td>Norway</td>
    <td>Bergen</td>
  </tr>
</table>--%>


<asp:Button ID="btnNext" runat="server" Text="Next"  OnClick="btnNext_click"/>
<asp:Button ID="btnPrev" runat="server" Text="Previous"  OnClick="btnPrev_click"/>
</asp:Content>

