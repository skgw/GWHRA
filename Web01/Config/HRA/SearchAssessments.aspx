<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="SearchAssessments.aspx.cs" Inherits="Config_HRA_SearchAssessments" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("table tbody tr")
        .css("cursor", "pointer")
        .click(function () {
            $row = $(this);
            var id = $("td", $row).eq(0).text();
            window.location.href = "Assessments.aspx?id=" + id;
        });
            BindEvents();
        });

        function BindEvents() {
            $("input[id$='txtEffectiveFrom']").datepicker({
                onSelect: function (e) {
                    //alert($("input[id$='txtEffectiveFrom']").val());
                },
                changeMonth: true,
                changeYear: true,
                maxDate: 0
            });
            $("input[id$='txtEffectiveTo']").datepicker({
                onSelect: function (e) {
                    //alert($("input[id$='txtEffectiveFrom']").val());
                },
                changeMonth: true,
                changeYear: true,
                maxDate: 0
            });
        }
    </script>
    <div class="grid_24 alpha">
        <div class="grid_12 alpha">
            <dl>
                <dt>Assessment Name </dt>
                <dd>
                    <asp:TextBox ID="txtAssessmentName" runat="server" CssClass="grid_6 alpha"></asp:TextBox>
                </dd>
                <dt>Effective From</dt>
                <dd>
                    <asp:TextBox ID="txtEffectiveFrom" runat="server" CssClass="grid_3 alpha"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <div class="grid_12 omega">
            <dl>
                <dt>Assessment Group</dt>
                <dd>
                    <asp:DropDownList ID="ddlAssessGroup" runat="server">
                        <asp:ListItem Value="">-- Select One --</asp:ListItem>
                        <asp:ListItem Value="1000">Medicare</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt>Effective To</dt>
                <dd>
                    <asp:TextBox ID="txtEffectiveTo" runat="server" CssClass="grid_3 alpha"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <div class="grid_24 alpha">
            <div class="grid_2 alpha">
            </div>
            <div class="grid_7 ">
            <asp:LinkButton ID="lnkSearchAssessments" runat="server" CssClass="btn btn-primary"
                OnClick="lnkSearchAssessments_Click">Search</asp:LinkButton>
            </div>
            <div class="grid_6 ">
             <asp:LinkButton ID="lnkAddNew" runat="server" CssClass="btn btn-success" OnClick="lnkAddNew_Click">+ Add New</asp:LinkButton>
            </div>
            <div class="grid_6 ">
             <asp:LinkButton ID="lnkCancel" runat="server" CssClass="btn" OnClick="lnkCancel_Click">Reset</asp:LinkButton>
            </div>
            <div class="grid_2 omega">
            </div>
            
           
           
        </div>
    </div>
    <div class="grid_24 alpha" style="margin-top: 1em">
        <asp:ListView ID="lvAssessments" runat="server">
            <EmptyDataTemplate>
                <b>No records returned.</b>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table table-bordered">
                    <thead>
                      <tr>
                            <th colspan="6"> 
                             ASSESSMENTS
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
                                Group Name
                            </th>
                            <th>
                                Effective From
                            </th>
                            <th>
                                Effective To
                            </th>
                            <%--<th>
                                QuestionList
                            </th>
                            <th>
                                Created Date
                            </th>
                            <th>
                                Created By
                            </th>--%>
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
                        <%#Eval("AssessmentGroupName")%>
                    </td>
                    <td>
                        <%#DateTime.Parse(Eval("EffectiveFrom").ToString()).ToString("MM/dd/yyyy")%>
                    </td>
                    <td>
                        <%#DateTime.Parse(Eval("EffectiveTo").ToString()).ToString("MM/dd/yyyy")%>
                    </td>
                    <%--<td>
                        <%#Eval("QuestionList") %>
                    </td>
                    <td>
                        <%#DateTime.Parse(Eval("ModifiedDate").ToString()).ToString("MM/dd/yyyy")%>
                    </td>
                    <td>
                        <%#Eval("ModifiedBy")%>
                    </td>--%>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
