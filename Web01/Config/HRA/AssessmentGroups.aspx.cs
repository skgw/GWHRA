using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Config_HRA_AssessmentGroups : System.Web.UI.Page
{
    private int mCurrentUserID = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Assessment Group";
    }

    private void LoadAssessmentGroup()
    {
    }

}