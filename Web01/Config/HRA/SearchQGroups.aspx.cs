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
        if (!IsPostBack)
        {
            SearchGroups();
        }
    }
    protected void lbSearchQGroups_Click (object sender, EventArgs e) {
        SearchGroups();
    }
    protected void SearchGroups()
    {
        List<QuestionGroup> lst = new List<QuestionGroup>();
        QuestionGroupList obj = new QuestionGroupList();
        lst = obj.GetQuestionGroups(tbSearchQGroups.Text);
        lvQuestionGroups.DataSource = lst;
        lvQuestionGroups.DataBind();
    }
    protected void lbAddNew_Click(object sender, EventArgs e)
    {
        Session["qgroupid"] = null;
        Response.Redirect("QuestionGroups.aspx");
    }
}