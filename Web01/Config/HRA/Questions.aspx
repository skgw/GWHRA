<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="Questions.aspx.cs" Inherits="Config_HRA_Questions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    $(function () {
        if ($("input[id$='hdnOptions']").val() != "") {
            var strOption = $("input[id$='hdnOptions']").val().split("~");
            for (var i = 0; i < strOption.length; i++) {
                displayOptions(strOption[i]);
            }
            BindEvents();
        }
    });

    $("input[id$='btnAddOption']").live("click", function (e) {
        e.preventDefault();
        var retMsg = ValidateOption();
        if (retMsg != "") {
            alert(retMsg);
            return;
        }
        displayOptions($("input[id$='txtResponseOption']").val());
        BindEvents()
        $("input[id$='txtResponseOption']").val("");

    });
    function displayOptions(OptionText) {
        //Add the options one in each click
        $("input[id$='hdnOptions']").val("");
        var thisTr = "";
        if ($("select[id$='ddlResponseType'] :selected").text() == "RadioButtons") {
            thisTr += "<tr><td style='border:1px solid Black;text-align:center;'><input type='radio' name='radioresponse'/></td><td style='width:90%;border:1px solid Black;'>" + OptionText + "</td><td style='border:1px solid Black;text-align:center;color:Red;'><b>&#120;</b></td></tr>";
        }
        else if ($("select[id$='ddlResponseType'] :selected").text() == "CheckBox") {
            thisTr += "<tr><td style='border:1px solid Black;text-align:center;'><input type='checkbox' name='checkresponse'/></td><td style='width:70%;border:1px solid Black;'>" + OptionText + "</td><td style='border:1px solid Black;text-align:center;color:Red;'><b>&#120;</b></td></tr>";
        }

        $("#tblOptions").append(thisTr);
    }
    function ValidateOption() {
        var msg = "";
        if (jQuery.trim($("input[id$='txtResponseOption']").val()) == "") {
            msg = "You must enter option text.";
            return msg;
        }
        $("#dvOptions table tr").each(function () {
            $row = $(this);
            var option = $("td", $row).eq(1).text();
            if (option == $("input[id$='txtResponseOption']").val()) {
                strOptions = option;
                msg = "This option already exists for this Question.";
            }
        });
        return msg;
    }
    function BindEvents() {
        var strOptions = "";
        $("#dvOptions table tr").each(function () {
            $row = $(this);
            var option = $("td", $row).eq(1).text();
            if (strOptions == "") {
                strOptions = option;
            }
            else {
                strOptions += "~" + option;
            }
            //alert(strOptions);
            $("td", $row).eq(2)
            .css("cursor", "pointer")
            .click(function (e) {
                $row = $(this).parent();
                $row.remove();
            });
        });
        $("input[id$='hdnOptions']").val(strOptions);
        //alert($("input[id$='hdnOptions']").val());
    }
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
            <dd><asp:TextBox ID="txtQuestionText" runat="server" TextMode="MultiLine" Rows="2" Columns="40"></asp:TextBox><span style="color:Red"><b>*</b></span>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtQuestionText"  ErrorMessage="Question Text is required."
                 ValidationGroup="Question" ForeColor="Red"></asp:RequiredFieldValidator>
            </dd>
        </dl>
    </div>
    <div id="dvResponseOptions" runat="server" class="grid_24 alpha" visible="false">
        <div id="dvOptions" class="grid_24 alpha">
        <dl>
            <dt>Response Options</dt>
            <dd>
                <asp:TextBox ID="txtResponseOption" runat="server" Width="450px"></asp:TextBox>
                <asp:Button ID="btnAddOption" runat="server" Text="Add" />
            </dd>
         </dl>
         <div class="grid_8 alpha">&nbsp;</div>
         <div class="grid_16 omega"><table style="width:80%; border:1px solid Black;" id="tblOptions"></table></div>
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
            <dd><asp:TextBox ID="txtNarrative" runat="server" TextMode="MultiLine" Rows="4" Columns="60"></asp:TextBox></dd>
            <dt>Help Text</dt>
            <dd><asp:TextBox ID="txtHelpText" runat="server" TextMode="MultiLine" Rows="4" Columns="60"></asp:TextBox></dd>
            <dt>Is Mandatory</dt>
            <dd><asp:CheckBox ID="chkMandatory" runat="server" /></dd>
            <dt>Is Active</dt>
            <dd><asp:CheckBox ID="chkStatus" runat="server" /></dd>
        </dl>
    </div>
    <div class="grid_24 alpha" >
        <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" OnClick="btnSave_Click" ValidationGroup="Question"/>
        <asp:Button ID="Button1" runat="server" Text="Test" OnClick="Button1_Click"/>
    </div>
<asp:HiddenField ID="hdnOptions" runat="server" />
</asp:Content>

