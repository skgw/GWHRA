using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
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
        private Int64 mID;
        private string mContent;
        private Sex mAppliesTo;
        private char mStatus;
        private Int64 mDisplayOrder;
        private string mHelpText;
        private string mNarrative;
        private Int64 mLOB;
        private ResponseTypes mQuestionResponseType;
        private string mResponseText;
        private char mIsMandatory;
        private Int64 mQGroupId_Ref;
        private Int64 mQResponseTypeId_Ref;
        private char mGender;

        public Int64 ID
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

        public Int64 DisplayOrder
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

        public Int64 LOB
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
        public char IsMandatory
        {
            get { return mIsMandatory; }
            set { mIsMandatory = value; }
        }

        public Int64 QGroupId_Ref
        {
            get { return mQGroupId_Ref; }
            set { mQGroupId_Ref = value; }
        }
        public Int64 QResponseTypeId_Ref
        {
            get { return mQResponseTypeId_Ref; }
            set { mQResponseTypeId_Ref = value; }
        }
        public char Gender
        {
            get { return mGender; }
            set { mGender = value; }
        }
        public Question()
        {            
        }

        public Question(IDataReader reader)
        {
            ID = Int64.Parse(reader[0].ToString());
            QGroupId_Ref = Int64.Parse(reader[1].ToString());
            QResponseTypeId_Ref = Int64.Parse(reader[2].ToString());
            Content = reader[3].ToString();
            DisplayOrder = Int64.Parse(reader[4].ToString());
            Gender =Convert.ToChar(reader[5].ToString());
            Narrative = reader[6].ToString();
            HelpText = reader[7].ToString();
            IsMandatory = Convert.ToChar(reader[8].ToString());
            Status = Convert.ToChar(reader[11].ToString());
            ResponseText = reader[12].ToString();
            //CreatedDate = DateTime.Parse(reader[4].ToString());
            //CreatedBy = reader[5].ToString();
            //LastModifiedDate = DateTime.Parse(reader[5].ToString());
            //LastModifiedBy = reader[6].ToString();
            //QuestionsCount = reader[6] == DBNull.Value ? 0 : Int64.Parse(reader[6].ToString());
            //QUESTION_GROUP_ID_REF, RESPONSE_TYPE_ID_REF, QUESTION_CONTENT, DISPLAY_ORDER
		    //, GENDER, NARRATIVE, HELP_TEXT, IS_MANDATORY, CREATED_DATE, CREATED_BY, STATUS
        }

        public Question Save(int userid)
        {
            Question obj = null; ;
            string procName = "INSERTUPDATE_QUESTIONS";
            DBHelper dl = new DBHelper(ConnectionStrings.DefaultDBConnection);
            dl.AddParameter("@id", this.ID);
            dl.AddParameter("@qgroupid_ref", this.QGroupId_Ref);
            dl.AddParameter("@responsetypeid_ref", this.QResponseTypeId_Ref);
            dl.AddParameter("@qcontent", this.Content);
            dl.AddParameter("@options", this.ResponseText);
            dl.AddParameter("@displayorder", this.DisplayOrder);
            dl.AddParameter("@gender", this.Gender);
            dl.AddParameter("@narrative", this.Narrative);
            dl.AddParameter("@helptext", this.HelpText);
            dl.AddParameter("@ismandatory", this.IsMandatory);

            dl.AddParameter("@status", this.Status);
            dl.AddParameter("@userId", userid);
            IDataReader dr = dl.ExecuteReader(procName);
            while (dr.Read())
            {
                obj = (new Question(dr));
            }
            return obj;
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

        public static DataTable GetQResponseTypes()
        {
            DataTable dt = new DataTable();
            string procName = "usp_GETRESPONSETYPES";
            using (DBHelper dbObj = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                DataSet ds = dbObj.ExecuteDataSet(procName);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];    
                }
            }
            return dt;
        }

        public static Question GetQuestionById(Int64 id)
        {
            Question obj = new Question();
            string procName = "GET_QUESTION_BY_ID";
            using (DBHelper dbObj = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbObj.AddParameter("@id", id);
                IDataReader dr = dbObj.ExecuteReader(procName);
                while (dr.Read())
                {
                    obj = (new Question(dr));
                }
            }
            return obj;
        }
    }
}
