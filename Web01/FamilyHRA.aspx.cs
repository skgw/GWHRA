using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.Services;
using BaseCore;
using HRACore;

public partial class FamilyHRA : System.Web.UI.Page
{
    private int MemberMasterID = 0;
    BaseCore.CodeManager cm = new CodeManager(1);
    private MemberInfo mInfo;
    private int CurrentUserID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        MemberMasterID = Int32.Parse(Request.QueryString["ID"]);
        if (!IsPostBack)
        {
            MemberMasterID = Int32.Parse(Request.QueryString["ID"]);
            mInfo = new MemberInfo(MemberMasterID, CurrentUserID);
        }
    }
    protected void btnNext_click(object sender, EventArgs e)
    {
        Response.Redirect("MemberHRA.aspx?ID=" + MemberMasterID.ToString());
    }
    [WebMethod]
    public static List<Tuple<int, string>> GetFamilyQuestionList(int userid)
    {
        List<Tuple<int, string>> lst = new List<Tuple<int, string>>();
        QuestionList obj = new QuestionList();
        lst = obj.GetFamilyQuestions(userid);
        return lst;
    }

    [WebMethod]
    public static List<FamilyMember> GetFamilyMembers(int MemberMasterID)
    {
        MemberInfo mInfo;
        mInfo = new MemberInfo(MemberMasterID, 1);
        List<FamilyMember> siblings = mInfo.familyMembers;
        return siblings;
    }

    [WebMethod]
    public static List<Tuple<int, int>> GetFamilyHRAResponseList(int MemberMasterID)
    {
        List<Tuple<int, int>> lst = new List<Tuple<int, int>>();
        MemberInfoList obj = new MemberInfoList(1);
        lst = obj.GetFamilyHRAResponse(MemberMasterID, 1);
        return lst;
    }

    [WebMethod]
    public static void InsertFamilyHRA(int MemberMasterID, int FamilyQuestionId)
    {
        MemberInfoList obj = new MemberInfoList(1);
        obj.INSERTFAMILYHRA(MemberMasterID, FamilyQuestionId, 1);
    }
}

