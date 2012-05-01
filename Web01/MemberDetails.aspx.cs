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
    BaseCore.CodeManager cm = new CodeManager(1);

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.PageHeader = "Member Details";
        if (!IsPostBack)
        {
            SetPageProperties();
        }


    }
    private void SetPageProperties()
    {
        Dictionary<int,string> addressTypes = new Dictionary<int, string>();
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
        dropDownData = new Dictionary<int,string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.OCCUPATION);
        ddlOccupation.DataSource = dropDownData;
        ddlOccupation.DataValueField = "Key";
        ddlOccupation.DataTextField = "Value";
        ddlOccupation.DataBind();
        //Marital Status
        dropDownData = new Dictionary<int,string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.MARITAL_STATUS);        
        ddlMaritalStatus.DataSource = dropDownData;
        ddlMaritalStatus.DataValueField = "Key";
        ddlMaritalStatus.DataTextField = "Value";
        ddlMaritalStatus.DataBind();
        //Ethnicity
        dropDownData = new Dictionary<int,string>();
        dropDownData = cm.GetSysCodeValues((int)BaseCore.Enumerations.SysCodeTypes.ETHNICITY);        
        ddlEthnicity.DataSource = dropDownData;
        ddlEthnicity.DataValueField = "Key";
        ddlEthnicity.DataTextField = "Value";
        ddlEthnicity.DataBind();
        //Handedness
         dropDownData = new Dictionary<int,string>();
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
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {        
        Member currentMember = new Member(1);
        currentMember.Firstname = tbFirstname.Text;
        currentMember.Middlename = tbMiddleName.Text;
        currentMember.Lastname = tbLastName.Text;
        currentMember.Salutation = Convert.ToInt32(ddlSalutation.SelectedValue);
        currentMember.Sex = Convert.ToInt32(ddlSex.SelectedValue);
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
        currentMember.HomeAddress.State = tbHState.Text;
        currentMember.HomeAddress.Zipcode = tbHZipcode.Text;

        currentMember.WorkAddress.Address1 = tbWorkAddress1.Text;
        currentMember.WorkAddress.Address2 = tbWorkAddress2.Text;
        currentMember.WorkAddress.City = tbWorkCity.Text;
        currentMember.WorkAddress.State = tbWorkState.Text;
        currentMember.WorkAddress.Zipcode = tbWorkZipcode.Text;

        currentMember.Save();
             


    }
}