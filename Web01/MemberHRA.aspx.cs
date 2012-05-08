using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BaseCore;
using HRACore;

public partial class MemberHRA : System.Web.UI.Page
{
    private int MemberMasterID = 0;
    private int AssessmentID = 0;
    BaseCore.CodeManager cm = new CodeManager(1);
    private MemberInfo mInfo;
    private int CurrentUserID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        MemberMasterID = Int32.Parse(Request.QueryString["ID"]);
        AssessmentID = Int32.Parse(Request.QueryString["AssessmentId"]);
        mInfo = new MemberInfo(MemberMasterID, CurrentUserID);
        Master.PageHeader = "Member HRA";
    }

    
    protected void btnSave_click(object sender, EventArgs e)
    {
    }
    protected void btnPrev_click(object sender, EventArgs e)
    {
        Response.Redirect("FamilyHRA.aspx?ID=" + MemberMasterID.ToString());
    }

    [WebMethod]
    public static List<Question> GetQuestionaire(int AssessmentID, int userid)
    {
        List<Question> lstQuestions = new List<Question>();
        Question Obj = new Question(1);
        lstQuestions = Obj.GetAssessmentQuestions(AssessmentID, 1);
        return lstQuestions;
    }
}