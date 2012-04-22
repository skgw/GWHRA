using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberDashboard : System.Web.UI.Page
{
    int QSMemberID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Welcome member";
        //if (Request.QueryString["MemberID"].ToString() != string.Empty)
        //{
        //    QSMemberID = Int32.Parse(Request.QueryString["MemberID"].ToString());
        //}
    }
}