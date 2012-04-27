using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using BaseCore;
using DAL;

namespace BaseCore
{
    public class MenuItem
    {
        private Int64 mID;
        private string mTitle;
        private string mDescription;
        private string mURL;
        private Int64 mDisplayOrder;
        private char mStatus;
        private Int64 mParentID;


        public long ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public string Title
        {
            get { return mTitle; }
            set { mTitle = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public string URL
        {
            get { return mURL; }
            set { mURL = value; }
        }

        public Int64 DisplayOrder
        {
            get { return mDisplayOrder; }
            set { mDisplayOrder = value; }
        }

        public char Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        public long ParentID
        {
            get { return mParentID; }
            set { mParentID = value; }
        }

        public MenuItem(IDataReader reader)
        {
            ID = ( reader["ID"] != DBNull.Value ) ? Convert.ToInt64( reader["ID"].ToString() ) : 0;
            ParentID = reader["ParentID"] == DBNull.Value ? 0 : Convert.ToInt64( reader["ParentID"] );
            Title = ( reader["Title"] == DBNull.Value ) ? string.Empty : reader["Title"].ToString();
            Description = ( reader["Description"] == DBNull.Value ) ? string.Empty : reader["Description"].ToString();
            URL = ( reader["URL"] == DBNull.Value ) ? string.Empty : reader["URL"].ToString();
            DisplayOrder = ( reader["DisplayOrder"] != DBNull.Value ) ? Convert.ToInt64( reader["DisplayOrder"].ToString() ) : 0;
            DisplayOrder = ( reader["Status"] != DBNull.Value ) ? Convert.ToChar( reader["Status"].ToString() ) : 0;
        }
        public MenuItem GetMenuItem(IDataReader reader)
        {
            return new MenuItem( reader );
        }

        public static MenuItem GetMenuItem( IDataReader reader, string purpose )
        {
            return new MenuItem( reader, "ParentNodeMenu" );

        }
        public MenuItem( IDataReader reader, string purpose )
        {
            if ( purpose.ToString().Length > 0 )
            {
                ID = reader.GetInt64( reader.GetOrdinal( "SiteId" ) );
                Title = reader.GetString( reader.GetOrdinal( "SiteDesc" ) );
            }
        }
    }
}