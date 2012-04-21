<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" CodeFile="AssessmentPreview.aspx.cs" Inherits="Config_HRA_AssessmentPreview" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="grid_24 alpha">
        <div class="grid_12 alpha">
            <dl>
                <dt>Assessment Name</dt>
                <dd><asp:Label ID="lblName" runat="server"></asp:Label></dd>
                <dt>Effective From</dt>
                <dd><asp:Label ID="lblEffectiveFrom" runat="server"></asp:Label>
                </dd>
            </dl>
        </div>
        <div class="grid_12 omega">
                <dl>
                    <dt>Assessment Group</dt>
                    <dd><asp:Label ID="lblGroupName" runat="server"></asp:Label></dd>
                    <dt>Effective To</dt>
                    <dd><asp:Label ID="lblEffectiveTo" runat="server"></asp:Label></dd>
                </dl>
        </div>

</div>  
<div class="grid_24 alpha">
        Selected Questions
        <asp:ListView ID="lvSelectedQ" runat="server" DataKeyNames="ID">
            <LayoutTemplate>
                <table id="tblSelectedQ" class="table table-bordered ">
                    <thead>
                        <tr>
                            <th>
                                Question Group
                            </th>
                            <th>
                                Question
                            </th>
                            <th>
                                Response Type
                            </th>
                            <th>
                                Display Order
                            </th>
                         </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("GroupName")%>
                    </td>
                    <td>
                        <%# Eval("Content")%>
                    </td>
                    <td>
                        <%# Eval("ResponseType") %>
                    </td>
                    <td>
                        <%# Eval("DisplayOrder") %>
                    </td>
                 </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr class="row">
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </EmptyDataTemplate>
        </asp:ListView>
        
</div>
        <asp:Button ID="btnBack" runat="server" Text="Return to Search results" CssClass="btn" OnClick="btnBack_Click"/>
        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-info" OnClick="btnEdit_Click"/>

</asp:Content>

