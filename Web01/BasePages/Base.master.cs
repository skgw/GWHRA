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
            string MenuXML = GetMenuXml(menuObj.GetMenuForRole(1000, 1));
            lblMenu.Text = MenuXML;
            //xmlMenu = "<ul id='nav' class='nav'>";
            //xmlMenu += "<li class='dropdown'><a href='#'>Home</a></li>";
            //xmlMenu += "<li class='dropdown'><a class='dropdown-toggle' href='#'>Setup</a>";
            //xmlMenu += "<ul class='dropdown-menu'>";
            //xmlMenu += "<li style='line-height:2em; width:150%;'><a href='/Dashboard/WidgetSetup.aspx'>Suspect Identification Config</a></li>";
            //xmlMenu += "<li style='line-height:2em; width:150%;'><a href='/Dashboard/WidgetSetup.aspx'>Rules Setup</a></li>";
            //xmlMenu += "<li style='line-height:2em; width:150%;'><a href='/Dashboard/WidgetSetup.aspx'>Search Rules</a></li>";
            //xmlMenu += "</ul></li></ul>";
            //lblMenu.Text = xmlMenu;
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
                    obj.Append("<ul class='dropdown-menu'>");
                    foreach (BaseCore.MenuItem childMenuItem in childItems)
                    {
                        obj.Append("<li style='line-height:2em;'>");
                        obj.Append(ResolveHyperlink(childMenuItem.URL, childMenuItem.Title));
                        //obj.Append(ResolveHyperlink("WidgetSetup.aspx", childMenuItem.Title));
                        obj.Append("</li>");
                    }
                    obj.Append("</ul>");
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
        hyperlink.Append(string.Format("<a href='{0}'>{1}</a>", obj.ResolveUrl(obj.NavigateUrl), title));
        return hyperlink.ToString();
    }
}
