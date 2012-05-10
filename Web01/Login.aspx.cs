using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomMembershipProvider;
using BaseCore;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Welcome";
        if (!IsPostBack)
        {
            Session.Abandon();
            Session.Clear();
        }
    }
    protected void siteLogin_LoggedIn(object sender, EventArgs e)
    {

        DBMembershipProvider obj = new DBMembershipProvider(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);        
        if (obj.ValidateUser(this.siteLogin.UserName, this.siteLogin.Password))
        {
            Session["UserName"] = this.siteLogin.UserName;
            UserInfo loggedInUser = new UserInfo();
            loggedInUser.GetUserInfo(this.siteLogin.UserName, 1);
            Session["LoggedInUserInfo"] = loggedInUser;
             Response.Redirect(loggedInUser.Homepage);
        }
        else
        {
            Session["UserName"] = null;
            this.siteLogin.FailureText = "Wrong username/password.";
        }
    }

}
