function GetQuestionaire() {
    $("#dvQuetionaire").html("");
    $.ajax({
        type: "POST",
        url: "MemberHRA.aspx/GetQuestionaire",
        data: "{'AssessmentID':" + "1000" + ",'userid':" + 1 + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $.each(msg.d, function (index, item) {
                //alert(item.ID + " -- " + item.Content + " -- " + item.DisplayOrder + " -- " + item.ResponseType + " -- " + item.ResponseText);
                var strTable = "<table id='" + "Q_" + item.ID + "' style='width:100%'><tr><td style='width:2%'>" + (index + 1) + ".</td><td>" + item.Content + "</td><td style='display:none;'>" + item.ResponseType + "</td></tr>";
                //alert(item.ResponseType);
                switch (item.ResponseType) {
                    case "TEXTBOX":
                        strTable += "<tr><td>&nbsp;</td><td><input type='text'" + " id='" + "Q_" + item.ID + "_1'></textbox></td></tr>";
                        break;
                    case "DROPDOWNLIST":
                        var strOptions = "";
                        for (var i = 0; i < item.Options.length; i++) {
                            strOptions += "<option value='" + item.Options[i].Item3 + "'>" + item.Options[i].Item2 + "</option>";
                        }
                        strTable += "<tr><td>&nbsp;</td><td><select id='Q_" + item.ID + "'>" + strOptions + "</select></td></tr>";
                        break;
                    case "CHECKBOX":
       
                        break;
                }
                strTable += "</table>";
                $("#dvQuetionaire").append(strTable);
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            CheckSession(XMLHttpRequest.responseText);
        }
    });                               //end ajax
}

$("input[id$='btnSave']").live("click", function () {
    var answerString = "";
    $("#dvQuetionaire table").each(function () {
        var tableid = $(this).attr("id");
        var responsetype = "";
        var answer = "";
        responsetype = $("#" + tableid + " tr:eq(0) td:eq(2)").text();

        switch (responsetype) {
            case "TEXTBOX":
                $("#" + tableid + " tr:not(:first)").each(function (index, item) {
                    var row = $(this);
                    var id = $("td", row).eq(1).children().attr("id");
                    if (jQuery.trim($("#" + id).val()) != "") {
                        answer += id + "," + jQuery.trim($("#" + id).val());
                    }
                });

                //answerString += tableid + "~" + answer;
                break;
            case "DROPDOWNLIST":
                $("#" + tableid + " tr:not(:first)").each(function (index, item) {
                    var row = $(this);
                    var id = $("td", row).eq(1).children().attr("id");
                    var selectedvalue = $("select[id$='" + id + "']").val();
                    alert("selectedvalue = " + selectedvalue);
                });
                break;
            case "checkbox":

                $("#" + tableid + " tr").each(function (index, item) {
                    var row = $(this);
                    var id = $("td", row).eq(1).children().attr("id");

                    if ($("#" + id).attr("checked") == true) {
                        if (answer == "") {
                            answer = id;
                        }
                        else {
                            answer += "," + id;
                        }
                    }
                });
                //answerString += tableid + "~" + answer;
                break
        }
        if (answerString == "") {
            answerString += tableid + "~" + answer;
        }
        else {
            answerString += "#" + tableid + "~" + answer;
        }
    });
    //alert(answerString);
    //RemoveOldAnswer();
    //alert($("input[id$='hdnResponseString']").val());
    answerString += "|" + $("input[id$='hdnResponseString']").val();
    //alert(answerString);
    $("input[id$='hdnResponseString']").val(answerString);
});
