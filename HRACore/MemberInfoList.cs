using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace HRACore
{
    public class MemberInfoList
    {
        private int mCurrentUserID;
        private DBHelper dbhMil;

        public MemberInfoList(int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;

        }
        public List<MemberInfo> GetMembers(string firstname, string lastname, string sex, string memberID)
        {
            List<MemberInfo> members = new List<MemberInfo>();
            using (dbhMil = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhMil.AddParameter("@FIRSTNAME", firstname);
                dbhMil.AddParameter("@LASTNAME", lastname);
                dbhMil.AddParameter("@SEX", sex);
                dbhMil.AddParameter("@MEMBERID", memberID);
                dbhMil.AddParameter("@CURRENTUSERID", mCurrentUserID);

                IDataReader reader = dbhMil.ExecuteReader("GET_MEMBERINFOLIST");
                while (reader.Read())
                {
                    members.Add(new MemberInfo(reader));
                }
            }
            return members;
        }
    }
}
