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
    private int GroupID = -1;
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
                AssessmentGroup obj = new AssessmentGroup(GroupID, mCurrentUserID);
                LoadAssessmentGroup(obj);
            }
        }
    }

    private void LoadAssessmentGroup(AssessmentGroup obj)
    {
        
        txtName.Text = obj.Name;
        txtDescription.Text = obj.Description;
        rblAGroupStatus.SelectedValue = obj.Status;
    }

    protected void lbAddNew_Click(object sender, EventArgs e)
    {
        //txtName.Text = "";
        //txtDescription.Text = "";
        //rblAGroupStatus.ClearSelection();
        //ViewState["GroupId"] = null;
        Response.Redirect("AssessmentGroups.aspx");
    }

    protected void lbSave_Click(object sender, EventArgs e)
    {
        AssessmentGroup obj = new AssessmentGroup(mCurrentUserID);
        if (ViewState["GroupId"] != null)
        {
            obj.ID = (int)ViewState["GroupId"];
        }
        else
        {
            obj.ID = (GroupID > 0) ? GroupID : -1;
        }
        obj.Name = txtName.Text;
        obj.Description = txtDescription.Text;
        obj.Status = rblAGroupStatus.SelectedValue;
        obj.Save();
        LoadAssessmentGroup(obj);
        ViewState["GroupId"] = obj.ID;
    }
}