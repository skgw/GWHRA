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
        if (Request.QueryString["id"] != null)
        {
            AssessmentId = Convert.ToInt32(Request.QueryString["id"]);
        }
        if (!IsPostBack)
        {
            //List<QuestionGroup> lst = new List<QuestionGroup>();
            //QuestionGroupList obj = new QuestionGroupList();
            //lst = obj.GetQuestionGroups("", 'A');
            //ddlAssessGroup.DataSource = lst;
            //ddlAssessGroup.DataTextField = "Name";
            //ddlAssessGroup.DataValueField = "ID";
            //ddlAssessGroup.DataBind();
            //ddlAssessGroup.Items.Insert(0, new ListItem("-- Select One --", ""));


            if (AssessmentId > 0)
            {
                //Populate the data for the QuestionId
                AssessmentList obj1 = new AssessmentList();
                Assessment aObj = obj1.GetAssessmentsById(CurrentUserId, AssessmentId);
                if (obj1 != null)
                {
                    PopulateData(aObj);
                }
            }
        }

    }
    protected void PopulateData(Assessment obj)
    {
        txtAssessmentName.Text = obj.Name;
        txtDescription.Text = obj.Description;
        txtEffectiveFrom.Text = obj.EffectiveFrom.ToString("MM/dd/yyyy");
        txtEffectiveTo.Text = obj.EffectiveTo.ToString("MM/dd/yyyy");
        ddlAssessGroup.SelectedValue = obj.AssessmentGroupId.ToString();
        chkStatus.Checked = obj.Status.ToString().Equals("A") ? true : false;
        tbNarrativeHeader.Text = obj.NarrativeHeader;
        tbNarrativeFooter.Text = obj.NarrativeFooter;
    }
    protected void lnkBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchAssessments.aspx");
    }
    
    protected void lnkAddQuestions_Click(object sender, EventArgs e)
    {
        string retMsg = ValidateData();
        if (retMsg.Length > 0)
        {
            //need to display this msg in the page 
            return;
        }
        
        Assessment obj = new Assessment(CurrentUserId);
        obj.ID = (AssessmentId > 0) ? AssessmentId : 0;
        obj.Name = txtAssessmentName.Text;
        obj.AssessmentGroupId = Convert.ToInt32(ddlAssessGroup.SelectedValue);
        //obj.AssessmentGroupName = ddlAssessGroup.SelectedItem.Text;
        obj.Description = txtDescription.Text;
        if (txtEffectiveFrom.Text != "")
        {
            obj.EffectiveFrom = Convert.ToDateTime(txtEffectiveFrom.Text);
        }
        if (txtEffectiveTo.Text != "")
        {
            obj.EffectiveTo = Convert.ToDateTime(txtEffectiveTo.Text);
        }
        obj.Status = chkStatus.Checked == true ? 'A' : 'I';
        Session["objAssessment"] = obj;
        //save this and go to the next page
        obj.Save();
        if (obj.ID > 0)
        {
            Response.Redirect("AddAssessmentQuestions.aspx?id=" + obj.ID);
        }
        //Response.Redirect("AddAssessmentQuestions.aspx");
     }

    protected string ValidateData()
    {
        string msg = string.Empty;
        if (txtAssessmentName.Text == "")
        {
            msg = "You must have the Assessment Name.";
            return msg;
        }
        if (ddlAssessGroup.SelectedIndex == 0) {
            msg = "You must have the Assessment Group Name.";
            return msg;
        }
        if (txtEffectiveFrom.Text.Trim() != "" && txtEffectiveFrom.Text.Trim() != "")
        {
            if (Convert.ToDateTime(txtEffectiveFrom.Text.Trim()) > Convert.ToDateTime(txtEffectiveTo.Text.Trim()))
            {
                msg = "From date can not be before To date.";
                return msg;
            }
            //DateTime value;
            //if (!DateTime.TryParse(txtEffectiveFrom.Text, out value))
            //{
            //    txtEffectiveFrom.Text = DateTime.Today.ToShortDateString();
            //} 

        }
        return msg;
    }
}