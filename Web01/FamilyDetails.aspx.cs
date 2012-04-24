using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;

public partial class FamilyDetails : System.Web.UI.Page
{
    BaseCore.CodeManager cm = new CodeManager(1);
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Family Information";
        if (!IsPostBack)
        {
            SetPageProperties();
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

    }
}