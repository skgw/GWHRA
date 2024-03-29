﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="MemberDetails.aspx.cs" Inherits="MemberDetails" %>

<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid_24 alpha">
        <h3>
            Personal Information</h3>
        <div class="grid_24 alpha">
            <div class="grid_12 alpha">
                <dl>
                    <dt>Salutation</dt>
                    <dd>
                        <asp:DropDownList ID="ddlSalutation" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>First name</dt>
                    <dd>
                        <asp:TextBox ID="tbFirstname" runat="server"></asp:TextBox>
                    </dd>
                    <dt>Middle name</dt>
                    <dd>
                        <asp:TextBox ID="tbMiddleName" runat="server"></asp:TextBox>
                    </dd>
                    <dt>Last name</dt>
                    <dd>
                        <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
                    </dd>
                    <dt>DOB</dt>
                    <dd>
                        <asp:TextBox ID="tbDOB" runat="server"></asp:TextBox>
                    </dd>
                    <dt>Ethnicity</dt>
                    <dd>
                        <asp:DropDownList ID="ddlEthnicity" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Sex</dt>
                    <dd>
                        <asp:DropDownList ID="ddlSex" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Height</dt>
                    <dd>
                        <asp:TextBox ID="tbHeightFeet" runat="server" CssClass="grid_2 alpha"></asp:TextBox>
                        <asp:TextBox ID="tbHeightInches" runat="server" CssClass="grid_2 omega"></asp:TextBox>
                    </dd>
                    <dt>Weight</dt>
                    <dd>
                        <asp:TextBox ID="tbWeight" runat="server"></asp:TextBox>
                    </dd>
                </dl>
            </div>
            <div class="grid_12 omega">
                <dl>
                    <dt>Occupation</dt>
                    <dd>
                        <asp:DropDownList ID="ddlOccupation" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Marital Status</dt>
                    <dd>
                        <asp:DropDownList ID="ddlMaritalStatus" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Member ID</dt>
                    <dd>
                        <asp:TextBox ID="tbMemberID" runat="server"></asp:TextBox>
                    </dd>
                    <dt>HICN</dt>
                    <dd>
                        <asp:TextBox ID="tbHICN" runat="server"></asp:TextBox>
                    </dd>
                    <dt>Handedness </dt>
                    <dd>
                        <asp:DropDownList ID="ddlHandedness" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Email</dt>
                    <dd>
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
    <div class="grid_24 alpha">
        <h3 class="alert-heading">
            Address Information</h3>
        <div class="grid_24 alpha">
            <div class="grid_12 alpha">
                <dl>
                    <dt>Address Type</dt>
                    <dd>
                        <asp:DropDownList ID="ddlAddressType" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Address 1 </dt>
                    <dd>
                        <asp:TextBox ID="tbHAddress1" runat="server"></asp:TextBox>
                    </dd>
                    <dt>Address 2</dt>
                    <dd>
                        <asp:TextBox ID="tbHAddress2" runat="server"></asp:TextBox>
                    </dd>
                    <dt>City</dt>
                    <dd>
                        <asp:TextBox ID="tbHCity" runat="server"></asp:TextBox>
                    </dd>
                    <dt>State</dt>
                    <dd>
                        <asp:DropDownList ID="ddlHomeState" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Zip code</dt>
                    <dd>
                        <asp:TextBox ID="tbHZipcode" runat="server"></asp:TextBox>
                    </dd>
                </dl>
            </div>
            <div class="grid_12 omega">
                <dl>
                    <dt>Address Type</dt>
                    <dd>
                        <asp:DropDownList ID="ddlWorkAddressType" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Address 1 </dt>
                    <dd>
                        <asp:TextBox ID="tbWorkAddress1" runat="server"></asp:TextBox>
                    </dd>
                    <dt>Address 2</dt>
                    <dd>
                        <asp:TextBox ID="tbWorkAddress2" runat="server"></asp:TextBox>
                    </dd>
                    <dt>City</dt>
                    <dd>
                        <asp:TextBox ID="tbWorkCity" runat="server"></asp:TextBox>
                    </dd>
                    <dt>State</dt>
                    <dd>
                        <asp:DropDownList ID="ddlWorkState" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>Zip code</dt>
                    <dd>
                        <asp:TextBox ID="tbWorkZipcode" runat="server"></asp:TextBox>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
    <div class="grid_24 alpha">
        <div class="grid_12 alpha">
            <asp:Button ID="btnBackToMemberDashboard" runat="server" Text="Return to member dashboard" CssClass="btn btn-primary" OnClick="btnBackToMemberDashboard_click" />
        </div>
        <div class="grid_12 omega">
            Once you are done confirming the above, please click <asp:Button ID="btnSave" runat="server" Text="Family Details" OnClick="btnSave_Click" CssClass="btn btn-success omega" />
        </div>
    </div>
</asp:Content>
