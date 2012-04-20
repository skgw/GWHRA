using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;
public partial class Config_HRA_AssessmentPreview : System.Web.UI.Page
{
    Assessment objAssessment = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["objAssessment"] != null)
        {
            objAssessment = (Assessment)Session["objAssessment"];
            lblName.Text = objAssessment.Name;
            lblGroupName.Text = objAssessment.AssessmentGroupName;
            lblEffectiveFrom.Text = objAssessment.EffectiveFrom.ToString();
            lblEffectiveTo.Text = objAssessment.EffectiveTo.ToString();
        }
        if (!IsPostBack)
        {
            populateData();
        }
    }
    protected void populateData()
    {
        if (Session["SelectedList"] != null)
        {
            List<Question> lst1 = (List<Question>)Session["SelectedList"];
            lvSelectedQ.DataSource = lst1;
            lvSelectedQ.DataBind();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessments.aspx?id=" + objAssessment.ID);
    }
}