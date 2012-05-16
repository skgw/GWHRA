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
        Master.PageHeader = "Family Conditions History";
        if (!IsPostBack)
        {
            MemberMasterID = Int32.Parse(Request.QueryString["ID"]);
            mInfo = new MemberInfo(MemberMasterID, CurrentUserID);
        }
    }
    protected void btnNext_click(object sender, EventArgs e)
    {
        // Load into dictionary object
        //AssessmentResponse FamilyResponses
        //Format for dictionary - use Question ID as the Key and for every member ID that has responded append the ID. 
        //Ex For question ID 100 Set the Dict Key as 100 and value as 1020,1022,1023. Assuming 1020,1021,1022,1023 are family members and 1021 did not respond yes to question 100.
        //Call SaveFamilyResponses method

        Response.Redirect("MemberHRA.aspx?ID=" + MemberMasterID.ToString() + "&AssessmentId=1000");
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
    public static List<Tuple<int, int>> GetFamilyHRAResponseList(int MemberMasterID, int AssessmentId)
    {
        List<Tuple<int, int>> lst = new List<Tuple<int, int>>();
        MemberInfoList obj = new MemberInfoList(1);
        lst = obj.GetFamilyHRAResponse(MemberMasterID, AssessmentId, 1);
        return lst;
    }

    [WebMethod]
    public static void InsertFamilyHRA(int MemberMasterID, int AssessmentId, int FamilyQuestionId)
    {
        MemberInfoList obj = new MemberInfoList(1);
        obj.INSERTFAMILYHRA(MemberMasterID, AssessmentId, FamilyQuestionId, 1);
    }
}

