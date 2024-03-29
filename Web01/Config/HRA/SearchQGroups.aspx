﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="SearchQGroups.aspx.cs" Inherits="Config_HRA_SearchQGroups" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("table tbody tr")
        .css("cursor", "pointer")
        .click(function () {
            $row = $(this);
            var id = $("td", $row).eq(0).text();
            window.location.href = "QuestionGroups.aspx?qgroupid=" + $.trim(id);
        });
        });
    
    </script>
    <div class="grid_24 alpha append_bottom">
        <div class="grid_17 alpha">
            <dl>
                <dt>Name </dt>
                <dd>
                    <asp:TextBox ID="tbSearchQGroups" runat="server" CssClass="grid_8 alpha"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <div class="grid_7 omega">
            <asp:CheckBox ID="cbQGroupStatus" runat="server" Text="Search Active groups only" />
        </div>
    </div>
    <div class="grid_24 alpha append_bottom">
        <div class="grid_8 alpha">
            <asp:LinkButton ID="lbSearchQGroups" runat="server" CssClass="btn btn-primary" OnClick="lbSearchQGroups_Click">Search</asp:LinkButton>
        </div>
        <div class="grid_8">
            <asp:Button ID="LinkButton1" runat="server" CssClass="btn" Text="Cancel"></asp:Button>
        </div>
        <div class="grid_8 omega">
            <asp:LinkButton ID="lbAddNew" runat="server" OnClick="lbAddNew_Click" CssClass="btn btn-success "> + Add New</asp:LinkButton>
        </div>
    </div>
    <div class="grid_24 alpha">
        <asp:ListView ID="lvQuestionGroups" runat="server">
            <EmptyDataTemplate>
                <b>No records returned.</b>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table table-bordered ">
                    <thead>
                        <tr>
                            <th colspan="6">
                                QUESTION GROUPS
                            </th>
                        </tr>
                        <tr>
                            <th>
                                ID
                            </th>
                            <th>
                                Name
                            </th>
                            <th>
                                Description
                            </th>
                            <th>
                                Created Date
                            </th>
                            <th>
                                Created By
                            </th>
                            <th>
                                Is Active
                            </th>
                           
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("ID") %>
                    </td>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <%#Eval("Description") %>
                    </td>
                    <td>
                        <%#DateTime.Parse(Eval("CreatedDate").ToString()).ToString("MM/dd/yyyy")%>
                    </td>
                    <td>
                        <%#Eval("CreatedBy") %>
                    </td>
                    <td>
                        <%#Eval("Status") %>
                    </td>
                  
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
