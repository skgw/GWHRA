using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BaseCore;

namespace HRACore
{
    [Serializable]
    public class QuestionList
    {
        private DBHelper dbhQuestionGroup;
        public List<Question> GetQuestions(string Content, int GroupId, int ResponseId, char status, char IsMandatory, int CurrentUserId)
        {
            List<Question> items = new List<Question>();
            const string procName = "GET_QUESTIONS";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestionGroup.AddParameter("@CONTENT", Content);
                dbhQuestionGroup.AddParameter("@QGROUP_ID", GroupId);
                dbhQuestionGroup.AddParameter("@RESPONSETYPE_ID", ResponseId);
                dbhQuestionGroup.AddParameter("@STATUS", status);
                dbhQuestionGroup.AddParameter("@IS_MANDATORY", IsMandatory);
                dbhQuestionGroup.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhQuestionGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    items.Add(new Question(dr));
                }
                dbhQuestionGroup.Dispose();
            }
            return items;
        }
        public List<Question> GetQuestionsByGroupId(int GroupId, int CurrentUserId)
        {
            List<Question> items = new List<Question>();
            const string procName = "GET_QUESTIONS_BY_GROUPID";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestionGroup.AddParameter("@QGROUP_ID", GroupId);
                dbhQuestionGroup.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhQuestionGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    items.Add(new Question(dr));
                }
                dbhQuestionGroup.Dispose();
            }
            return items;
        }
        public Question GetQuestionById(Int64 id, int CurrentUserId)
        {
            Question obj = new Question(1);
            string procName = "GET_QUESTION_BY_ID";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestionGroup.AddParameter("@id", id);
                dbhQuestionGroup.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhQuestionGroup.ExecuteReader(procName);
                while (dr.Read())
                {
                    obj = (new Question(dr));
                }
            }
            return obj;
        }

        public DataTable GetQResponseTypes()
        {
            DataTable dt = new DataTable();
            string procName = "usp_GETRESPONSETYPES";
            using (dbhQuestionGroup = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                DataSet ds = dbhQuestionGroup.ExecuteDataSet(procName);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            return dt;
        }
    }
}

