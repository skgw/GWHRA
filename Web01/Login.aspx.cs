using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomMembershipProvider;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Welcome";
    }
    protected void siteLogin_LoggedIn(object sender, EventArgs e)
    {
        DBMembershipProvider obj = new DBMembershipProvider(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        bool vSuccess = obj.ValidateUser(this.siteLogin.UserName, this.siteLogin.Password);
        if (vSuccess)
        {
            Session["UserName"] = this.siteLogin.UserName;
            Response.Redirect("Config/HRA/SearchAssessments.aspx");
        }
        else
        {
            Session["UserName"] = null;
            this.siteLogin.FailureText = "Wrong username/password.";
        }
    }
}