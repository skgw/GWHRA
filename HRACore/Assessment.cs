using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BaseCore;
using DAL;


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
        private char mStatus;
        private int mCurrentUserID = 0;

        public DateTime CompletedDate { get; set; }
        

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
        public int AssessmentGroupId
        {
            get { return mAssessmentGroupId; }
            set { mAssessmentGroupId = value; }
        }
        public string AssessmentGroupName
        {
            get { return mAssessmentGroupName; }
            set { mAssessmentGroupName = value; }
        }
        public char Status
        {
            get { return mStatus; }
            set { mStatus = value; }
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
                dbhAssessment.AddParameter("@ID",this.ID);
                dbhAssessment.AddParameter("@NAME", this.Name);
                dbhAssessment.AddParameter("@DESCRIPTION", this.Description);
                dbhAssessment.AddParameter("@ASSESSMENT_GROUP_ID_REF", this.AssessmentGroupId);
                dbhAssessment.AddParameter("@EFFECTIVE_FROM", this.EffectiveFrom);
                dbhAssessment.AddParameter("@EFFECTIVE_TO", this.EffectiveTo);
                dbhAssessment.AddParameter("@STATUS", this.Status);
                dbhAssessment.AddParameter("@NARRATIVE_HEADER", "");
                dbhAssessment.AddParameter("@NARRATIVE_FOOTER", "");
                dbhAssessment.AddParameter("@CURRENTUSERID", mCurrentUserID);

                IDataReader reader = dbhAssessment.ExecuteReader("INSERTUPDATE_ASSESSMENTS");
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
            AssessmentGroupId = Int32.Parse(reader[3].ToString());
            EffectiveFrom = DateTime.Parse(reader[4].ToString());
            EffectiveTo = DateTime.Parse(reader[5].ToString());
            ModifiedBy = reader[6].ToString();
            ModifiedDate = reader[7] != DBNull.Value ? DateTime.Parse(reader[7].ToString()) : Convert.ToDateTime("01/01/2099");
            Status = Convert.ToChar(reader[8].ToString());
            AssessmentGroupName = reader[9].ToString();
            
        }
        public void LoadAssessmentInfoForMember(IDataReader reader)
        {

            ID = Int32.Parse(reader[0].ToString());
            Name = reader[1].ToString();
            Description = reader[2].ToString();
            AssessmentGroupId = Int32.Parse(reader[3].ToString());
            EffectiveFrom = DateTime.Parse(reader[4].ToString());
            EffectiveTo = DateTime.Parse(reader[5].ToString());
            ModifiedBy = reader[6].ToString();
            ModifiedDate = reader[7] != DBNull.Value ? DateTime.Parse(reader[7].ToString()) : Convert.ToDateTime("01/01/2099");
            Status = Convert.ToChar(reader[8].ToString());
            AssessmentGroupName = reader[9].ToString();
            CompletedDate = string.IsNullOrWhiteSpace(reader[10].ToString())
                                ? DateTime.MinValue
                                : Convert.ToDateTime(reader[10].ToString());
        }
  
    }
}
