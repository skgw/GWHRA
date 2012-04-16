using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;

public partial class Config_HRA_SearchAGroups : System.Web.UI.Page
{
    private int CurrentUserID = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Search Assessment Groups";
        if (!IsPostBack)
        {
            SearchGroups();
        }
    }
    protected void lbSearchAGroups_Click(object sender, EventArgs e)
    {
        SearchGroups();
    }
    private void SearchGroups()
    {
        List<AssessmentGroup> qGroups = new List<AssessmentGroup>();
        AssessmentGroupList qGroupList = new AssessmentGroupList(CurrentUserID);

        qGroups = qGroupList.GetAssessmentGroups(Server.HtmlEncode(tbSearchAGroups.Text), cbAGroupStatus.Checked);

        lvAssessmentGroups.DataSource = qGroups;
        lvAssessmentGroups.DataBind();
    }
    protected void lbAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssessmentGroups.aspx");
    }
}