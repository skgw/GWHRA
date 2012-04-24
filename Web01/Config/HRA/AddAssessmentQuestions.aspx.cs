using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;
using System.Data;
public partial class Config_HRA_AddAssessmentQuestions : System.Web.UI.Page
{
    List<Question> lstQuestions = new List<Question>();
    List<Question> lstSelectedQuestions = new List<Question>();
    Assessment objAssessment = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["objAssessment"] != null)
        {
            objAssessment = (Assessment)Session["objAssessment"];
            lblName.Text = objAssessment.Name;
            lblGroupName.Text = objAssessment.AssessmentGroupName;
        }
        if (!IsPostBack)
        {
            //populate QuestionGroups
            PopulateGroups();
            AssessmentList lstObj = new AssessmentList();
            lstQuestions = lstObj.GetAssessmentQuestions(objAssessment.ID, 1);
            if (lstQuestions.Count > 0)
            {
                DisplayData(lstQuestions);
                Session["SelectedList"] = lstQuestions;
                lnkPreview.Visible = true;
            }
            else
            {
                lnkPreview.Visible = false;
                Session["SelectedList"] = null;
            }
         }
    }
    protected void PopulateGroups()
    {
        QuestionGroupList obj = new QuestionGroupList();
        ddlQuestionGroup.DataSource = obj.GetQuestionGroups("",'A');
        ddlQuestionGroup.DataTextField = "Name";
        ddlQuestionGroup.DataValueField = "ID";
        ddlQuestionGroup.DataBind();
        ddlQuestionGroup.Items.Insert(0,(new ListItem("-- Select One --","")));
    }
    protected void ddlQuestionGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        //retrieve the Questions under the selected Group and Bind the ListView
        QuestionList obj = new QuestionList();
        lstQuestions = obj.GetQuestionsByGroupId(Convert.ToInt32(ddlQuestionGroup.SelectedValue), 1);
        if (lstQuestions.Count > 0)
        {
            lvQuestions.DataSource = lstQuestions;
            lvQuestions.DataBind();
            ViewState["QList"] = lstQuestions;
            lnkAddQuestions.Visible = true;
        }
        else
        {
            lvQuestions.DataSource = null;
            lvQuestions.DataBind();
            lnkAddQuestions.Visible = false;
        }
    }
    protected void lnkAddQuestions_click(object sender, EventArgs e)
    {
        Boolean alreadyExists = false;
        Session["SelectedList"] = null;
        for (int i = 0; i < lvQuestions.Items.Count; i++)
        {
            CheckBox myCheckbox = (CheckBox)lvQuestions.Items[i].Controls[1];
            if (myCheckbox.Checked == true)
            {
                Label myContent = (Label)lvQuestions.Items[i].Controls[3];
                string xyz = myContent.Text;
                //check for duplicate entry in the Already Selected Questions
                for (int j = 0; j < lvSelectedQ.Items.Count; j++)
                {
                    Label mySelectedContent = (Label)lvSelectedQ.Items[j].Controls[1];
                    if (mySelectedContent.Text.Trim() == xyz.Trim()) {
                        alreadyExists = true; 
                    }
                }
                if (alreadyExists == false)
                {
                    if (ViewState["QList"] != null)
                    {
                        lstQuestions = (List<Question>)ViewState["QList"];
                        lstSelectedQuestions.Add(lstQuestions[i]);
                    }
                }
            }
        }
        if (alreadyExists == false)
        {
            if (lstSelectedQuestions.Count > 0)
            {
                SaveQuestions(lstSelectedQuestions);
                lnkPreview.Visible = true;
            }
            else
            {
                lnkPreview.Visible = true;
            }
        }
     }
    protected void chkSelectAll_OnCheckedChanged(object sender, EventArgs e)
    {
        Boolean chkValue;
        CheckBox source = (CheckBox)sender;
        if (source.Checked)
        {
            chkValue = true;
        }
        else
        {
            chkValue = false;
        }
        for (int i = 0; i < lvQuestions.Items.Count; i++)
        {
            CheckBox myCheckbox = (CheckBox)lvQuestions.Items[i].Controls[1];
            myCheckbox.Checked = chkValue;
        }
    }

    protected void lvSelectedQ_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (String.Equals(e.CommandName, "Remove"))
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            string id = lvSelectedQ.DataKeys[dataItem.DisplayIndex].Value.ToString();
            lstSelectedQuestions = (List<Question>)Session["SelectedList"];

            lstSelectedQuestions.RemoveAt(dataItem.DataItemIndex);
            DisplayData(lstSelectedQuestions);
        }
    }

    protected void lnkPreview_click(object sender, EventArgs e)
    {
        Response.Redirect("AssessmentPreview.aspx?=id" + objAssessment.ID);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessments.aspx?id=" + objAssessment.ID);
    }

    protected void SaveQuestions(List<Question> lst)
    {
        //code to save in database 
        string QuestionIds = "";
        string DisplayOrder = "";
         for (int i = 0; i < lst.Count; i++)
        {
            
            if (QuestionIds == "")
            {
                QuestionIds = lst[i].ID.ToString();
                DisplayOrder = lst[i].DisplayOrder.ToString();
            }
            else
            {
                QuestionIds += "," + lst[i].ID.ToString();
                DisplayOrder += "," + lst[i].DisplayOrder.ToString();
            }
        }
        AssessmentList assList = new AssessmentList();
        List<Question> qLst = assList.SaveQuestions(objAssessment.ID,Convert.ToInt32(lst[0].QGroupId_Ref),QuestionIds,DisplayOrder,1);
        //------------------------------------
        if (qLst.Count > 0)
        {
            DisplayData(qLst);
            Session["SelectedList"] = qLst;
        }
        else
        {
            DisplayData(null);   
        }

    }
    protected void DisplayData(List<Question> lst)
    {
        lvSelectedQ.DataSource = lst;
        lvSelectedQ.DataBind();
        lvQuestions.DataSource = null;
        lvQuestions.DataBind();
        ViewState["QList"] = null;
        lnkAddQuestions.Visible = false;
        Session["SelectedList"] = lst;
    }
}