<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="MemberDashboard.aspx.cs" Inherits="MemberDashboard" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .error
        {
            color: red;
        }
    </style>
    <div class="grid_16 alpha">
        <asp:LinkButton ID="lnkMemberDetails" runat="server" OnClick="lnkMemberDetails_click">MemberDetails</asp:LinkButton>
        <%--<a href="MemberDetails.aspx">Member Details</a>
    <a href="FamilyDetails.aspx">Family Details</a>--%>
        <div>
            <asp:ListView ID="lvFamilyDetails" runat="server">
                <LayoutTemplate>
                    <table class="table table-bordered" id="tblFamilyDetails">
                        <thead>
                            <tr style="background-color: #dfdfdf">
                                <th colspan="6">
                                    <asp:LinkButton ID="lnkFamilyDetails" runat="server" OnClick="lnkFamilyDetails_click">FAMILY DETAILS</asp:LinkButton>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    RELATIONSHIP
                                </th>
                                <th>
                                    LAST NAME
                                </th>
                                <th>
                                    FIRST NAME
                                </th>
                                <th>
                                    SEX
                                </th>
                                <th>
                                    DOB
                                </th>
                                <%--<th>
                                Status
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
                            <%#Eval("RelationshipName")%>
                        </td>
                        <td>
                            <%#Eval("Lastname") %>
                        </td>
                        <td>
                            <%#Eval("Firstname") %>
                        </td>
                        <td>
                            <%#Eval("Sex") %>
                        </td>
                        <td>
                            <%# ((DateTime)Eval("DOB")).ToShortDateString() %>
                        </td>
                        <%--  <td>
                    </td>--%>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table class="table table-bordered" id="tblFamilyDetails">
                        <thead>
                            <tr style="background-color: #dfdfdf">
                                <th colspan="6">
                                    <asp:LinkButton ID="lnkFamilyDetails" runat="server" OnClick="lnkFamilyDetails_click">FAMILY DETAILS</asp:LinkButton>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    RELATIONSHIP
                                </th>
                                <th>
                                    LAST NAME
                                </th>
                                <th>
                                    FIRST NAME
                                </th>
                                <th>
                                    SEX
                                </th>
                                <th>
                                    DOB
                                </th>
                                <%--<th>
                                Status
                            </th>--%>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td colspan="6">
                                    No dependents.
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div>
            <asp:ListView ID="lvMemberAssessments" runat="server">
                <LayoutTemplate>
                    <table class="table table-bordered" id="tblAssessments">
                        <thead>
                            <tr style="background-color: #dfdfdf">
                                <th colspan="5">
                                    ASSESSMENTS
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    NAME
                                </th>
                                <th>
                                    GROUP
                                </th>
                                <th>
                                    STATUS
                                </th>
                                <th>
                                    NARRATION
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
                            <%#Eval("Name")%>
                        </td>
                        <td>
                            <%#Eval("AssessmentGroupName") %>
                        </td>
                        <td>
                            <%# (Eval("Status").ToString()=="A")?"<span class='error'>Due</span>":"Completed" %>
                        </td>
                        <td>
                            <a href="#">
                                <%#Eval("Narrative") %></a>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table class="table table-bordered">
                        <thead>
                            <tr style="background-color: #dfdfdf">
                                <th colspan="5">
                                    ASSESSMENTS
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    NAME
                                </th>
                                <th>
                                    GROUP
                                </th>
                                <th>
                                    STATUS
                                </th>
                                <th>
                                    <a href="#">NARRATION</a>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td colspan="5">
                                    No assessments due at this time.
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
    <div class="grid_8 omega">
        <p>
            The HRA will contain questions in the following topics
        </p>
        <ul>
            <li>Personal details (About you and your biological family ) ( DOB, Physician detail,
                Insurance details, health history etc) </li>
            <li>Personal features </li>
            <li>Medications (all medication taking or taken in the past 2 years) </li>
            <li>Sexuality assessment and drug use </li>
            <li>Gynecologic history (If applicable) </li>
            <li>Past obstetric history (If applicable) </li>
            <li>Alcohol and tobacco use </li>
            <li>Hospitalizations, surgical procedures, reactions or (allergies) </li>
            <li>Immunization </li>
            <li>Communicable diseases history </li>
            <li>Education, ethnicity, marital status </li>
            <li>Life style issues (exercise) </li>
            <li>Preventive health and safety considerations</li>
            <li>Frailty considerations </li>
        </ul>
    </div>
    <script type="text/javascript">
        $(function () {
            $("tr:odd").addClass('AlternateRow');
            $("#tblAssessments tbody tr td")
              .css("cursor", "pointer")
        .click(function (e) {
            $row = $(this).parent();
            var id = $("td", $row).eq(0).text();
            var col = $(this).parent().children().index($(this)); ;
            if (col == 4) {
                window.location.href = "Narrative.aspx?ID=" + getQueryStringByName("ID") + "&AssessmentID=" + $.trim(id);
            }
            else {
                window.location.href = "FamilyHRA.aspx?ID=" + getQueryStringByName("ID") + "&AssessmentID=" + $.trim(id);
            }
        });
        });
    </script>
</asp:Content>
