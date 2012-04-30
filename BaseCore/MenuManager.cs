/*
Filename          : MenuManager.cs
Namespace         : BaseCore
Author			  : Sashidhar S. Kokku
Contributors	  : 
*/


using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using BaseCore;
using DAL;

namespace BaseCore
{
    [Serializable()]
    public class MenuManager
    {


        public List<MenuItem> GetMenuForRole(Int64 roleID, int CurrentUserID)
        {
            DBHelper dbhMenuManager;
            List<MenuItem> menuItems = new List<MenuItem>();
            using (dbhMenuManager = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhMenuManager.AddParameter("@ROLEID", roleID.ToString());
                dbhMenuManager.AddParameter("@CurrentUserID", CurrentUserID);
                IDataReader dr = dbhMenuManager.ExecuteReader("GET_USER_SITEMAP");
                while (dr.Read())
                {
                    menuItems.Add(new MenuItem(dr));
                }
                dbhMenuManager.Dispose();
            }
            return menuItems;
        }

     
        public static Boolean IsThereChildMenu(Int32 SiteId, Int64 CurrentUserID)
        {
            DBHelper dbhMenuManager;
            Boolean IsValid = false;
            List<ModuleInfo> menuItems = new List<ModuleInfo>();
            using (dbhMenuManager = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhMenuManager.AddParameter("@iSiteId", SiteId);
                IDataReader dr = dbhMenuManager.ExecuteReader("IsthereChildMenu");
                while (dr.Read())
                {
                    IsValid = Convert.ToBoolean(Convert.ToInt32(dr["IsValid"].ToString()));
                }
                dbhMenuManager.Dispose();
            }
            return IsValid;
            
        }
    }
}