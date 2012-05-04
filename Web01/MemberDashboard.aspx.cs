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
    }
}