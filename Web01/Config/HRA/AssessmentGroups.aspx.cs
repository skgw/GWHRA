using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;
public partial class Config_HRA_AssessmentGroups : System.Web.UI.Page
{
    private int mCurrentUserID = 1;
    private int GroupID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Assessment Group";
        if (Request.QueryString["AGroupid"] != null)
        {
            GroupID = Convert.ToInt32(Request.QueryString["AGroupid"]);
        }
        if (!Page.IsPostBack)
        {
            if (GroupID > 0)
            {
                LoadAssessmentGroup(GroupID);
            }
        }
    }

    private void LoadAssessmentGroup(int currentGroupID)
    {
        AssessmentGroup agrp = new AssessmentGroup(currentGroupID, mCurrentUserID);
        txtName.Text = agrp.Name;
        txtDescription.Text = agrp.Description;
        rblAGroupStatus.SelectedValue = agrp.Status;
    }

}