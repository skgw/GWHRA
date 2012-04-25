using System;
using System.Data;
using BaseCore;
using DAL;

namespace HRACore
{
    public class AssessmentGroup
    {
        private int mID;
        private string mName;
        private string mDescription;
        private string mLastModifiedBy;
        private DateTime mLastModifiedDate;
        private string mStatus;

        private int mCurrentUserID;
        private DBHelper dbhAssessmentGroup;


        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public string LastModifiedBy
        {
            get { return mLastModifiedBy; }
            set { mLastModifiedBy = value; }
        }

        public DateTime LastModifiedDate
        {
            get { return mLastModifiedDate; }
            set { mLastModifiedDate = value; }
        }

        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        private void LoadReader(IDataReader reader)
        {
            ID = Int32.Parse(reader[0].ToString());
            Name = reader[1].ToString();
            Description = reader[2].ToString();
            Status = reader[3].ToString();
            LastModifiedDate = DateTime.Parse(reader[4].ToString());
            LastModifiedBy = reader[5].ToString();
        }

        public AssessmentGroup(IDataReader reader)
        {
            LoadReader(reader);
        }
        public AssessmentGroup(int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
        }
        public AssessmentGroup(int ID, int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
            const string procName = "GET_ASSESSMENT_GROUP_BY_ID";
            using (dbhAssessmentGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessmentGroup.AddParameter("@ID", ID);
                dbhAssessmentGroup.AddParameter("@CURRENTUSERID", mCurrentUserID);
                IDataReader dr = dbhAssessmentGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    LoadReader(dr);
                }
                dbhAssessmentGroup.Dispose();
            }
        }
 
        public void Save()
        {

            string procName = "INSERTUPDATE_ASSESSMENT_GROUP";
            using (dbhAssessmentGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessmentGroup.AddParameter("@ID", this.ID);
                dbhAssessmentGroup.AddParameter("@NAME", this.Name);
                dbhAssessmentGroup.AddParameter("@DESCRIPTION", this.Description);
                dbhAssessmentGroup.AddParameter("@STATUS", this.Status);
                dbhAssessmentGroup.AddParameter("@CURRENTUSERID", mCurrentUserID);

                IDataReader dr = dbhAssessmentGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    LoadReader(dr);
                }
                dbhAssessmentGroup.Dispose();
            }

        }      
    }
}
