using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;
using System.Data;
public partial class Config_HRA_AddAssessmentQuestions : System.Web.UI.Page
{
    List<Question> lstQuestions = new List<Question>();
    List<Question> lstSelectedQuestions = new List<Question>();
    Assessment objAssessment = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["objAssessment"] != null)
        {
            objAssessment = (Assessment)Session["objAssessment"];
            lblName.Text = objAssessment.Name;
            lblGroupName.Text = objAssessment.AssessmentGroupName;
        }
        if (!IsPostBack)
        {
            //populate QuestionGroups
            PopulateGroups();
            if (Session["SelectedList"] != null)
            {
                DisplayData((List < Question >) Session["SelectedList"]);
            }
        }
    }
    protected void PopulateGroups()
    {
        QuestionGroupList obj = new QuestionGroupList();
        ddlQuestionGroup.DataSource = obj.GetQuestionGroups("",'A');
        ddlQuestionGroup.DataTextField = "Name";
        ddlQuestionGroup.DataValueField = "ID";
        ddlQuestionGroup.DataBind();
        ddlQuestionGroup.Items.Insert(0,(new ListItem("-- Select One --","")));
    }
    protected void ddlQuestionGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        //retrieve the Questions under the selected Group and Bind the ListView
        QuestionList obj = new QuestionList();
        lstQuestions = obj.GetQuestionsByGroupId(Convert.ToInt32(ddlQuestionGroup.SelectedValue), 1);
        lvQuestions.DataSource = lstQuestions;
        lvQuestions.DataBind();
        ViewState["QList"] = lstQuestions;
    }
    protected void lnkAddQuestions_click(object sender, EventArgs e)
    {
        for (int i = 0; i < lvQuestions.Items.Count; i++)
        {
            CheckBox myCheckbox = (CheckBox)lvQuestions.Items[i].Controls[1];
            if (myCheckbox.Checked == true)
            {
                if (ViewState["QList"] != null)
                {
                    lstQuestions = (List<Question>)ViewState["QList"];
                    lstSelectedQuestions.Add(lstQuestions[i]);
                }
            }
        }
        AddQuestions(lstSelectedQuestions);
     }
    protected void chkSelectAll_OnCheckedChanged(object sender, EventArgs e)
    {
        Boolean chkValue;
        CheckBox source = (CheckBox)sender;
        if (source.Checked)
        {
            chkValue = true;
        }
        else
        {
            chkValue = false;
        }
        for (int i = 0; i < lvQuestions.Items.Count; i++)
        {
            CheckBox myCheckbox = (CheckBox)lvQuestions.Items[i].Controls[1];
            myCheckbox.Checked = chkValue;
        }
    }

    protected void lvSelectedQ_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (String.Equals(e.CommandName, "Remove"))
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            string id = lvSelectedQ.DataKeys[dataItem.DisplayIndex].Value.ToString();
            lstSelectedQuestions = (List<Question>)Session["SelectedList"];

            lstSelectedQuestions.RemoveAt(dataItem.DataItemIndex);
            DisplayData(lstSelectedQuestions);
        }
    }

    protected void lnkPreview_click(object sender, EventArgs e)
    {
        Response.Redirect("AssessmentPreview.aspx?=id" + objAssessment.ID);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessments.aspx?id=" + objAssessment.ID);
    }

    protected void AddQuestions(List<Question> lst)
    {
        //code to lst save in database 
        //------------------------------------
        if (Session["SelectedList"] != null)
        {
            List<Question> lst1 = (List<Question>)Session["SelectedList"];
            Session["SelectedList"] = lst1.Union(lst).ToList();
            DisplayData(lst1.Union(lst).ToList());
        }
        else
        {
            DisplayData(lst);
        }
    }
    protected void DisplayData(List<Question> lst)
    {
        lvSelectedQ.DataSource = lst;
        lvSelectedQ.DataBind();
        Session["SelectedList"] = lst;
    }
}