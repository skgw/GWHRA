using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BaseCore;
using System.Data;

namespace HRACore
{
    public class Assessment
    {
        private DBHelper dbhAssessment;

        private int mID;
        private string mName;
        private string mDescription;
        private DateTime mModifiedDate;
        private string mModifiedBy;
        private DateTime mEffectiveFrom;
        private DateTime mEffectiveTo;
        private List<Question> mQuestionList;
        private int mAssessmentGroupId;
        private string mAssessmentGroupName;
        private DateTime mCreatedDate;
        private string mCreatedBy;
        private string mStatus;
        private int mCurrentUserID = 0;

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

        public DateTime ModifiedDate
        {
            get { return mModifiedDate; }
            set { mModifiedDate = value; }
        }

        public string ModifiedBy
        {
            get { return mModifiedBy; }
            set { mModifiedBy = value; }
        }

        public DateTime EffectiveFrom
        {
            get { return mEffectiveFrom; }
            set { mEffectiveFrom = value; }
        }

        public DateTime EffectiveTo
        {
            get { return mEffectiveTo; }
            set { mEffectiveTo = value; }
        }

        public List<Question> Questions
        {
            get { return mQuestionList; }
            set { mQuestionList = value; }
        }

        public Assessment(int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
        }
        public Assessment (int assessmentID, int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
            ID = assessmentID;

            string procName = "GET_ASSESSMENT_BY_ID";
            using(dbhAssessment = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessment.AddParameter("@ID", ID);
                dbhAssessment.AddParameter("@CURRENTUSERID", @mCurrentUserID);

                IDataReader reader = dbhAssessment.ExecuteReader(procName);
                if(reader.Read())
                {
                    LoadReader(reader);
                }
            }
        }
        public void Save()
        {
            using (dbhAssessment = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessment.AddParameter("@ID",ID);
                dbhAssessment.AddParameter("@NAME",Name);
                dbhAssessment.AddParameter("@DESCRIPTION",Description);
                dbhAssessment.AddParameter("@EFFECTIVE_FROM", EffectiveFrom);
                dbhAssessment.AddParameter("@EFFECTIVE_TO", EffectiveTo);
                dbhAssessment.AddParameter("@CURRENTUSERID", mCurrentUserID);

                IDataReader reader = dbhAssessment.ExecuteReader("INSERTUPDATE_ASSESSMENT");
                if(reader.Read())
                {
                    LoadReader(reader);

                }
            }
        }
        public void AddQuestionsToAssessment()
        {
            
        }
        public Assessment(IDataReader reader)
        {
            LoadReader(reader);
        }
        private void LoadReader(IDataReader reader)
        {
            ID = Int32.Parse(reader[0].ToString());
            Name = reader[1].ToString();
            Description = reader[2].ToString();
            EffectiveFrom = DateTime.Parse(reader[3].ToString());
            EffectiveTo = DateTime.Parse(reader[4].ToString());
            ModifiedBy = reader[5].ToString();
            ModifiedDate = DateTime.Parse(reader[6].ToString());
        }
    }
}
