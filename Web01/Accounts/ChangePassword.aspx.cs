using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomMembershipProvider;

public partial class Accounts_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
    {
    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            ErrorMessage.Text = "You are not authorized to change Q&A.";
            return;
        }
        string userName = (string)Session["UserName"];
        //ErrorMessage.Text = "";
        DBMembershipProvider obj = new DBMembershipProvider(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        Boolean res = obj.ChangePassword(userName, ChangePassword1.CurrentPassword, ChangePassword1.NewPassword);
        if (res == false)
        {
            ErrorMessage.Text = "Your password could not be changed.";
        }
        else
        {
            ErrorMessage.Text = "Your password is changed successfully.";
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        // Redirect to the previous page
    }
}