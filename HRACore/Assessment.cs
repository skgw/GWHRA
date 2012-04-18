using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseCore;
using System.Data;

namespace HRACore
{
    public class Assessment
    {
        private DBHelper dbhQuestionGroup;

        private int mID;
        private string mName;
        private string mDescription;
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

        public List<Question> QuestionList
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

        public DateTime CreatedDate
        {
            get { return mCreatedDate; }
            set { mCreatedDate = value; }
        }
        public string CreatedBy
        {
            get { return mCreatedBy; }
            set { mCreatedBy = value; }
        }
        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        public Assessment(int CurrentUserId)
        {
            mCurrentUserID = CurrentUserId;
        }
        private void LoadReader(IDataReader reader)
        {
            ID = Int32.Parse(reader[0].ToString());
            Name = reader[1].ToString();
            Description = reader[2].ToString();
            Status = reader[3].ToString();
            CreatedDate = DateTime.Parse(reader[4].ToString());
            CreatedBy = reader[5].ToString();
            //LastModifiedDate = DateTime.Parse(reader[5].ToString());
            //LastModifiedBy = reader[6].ToString();
            //QuestionsCount = reader[6] == DBNull.Value ? 0 : Int32.Parse(reader[6].ToString());
        }
        public void Save()
        {

            string procName = "INSERTUPDATE_ASSESSMENTS";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestionGroup.AddParameter("@id", this.ID);
                dbhQuestionGroup.AddParameter("@name", this.Name);
                dbhQuestionGroup.AddParameter("@description", this.Description);
                dbhQuestionGroup.AddParameter("@status", this.Status);
                dbhQuestionGroup.AddParameter("@CURRENTUSERID", mCurrentUserID);


                IDataReader dr = dbhQuestionGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    LoadReader(dr);
                }
                dbhQuestionGroup.Dispose();
            }

        }
    }
}
