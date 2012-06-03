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
using BaseCore;

public partial class UserCreate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDowns();
        }
    }
    protected void LoadDropDowns()
    {
        BaseCore.CodeManager cm = new CodeManager(1);
        Dictionary<int, string> questions = new Dictionary<int, string>();
        questions = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.SECRET_QUESTIONS);
        ddlQuestion.DataSource = questions;
        ddlQuestion.DataValueField = "Key";
        ddlQuestion.DataTextField = "Value";
        ddlQuestion.DataBind();
        ddlQuestion.Items.Insert(0, new ListItem("-- Select One --", ""));

        BaseCore.RoleList obj = new BaseCore.RoleList();
        ddlRole.DataSource = obj.GetRoles(-1, 1);
        ddlRole.DataTextField = "Name";
        ddlRole.DataValueField = "ID";
        ddlRole.DataBind();
        ddlRole.Items.Insert(0, new ListItem("-- Select One --", ""));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlQuestion.SelectedValue == "")
        {
            cvSecretQuestion.ErrorMessage = "You must select a secret question.";
            cvSecretQuestion.IsValid = false;
            cvSecretQuestion.Visible = true;
            return;
        }
        if (ddlRole.SelectedValue == "")
        {
            cvRole.ErrorMessage = "You must select a role.";
            cvRole.IsValid = false;
            cvRole.Visible = true;
            return;
        }

        DBMembershipProvider obj = new DBMembershipProvider(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        MembershipCreateStatus mMStatus;
        MembershipUser mNewMemberStatus = obj.CreateUser(
            txtUserName.Text, txtPassword.Text, txtEmail.Text, ddlQuestion.SelectedItem.Text, txtAnswer.Text, true, null, out mMStatus, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), Convert.ToInt32(ddlRole.SelectedValue));
        if (mNewMemberStatus == null)
        {
            Master.SetMessage("User could not be created due to " + mMStatus.ToString(), BaseCore.Enumerations.MessageBoxCss.ERROR);
        }
        else
        {
            Master.SetMessage("New User created successfully.", BaseCore.Enumerations.MessageBoxCss.SUCCESS);
        }
        
      }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtUserName.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtConfirmPassword.Text = string.Empty;
        txtEmail.Text = string.Empty;
        ddlQuestion.SelectedIndex = 0;
        txtAnswer.Text = string.Empty;
        ddlRole.SelectedIndex = 0;
        txtFirstName.Text = string.Empty;
        txtMiddleName.Text = string.Empty;
        txtLastName.Text = string.Empty;

    }
  
}