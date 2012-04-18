<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" CodeFile="AddAssessmentQuestions.aspx.cs" Inherits="Config_HRA_AddAssessmentQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid_24 alpha">
        <div class="grid_12 alpha">
            <dl>
                <dt>Assessment Name</dt>
                <dd><asp:Label ID="lblName" runat="server"></asp:Label></dd>
            </dl>
        </div>
        <div class="grid_12 omega">
                <dl>
                    <dt>Assessment Group</dt>
                    <dd><asp:Label ID="lblGroupName" runat="server"></asp:Label></dd>
                </dl>
        </div>
    </div>
    <div class="grid_24 alpha">
        Question Group  <asp:DropDownList ID="ddlQuestionGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQuestionGroup_SelectedIndexChanged">
            <asp:ListItem Value="">-- Select One --</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="grid_24 alpha">
        Select Questions
        <asp:ListView ID="lvQuestions" runat="server">
            <LayoutTemplate>
                <table id="tblQuestions" class="table table-bordered ">
                    <thead>
                        <tr>
                            <th>
                                Select
                            </th>
                            <th>
                                Question
                            </th>
                            <th>
                                Response Type
                            </th>
                             <th style="display:none">
                                ID
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </td>
                    <td>
                        <%# Eval("Content")%>
                    </td>
                    <td>
                        <%# Eval("ResponseType") %>
                    </td>
                    <td style="display:none">
                        <%# Eval("ID") %>
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr class="row">
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </EmptyDataTemplate>
        </asp:ListView>
        
    </div>
    <div class="grid_24 alpha" style="margin-top:1em;margin-bottom:1em;">
        <asp:LinkButton ID="lnkAddQuestions" runat="server" CssClass="btn btn-success" Text="Add Questions" OnClick="lnkAddQuestions_click"></asp:LinkButton>
        <asp:Button ID="btnBack" runat="server" Text="Return to Assessment" CssClass="btn btn-info" OnClick="btnBack_Click"/>
    </div>
    <div class="grid_24 alpha">
        Selected Questions
        <asp:ListView ID="lvSelectedQ" runat="server">
            <LayoutTemplate>
                <table id="tblSelectedQ" class="table table-bordered ">
                    <thead>
                        <tr>
                            <th>
                                Question
                            </th>
                            <th>
                                Response Type
                            </th>
                            <th>
                                Remove
                            </th>
                            <th style="display:none">
                                ID
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Content")%>
                    </td>
                    <td>
                        <%# Eval("ResponseType") %>
                    </td>
                    <td>
                        &#120;
                    </td>
                    <td style="display:none">
                        <%# Eval("ID") %>
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr class="row">
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </EmptyDataTemplate>
        </asp:ListView>
        
    </div>
    <div class="grid_24 alpha" style="margin-top:1em; margin-bottom:1em;">
        <asp:LinkButton ID="lnkPreview" runat="server" CssClass="btn btn-success" Text="Preview" OnClick="lnkPreview_click"></asp:LinkButton>
    </div>
</asp:Content>

