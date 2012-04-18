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
    private Question qObj = new Question(1);
    private Int64 QuestionId = 0;
    List<Tuple<string>> lstOptions = new List<Tuple<string>>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["QuestionId"] != null)
        {
            QuestionId = Convert.ToInt64(Request.QueryString["QuestionId"]);
        }
        if (!IsPostBack)
        {
            List<QuestionGroup> lst = new List<QuestionGroup>();
            QuestionGroupList obj = new QuestionGroupList();
            lst = obj.GetQuestionGroups("",'A');
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
                QuestionList qObj = new QuestionList();
                Question obj1 = qObj.GetQuestionById(QuestionId,1);
                if (obj1 != null)
                {
                    txtQuestionText.Text = obj1.Content;
                    txtDisplayOrder.Text = obj1.DisplayOrder.ToString();
                    txtNarrative.Text = obj1.Narrative;
                    txtHelpText.Text = obj1.HelpText;
                    ddlQuestionGroup.SelectedValue = obj1.QGroupId_Ref.ToString();
                    ddlResponseType.SelectedValue = obj1.QResponseTypeId_Ref.ToString();
                    chkMandatory.Checked = obj1.IsMandatory.ToString() == "Y" ? true : false;
                    chkStatus.Checked = obj1.Status.ToString() == "A" ? true : false;
                    LoadOptions(obj1.ResponseText);
                }
                //Session["Questionid"] = QuestionId;
            }
        }
    }
    protected void BindResponseTypes()
    {
        QuestionList QList = new QuestionList();
        DataTable dt = QList.GetQResponseTypes();
        ddlResponseType.DataSource = dt;
        ddlResponseType.DataTextField = "Name";
        ddlResponseType.DataValueField = "ID";
        ddlResponseType.DataBind();

    }
    protected void ddlResponseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtResponseOption.Text = string.Empty;
        
        switch (ddlResponseType.SelectedItem.Text)
        {
            case "TextBox":
                dvResponseOptions.Visible = false;
                break;
            case "TextArea":
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
                //make the xml string
                if (Session["OptionList"] != null)
                {
                    strXML = "<optionlist>";
                    lstOptions = (List<Tuple<string>>)Session["OptionList"];
                    for (int i = 0; i < lstOptions.Count; i++)
                    {
                        strXML += "<option>" + lstOptions[i].Item1 + "</option>";
                    }
                    strXML += "</optionlist>";
                }
                break;

        }
        //assign the values to the Question Object properties
        Question obj = new Question(1);
        obj.ID = (QuestionId > 0) ? QuestionId : 0;
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
        
        obj.Save(1);
        LoadOptions(obj.ResponseText);
        //Session["Questionid"] = obj.ID;
    }
    
    protected void LoadOptions(string optionString)
    {
        Session["OptionList"] = null;
        XmlDocument optionsXML = new XmlDocument();
        if (optionString.Length > 0)
        {
            optionsXML.LoadXml(optionString);
            
            XmlElement root = optionsXML.DocumentElement;
            XmlNodeList xnList = root.ChildNodes;
            lstOptions.Clear();
            for (int i = 0; i < xnList.Count; i++)
            {
                lstOptions.Add(Tuple.Create<string>(Server.HtmlDecode(xnList[i].InnerXml)));
            }
            Session["OptionList"] = lstOptions;
            BindOptions();
        }
    }
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Session["OptionList"] = null;
        Response.Redirect("Questions.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchQuestions.aspx");
    }


    protected void btnAddOption_click(object sender, EventArgs e)
    {
        if (txtResponseOption.Text.Trim().Length > 0)
        {
            if (Session["OptionList"] != null)
            {
                lstOptions = (List<Tuple<string>>)Session["OptionList"];
            }
            lstOptions.Add(Tuple.Create<string>(txtResponseOption.Text.Trim()));
        }
        if (lstOptions.Count > 0)
        {
            Session["OptionList"] = lstOptions;
        }
        BindOptions();
        txtResponseOption.Text = "";
        txtResponseOption.Focus();
    }

    protected void gvOptions_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            int thisIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvOptions.Rows[thisIndex];
            string thisOptionText = Server.HtmlDecode(row.Cells[0].Text).ToString();
            if (Session["OptionList"] != null)
            {
                lstOptions = (List<Tuple<string>>)Session["OptionList"];
                lstOptions.RemoveAt(thisIndex);
                Session["OptionList"] = lstOptions;
            }
            BindOptions();
        }
    }

    protected void BindOptions()
    {
        dvResponseOptions.Visible = true;
        gvOptions.DataSource = lstOptions;
        gvOptions.DataBind();
    }
}