using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using BaseCore;
using DAL;
using System.Xml;

namespace HRACore
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Synced with db (SYS_CODES). Code type : 1005</remarks>
    public enum Sex
    {
        Both = 1000,
        Female = 1001,
        Male = 1002
    }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Synced with db (SYS_CODES). Code type : 1005</remarks>
    ///
    public enum ResponseTypes
    {
        CheckBox = 1003,
        RadioButtons = 1004,
        TextArea = 1005,
        TextBox = 1006
    }
    [Serializable]
    public class Question
    {
        private DBHelper dbhQuestionGroup;

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
        private string mGroupName;
        private Int64 mQResponseTypeId_Ref;
        private string mResponseType;
        private char mGender;
        private string mCreatedBy;
        private DateTime mCreatedDate;
        private int mCurrentUserID = 0;
        public List<Tuple<int, string, string>> Options = new List<Tuple<int, string, string>>();

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
        public string ResponseType
        {
            get { return mResponseType; }
            set { mResponseType = value; }
        }
        public char Gender
        {
            get { return mGender; }
            set { mGender = value; }
        }
        public string GroupName
        {
            get { return mGroupName; }
            set { mGroupName = value; }
        }
        public string CreatedBy
        {
            get { return mCreatedBy; }
            set { mCreatedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return mCreatedDate; }
            set { mCreatedDate = value; }
        }
        

        public Question( int CurrentUserId)
        {
            mCurrentUserID = CurrentUserId;
        }

        public void LoadQuestion(IDataReader reader)
        {
            ID = Int64.Parse(reader[0].ToString());
            Gender = Convert.ToChar(reader[1].ToString());
            Content = reader[2].ToString();
            GroupName = reader[3].ToString();
            DisplayOrder = Int64.Parse(reader[4].ToString());
            Status = Convert.ToChar(reader[5].ToString());
            IsMandatory = Convert.ToChar(reader[6].ToString());
            CreatedBy = reader[7].ToString();
            CreatedDate = DateTime.Parse(reader[8].ToString());

            QGroupId_Ref = Int64.Parse(reader[9].ToString());
            QResponseTypeId_Ref = Int64.Parse(reader[10].ToString());
            //Narrative = reader[11].ToString();
            HelpText = reader[12].ToString();
            ResponseText = reader[13].ToString();
            ResponseType = reader[14].ToString();
            
        }

        public Question(IDataReader reader)
        {
            LoadQuestion(reader);
        }

        public void Save(int userid)
        {
            string procName = "INSERTUPDATE_QUESTIONS";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestionGroup.AddParameter("@id", this.ID);
                dbhQuestionGroup.AddParameter("@qgroupid_ref", this.QGroupId_Ref);
                dbhQuestionGroup.AddParameter("@responsetypeid_ref", this.QResponseTypeId_Ref);
                dbhQuestionGroup.AddParameter("@qcontent", this.Content);
                dbhQuestionGroup.AddParameter("@options", this.ResponseText);
                //dbhQuestionGroup.AddParameter("@displayorder", this.DisplayOrder);
                dbhQuestionGroup.AddParameter("@gender", this.Gender);
                //dbhQuestionGroup.AddParameter("@narrative", this.Narrative);
                dbhQuestionGroup.AddParameter("@helptext", this.HelpText);
                dbhQuestionGroup.AddParameter("@ismandatory", this.IsMandatory);

                dbhQuestionGroup.AddParameter("@status", this.Status);
                dbhQuestionGroup.AddParameter("@CURRENTUSERID", userid);
                IDataReader dr = dbhQuestionGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    LoadQuestion(dr);
                }
                dbhQuestionGroup.Dispose();
            }
        }

        public List<Question> GetAssessmentQuestions(int AssessmentId, int CurrentUserId)
        {
            List<Question> lst = new List<Question>();
            const string procName = "GET_ASSESSMENT_QUESTIONS";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestionGroup.AddParameter("@ASSESSMENT_ID", AssessmentId);
                dbhQuestionGroup.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhQuestionGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    lst.Add(new Question(dr));
                }
                if (dr.NextResult())
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < lst.Count; i++)
                        {
                            if (Convert.ToInt32(dr["QUESTION_ID"]) == lst[i].ID)
                            {
                                lst[i].Options.Add(Tuple.Create<int, string, string>(Convert.ToInt32(dr["QUESTION_ID"]), Convert.ToString(dr["OPTION"]), Convert.ToString(dr["VALUE"])));
                            }
                        }
                    }
                }
                
                dbhQuestionGroup.Dispose();
            }
            return lst;
        }
                
    }
}
