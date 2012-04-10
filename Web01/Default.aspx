<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $(function () {
            $("input:submit, a, button", ".demo").button();
            $("a", ".demo").click(function () { return false; });
        });
    </script>
    <div class="demo"> 
        <button>
            A button element</button>
        <input type="submit" value="A submit button">
        <a href="#">An anchor</a>
    </div>
    <!-- End demo -->
    <div class="demo-description" style="display: none;">
        <p>
            Examples of the markup that can be used for buttons: A button element, an input
            of type submit and an anchor.</p>
    </div>
    <!-- End demo-description -->
</asp:Content>
