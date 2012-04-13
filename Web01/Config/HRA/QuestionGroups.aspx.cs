using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;
using HRACore;

public partial class Config_HRA_QuestionGroups : System.Web.UI.Page
{
    private int QGroupId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
           if (Request.QueryString["qgroupid"] != null)
           {
               QGroupId = Convert.ToInt16(Request.QueryString["qgroupid"]);
               Session["qgroupid"] = QGroupId;
               getQuestionGroupDetails();
           }
           else
           {
               Session["qgroupid"] = null;
           }
       }
    }
    
    protected void lbSave_Click(object sender, EventArgs e)
    {
        QuestionGroup obj = new QuestionGroup();
        if (Session["qgroupid"] == null)
        {
            obj.ID = 0;
        }
        else
        {
            obj.ID = (int)Session["qgroupid"];
        }
        obj.Name = txtName.Text;
        obj.Description = txtDescription.Text;
        obj.Status = chkIsActive.Checked ? "A" : "I";
        QuestionGroup retObj = obj.Save();
        if (retObj != null) {
            txtName.Text = retObj.Name;
            txtDescription.Text = retObj.Description;
            chkIsActive.Checked = retObj.Status == "ACTIVE" ? true : false;
            Session["qgroupid"] = retObj.ID;
        }
    }
    private void getQuestionGroupDetails()
    {
        QuestionGroup obj = QuestionGroupList.GetQuestionGroup_By_ID(QGroupId);
        if (obj != null)
        {
            txtName.Text = obj.Name;
            txtDescription.Text = obj.Description;
            chkIsActive.Checked = obj.Status == "ACTIVE" ? true : false;
        }
    }
}