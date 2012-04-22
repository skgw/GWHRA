using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;

public partial class MemberDetails : System.Web.UI.Page
{
    BaseCore.CodeManager cm = new CodeManager(1);

    protected void Page_Load(object sender, EventArgs e)
    {
    if(!IsPostBack)
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
    }
}