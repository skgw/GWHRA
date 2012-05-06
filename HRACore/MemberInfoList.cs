using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
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

        public List<Tuple<int,int>>  GetFamilyHRAResponse(int MemberMasterID, int CurrentUserID)
        {
            List<Tuple<int, int>> lst = new List<Tuple<int, int>>();
            mCurrentUserID = CurrentUserID;
            using (dbhMil = new DBHelper(ConnectionStrings.DefaultDBConnection, mCurrentUserID))
            {
                dbhMil.AddParameter("@MemberMasterID", MemberMasterID);
                dbhMil.AddParameter("@CurrentUserID", mCurrentUserID);
                IDataReader reader = dbhMil.ExecuteReader("TEST_GetFamilyHRAResponses");
                while (reader.Read())
                {
                    lst.Add(Tuple.Create<int, int>(Convert.ToInt32(reader["RELATIONSHIP_ID_REF"]), Convert.ToInt32(reader["FAMILYQUESTION_ID_REF"])));
                }

            }
            return lst;
        }

        public void INSERTFAMILYHRA(int MemberMasterID, int RelationshipId, int FamilyQuestionId, int CurrentUserID)
        {
            using (dbhMil = new DBHelper(ConnectionStrings.DefaultDBConnection, mCurrentUserID))
            {
                dbhMil.AddParameter("@membermaster_id_ref", MemberMasterID);
                dbhMil.AddParameter("@relation_id_ref", RelationshipId);
                dbhMil.AddParameter("@familyquestion_id_ref", FamilyQuestionId);
                dbhMil.AddParameter("@CURRENTUSERID", mCurrentUserID);
                IDataReader reader = dbhMil.ExecuteReader("TEST_INSERT_FAMILYHRA");
               
            }
            
        }
    }
}
