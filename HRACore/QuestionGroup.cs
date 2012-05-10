using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BaseCore;
using DAL;

namespace HRACore
{
    public class QuestionGroup
    {
      
        private int mID;
        private string mName;
        private string mDescription;
        private DateTime mCreatedDate;
        private string mCreatedBy;
        private string mLastModifiedBy;
        private DateTime mLastModifiedDate;
        private int mQuestionsCount;
        private string mStatus;

        private int mCurrentUserID = 0;
        private DBHelper dbhQuestionGroup;

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

        public int QuestionsCount
        {
            get { return mQuestionsCount; }
            set { mQuestionsCount = value; }
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
            CreatedDate = DateTime.Parse(reader[4].ToString());
            CreatedBy = reader[5].ToString();
            //LastModifiedDate = DateTime.Parse(reader[5].ToString());
            //LastModifiedBy = reader[6].ToString();
           // QuestionsCount = reader[6] == DBNull.Value ? 0 : Int32.Parse(reader[6].ToString());
        }
        public QuestionGroup(int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
        }
        public QuestionGroup(int ID,int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
            const string procName = "GET_QUESTIONGROUPS_BY_ID";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestionGroup.AddParameter("@id", ID);
                dbhQuestionGroup.AddParameter("@CurrentUserID", mCurrentUserID);
                IDataReader dr = dbhQuestionGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    LoadReader(dr);
                }
                dbhQuestionGroup.Dispose();
            }         
        }
        public QuestionGroup(IDataReader reader)
        {
           LoadReader(reader);

        }
        public void Save()
        {
            
            string procName = "INSERTUPDATE_QUESTIONGROUP";
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
        public QuestionGroup GetQuestionGroup_By_ID(int ID)
        {
            QuestionGroup obj = new QuestionGroup(ID,1);
            const string procName = "GET_QUESTIONGROUPS_BY_ID";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestionGroup.AddParameter("@id", ID);
                dbhQuestionGroup.AddParameter("@CURRENTUSERID", mCurrentUserID);
                IDataReader dr = dbhQuestionGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    obj = (new QuestionGroup(dr));
                }
                dbhQuestionGroup.Dispose();
            }
            return obj;
        }
        
    }
}
