using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;
using HRACore;

public partial class Config_HRA_QuestionGroups : System.Web.UI.Page
{
    private int GroupID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Question Group Details";
        if (Request.QueryString["qgroupid"] != null)
        {
            GroupID = Convert.ToInt32(Request.QueryString["qgroupid"]);
            getQuestionGroupDetails();
        }

        if (!Page.IsPostBack)
        {

        }
    }
    protected void lbAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuestionGroups.aspx");
        //Session["id"] = null;
        //txtName.Text = string.Empty;
        //txtDescription.Text = string.Empty;
        //chkIsActive.Checked = false;
    }
    protected void lbSave_Click(object sender, EventArgs e)
    {
        QuestionGroup obj = new QuestionGroup();
        obj.ID = (GroupID > 0) ? GroupID : 0;
        obj.Name = txtName.Text;
        obj.Description = txtDescription.Text;
        obj.Status = rblqGroupStatus.SelectedValue;
        QuestionGroup retObj = obj.Save();

        LoadQuestionGroupDetail(retObj);
    }
    private void LoadQuestionGroupDetail(QuestionGroup obj)
    {
        if (obj != null)
        {
            txtName.Text = obj.Name;
            txtDescription.Text = obj.Description;
            rblqGroupStatus.SelectedIndex = obj.Status.Trim().Equals("A") ? 0 : 1;
        }
    }
    private void getQuestionGroupDetails()
    {
        QuestionGroup obj = new QuestionGroup(GroupID, 1);
        LoadQuestionGroupDetail(obj);
    }
}