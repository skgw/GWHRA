using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;
using HRACore;

public partial class FamilyDetails : System.Web.UI.Page
{
    BaseCore.CodeManager cm = new CodeManager(1);
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Family Information";
        if (!IsPostBack)
        {
            SetPageProperties();
            HideDeadControls();
        }
    }
    private void SetPageProperties()
    {
        Dictionary<int, string> relationships = new Dictionary<int, string>();
        relationships = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.RELATIONSHIPS);

        ddlRelationship.DataSource = relationships;
        ddlRelationship.DataValueField = "Key";
        ddlRelationship.DataTextField = "Value";
        ddlRelationship.DataBind();

        ddlSex.DataSource = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.SEX);
        ddlSex.DataValueField = "Key";
        ddlSex.DataTextField = "Value";
        ddlSex.DataBind();

        ddlCauseOfDeath.DataSource = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.CAUSE_OF_DEATH);
        ddlCauseOfDeath.DataValueField = "Key";
        ddlCauseOfDeath.DataTextField = "Value";
        ddlCauseOfDeath.DataBind();

        ddlLivingStatus.DataSource = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.LIVING_STATE);
        ddlLivingStatus.DataValueField = "Key";
        ddlLivingStatus.DataTextField = "Value";
        ddlLivingStatus.DataBind();
    }
    protected void ddlCurrentStatus_IndexChanged(object sender, EventArgs e)
    {
        if (ddlCurrentStatus.SelectedValue == "A")
        {
            HideDeadControls();
        }
        else if (ddlCurrentStatus.SelectedValue == "D")
        {
            HideAliveControls();
        }
    }
    protected void HideDeadControls()
    {
        dtCauseOfDeath.Visible = false;
        dtDateOfDeath.Visible = false;
        ddCauseOfDeath.Visible = false;
        ddDateOfDeath.Visible = false;
        dtLivingStatus.Visible = true;
        ddLivingStatus.Visible = true;
    }
    protected void HideAliveControls()
    {
        dtCauseOfDeath.Visible = true;
        dtDateOfDeath.Visible = true;
        ddCauseOfDeath.Visible = true;
        ddDateOfDeath.Visible = true;
        dtLivingStatus.Visible = false;
        ddLivingStatus.Visible = false;
    }
    protected void btnAdd_click(object sender, EventArgs e)
    {
        cvDOB.Visible = false;
        if (txtDOB.Text == string.Empty)
        {
            cvDOB.ErrorMessage = "DOB is required.";
            cvDOB.IsValid = false;
            cvDOB.Visible = true;
            return;
        }
        Member obj = new Member(1);
         
        obj.ID = 0;
        obj.Salutation = 0;
        obj.Firstname= tbFirstName.Text;
        obj.Middlename= "B";
        obj.Lastname= tbLastname.Text;
        obj.Sex= Convert.ToInt32(ddlSex.SelectedValue);
        obj.MemberID= "788654329";
        obj.HICN= "A492853954";
        obj.DOB= Convert.ToDateTime(txtDOB.Text);
        obj.Email= "";
        obj.Ethnicity= 0;
        obj.MaritalStatus= 0;
        obj.Handedness= 0;
        obj.Occupation= 0;
        obj.Height_Feet= 0;
        obj.Height_Inches= 0;
        obj.Weight= 0;
        Address addObj = new Address(1);
        addObj.Address1 = "295 turnpike road";
        obj.WorkAddress = addObj;
        obj.WorkAddress.Address1 = addObj.Address1;
        obj.WorkAddress.Address2= "";
        obj.WorkAddress.City= "";
        obj.WorkAddress.State= "";
        obj.WorkAddress.Zipcode= "";

        obj.HomeAddress = addObj;
        obj.HomeAddress.Address1 = addObj.Address1;
        obj.HomeAddress.Address2= "";
        obj.HomeAddress.City="";
        obj.HomeAddress.State="";
        obj.HomeAddress.Zipcode = "";

        obj.Save();
        

    }
}