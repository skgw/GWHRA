using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;

public partial class Config_HRA_SearchQGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Search Question Groups";
        if (!IsPostBack)
        {
            SearchGroups();
        }
    }
    protected void lbSearchQGroups_Click(object sender, EventArgs e)
    {
        SearchGroups();
    }
    private void SearchGroups()
    {
        List<QuestionGroup> qGroups = new List<QuestionGroup>();
        QuestionGroupList qGroupList = new QuestionGroupList();
        
        qGroups = qGroupList.GetQuestionGroups(Server.HtmlEncode(tbSearchQGroups.Text), cbQGroupStatus.Checked);

        lvQuestionGroups.DataSource = qGroups;
        lvQuestionGroups.DataBind();
    }
    protected void lbAddNew_Click(object sender, EventArgs e)
    {    
        Response.Redirect("QuestionGroups.aspx");
    }
}