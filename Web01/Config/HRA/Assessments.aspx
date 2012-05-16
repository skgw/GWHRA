<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" ValidateRequest="false"
    CodeFile="Assessments.aspx.cs" Inherits="Config_HRA_Assessments" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
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
                    <asp:TextBox ID="txtAssessmentName" runat="server" CssClass="grid_6 alpha"></asp:TextBox><span
                        style="color: Red"><b>*</b></span>
                </dd>
                <dt></dt>
                <dd>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtAssessmentName"
                        ErrorMessage="Assessment Name is required." ValidationGroup="Assessment" ForeColor="Red"></asp:RequiredFieldValidator>
                </dd>
                <dt>Description</dt>
                <dd>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Columns="80"
                        Rows="4" CssClass="grid_6 alpha"></asp:TextBox>
                </dd>
                <dt>IsActive</dt>
                <dd>
                    <asp:CheckBox ID="chkStatus" runat="server"></asp:CheckBox>
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
                <dt>Effective From</dt>
                <dd>
                    <asp:TextBox ID="txtEffectiveFrom" runat="server" CssClass="grid_3 alpha"></asp:TextBox>
                </dd>
                <dt>Effective To</dt>
                <dd>
                    <asp:TextBox ID="txtEffectiveTo" runat="server" CssClass="grid_3 alpha"></asp:TextBox>
                </dd>
            </dl>
        </div>
    </div>
    <div class="grid_24 alpha">
        <dl>
            <dt>Narrative Header</dt>
            <dd>
                <asp:TextBox ID="tbNarrativeHeader" runat="server" TextMode="MultiLine" class="grid_15 textarea_h80 "></asp:TextBox>
            </dd>
            <dt>Narrative Footer</dt>
            <dd>
                <asp:TextBox ID="tbNarrativeFooter" runat="server" TextMode="MultiLine" class="grid_15 textarea_h80"></asp:TextBox>
            </dd>
        </dl>
    </div>
    <div class="grid_24 alpha">
        <div class="grid_6 alpha">
            &nbsp;
        </div>
        <div class="grid_6 ">
            <asp:LinkButton ID="lnkBack" runat="server" CssClass="btn" OnClick="lnkBack_Click">Return to search results</asp:LinkButton></div>
        <div class="grid_6 ">
            &nbsp;
        </div>
        <div class="grid_6 omega">
            <asp:LinkButton ID="lnkAddQuestions" runat="server" CssClass="btn btn-success" OnClick="lnkAddQuestions_Click"
                ValidationGroup="Assessment" CausesValidation="true">Save & Continue</asp:LinkButton>
        </div>
    </div>
</asp:Content>
