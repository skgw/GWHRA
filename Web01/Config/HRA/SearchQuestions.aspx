<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" CodeFile="SearchQuestions.aspx.cs" Inherits="Config_HRA_SearchQuestions" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    $(function () {
        $("table tbody tr")
        .css("cursor", "pointer")
        .click(function () {
            $row = $(this);
            var id = $("td", $row).eq(0).text();
            window.location.href = "Questions.aspx?QuestionId=" + $.trim(id);
        });
    });
    
</script>

<div class="grid_24 alpha">
    <div class="grid_12 alpha">
            <dl>
                <dt>Question Text </dt>
                <dd>
                <asp:TextBox ID="txtQuestionText" runat="server" CssClass="grid_6 alpha" MaxLength="500"></asp:TextBox>
                </dd>
                <dt>Question Group</dt>
                <dd>
                <asp:DropDownList ID="ddlQuestionGroup" runat="server">
                </asp:DropDownList>
                </dd>
                
            </dl>
    </div>
    <div class="grid_12 omega">
            <dl>
                <dt>Response Type</dt>
                <dd>
                <asp:DropDownList ID="ddlResponseType" runat="server" >
                </asp:DropDownList>
                </dd>
                <dt>Is Active</dt>
                <dd><asp:CheckBox ID="chkIsActive" runat="server" /></dd>
                <dt>Is Mandatory</dt>
                <dd><asp:CheckBox ID="chkIsMandatory" runat="server" /></dd>
                <dt>&nbsp;</dt>
                <dd>
                <asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn btn-primary" OnClick="lnkSearch_Click">Search</asp:LinkButton>
                <asp:LinkButton ID="lnkAddNew" runat="server" CssClass="btn" OnClick="lnkAddNew_Click">Add New</asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="btn btn-success " OnClick="lnkCancel_Click">Reset</asp:LinkButton>
                </dd>
            </dl>
    </div>
</div>
<div class="grid_24 alpha">
    <asp:ListView ID="lvQuestions" runat="server">
        <EmptyDataTemplate>
        <b>No records returned.</b>
        </EmptyDataTemplate>
    <LayoutTemplate>
    <table class="table table-bordered ">
            <thead>
                <tr>
                    <th>
                       ID
                    </th>
                    <th>
                       Question Text
                    </th>
                    <th>
                       Group
                    </th>
                    <%--<th>
                       Response Type
                    </th>--%>
                    <th>
                       Display Order
                    </th>
                    <th>
                       Status
                    </th>
                    <th>
                       Is Mandatory
                    </th>
                    <th>
                      Created By
                    </th>
                    <th>
                      Created Date
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
                   <%#Eval("Content")%>
                </td>
                <td>
                  <%#Eval("GroupName")%>
                </td>
                <%--<td>
                   <%# Eval("ResponseType")%>
                </td>--%>
                <td>
                   <%#Eval("DisplayOrder")%>
                </td>
                <td>
                   <%#Eval("Status") %>
                </td>
                <td>
                   <%#Eval("IsMandatory")%>
                </td>
                <td>
                   <%#Eval("CreatedBy") %>
                </td>
                <td>
                    <%#DateTime.Parse(Eval("CreatedDate").ToString()).ToString("MM/dd/yyyy")%>
                </td>
            </tr>
            
        </ItemTemplate>
    </asp:ListView>
</div>
</asp:Content>