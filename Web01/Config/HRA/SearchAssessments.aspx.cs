using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;

public partial class Config_HRA_SearchAssessments : System.Web.UI.Page
{
    private int mCurrentUserID = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["SelectedList"] = null;
        Master.PageHeader = "Search Assessments";
        if (!IsPostBack)
        {
            SearchAssessments();
        }
    }
    protected void SearchAssessments()
    {
        List<Assessment> lst = new List<Assessment>();
        AssessmentList obj = new AssessmentList();

        lst = obj.GetAssessments(txtAssessmentName.Text, ddlAssessGroup.SelectedIndex == 0 ? "" : ddlAssessGroup.SelectedValue, txtEffectiveFrom.Text, txtEffectiveTo.Text, 'A', mCurrentUserID);

        lvAssessments.DataSource = lst;
        lvAssessments.DataBind();
    }
    protected void lnkSearchAssessments_Click(object sender, EventArgs e)
    {
        SearchAssessments();
    }
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessments.aspx");
    }
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
    }
}