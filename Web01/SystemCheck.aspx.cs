using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;

public partial class SystemCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            PerformSystemCheck();
        }
    }
    private void PerformSystemCheck()
    {
        BaseCore.DBHelper o = new DBHelper();
        o.Dispose();
        
    }
}