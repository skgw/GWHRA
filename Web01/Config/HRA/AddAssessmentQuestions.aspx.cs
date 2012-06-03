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
            lblEffectiveFrom.Text = objAssessment.EffectiveFrom.ToString("MM/dd/yyyy");
            lblEffectiveTo.Text = objAssessment.EffectiveTo.ToString("MM/dd/yyyy");
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
        ddlQuestionGroup.DataSource = obj.GetQuestionGroups("",'A',Master.CurrentUser.UserID);
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
                string QContent = myContent.Text;
                //check for duplicate entry in the Already Selected Questions
                for (int j = 0; j < lvSelectedQ.Items.Count; j++)
                {
                    Label mySelectedContent = (Label)lvSelectedQ.Items[j].Controls[1];
                    if (mySelectedContent.Text.Trim() == QContent.Trim())
                    {
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
            AssessmentList obj = new AssessmentList();
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            string Qid = lvSelectedQ.DataKeys[dataItem.DisplayIndex]["ID"].ToString();
            string QGid = lvSelectedQ.DataKeys[dataItem.DisplayIndex]["QGroupId_Ref"].ToString();
            lstSelectedQuestions = obj.DeleteQuestions(objAssessment.ID, Convert.ToInt32(QGid), Convert.ToInt32(Qid), 1);
            //Bind returned data
            DisplayData(lstSelectedQuestions);
        }
    }

    protected void lnkPreview_click(object sender, EventArgs e)
    {
        string retMsg = ValidateDisplayOrder();
        if (retMsg.Length == 0)
        {
            //Update and go to next page
            if (Session["SelectedList"] != null)
            {
                List<Question> QList = new List<Question>();
                QList = (List<Question>)Session["SelectedList"];
                UpdateQuestions(QList);
            }
            Response.Redirect("AssessmentPreview.aspx?=ID" + objAssessment.ID);
        }
        else
        {
            //display validation msg
            lvQuestions.DataSource = null;
            lvQuestions.DataBind();
            lblMsg.Text = retMsg;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessments.aspx?ID=" + objAssessment.ID);
    }

    protected void SaveQuestions(List<Question> lst)
    {
        //code to save in database 
        //create the display order depending on the no of questions already added for this Assessment.
        //if not start from 1
        int QCount = 1;
        if (lvSelectedQ.Items.Count > 0)
        {
            QCount = lvSelectedQ.Items.Count + 1;
        }
        string QuestionIds = "";
        string DisplayOrder = "";
         for (int i = 0; i < lst.Count; i++)
        {
            
            if (QuestionIds == "")
            {
                QuestionIds = lst[i].ID.ToString();
                DisplayOrder = QCount.ToString();
            }
            else
            {
                QuestionIds += "," + lst[i].ID.ToString();
                DisplayOrder += "," + QCount.ToString();
            }
            QCount += 1;
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

    protected void UpdateQuestions(List<Question> lst)
    {
        //code to save in database 
        //create the display order depending on the no of questions already added for this Assessment.
        //if not start from 1
        //int QCount = 1;
        //if (lvSelectedQ.Items.Count > 0)
        //{
        //    QCount = lvSelectedQ.Items.Count + 1;
        //}
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
        List<Question> qLst = assList.SaveQuestions(objAssessment.ID, Convert.ToInt32(lst[0].QGroupId_Ref), QuestionIds, DisplayOrder, 1);
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
        ddlQuestionGroup.SelectedIndex = 0;
        ViewState["QList"] = null;
        lnkAddQuestions.Visible = false;
        Session["SelectedList"] = lst;
    }

    protected string ValidateDisplayOrder()
    {
        int minQCount = 1;
        int maxQCount = lvSelectedQ.Items.Count;
        string msg = "";
        int RepeatCount = 0;
        List<Question> QList = new  List<Question>();
        if (Session["SelectedList"] != null)
        {
            QList = (List<Question>) Session["SelectedList"];
        }
        //check min & max limit
        for (int j = 0; j < lvSelectedQ.Items.Count; j++)
        {
            TextBox mySelectedContent = (TextBox)lvSelectedQ.Items[j].Controls[3];
            if (Convert.ToInt32(mySelectedContent.Text) < minQCount || Convert.ToInt32(mySelectedContent.Text) > maxQCount)
            {
                msg = "Display Order must be within " + minQCount + " and " + maxQCount;
                QList.Clear();
                return msg;
            }
            QList[j].DisplayOrder = Convert.ToInt32(mySelectedContent.Text);
        }

        for (int i = minQCount; i < maxQCount + 1; i++)
        {
            
            for (int j = 0; j < lvSelectedQ.Items.Count; j++)
            {
                TextBox mySelectedContent = (TextBox)lvSelectedQ.Items[j].Controls[3];
                if (Convert.ToInt32(mySelectedContent.Text) == i)
                {
                    RepeatCount += 1;
                }
                if (RepeatCount > 1)
                {
                    msg = i + " is repeated";
                    QList.Clear();
                    return msg;
                }
            }
            RepeatCount = 0;
        }
        Session["SelectedList"] = QList;
        return msg;
    }
}