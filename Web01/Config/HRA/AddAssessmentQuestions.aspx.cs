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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["objAssessment"] != null)
            {
                Assessment obj = (Assessment)Session["objAssessment"];
                lblName.Text = obj.Name;
                lblGroupName.Text = obj.AssessmentGroupName;
               
            }
            //populate QuestionGroups
            PopulateGroups();
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
        string SelectedQuestions = "";
        //foreach (ListViewItem Item in lvQuestions.Items)
        //{
        //    CheckBox myCheckbox = (CheckBox)lvQuestions.Items[0].Controls[1];
        //    if (myCheckbox.Checked == true)
        //    {
        //        string xy = "true";
        //    }
        //}
        for (int i = 0; i < lvQuestions.Items.Count; i++)
        {
            CheckBox myCheckbox = (CheckBox)lvQuestions.Items[i].Controls[1];
            if (myCheckbox.Checked == true)
            {
                if (ViewState["QList"] != null)
                {
                    lstQuestions = (List<Question>)ViewState["QList"];
                    lstSelectedQuestions.Add(lstQuestions[i]);
                    //if (SelectedQuestions == "")
                    //{
                    //    SelectedQuestions = lstQuestions[i].ID.ToString();
                    //}
                    //else
                    //{
                    //    SelectedQuestions += "," + lstQuestions[i].ID.ToString();
                    //}
                }
            }
        }
        lvSelectedQ.DataSource = lstSelectedQuestions;
        lvSelectedQ.DataBind();
        //string xyz = SelectedQuestions;
    }
    protected void lnkPreview_click(object sender, EventArgs e)
    {
        Response.Redirect("AssessmentPreview.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessments.aspx?id=xxx");
    }
}