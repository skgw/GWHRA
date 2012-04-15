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
        }
        if (!Page.IsPostBack)
        {
            if (GroupID > 0)
            {
                GetQuestionGroupDetail();
            }
        }
    }
    protected void lbAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuestionGroups.aspx");
    }
    protected void lbSave_Click(object sender, EventArgs e)
    {
        QuestionGroup obj = new QuestionGroup(1);
        obj.ID = (GroupID > 0) ? GroupID : 0;
        obj.Name = txtName.Text;
        obj.Description = txtDescription.Text;
        obj.Status = rblqGroupStatus.SelectedValue;
        obj.Save();

        LoadQuestionGroupDetail(obj);
    }
    private void LoadQuestionGroupDetail(QuestionGroup obj)
    {
        if (obj != null)
        {
            txtName.Text = Server.HtmlDecode(obj.Name);
            txtDescription.Text = Server.HtmlDecode(obj.Description);
            rblqGroupStatus.SelectedIndex = obj.Status.Trim().Equals("A") ? 0 : 1;
        }
    }
    private void GetQuestionGroupDetail()
    {
        QuestionGroup obj = new QuestionGroup(GroupID, 1);
        LoadQuestionGroupDetail(obj);
    }
}