using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;
using HRACore;

public partial class MemberDashboard : System.Web.UI.Page
{
    private int MemberMasterID = 0;
    BaseCore.CodeManager cm = new CodeManager(1);
    private MemberInfo mInfo;
    private int CurrentUserID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        MemberMasterID = Int32.Parse(Request.QueryString["ID"]);
        mInfo = new MemberInfo(MemberMasterID, CurrentUserID);
        Master.PageHeader = "Welcome " + mInfo.Firstname + " " + mInfo.Lastname;
        if (!IsPostBack)
        {
            DisplayFamily();
            DisplayAssessmentsForMember();
        }
    }
    protected void DisplayFamily()
    {
        mInfo = new MemberInfo(MemberMasterID, CurrentUserID);
        lvFamilyDetails.DataSource = mInfo.familyMembers;
        lvFamilyDetails.DataBind();

    }
    protected void DisplayAssessmentsForMember()
    {
        AssessmentList alist = new AssessmentList();
        List<Assessment> obj =  alist.GetAssessmentsForMember(mInfo.ID, CurrentUserID);
        lvMemberAssessments.DataSource = obj;
        lvMemberAssessments.DataBind();
    }
    protected void lnkMemberDetails_click(object sender, EventArgs e)
    {
        Response.Redirect("MemberDetails.aspx?ID=" + MemberMasterID.ToString());
    }
    protected void lnkFamilyDetails_click(object sender, EventArgs e)
    {
        Response.Redirect("FamilyDetails.aspx?ID=" + MemberMasterID.ToString() + "&AssessmentId=1000");
    }
}