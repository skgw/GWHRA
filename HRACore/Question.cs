
using System.Data;
using System.Data.SqlClient;
using BaseCore;

namespace HRACore
{
    public enum Sex
    {
        Both = 0,
        Male = 1,
        Female = 2
    }
    public enum ResponseTypes
    {
        TextBox = 0,
        TextArea = 1,
        CheckBox = 2,
        RadioButtons = 3
    }
    public class Question
    {
        private int mID;
        private string mContent;
        private Sex mAppliesTo;
        private char mStatus;
        private int mDisplayOrder;
        private string mHelpText;
        private string mNarrative;
        private int mLOB;
        private ResponseTypes mQuestionResponseType;
        private string mResponseText;

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public string Content
        {
            get { return mContent; }
            set { mContent = value; }
        }

        public Sex AppliesTo
        {
            get { return mAppliesTo; }
            set { mAppliesTo = value; }
        }

        public char Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        public int DisplayOrder
        {
            get { return mDisplayOrder; }
            set { mDisplayOrder = value; }
        }

        public string HelpText
        {
            get { return mHelpText; }
            set { mHelpText = value; }
        }

        public string Narrative
        {
            get { return mNarrative; }
            set { mNarrative = value; }
        }

        public int LOB
        {
            get { return mLOB; }
            set { mLOB = value; }
        }

        public ResponseTypes QuestionResponseType
        {
            get { return mQuestionResponseType; }
            set { mQuestionResponseType = value; }
        }

        public string ResponseText
        {
            get { return mResponseText; }
            set { mResponseText = value; }
        }

        public bool IsDuplicate()
        {
            bool isDuplicateQuestion = false;

            return isDuplicateQuestion;
        }
        public void Save()
        {
            //Push to database
        }
        /// <summary>
        /// TEST : REMOVE THIS LATER.
        /// </summary>
        /// <returns></returns>
        public DataSet GetGroups()
        {
            DataSet ds = new DataSet("QuestionGroups");
            using (DBHelper obj = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                ds = obj.ExecuteDataSet("usp_GetQuestionGroups");
                obj.Dispose();
            }
            return ds;
        }
    }
}
