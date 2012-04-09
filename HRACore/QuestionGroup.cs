using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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

        public QuestionGroup(IDataReader reader)
        {
            ID = Int32.Parse(reader[0].ToString());
            Name = reader[1].ToString();
            Description = reader[2].ToString();
            CreatedDate = DateTime.Parse(reader[3].ToString());
            CreatedBy = reader[4].ToString();
            LastModifiedDate = DateTime.Parse(reader[5].ToString());
            LastModifiedBy = reader[6].ToString();
            QuestionsCount = Int32.Parse(reader[7].ToString());

        }
    }
}
