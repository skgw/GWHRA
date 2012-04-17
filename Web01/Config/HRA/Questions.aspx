<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="Questions.aspx.cs" Inherits="Config_HRA_Questions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    $(function () {
    });
</script>
    <div class="grid_24 alpha" >
        <div class="grid_12 alpha">
            Select Question Group
                <asp:DropDownList ID="ddlQuestionGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlResponseType_SelectedIndexChanged">
                    <asp:ListItem Value="100">Text</asp:ListItem>
                    <asp:ListItem Value="101">TextArea</asp:ListItem>
                    <asp:ListItem Value="102">Option List</asp:ListItem>
                    <asp:ListItem Value="103">Check List</asp:ListItem>
                </asp:DropDownList>
                <span style="color:Red"><b>*</b></span>
            <asp:CustomValidator ID="cvQuestionGroup" runat="server" ControlToValidate="ddlQuestionGroup" 
                 ValidationGroup="Question" ForeColor="Red"></asp:CustomValidator>
        </div>
        <div class="grid_12 omega">
            Select Response Type
            <asp:DropDownList ID="ddlResponseType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlResponseType_SelectedIndexChanged">
                    <%--<asp:ListItem Value="">-- Select One --</asp:ListItem>
                    <asp:ListItem Value="100">Text</asp:ListItem>
                    <asp:ListItem Value="101">TextArea</asp:ListItem>
                    <asp:ListItem Value="102">Option List</asp:ListItem>
                    <asp:ListItem Value="103">Check List</asp:ListItem>--%>
                </asp:DropDownList>
                <span style="color:Red"><b>*</b></span>
        </div>
        
    </div>

    <div class="grid_24 alpha" style="margin-top:2.0em">
        <dl>
            <dt>Question Text</dt>
            <dd><asp:TextBox ID="txtQuestionText" runat="server" TextMode="MultiLine" Rows="2" class="grid_12" Columns="100"></asp:TextBox><span style="color:Red"><b>*</b></span>
            </dd>
            <dt></dt>
            <dd>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtQuestionText"  ErrorMessage="Question Text is required."
                 ValidationGroup="Question" ForeColor="Red"></asp:RequiredFieldValidator>
            </dd>
        </dl>
    </div>
    <div id="dvResponseOptions" runat="server" class="grid grid_24 alpha" visible="false">
        <dl>
            <dt>Response Options</dt>
            <dd>
                <asp:TextBox ID="txtResponseOption" runat="server" Width="450px"></asp:TextBox>
                <asp:Button ID="btnAddOption" runat="server" Text="Add" OnClick="btnAddOption_click" />
            </dd>
         </dl>
         <div class="grid_12 alpha push_8" style="margin-left:0.8em">
                 <asp:GridView ID="gvOptions" runat="server" class="table table-bordered" AutoGenerateColumns="false"  GridLines="Both" OnRowCommand="gvOptions_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Item1" HeaderText="Option Text" ReadOnly="True" />
                            <asp:ButtonField ButtonType="Link" CommandName="Remove" HeaderText="Remove" Text="&#120;" />
                        </Columns>
                </asp:GridView>
         </div>
        
    </div>


    <div class="grid_24 alpha">
        <dl>
            <dt>Display Order</dt>
            <dd><asp:TextBox ID="txtDisplayOrder" runat="server"></asp:TextBox>
            <span style="color:Red"><b>*</b></span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDisplayOrder"  ErrorMessage="Display Order is required."
                 ValidationGroup="Question" ForeColor="Red"></asp:RequiredFieldValidator>
            </dd>
            <dt>Gender</dt>
            <dd><asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Value="B">Both</asp:ListItem>
                <asp:ListItem Value="M">Male</asp:ListItem>
                <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:DropDownList></dd>
            <dt>Narrative</dt>
            <dd><asp:TextBox ID="txtNarrative" runat="server" TextMode="MultiLine" Rows="4" Columns="100" class="grid_12" MaxLength="1000"></asp:TextBox></dd>
            <dt>Help Text</dt>
            <dd><asp:TextBox ID="txtHelpText" runat="server" TextMode="MultiLine" Rows="4" Columns="100" class="grid_12" MaxLength="1000"></asp:TextBox></dd>
            <dt>Is Mandatory</dt>
            <dd><asp:CheckBox ID="chkMandatory" runat="server" /></dd>
            <dt>Is Active</dt>
            <dd><asp:CheckBox ID="chkStatus" runat="server" /></dd>
        </dl>
    </div>
    <div class="grid_24 alpha" >
        <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="Question"/>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-success" OnClick="btnCancel_Click"/>
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-success" OnClick="btnBack_Click"/>
    </div>

</asp:Content>

