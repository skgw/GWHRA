using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using System.Web.Security;
using CustomMembershipProvider;

public partial class UserCreate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        DBMembershipProvider obj = new DBMembershipProvider(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        MembershipCreateStatus mMStatus;
        MembershipUser mNewMemberStatus = obj.CreateUser(
            txtUserName.Text, txtPassword.Text, txtEmail.Text, ddlQuestion.SelectedItem.Text, txtAnswer.Text, true, null, out mMStatus, txtFirstName.Text.Trim(), txtLastName.Text.Trim());
        if (mNewMemberStatus == null)
        {
            ErrorMessage.Text = "User could not be created due to " + mMStatus.ToString();
        }
        else
        {
            ErrorMessage.Text = "New User created successfully.";
            //save the UserDetails in the database as per Application requirement.
            //obj.CreateUser(
            //txtUserName.Text, txtPassword.Text, txtEmail.Text, ddlQuestion.SelectedItem.Text, txtAnswer.Text, true
            //, out mMStatus, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
    }
  
}