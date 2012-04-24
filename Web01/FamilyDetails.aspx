<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="FamilyDetails.aspx.cs" Inherits="FamilyDetails" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                </dd>
                <dt>Last name</dt>
                <dd>
                    <asp:TextBox ID="tbLastname" runat="server"></asp:TextBox>
                </dd>
                <dt>Alive/Dead</dt>
                <dd>
                    <asp:DropDownList ID="ddlCurrentStatus" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>Living Status </dt>
                <dd>
                    <asp:DropDownList ID="ddlLivingStatus" runat="server">
                    </asp:DropDownList>
                </dd>
            </dl>
        </div>
        <div class="grid_12 omega">
            <dl>
                <dt>DOB</dt>
                <dd>
                    <asp:DropDownList ID="ddlDOB" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>Sex</dt>
                <dd>
                    <asp:DropDownList ID="ddlSex" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>Date of Death</dt>
                <dd>
                    <asp:TextBox ID="tbDateOfDeath" runat="server"> c</asp:TextBox>
                </dd>
                <dt>Cause of Death</dt>
                <dd>
                    <asp:DropDownList ID="ddlCauseOfDeath" runat="server">
                    </asp:DropDownList>
                </dd>
            </dl>
        </div>
    </div>
    <div class="grid_24 alpha">
        <asp:ListView ID="lvFamilyDetails" runat="server">
            <LayoutTemplate>
                <table>
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
                        <%#Eval("Relation") %>
                    </td>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <%#Eval("Sex") %>
                    </td>
                    <td>
                        <%#Eval("DOB") %>
                    </td>
                    <td>
                        <%#Eval("Status") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
