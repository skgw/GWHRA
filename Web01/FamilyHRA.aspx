<%@ Page Title="" Language="C#" MasterPageFile="~/BasePages/Base.master" AutoEventWireup="true" CodeFile="FamilyHRA.aspx.cs" Inherits="FamilyHRA" %>
<%@ MasterType VirtualPath="~/BasePages/Base.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
   .relation { writing-mode: tb-rl; -webkit-transform: rotate(45deg); -moz-transform: rotate(45deg); width: -moz-fit-content;}
   
</style>

<script type="text/javascript">
    var memberMasterID = 0;
    $(function () {
        $("tr:odd").addClass('AlternateRow');
        $("tr th:eq(0)").add().css("display", "none");
        $("tr").each(function () {
            $row = $(this);
            //$("tr td:eq(0)").add().css("display", "none");
            $("td", $row).eq(0).add().css("display", "none");
            $("td", $row).eq(1).add().css("text-align", "left");
        });
        $("tr td").each(function () {
            if ($(this).text() == "x") {
                $(this).add().css("color", "Red");
                $(this).html("&#120;");
            }
        });
        if (jQuery.trim(getParameterByName("ID")) != "") {
            memberMasterID = jQuery.trim(getParameterByName("ID"));
        }
        GetFamilyQuestionList();
    });
    function GetFamilyQuestionList() {
        $.ajax({
            type: "POST",
            url: "FamilyHRA.aspx/GetFamilyQuestionList",
            data: "{'userid':" + 1 + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var strTable = "<table id='tblFamily' class='gv table table-bordered'><tr><th style='height:60px;'>Conditions</th></tr>";
                $.each(msg.d, function (index, item) {
                    //alert(item);
                    strTable += "<tr><td>" + item.Item1 + "</td><td>" + item.Item2 + "</td></tr>";
                });
                strTable += "</table>";
                $("#" + "dvFamily").append(strTable);
                //retrieve data for the family members name, count etc an creat the other columns
                GetFamilyMembers();
                $("tr:odd").addClass('AlternateRow');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //CheckSession(XMLHttpRequest.responseText);
            }
        });
    }

    function GetFamilyMembers() {
       
        $.ajax({
            type: "POST",
            url: "FamilyHRA.aspx/GetFamilyMembers",
            data: "{'MemberMasterID':" + memberMasterID + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var memberCount = 1;
                var strSiblingsHeader = "";
                strSiblingsHeader += "<th class='relation'>Self<span class='relationId' style='display:none;'>" + memberMasterID + "</span></th>";
                $.each(msg.d, function (index, item) {
                    strSiblingsHeader += "<th class='relation'>" + item.RelationshipName + "<span class='relationId' style='display:none;'>" + item.ID + "</span></th>";
                    memberCount += 1;
                });
                $("#" + "dvFamily" + " tr:first").append(strSiblingsHeader);

                var strSiblingsRows = "";
                for (var i = 0; i < memberCount; i++) {
                    strSiblingsRows += "<td><input type='checkbox' class='chk' value='xx'/></td>";
                }
                $("#" + "dvFamily" + " tr:not(:first)").append(strSiblingsRows);
                $("tr").each(function () {
                    $row = $(this);
                    $("td", $row).eq(0).add().css("display", "none");
                    $("td", $row).eq(1).add().css("text-align", "left");
                });
                //alert('IN');
                GetFamilyHRAResponse();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //CheckSession(XMLHttpRequest.responseText);
            }
        });
    }
    $("input[id$='btnSave']").live("click", function (e) {
        e.preventDefault();

        $("#dvFamily tr").each(function (indextd) {
            var $row = $(this);
            var FamilyQuestionId = $("td", $row).eq(0).text();
            $(" .relationId").each(function (indexth) {
                var MemberMasterID = $(this).text();
                if ($("td", $row).eq(indexth + 2).children().attr("checked") == "checked") {
                    InsertFamilyHRA(MemberMasterID, FamilyQuestionId);
                }
            });

        });
    });
        
    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.href);
        if (results == null)
            return "";
        else
            return decodeURIComponent(results[1].replace(/\+/g, " "));
    }

    function GetFamilyHRAResponse() {
       
        $.ajax({
            type: "POST",
            url: "FamilyHRA.aspx/GetFamilyHRAResponseList",
            data: "{'MemberMasterID':" + memberMasterID + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                //alert(msg.d);
                $.each(msg.d, function (index, item) {
                    $("#dvFamily tr").each(function (indextd) {
                        var $row = $(this);
                        var DiseaseID = $("td", $row).eq(0).text();
                        if (DiseaseID == item.Item2) {
                            //alert(DiseaseID + " == " + item.Item2);
                            $(" .relationId").each(function (indexth) {
                                var relationid = $(this).text();
                                //alert(relationid + " == " + item.Item1);
                                if (relationid == item.Item1) {
                                    $("td", $row).eq(indexth + 2).children().attr("checked", true);
                                }
                            });
                        }

                    });
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //CheckSession(XMLHttpRequest.responseText);
            }
        });
    }

    function InsertFamilyHRA(MemberMasterID, FamilyQuestionId) {
        
        $.ajax({
            type: "POST",
            url: "FamilyHRA.aspx/InsertFamilyHRA",
            data: "{'MemberMasterID':" + MemberMasterID + ",'FamilyQuestionId':" + FamilyQuestionId + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
            
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //CheckSession(XMLHttpRequest.responseText);
            }
        });
    }
</script>
<asp:Button ID="btnSave" runat="server" Text="Save"/>
<asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_click"/>

<div id="dvFamily" class="grid">
    
</div>
       
<div id="dvDisplay" class="grid">
    
</div>

    <asp:HiddenField ID="hdnSiblings" runat="server" />
    <%--<style>
th { background-color: #001640; color: white; height:50px;padding-bottom: 10px;writing-mode: tb-rl; -webkit-transform: rotate(45deg); -moz-transform: rotate(45deg); width: -moz-fit-content; width: fit-content; }
</style>
<table border="1">
  <tr>
    <th>Position</th>
    <th>Country</th>
    <th>City</th>
  </tr>
  <tr>
    <td>1</th>
    <td>UK</td>
    <td>Inverness</td>
  </tr>
  <tr>
    <td >2</th>
    <td>Norway</td>
    <td>Bergen</td>
  </tr>
</table>
--%>
</asp:Content>



