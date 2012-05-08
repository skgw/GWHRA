using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;
using HRACore;

public partial class MemberDetails : System.Web.UI.Page
{
    private int MemberMasterID = 0;
    BaseCore.CodeManager cm = new CodeManager(1);
    private MemberInfo mInfo;
    private int CurrentUserID = 0;

   protected void Page_Load(object sender, EventArgs e)
    {
        MemberMasterID = Int32.Parse(Request.QueryString["ID"]);
        mInfo = new MemberInfo(MemberMasterID, CurrentUserID);
        Master.PageHeader = "Member Details for " + mInfo.Firstname + " " + mInfo.Lastname;        
        if (!IsPostBack)
        {
            SetPageProperties();         
            LoadMemberDetails();
        }
    }
    private void LoadMemberDetails()
    {
        Member m = new Member(MemberMasterID, CurrentUserID);
        //Bind data 
        tbFirstname.Text = m.Firstname;
        tbMiddleName.Text = m.Middlename;
        tbLastName.Text = m.Lastname;
        ddlSalutation.SelectedValue = m.Salutation.ToString();
        ddlSex.SelectedValue = m.Sex.ToString();
        tbMemberID.Text = m.MemberID;
        tbHICN.Text = m.HICN;
        tbDOB.Text = m.DOB.ToShortDateString();
        tbEmail.Text = m.Email;
        ddlEthnicity.SelectedValue = m.Ethnicity.ToString();
        ddlMaritalStatus.SelectedValue = m.MaritalStatus.ToString();
        ddlHandedness.SelectedValue = m.Handedness.ToString();
        ddlOccupation.SelectedValue = m.Occupation.ToString();
        tbHeightFeet.Text = m.Height_Feet.ToString();
        tbHeightInches.Text = m.Height_Inches.ToString();
        tbWeight.Text = m.Weight.ToString();
        tbHAddress1.Text = m.HomeAddress.Address1;
        tbHAddress2.Text = m.HomeAddress.Address2;
        tbHCity.Text = m.HomeAddress.City;
        ddlHomeState.SelectedValue = m.HomeAddress.State.ToString();
        tbHZipcode.Text = m.HomeAddress.Zipcode;

        tbWorkAddress1.Text = m.WorkAddress.Address1;
        tbWorkAddress2.Text = m.WorkAddress.Address2;
        tbWorkCity.Text = m.WorkAddress.City;
        ddlWorkState.SelectedValue = m.WorkAddress.State.ToString();
        tbWorkZipcode.Text = m.WorkAddress.Zipcode;
    }
    private void SetPageProperties()
    {
        Dictionary<int, string> addressTypes = new Dictionary<int, string>();
        addressTypes = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.ADDRESS_TYPES);

        ddlAddressType.DataSource = addressTypes;
        ddlAddressType.DataValueField = "Key";
        ddlAddressType.DataTextField = "Value";
        ddlAddressType.DataBind();

        ddlAddressType.SelectedIndex = 0;
        ddlAddressType.Enabled = false;

        ddlWorkAddressType.DataSource = addressTypes;
        ddlWorkAddressType.DataValueField = "Key";
        ddlWorkAddressType.DataTextField = "Value";
        ddlWorkAddressType.DataBind();

        ddlWorkAddressType.SelectedIndex = 1;
        ddlWorkAddressType.Enabled = false;

        Dictionary<int, string> dropDownData = new Dictionary<int, string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.SALUTATION);

        ddlSalutation.DataSource = dropDownData;
        ddlSalutation.DataValueField = "Key";
        ddlSalutation.DataTextField = "Value";
        ddlSalutation.DataBind();
        //Occupation
        dropDownData = new Dictionary<int, string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.OCCUPATION);
        ddlOccupation.DataSource = dropDownData;
        ddlOccupation.DataValueField = "Key";
        ddlOccupation.DataTextField = "Value";
        ddlOccupation.DataBind();
        //Marital Status
        dropDownData = new Dictionary<int, string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.MARITAL_STATUS);
        ddlMaritalStatus.DataSource = dropDownData;
        ddlMaritalStatus.DataValueField = "Key";
        ddlMaritalStatus.DataTextField = "Value";
        ddlMaritalStatus.DataBind();
        //Ethnicity
        dropDownData = new Dictionary<int, string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.ETHNICITY);
        ddlEthnicity.DataSource = dropDownData;
        ddlEthnicity.DataValueField = "Key";
        ddlEthnicity.DataTextField = "Value";
        ddlEthnicity.DataBind();
        //Handedness
        dropDownData = new Dictionary<int, string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.HANDEDNESS);
        ddlHandedness.DataSource = dropDownData;
        ddlHandedness.DataValueField = "Key";
        ddlHandedness.DataTextField = "Value";
        ddlHandedness.DataBind();
        //Sex
        dropDownData = new Dictionary<int, string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.SEX);
        ddlSex.DataSource = dropDownData;
        ddlSex.DataValueField = "Key";
        ddlSex.DataTextField = "Value";
        ddlSex.DataBind();

        dropDownData = new Dictionary<int, string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.US_STATES);
        ddlHomeState.DataSource = dropDownData;
        ddlHomeState.DataValueField = "Key";
        ddlHomeState.DataTextField = "Value";
        ddlHomeState.DataBind();

        ddlWorkState.DataSource = dropDownData;
        ddlWorkState.DataValueField = "Key";
        ddlWorkState.DataTextField = "Value";
        ddlWorkState.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Member currentMember = new Member(1);
        currentMember.Firstname = tbFirstname.Text;
        currentMember.Middlename = tbMiddleName.Text;
        currentMember.Lastname = tbLastName.Text;
        currentMember.Salutation = Convert.ToInt32(ddlSalutation.SelectedValue);
        currentMember.Sex = ddlSex.SelectedValue;
        currentMember.MemberID = tbMemberID.Text;
        currentMember.HICN = tbHICN.Text;
        currentMember.DOB = Convert.ToDateTime(tbDOB.Text);
        currentMember.Email = tbEmail.Text;
        currentMember.Ethnicity = Convert.ToInt32(ddlEthnicity.SelectedValue);
        currentMember.MaritalStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
        currentMember.Handedness = Convert.ToInt32(ddlHandedness.SelectedValue);
        currentMember.Occupation = Convert.ToInt32(ddlOccupation.SelectedValue);
        currentMember.Height_Feet = Convert.ToInt32(tbHeightFeet.Text);
        currentMember.Height_Inches = Convert.ToInt32(tbHeightInches.Text);
        currentMember.Weight = Convert.ToInt32(tbWeight.Text);
        currentMember.HomeAddress.Address1 = tbHAddress1.Text;
        currentMember.HomeAddress.Address2 = tbHAddress2.Text;
        currentMember.HomeAddress.City = tbHCity.Text;
        currentMember.HomeAddress.State = Convert.ToInt32(ddlHomeState.SelectedValue);
        currentMember.HomeAddress.Zipcode = tbHZipcode.Text;

        currentMember.WorkAddress.Address1 = tbWorkAddress1.Text;
        currentMember.WorkAddress.Address2 = tbWorkAddress2.Text;
        currentMember.WorkAddress.City = tbWorkCity.Text;
        currentMember.WorkAddress.State = Convert.ToInt32(ddlWorkState.SelectedValue);
        currentMember.WorkAddress.Zipcode = tbWorkZipcode.Text;

        currentMember.Save();
        Response.Redirect("FamilyDetails.aspx?ID=" + currentMember.ID);


    }
}