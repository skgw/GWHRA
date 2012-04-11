<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="SearchQGroups.aspx.cs" Inherits="Config_HRA_SearchQGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    $(function () {
        $("table tr")
        .css("cursor", "pointer")
        .click(function () {
            $row = $(this);
            var id = $("td", $row).eq(0).text();
            window.location.href = "QuestionGroups.aspx?id=" + id;
        });
    });
    
</script>
    <div class="grid_24 alpha">
        <dl>
            <dt>Search </dt>
            <dd>
                <asp:TextBox ID="tbSearchQGroups" runat="server" CssClass="grid_10 alpha"></asp:TextBox>
                <asp:LinkButton ID="lbSearchQGroups" runat="server" CssClass="grid_5 omega" OnClick="lbSearchQGroups_Click">Search</asp:LinkButton>
            </dd>
        </dl>
    </div>
    <div class="grid_24 alpha">
        <asp:ListView ID="lvQuestionGroups" runat="server">
            <EmptyDataTemplate>
                <b>No records returned.</b>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table>
                    <thead>
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
                            <th>
                                Question count
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
                    <td>
                        <%#Eval("QuestionsCount") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
