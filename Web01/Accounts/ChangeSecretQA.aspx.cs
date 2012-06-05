using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Data;
using CustomMembershipProvider;
using BaseCore;


public partial class ChangeSecretQA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BaseCore.CodeManager cm = new CodeManager(1);
            Dictionary<int, string> questions = new Dictionary<int, string>();
            questions = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.SECRET_QUESTIONS);
            ddlQuestion.DataSource = questions;
            ddlQuestion.DataValueField = "Key";
            ddlQuestion.DataTextField = "Value";
            ddlQuestion.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            Master.SetMessage("You are not authorized to change Q&A.", BaseCore.Enumerations.MessageBoxCss.NOTICE);
            return;
        }
        string userName = (string)Session["UserName"];
        ErrorMessage.Text = "";
        DBMembershipProvider obj = new DBMembershipProvider(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

        Boolean res = obj.ChangePasswordQuestionAndAnswer(userName, txtPassword.Text, ddlQuestion.SelectedItem.Text, txtAnswer.Text);
        if (res == false)
        {
            Master.SetMessage("Your secret Q&A could not be changed.", BaseCore.Enumerations.MessageBoxCss.ERROR);
        }
        else
        {
            Master.SetMessage("Your secret Q&A is changed successfully.", BaseCore.Enumerations.MessageBoxCss.SUCCESS);
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
    }

}