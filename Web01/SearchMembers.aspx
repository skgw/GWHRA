<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="SearchMembers.aspx.cs" Inherits="SearchMembers" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("table tbody tr")
        .css("cursor", "pointer")
        .click(function () {
            $row = $(this);
            var id = $("td", $row).eq(0).text();
            window.location.href = "MemberDashboard.aspx?ID=" + $.trim(id);
        });
        });
    
    </script>
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
                <dt>Sex</dt>
                <dd>
                    <asp:DropDownList ID="ddlSex" runat="server">
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt>MemberID</dt>
                <dd>
                    <asp:TextBox ID="tbMemberID" runat="server"></asp:TextBox>
                </dd>
            </dl>
        </div>
    </div>
    <div class="grid_24 alpha append_bottom">
        <div class="grid_6 alpha">
            &nbsp;</div>
        <div class="grid_6">
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                CssClass="btn btn-primary" />
        </div>
        <div class="grid_6 ">
            &nbsp;
        </div>
        <div class="grid_6 omega">
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-inverse" />
        </div>
    </div>
    <div class="grid_24 alpha">
        <asp:ListView ID="lvMemberDetails" runat="server">
            <LayoutTemplate>
                <table class="table table-bordered">
                    <thead>
                        <tr style="background-color: #DFDFDF;">
                            <th colspan="6">
                                MEMBERS
                            </th>
                        </tr>
                        <tr>
                            <th>
                                ID
                            </th>
                            <th>
                                MEMBER ID
                            </th>
                            <th>
                                FIRST NAME
                            </th>
                            <th>
                                LAST NAME
                            </th>
                            <th>
                                DOB
                            </th>
                            <th>
                                SEX
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
                        <%#Eval("MemberID") %>
                    </td>
                    <td>
                        <%#Eval("Firstname") %>
                    </td>
                    <td>
                        <%#Eval("Lastname") %>
                    </td>
                    <td>
                        <%#((DateTime)Eval("DOB")).ToShortDateString() %>
                    </td>
                    <td>
                        <%#Eval("Sex") %>
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <table class="table table-bordered">
                    <thead>
                        <tr style="background-color: #DFDFDF;">
                            <th colspan="6">
                                MEMBERS
                            </th>
                        </tr>
                        <tr>
                            <th>
                                ID
                            </th>
                            <th>
                                MEMBER ID
                            </th>
                            <th>
                                FIRST NAME
                            </th>
                            <th>
                                LAST NAME
                            </th>
                            <th>
                                DOB
                            </th>
                            <th>
                                SEX
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="6">
                              No members found.
                            </td>
                        </tr>
                    </tbody>
                    </table>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
</asp:Content>
