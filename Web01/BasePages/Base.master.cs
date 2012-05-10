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
    UserInfo currentUser = new UserInfo();

    public UserInfo CurrentUser
    {
        get
        {
            return currentUser;
        }
        set
        {
            currentUser = value;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (null != Session["LoggedInUserInfo"])
        {
            currentUser = (UserInfo)Session["LoggedInUserInfo"];
            //put it in session first.
            MenuManager mm = new MenuManager();
            lblMenu.Text = GetMenuXml(mm.GetMenuForRole(currentUser.RoleID, 1));
        }
        if (!IsPostBack)
        {
        }
    }

   

    private string GetMenuXml(List<BaseCore.MenuItem> allMenuItems)
    {
        StringBuilder obj = new StringBuilder();
        var parentMenuItems = from item in allMenuItems where item.ParentID.Equals(0) select item;
        if (parentMenuItems.Count() > 0)
        {
            obj.Append("<ul class='nav'>");
            foreach (BaseCore.MenuItem parentItem in parentMenuItems)
            {
                //  obj.Append("<li>");                
                Int64 parentID = parentItem.ID;
                var childItems = from childItem in allMenuItems
                                 where childItem.ParentID.Equals(parentID)
                                 select childItem;
                if (childItems.Count() > 0)
                {
                    obj.Append("<li class='dropdown'>");
                    obj.Append(makeMainItems(parentItem.Title, true));
                    obj.Append("<ul class='dropdown-menu'>");
                    foreach (BaseCore.MenuItem childMenuItem in childItems)
                    {
                        obj.Append("<li>");
                        obj.Append(ResolveHyperlink(childMenuItem.URL, childMenuItem.Title));
                        //obj.Append(ResolveHyperlink("WidgetSetup.aspx", childMenuItem.Title));
                        //obj.Append(ResolveHyperlink(childMenuItem.URL, childMenuItem.Title));
                        //obj.Append(ResolveHyperlink("WidgetSetup.aspx", childMenuItem.Title));
                        obj.Append("</li>");
                    }
                    //obj.Append("</ul>");
                    obj.Append("</ul>");
                }
                else
                {
                    obj.Append("<li>");
                    obj.Append(ResolveHyperlink(parentItem.URL, parentItem.Title));
                }
                obj.Append("</li>");
            }
            obj.Append("</ul>");
        }
        return obj.ToString();
    }

    private string makeMainItems(string title, bool HasChildren)
    {
        return ((HasChildren == true)
                   ? "<a class='dropdown-toggle' data-toggle='dropdown' href='#'>" + title + "<b class='caret'></b></a>"
                   : "<a href='#'>" + title + "</a>");
    }
    private string ResolveHyperlink(string currentHyperlink, string title)
    {
        HyperLink obj = new HyperLink { NavigateUrl = currentHyperlink };
        StringBuilder hyperlink = new StringBuilder();
        hyperlink.Append(string.Format("<a href='{0}'>{1}</a>", obj.ResolveClientUrl(obj.NavigateUrl), title));
        return hyperlink.ToString();
    }
}
