<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="SearchAGroups.aspx.cs" Inherits="Config_HRA_SearchAGroups" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("table tbody tr")
                .css("cursor", "pointer")
                .click(function () {
                    $row = $(this);
                    var id = $("td", $row).eq(0).text();
                    window.location.href = "AssessmentGroups.aspx?AGroupid=" + $.trim(id);
                });
        });
    
    </script>
    <div class="grid_24 alpha append_bottom">
        <div class="grid_17 alpha">
            <dl>
                <dt>Name </dt>
                <dd>
                    <asp:TextBox ID="tbSearchAGroups" runat="server" CssClass="grid_8 alpha"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <div class="grid_7 omega">
            <asp:CheckBox ID="cbAGroupStatus" runat="server" Text="Search Active groups only" Checked="true" />
        </div>
    </div>
    <div class="grid_24 alpha append_bottom">
        <div class="grid_8 alpha">
            <asp:LinkButton ID="lbSearchAGroups" runat="server" CssClass="btn btn-primary" OnClick="lbSearchAGroups_Click">Search</asp:LinkButton>
        </div>
        <div class="grid_8">
            <asp:Button ID="LinkButton1" runat="server" CssClass="btn" Text="Cancel"></asp:Button>
        </div>
        <div class="grid_8 omega">
            <asp:LinkButton ID="lbAddNew" runat="server" OnClick="lbAddNew_Click" CssClass="btn btn-success "> + Add New</asp:LinkButton>
        </div>
    </div>
    <div class="grid_24 alpha">
        <asp:ListView ID="lvAssessmentGroups" runat="server">
            <EmptyDataTemplate>
                <table class="table table-bordered ">
                    <thead>
                        <tr>
                            <th colspan="6" style="background-color: #dfdfdf">
                                ASSESSMENT GROUPS
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
                        <tr>
                            <td colspan="6">
                                No records returned.
                            </td>
                        </tr>
                    </tbody>
                </table>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table table-bordered ">
                    <thead>
                        <tr>
                            <th colspan="6" style="background-color:#dfdfdf;">
                                ASSESSMENT GROUPS
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
                        <%#DateTime.Parse(Eval("LastModifiedDate").ToString()).ToString("MM/dd/yyyy")%>
                    </td>
                    <td>
                        <%#Eval("LastModifiedBy") %>
                    </td>
                    <td>
                        <%#Eval("Status") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
