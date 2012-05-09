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

                var strTable = "<div id='" + "Q_" + item.ID + "' class='Question grid_24 omega'>";
                strTable += "<div class='grid_1 alpha'>" + (index + 1) + ".</div>";
                strTable += "<div class='grid_10'>" + item.Content + "</div>";
                strTable += "<div class='restype grid_1 omega' style='display:none;'>" + item.ResponseType + "</div>";
                switch (item.ResponseType) {
                    case "TEXTBOX":
                        strTable += "<div class='grid_1 alpha'>&nbsp;</div>";
                        strTable += "<div class='grid_8 omega'><input type='text'" + " id='" + "Q_" + item.ID + "_1'></textbox></div>";
                        break;
                    case "DROPDOWNLIST":
                        var strOptions = "";
                        strOptions += "<option value=''>-- Select One --</option>";
                        for (var i = 0; i < item.Options.length; i++) {
                            strOptions += "<option value='" + item.Options[i].Item3 + "'>" + item.Options[i].Item2 + "</option>";
                        }
                        strTable += "<div class='grid_1 alpha'>&nbsp;</div>";
                        strTable += "<div class='grid_8 omega push_2'><select id='ddl_" + item.ID + "'>" + strOptions + "</select></div>";
                        break;
                    case "RADIOBUTTONS":
                        var strOptions = "";
                        for (var i = 0; i < item.Options.length; i++) {
                            strOptions += "<div class='grid_11 alpha push_2'><input type='radio' id='rad_" + item.ID + "_" + i + "'" + " name='rad_" + item.ID + "' value='" + item.Options[i].Item3 + "' />" + item.Options[i].Item2 + "</div>"
                        }
                        //strTable += "<div class='grid_1 alpha'>&nbsp;</div>" + strOptions;
                        strTable += strOptions;
                        break;
                    case "CHECKBOX":
                        var strOptions = "";
                        for (var i = 0; i < item.Options.length; i++) {
                            strOptions += "<div class='grid_8 alpha push_2'><input type='checkbox' id='chk_" + item.ID + "_" + i + "'" + " name='chk_" + item.ID + "' value='" + item.Options[i].Item3 + "' /><label for='chk_" + item.ID + "'>" + item.Options[i].Item2 + "</label></div>"
                        }
                        strTable += "<div class='grid_1 alpha'>&nbsp;</div>" + strOptions;
                        break;
                }
                strTable += "</div>";
                $("#dvQuetionaire").append(strTable);
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //CheckSession(XMLHttpRequest.responseText);
        }
    });                                  //end ajax
}

$("input[id$='btnSave']").live("click", function () {
    var answerString = "";
    var questionidArr = [];
    var answerArr = [];
    var noAnswer = true;
    $("#dvQuetionaire .Question").each(function (index) {
        var QuetionId = $(this).attr("id").toString().split('_')[1];
        var responsetype = "";
        responsetype = $(this).children(".restype").text();
        //alert(QuetionId + " -- " + responsetype);
        var selectedVal = "";
        switch (responsetype) {
            case "TEXTBOX":
                $("#" + tableid + " tr:not(:first)").each(function (index, item) {
                    var row = $(this);
                    var id = $("td", row).eq(1).children().attr("id");
                    if (jQuery.trim($("#" + id).val()) != "") {
                        answer += id + "," + jQuery.trim($("#" + id).val());
                    }
                });
                break;
            case "DROPDOWNLIST":
                selectedVal = $("#ddl_" + QuetionId).val();
                if (selectedVal != "") {
                    noAnswer = false;
                }
                break;
            case "RADIOBUTTONS":
                $("input[name*='rad_" + QuetionId + "']").each(function () {
                    if ($(this).attr("checked") == "checked") {
                        selectedVal = $(this).val();
                        if (selectedVal != "") {
                            noAnswer = false;
                        }
                    }
                });
                break;
            case "CHECKBOX":


                //answerString += tableid + "~" + answer;
                break
        }
        

        questionidArr[index] = QuetionId;
        answerArr[index] = selectedVal;
    });
    if (noAnswer == true) {
        alert("You need to Answer atleast one Question.");
        return;
    }
    SaveResponses(questionidArr.toString(), answerArr.toString());
});

function SaveResponses(questionidArr, answerArr) {
    //alert(questionidArr + " -- " + answerArr);
    $.ajax({
        type: "POST",
        url: "MemberHRA.aspx/SaveResponses",
        data: "{'MemberMasterID':" + memberMasterID + ",'AssessmentID':" + assessmentId + ",'QuestionId':'" + questionidArr + "','Answers':'" + answerArr + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //CheckSession(XMLHttpRequest.responseText);
        }
    });  
}
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
