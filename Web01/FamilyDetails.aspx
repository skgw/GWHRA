<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="FamilyDetails.aspx.cs" Inherits="FamilyDetails" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            BindEvents();
        });

        function BindEvents() {
            $("input[id$='txtDOB']").datepicker({
                onSelect: function (e) {
                    //alert($("input[id$='txtEffectiveFrom']").val());
                },
                changeMonth: true,
                changeYear: true,
                maxDate: 0
            });
            $("input[id$='tbDateOfDeath']").datepicker({
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
                <dt>Relationship</dt>
                <dd>
                    <asp:DropDownList ID="ddlRelationship" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>First name</dt>
                <dd>
                    <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="tbFirstName"
                        ErrorMessage="*" ValidationGroup="FamilyDetails" ForeColor="Red"></asp:RequiredFieldValidator></dd>
                <dt>Last name</dt>
                <dd>
                    <asp:TextBox ID="tbLastname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="tbLastname"
                        ErrorMessage="*" ValidationGroup="FamilyDetails" ForeColor="Red"></asp:RequiredFieldValidator>
                </dd>
                <dt>Alive/Dead</dt>
                <dd>
                    <asp:DropDownList ID="ddlCurrentStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCurrentStatus_IndexChanged">
                        <asp:ListItem Value="A">Alive</asp:ListItem>
                        <asp:ListItem Value="D">Dead</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt id="dtLivingStatus" runat="server">Living Status </dt>
                <dd id="ddLivingStatus" runat="server">
                    <asp:DropDownList ID="ddlLivingStatus" runat="server">
                    </asp:DropDownList>
                </dd>
            </dl>
        </div>
        <div class="grid_12 omega">
            <dl>
                <dt>DOB</dt>
                <dd>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="grid_3 alpha"></asp:TextBox><span
                        style="color: Red"><b> *</b></span>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ErrorMessage=""
                        ForeColor="Red"></asp:CustomValidator>
                </dd>
                <dt>Sex</dt>
                <dd>
                    <asp:DropDownList ID="ddlSex" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt id="dtDateOfDeath" runat="server">Date of Death</dt>
                <dd id="ddDateOfDeath" runat="server">
                    <asp:TextBox ID="tbDateOfDeath" runat="server" CssClass="grid_3 alpha"></asp:TextBox>
                </dd>
                <dt id="dtCauseOfDeath" runat="server">Cause of Death</dt>
                <dd id="ddCauseOfDeath" runat="server">
                    <asp:DropDownList ID="ddlCauseOfDeath" runat="server">
                    </asp:DropDownList>
                </dd>
            </dl>
        </div>
    </div>
    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_click" ValidationGroup="FamilyDetails"
        CssClass="btn btn-success" />
    <div class="grid_24 alpha">
        <asp:ListView ID="lvFamilyDetails" runat="server">
            <LayoutTemplate>
                <table class="table table-bordered">
                    <thead>
                         <tr style="background-color: #DFDFDF;">
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
                          <%# ((Eval("Sex")).ToString()=="1001")?"F":"M" %>
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
    <div class="grid_24 alpha">
        <div class="grid_16 alpha">
            <asp:Button ID="btnNext" runat="server" Text="Return to member dashboard" CssClass="btn btn-primary" OnClick="btnNext_click" />
        </div>
        <div class="grid_8 omega">
            &nbsp;
        </div>
    </div>
</asp:Content>
