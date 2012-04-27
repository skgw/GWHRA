using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseCore;
using System.Text;

public partial class BasePages_Base : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MenuManager menuObj = new MenuManager();
            //string MenuXML = GetMenuXml(menuObj.GetMenuForRole(1, 1));
            //lblMenu.Text = MenuXML;
            string xmlMenu = "<ul id='nav' class='nav'><li class='dropdown'><a class='dropdown-toggle' href='#'>Home</a></li><li class='dropdown'><a class='dropdown-toggle' ";
            xmlMenu += "href='#'>Setup</a><div class='span-15'> <ul class='dropdown-menu'><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Suspect Identification Config</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Rules Setup</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Search Rules</a></li></ul></div></li><li class='dropdown'><a class='dropdown-toggle' ";
            xmlMenu += "href='#'>Reporting</a><div class='span-15'> <ul class='dropdown-menu'><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Consolidated MMR Statistics</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Plan HCC Statistics</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>RAPS Statistics</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Risk Adjustment Factor Trend</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Monthly Payment Report</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Cash Flow Summary</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Productivity - Provider level</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Productivity - MRR level</a></li></ul></div></li><li class='dropdown'><a class='dropdown-toggle' ";
            xmlMenu += "href='#'>Admin</a><div class='span-15'> <ul class='dropdown-menu'><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Error logs</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Request logs</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Module manager</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Operations Manager</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Create user</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Query</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>System diagnostics</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Search Users</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Master menu config</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Map roles to menu</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Dashboard Layout</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Widget Setup</a></li></ul></div></li><li class='dropdown'><a class='dropdown-toggle' ";
            xmlMenu += "href='#'>Config</a><div class='span-15'> <ul class='dropdown-menu'><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Application Setup</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Client Setup</a></li></ul></div></li><li class='dropdown'><a class='dropdown-toggle' ";
            xmlMenu += "href='#'>RAPS</a><div class='span-15'> <ul class='dropdown-menu'><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Main Statistics</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>RAPS Transactions</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Rejected Error Transactions</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>CMS RAPS Reports</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Financial Impact</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>CMS Guidelines</a></li></ul></div></li><li class='dropdown'><a class='dropdown-toggle' ";
            xmlMenu += "href='#'>D4C</a><div class='span-15'> <ul class='dropdown-menu'><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Providers list</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Potential Members List</a></li></ul></div></li><li class='dropdown'><a class='dropdown-toggle' ";
            xmlMenu += "href='#'>Settings</a><div class='span-15'> <ul class='dropdown-menu'><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Change secret Q & A</a></li><li style='line-height:2em;'><a class='dropdown-toggle' ";
            xmlMenu += "href='SearchAssessments.aspx'>Change password</a></li></ul></div></li></ul>";

            //string xmlMenu = "<ul id='nav' class='nav' style='list-style-type:none;'>";
            //xmlMenu += "<li class='dropdown'><a href='#'>Home</a></li>";
            //xmlMenu += "<li class='dropdown'><a class='dropdown-toggle' href='#'>Setup</a>";
            ////xmlMenu += "<div class='span-15'> ";
            //xmlMenu += "<ul class='dropdown-menu' style='list-style-type:none;'><li style='line-height:2em;'>";
            //xmlMenu += "<a class='dropdown-toggle' href='SearchAssessments.aspx'>Suspect Identification Config</a></li>";
            //xmlMenu += "<li style='line-height:2em;'><a class='dropdown-toggle' href='SearchAssessments.aspx'>Rules Setup</a></li>";
            //xmlMenu += "<li style='line-height:2em;'><a class='dropdown-toggle' href='SearchAssessments.aspx'>Search Rules</a></li>";
            //xmlMenu += "</ul></li></ul>";

            lblMenu.Text = xmlMenu;
        }
    }
    public string PageHeader
    {
        get
        {
            return lblPageHeader.Text;
        }
        set
        {
            lblPageHeader.Text = value;
        }
    }

    private static string GetMenuXml(List<BaseCore.MenuItem> allMenuItems)
    {
        StringBuilder obj = new StringBuilder();
        // List<MenuItem> allMenuItems = new List<MenuItem>();
        var parentMenuItems = from item in allMenuItems where item.ParentID.Equals(0) select item;
        if (parentMenuItems.Count() > 0)
        {
            obj.Append("<ul id='nav' class='nav'>");
            //  obj.Append("<li> <a href='#'></a> </li>");
            foreach (BaseCore.MenuItem parentItem in parentMenuItems)
            {
                obj.Append("<li class='dropdown'>");
                //obj.Append(ResolveHyperlink(parentItem.URL, parentItem.Title));
                obj.Append(makeMainItems(parentItem.Title));
                Int64 parentID = parentItem.ID;
                var childItems = from childItem in allMenuItems
                                 where childItem.ParentID.Equals(parentID)
                                 select childItem;
                if (childItems.Count() > 0)
                {
                    //obj.Append("<div class='span-15'> <ul class='dropdown-menu'>");
                    obj.Append("<div class='span-15'> <ul class='dropdown-menu'>");
                    foreach (BaseCore.MenuItem childMenuItem in childItems)
                    {
                        obj.Append("<li style='line-height:2em;'>");
                        //obj.Append(ResolveHyperlink(childMenuItem.URL, childMenuItem.Title));
                        obj.Append(ResolveHyperlink("WidgetSetup.aspx", childMenuItem.Title));
                        obj.Append("</li>");
                    }
                    obj.Append("</ul></div>");
                }
                obj.Append("</li>");
            }
            obj.Append("</ul>");
        }
        return obj.ToString();
    }

    public static string makeMainItems(string title)
    {
        //HyperLink obj = new HyperLink { NavigateUrl = currentHyperlink };
        StringBuilder hyperlink = new StringBuilder();
        hyperlink.Append(string.Format("<a class='dropdown-toggle' href='#'>" + title + "</a>"));
        return hyperlink.ToString();
    }

    public static string ResolveHyperlink(string currentHyperlink, string title)
    {
        HyperLink obj = new HyperLink { NavigateUrl = currentHyperlink };
        StringBuilder hyperlink = new StringBuilder();
        hyperlink.Append(string.Format("<a class='dropdown-toggle' href='{0}'>{1}</a>", obj.ResolveUrl(obj.NavigateUrl), title));
        return hyperlink.ToString();
    }
}
