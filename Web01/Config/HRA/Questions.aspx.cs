using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using HRACore;

public partial class Config_HRA_Questions : System.Web.UI.Page
{
    private Question qObj = new Question();
    private Int64 QuestionId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["QuestionId"] != null)
        {
            QuestionId = Convert.ToInt64(Request.QueryString["QuestionId"]);
        }
        if (!IsPostBack) {
            List<QuestionGroup> lst = new List<QuestionGroup>();
            QuestionGroupList obj = new QuestionGroupList();
            lst = obj.GetQuestionGroups("",true);
            ddlQuestionGroup.DataSource = lst;
            ddlQuestionGroup.DataTextField = "Name";
            ddlQuestionGroup.DataValueField = "ID";
            ddlQuestionGroup.DataBind();
            ddlQuestionGroup.Items.Insert(0, new ListItem("-- Select One --", ""));

            //load the Response Type dropdown from the Enums
            BindResponseTypes();
            
            if (QuestionId > 0)
            {
                    //Populate the data for the QuestionId
                Question qObj = Question.GetQuestionById(QuestionId);
                if (qObj != null)
                {
                    txtQuestionText.Text = qObj.Content;
                    txtDisplayOrder.Text = qObj.DisplayOrder.ToString();
                    txtNarrative.Text = qObj.Narrative;
                    txtHelpText.Text = qObj.HelpText;
                    ddlQuestionGroup.SelectedValue = qObj.QGroupId_Ref.ToString();
                    ddlResponseType.SelectedValue = qObj.QResponseTypeId_Ref.ToString();
                    chkMandatory.Checked = qObj.IsMandatory.ToString() == "Y" ? true : false;
                    chkStatus.Checked = qObj.Status.ToString() == "A" ? true : false;
                    LoadOptions(qObj.ResponseText);
                }
                Session["Questionid"] = QuestionId;
            }
        }
    }
    protected void BindResponseTypes()
    {
        DataTable dt = Question.GetQResponseTypes();
        ddlResponseType.DataSource = dt;
        ddlResponseType.DataTextField = "Name";
        ddlResponseType.DataValueField = "ID";
        ddlResponseType.DataBind();
        
    }
    protected void ddlResponseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtResponseOption.Text = string.Empty;
        hdnOptions.Value = string.Empty;
        switch (ddlResponseType.SelectedItem.Text)
        {
            case "TextBox":
                dvResponseOptions.Visible = false;
                break;
            case  "TextArea":
                dvResponseOptions.Visible = false;
                break;
            case "RadioButtons":
                dvResponseOptions.Visible = true;
                break;
            case "CheckBox":
                dvResponseOptions.Visible = true;
                break;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlQuestionGroup.SelectedIndex == 0)
        {
            cvQuestionGroup.ErrorMessage = "Question Group is required.";
            cvQuestionGroup.IsValid = false;
            cvQuestionGroup.Visible = true;
            return;
        }
        string strXML = "";
        switch (ddlResponseType.SelectedItem.Text)
        {
            case "TextBox":
                dvResponseOptions.Visible = false;
                break;
            case "TextArea":
                dvResponseOptions.Visible = false;
                break;
            case "RadioButtons":
            case "CheckBox":
                if (hdnOptions.Value != "")
                {
                    //make the xml string
                    strXML = "<optionlist>";
                    string[] options = hdnOptions.Value.Split('~');
                    for (int i = 0; i < options.Length; i++)
                    {
                        strXML += "<option>" + options[i] + "</option>";
                    }
                    strXML += "</optionlist>";
                }
                break;
            
        }
//assign the values to the Question Object properties
        Question obj = new Question();

        if (Session["Questionid"] == null)
        {
            obj.ID = 0;
        }
        else
        {
            obj.ID = (Int64)Session["Questionid"];
        }
        obj.Content = txtQuestionText.Text;
        obj.DisplayOrder = Convert.ToInt64(txtDisplayOrder.Text);

        //Sex selectedSex;
        //foreach (Sex item in Enum.GetValues(typeof(Sex)))
        //{
        //    if (ddlGender.SelectedItem.Text == item.ToString())
        //    {
        //        selectedSex = item;
        //        obj.AppliesTo = selectedSex;
        //    }
        //}

        //if (ddlGender.SelectedValue == "0")
        //    obj.AppliesTo = Sex.Both;
        //else if (ddlGender.SelectedValue == "1")
        //    obj.AppliesTo = Sex.Male;
        //else if (ddlGender.SelectedValue == "2")
        //    obj.AppliesTo = Sex.Female;
        obj.Gender = Convert.ToChar(ddlGender.SelectedValue);
        obj.Narrative = txtNarrative.Text;
        obj.HelpText = txtHelpText.Text;
        obj.IsMandatory = chkStatus.Checked == true ? 'Y' : 'N';
        obj.Status = chkStatus.Checked == true ? 'A' : 'I';

        ResponseTypes selectedResponseTypes;
        foreach (ResponseTypes item in Enum.GetValues(typeof(ResponseTypes)))
        {
            if (ddlResponseType.SelectedItem.Text == item.ToString())
            {
                selectedResponseTypes = item;
                obj.QuestionResponseType = selectedResponseTypes;
            }
        }
        obj.ResponseText = strXML;
        obj.QGroupId_Ref = Convert.ToInt64(ddlQuestionGroup.SelectedValue);
        obj.QResponseTypeId_Ref = Convert.ToInt64(ddlResponseType.SelectedValue);
        Question retObj = obj.Save(1);
        if (retObj != null)
        {
            LoadOptions(retObj.ResponseText);
            Session["Questionid"] = retObj.ID;
        }

    }
    protected void LoadOptions(string optionString)
    {
        XmlDocument optionsXML = new XmlDocument();
        if (optionString.Length > 0)
        {
            optionsXML.LoadXml(optionString);
            hdnOptions.Value = "";
            XmlElement root = optionsXML.DocumentElement;
            XmlNodeList xnList = root.ChildNodes;
            for (int i = 0; i < xnList.Count; i++)
            {
                if (hdnOptions.Value == "")
                {
                    hdnOptions.Value = xnList[i].InnerXml;
                }
                else
                {
                    hdnOptions.Value += "~" + xnList[i].InnerXml;
                }
            }
            dvResponseOptions.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Questions.aspx?QuestionId=1645"); 
        return;
        txtQuestionText.Text = "xxxxxxxxxxxxxxxxxxxx";
        txtDisplayOrder.Text = "1";
        txtNarrative.Text = "yyyyyyyyyyyyyyyy";
        txtHelpText.Text = "zzzzzzzzzzzzzzzzzzz";
        
        //string xyz = "<optionlist><option>QWQWQW</option><option>SAASASS</option><option>ZXZXZX</option></optionlist>";
        //hdnOptions.Value = "";
        //XmlDocument optionsXML = new XmlDocument();
        //optionsXML.LoadXml(xyz);
        //XmlElement root = optionsXML.DocumentElement;
        //XmlNodeList xnList = root.ChildNodes;
        //for (int i = 0; i < xnList.Count; i++)
        //{
        //    if (hdnOptions.Value == "")
        //    {
        //        hdnOptions.Value = xnList[i].InnerXml;
        //    }
        //    else
        //    {
        //        hdnOptions.Value += "~" + xnList[i].InnerXml;
        //    }
        //}
        
    }
}