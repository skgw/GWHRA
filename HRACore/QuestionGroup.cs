using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BaseCore;

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

        public QuestionGroup()
        {
            
        }
        public QuestionGroup(IDataReader reader)
        {
            ID = Int32.Parse(reader[0].ToString());
            Name = reader[1].ToString();
            Description = reader[2].ToString();
            Status = reader[3].ToString();
            CreatedDate = DateTime.Parse(reader[4].ToString());
            CreatedBy = reader[5].ToString();
            //LastModifiedDate = DateTime.Parse(reader[5].ToString());
            //LastModifiedBy = reader[6].ToString();
            QuestionsCount = reader[6] == DBNull.Value ? 0 : Int32.Parse(reader[6].ToString());

        }
        public  QuestionGroup Save()
        {
            QuestionGroup obj = null;;
            string procName = "INSERTUPDATE_QUESTIONGROUP";
            DBHelper dl = new DBHelper(ConnectionStrings.DefaultDBConnection);
            dl.AddParameter("@id", this.ID);
            dl.AddParameter("@name", this.Name);
            dl.AddParameter("@description", this.Description);
            dl.AddParameter("@status", this.Status);
            //DataSet ds = dl.ExecuteDataSet(procName);
            IDataReader dr = dl.ExecuteReader(procName);
            while (dr.Read())
            {
                obj = (new QuestionGroup(dr));
            }
            return obj;
        }
        
    }
}
