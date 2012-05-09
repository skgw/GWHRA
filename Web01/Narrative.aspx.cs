using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BaseCore;
using HRACore;
using System.Data;

public partial class Narrative : System.Web.UI.Page
{
    private int MemberMasterID = 0;
    private int AssessmentID = 0;
    BaseCore.CodeManager cm = new CodeManager(1);
    private MemberInfo mInfo;
    private int CurrentUserID = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        MemberMasterID = Int32.Parse(Request.QueryString["ID"]);
        AssessmentID = Int32.Parse(Request.QueryString["AssessmentId"]);
        mInfo = new MemberInfo(MemberMasterID, CurrentUserID);
        Master.PageHeader = "Member Narrative:";
        LoadNarrative();

   }
    private void LoadNarrative()
    {
        divNarrative.InnerHtml = GetNarrative();
    }
    private string GetNarrative()
    {
        MemberInfo mi = new MemberInfo(CurrentUserID);
        DataSet dsNarrative = mi.GetNarrative(MemberMasterID, AssessmentID);
        DataTable dtMemberInfo = new DataTable();
        DataTable dtNarration = new DataTable();
        string Narration = string.Empty;
        if (dsNarrative.Tables.Count > 0)
        {
            dtMemberInfo = dsNarrative.Tables[0];
            dtNarration = dsNarrative.Tables[1];
        }

        if (dtNarration.Rows.Count > 0)
        {
            Narration = dtNarration.Rows[0]["NARRATION"].ToString();
        }
        if (dtMemberInfo.Rows.Count > 0)
        {
            for (int i = 0; i < dtMemberInfo.Columns.Count; i++)
            {
                Narration = Narration.Replace(dtMemberInfo.Columns[i].ColumnName, dtMemberInfo.Rows[0][i].ToString());
            }
        }
        return Narration;
    }
}