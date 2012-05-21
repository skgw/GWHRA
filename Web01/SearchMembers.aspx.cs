using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRACore;

public partial class SearchMembers : System.Web.UI.Page
{
    int CurrentUserID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Search Members";
        if (!Page.IsPostBack)
        {
            Search();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        Search();
    }
    private void Search()
    {
        MemberInfoList mil = new MemberInfoList(CurrentUserID);
        List<MemberInfo> m = mil.GetMembers(tbFirstname.Text, tbLastname.Text, ddlSex.SelectedItem.Text, tbMemberID.Text);
        lvMemberDetails.DataSource = m;
        lvMemberDetails.DataBind();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        tbFirstname.Text = string.Empty;
        tbLastname.Text = string.Empty;
        tbMemberID.Text = string.Empty;
        ddlSex.SelectedIndex = 0;
    }
    private void BindDummyData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("MemberMasterID");
        dt.Columns.Add("MemberID");
        dt.Columns.Add("Firstname");
        dt.Columns.Add("Lastname");
        dt.Columns.Add("DOB");
        dt.Columns.Add("Sex");

        DataRow dr;
        for (int i = 0; i < 25; i++)
        {
            dr = dt.NewRow();
            dr["MemberMasterID"] = i;
            dr["MemberID"] = i;
            dr["Firstname"] = "John";
            dr["Lastname"] = "Doe";
            dr["DOB"] = DateTime.Today;
            dr["Sex"] = "M";

            dt.Rows.Add(dr);
        }
        lvMemberDetails.DataSource = dt;
        lvMemberDetails.DataBind();
    }
}