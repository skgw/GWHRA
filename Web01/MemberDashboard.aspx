<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="MemberDashboard.aspx.cs" Inherits="MemberDashboard" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div class="grid_16 alpha">
        <asp:LinkButton ID="lnkMemberDetails" runat="server" OnClick="lnkMemberDetails_click">MemberDetails</asp:LinkButton>
        <asp:LinkButton ID="lnkFamilyDetails" runat="server" OnClick="lnkFamilyDetails_click">FamilyDetails</asp:LinkButton>
        <%--<a href="MemberDetails.aspx">Member Details</a>
    <a href="FamilyDetails.aspx">Family Details</a>--%>
        <div>
            <asp:ListView ID="lvFamilyDetails" runat="server">
                <LayoutTemplate>
                    <table class="table table-bordered">
                        <thead>
                            <tr style="background-color: #2ccccc">
                                <th colspan="6">
                                    FAMILY MEMBERS
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    Relation
                                </th>
                                <th>
                                    Last Name
                                </th>
                                <th>
                                    First Name
                                </th>
                                <th>
                                    Sex
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
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    Relation
                                </th>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Sex
                                </th>
                                <th>
                                    DOB
                                </th>
                                <th>
                                    Status
                                </th>
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
                    <table class="table table-bordered">
                        <thead>
                            <tr style="background-color: #2ccccc">
                                <th colspan="4">
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
                            <%#Eval("Status") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    Relation
                                </th>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Sex
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td colspan="4">
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
</asp:Content>
