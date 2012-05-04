using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace HRACore
{
    public class FamilyMember
    {
      //  public string SubscriberID { get; set; }
        public int MemberMasterID { get; set; }
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int RelationshipID { get; set; }
        public string RelationshipName { get; set; }
        public string Sex { get; set; }
        public DateTime DOB { get; set; }
        public char CurrentStatus { get; set; }
        public int LivingStatus { get; set; }
        public DateTime DateOfDeath { get; set; }
        public int CauseOfDeath { get; set; }

        public DBHelper dbhFamilyMember;
        private int mCurrentUserID = 0;
        public FamilyMember(int memberMasterID)
        {
            MemberMasterID = memberMasterID;
        }
        public FamilyMember(IDataReader reader)
        {
            ID = Int32.Parse(reader[0].ToString());
            Firstname = reader[1].ToString();
            Lastname = reader[2].ToString();
            RelationshipID = Int32.Parse(reader[3].ToString());
            RelationshipName = reader[4].ToString();
            Sex = reader[5].ToString();
            DOB = Convert.ToDateTime(reader[6].ToString());
            MemberMasterID = Int32.Parse(reader[7].ToString());
        }
        public void Save()
        {
            using (dbhFamilyMember = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhFamilyMember.AddParameter("@MemberMasterID", this.MemberMasterID);
                dbhFamilyMember.AddParameter("@ID", this.ID);
                dbhFamilyMember.AddParameter("@FIRSTNAME", this.Firstname);                
                dbhFamilyMember.AddParameter("@LASTNAME", this.Lastname);
                dbhFamilyMember.AddParameter("@SEX", this.Sex);                                
                dbhFamilyMember.AddParameter("@DOB", this.DOB);
                
                dbhFamilyMember.AddParameter("@CurrentStatus", this.CurrentStatus);
                dbhFamilyMember.AddParameter("@LivingStatus", this.LivingStatus);
                dbhFamilyMember.AddParameter("@DateOfDeath", this.DateOfDeath);
                dbhFamilyMember.AddParameter("@CauseOfDeath", this.CauseOfDeath);          
                                      
            
                dbhFamilyMember.AddParameter("@CURRENTUSERID", mCurrentUserID);


                dbhFamilyMember.ExecuteCommand("INSERTUPDATE_FAMILY_MEMBER");                
            }
        }

    }
}
