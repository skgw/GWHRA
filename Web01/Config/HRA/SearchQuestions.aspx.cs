using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRACore;

public partial class Config_HRA_SearchQuestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Search Questions";
        if (!IsPostBack)
        {
            List<QuestionGroup> lst = new List<QuestionGroup>();
            QuestionGroupList obj = new QuestionGroupList();
            lst = obj.GetQuestionGroups("", 'A',Master.CurrentUser.UserID);
            ddlQuestionGroup.DataSource = lst;
            ddlQuestionGroup.DataTextField = "Name";
            ddlQuestionGroup.DataValueField = "ID";
            ddlQuestionGroup.DataBind();
            ddlQuestionGroup.Items.Insert(0, new ListItem("-- Select One --", ""));

            QuestionList QList = new QuestionList();
            DataTable dt = QList.GetQResponseTypes();
            ddlResponseType.DataSource = dt;
            ddlResponseType.DataTextField = "Name";
            ddlResponseType.DataValueField = "ID";
            ddlResponseType.DataBind();

            SearchQuestions();
        }
    }
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        SearchQuestions();
    }
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        //Session["Questionid"] = null;
        Response.Redirect("Questions.aspx");
    }
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        txtQuestionText.Text = "";
        ddlQuestionGroup.SelectedIndex = 0;
        ddlResponseType.SelectedIndex = 0;
        chkIsMandatory.Checked = false;
        chkIsActive.Checked = false;
        SearchQuestions();
    }

    private void SearchQuestions()
    {
        List<Question> lst = new List<Question>();
        QuestionList obj = new QuestionList();
        lst = obj.GetQuestions(txtQuestionText.Text, ddlQuestionGroup.SelectedIndex == 0 ? 0 : Convert.ToInt32(ddlQuestionGroup.SelectedValue), Convert.ToInt32(ddlResponseType.SelectedValue), chkIsActive.Checked == true ? 'A' : 'I', chkIsMandatory.Checked == true ? 'Y' : 'N', 1);
        lvQuestions.DataSource = lst;
        lvQuestions.DataBind();
    }
    
}