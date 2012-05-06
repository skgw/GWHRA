using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BaseCore;
using DAL;

namespace HRACore
{
    [Serializable]
    public class QuestionList
    {
        private DBHelper dbhQuestion;
        public List<Question> GetQuestions(string Content, int GroupId, int ResponseId, char status, char IsMandatory, int CurrentUserId)
        {
            List<Question> items = new List<Question>();
            const string procName = "GET_QUESTIONS";
            using (dbhQuestion = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestion.AddParameter("@CONTENT", Content);
                dbhQuestion.AddParameter("@QGROUP_ID", GroupId);
                dbhQuestion.AddParameter("@RESPONSETYPE_ID", ResponseId);
                dbhQuestion.AddParameter("@STATUS", status);
                dbhQuestion.AddParameter("@IS_MANDATORY", IsMandatory);
                dbhQuestion.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhQuestion.ExecuteReader(procName);
                while (dr.Read())
                {
                    items.Add(new Question(dr));
                }
                dbhQuestion.Dispose();
            }
            return items;
        }
        public List<Question> GetQuestionsByGroupId(int GroupId, int CurrentUserId)
        {
            List<Question> items = new List<Question>();
            const string procName = "GET_QUESTIONS_BY_GROUPID";
            using (dbhQuestion = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestion.AddParameter("@QGROUP_ID", GroupId);
                dbhQuestion.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhQuestion.ExecuteReader(procName);
                while (dr.Read())
                {
                    items.Add(new Question(dr));
                }
                dbhQuestion.Dispose();
            }
            return items;
        }
        public Question GetQuestionById(Int64 id, int CurrentUserId)
        {
            Question obj = new Question(1);
            string procName = "GET_QUESTION_BY_ID";
            using (dbhQuestion = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhQuestion.AddParameter("@id", id);
                dbhQuestion.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhQuestion.ExecuteReader(procName);
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
            using (dbhQuestion = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                DataSet ds = dbhQuestion.ExecuteDataSet(procName);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            return dt;
        }

        public List<Tuple<int, string>> GetFamilyQuestions(int CurrentUserID)
        {
            List<Tuple<int, string>> lst = new List<Tuple<int, string>>();
            using (dbhQuestion = new DBHelper(ConnectionStrings.DefaultDBConnection, CurrentUserID))
            {
                dbhQuestion.AddParameter("@CurrentUserID", CurrentUserID);
                IDataReader reader = dbhQuestion.ExecuteReader("GET_FAMILY_QUESTIONS");
                while (reader.Read())
                {
                    lst.Add(Tuple.Create<int, string>(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["QUESTION_CONTENT"])));
                }

            }
            return lst;
        }
    }
}

