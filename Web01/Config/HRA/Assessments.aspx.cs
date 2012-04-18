using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;

public partial class Config_HRA_Assessments : System.Web.UI.Page
{
    private int CurrentUserId = 1;
    private int AssessmentId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["AssessmentId"] != null)
        {
            AssessmentId = Convert.ToInt32(Request.QueryString["AssessmentId"]);
        }
    }
    protected void lnkBack_Click(object sender, EventArgs e)
    {
    }
    
    protected void lnkAddQuestions_Click(object sender, EventArgs e)
    {
        Assessment obj = new Assessment(CurrentUserId);
        obj.ID = (AssessmentId > 0) ? AssessmentId : 0;
        obj.Name = txtAssessmentName.Text;
        obj.AssessmentGroupId = Convert.ToInt32(ddlAssessGroup.SelectedValue);
        obj.AssessmentGroupName = ddlAssessGroup.SelectedItem.Text;
        obj.Description = txtDescription.Text;
        if (txtEffectiveFrom.Text != "")
        {
            obj.EffectiveFrom = Convert.ToDateTime(txtEffectiveFrom.Text);
        }
        if (txtEffectiveTo.Text != "")
        {
            obj.EffectiveTo = Convert.ToDateTime(txtEffectiveTo.Text);
        }
        Session["objAssessment"] = obj;
        //save this and go to the next page
        //obj.Save();
        //if (obj.ID > 0)
        //{
        //    Response.Redirect("AddAssessmentQuestions.aspx");
        //}
        Response.Redirect("AddAssessmentQuestions.aspx");
        
    }
}