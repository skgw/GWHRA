using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BaseCore
{
    public class CodeManager
    {
        private int mCurrentUserID;
        public DBHelper dbhCodeManager;
        public CodeManager(int pCurrentUserID)
        {
            mCurrentUserID = pCurrentUserID;
        }
        public Dictionary<int, string> GetSysCodeValues(int CodeType)
        {
            Dictionary<int, string> items = new Dictionary<int, string>();
            using (dbhCodeManager = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhCodeManager.AddParameter("@CODE_TYPE_ID_REF", CodeType);
                dbhCodeManager.AddParameter("@CurrentUserID", mCurrentUserID);

                IDataReader reader = dbhCodeManager.ExecuteReader("GET_SYS_CODE_VALUES");
                while (reader.Read())
                {
                    items.Add(Int32.Parse(reader[0].ToString()), reader[1].ToString());
                }

                dbhCodeManager.Dispose();
            }
            return items;
        }
    }
}
