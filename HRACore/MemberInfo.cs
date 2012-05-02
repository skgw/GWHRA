using System;
using System.Data;
using DAL;

namespace HRACore
{
    public class MemberInfo
    {
        private int mCurrentUserID;
        private DBHelper dbhMemberInfo;
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MemberID { get; set; }
        public string SubscriberID { get; set; }

        public MemberInfo(int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
        }
        public void LoadReader(IDataReader reader)
        {
            ID = Int32.Parse(reader[0].ToString());
            Firstname = reader[1].ToString();
            Lastname = reader[2].ToString();
            MemberID = reader[3].ToString();
            SubscriberID = reader[4].ToString();
        }
        public MemberInfo(int MemberMasterID, int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
            using(dbhMemberInfo =new DBHelper(ConnectionStrings.DefaultDBConnection,mCurrentUserID))
            {
                dbhMemberInfo.AddParameter("@MemberMasterID",MemberMasterID);
                dbhMemberInfo.AddParameter("@CurrentUserID",mCurrentUserID);                
                IDataReader reader = dbhMemberInfo.ExecuteReader("GET_MEMBER_BY_MASTER_ID");
                if(reader.Read())
                {
                    LoadReader(reader);
                }

            }
        }
        public MemberInfo(string Subscriber_ID, int CurrentUserID)
        {
            SubscriberID = Subscriber_ID;
            mCurrentUserID = CurrentUserID;
            using (dbhMemberInfo = new DBHelper(ConnectionStrings.DefaultDBConnection, mCurrentUserID))
            {
                dbhMemberInfo.AddParameter("@SubscriberID", SubscriberID);
                dbhMemberInfo.AddParameter("@CurrentUserID", mCurrentUserID);
                IDataReader reader = dbhMemberInfo.ExecuteReader("GET_MEMBER_BY_SUBSCRIBER_ID");
                if (reader.Read())
                {
                    LoadReader(reader);
                }
            }
        }
    }
}
