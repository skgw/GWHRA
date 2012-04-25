using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BaseCore;
using DAL;

namespace HRACore
{
    [Serializable]
    public class AssessmentList
    {
        private DBHelper dbhAssessments;
        public List<Assessment> GetAssessments(string Name, int GroupId, string EffectiveFrom, string EffectiveTo, char Status, int CurrentUserId)
        {
            List<Assessment> items = new List<Assessment>();
            const string procName = "GET_ASSESSMENTS";
            using (dbhAssessments = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessments.AddParameter("@NAME", Name);
                dbhAssessments.AddParameter("@ASSESSMENT_GROUP_ID_REF", GroupId);
                dbhAssessments.AddParameter("@EFFECTIVE_FROM", EffectiveFrom);
                dbhAssessments.AddParameter("@EFFECTIVE_TO", EffectiveTo);
                dbhAssessments.AddParameter("@STATUS", Status);
                dbhAssessments.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhAssessments.ExecuteReader(procName);
                while (dr.Read())
                {
                    items.Add(new Assessment(dr));
                }
                dbhAssessments.Dispose();
            }
            return items;
        }
       

        public Assessment GetAssessmentsById(int CurrentUserId, int ID)
        {
            Assessment item = null;
            const string procName = "GET_ASSESSMENT_BY_ID";
            using (dbhAssessments = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessments.AddParameter("@ID", ID);
                dbhAssessments.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhAssessments.ExecuteReader(procName);
                while (dr.Read())
                {
                    item = new Assessment(dr);
                }
                dbhAssessments.Dispose();
            }
            return item;
        }
        public List<Question> GetAssessmentQuestions(int AssessmentId, int CurrentUserId)
        {
            List<Question> lst = new List<Question>();
            const string procName = "GET_ASSESSMENT_QUESTIONS";
            using (dbhAssessments = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessments.AddParameter("@ASSESSMENT_ID", AssessmentId);
                dbhAssessments.AddParameter("@CURRENTUSERID", CurrentUserId);
                IDataReader dr = dbhAssessments.ExecuteReader(procName);
                while (dr.Read())
                {
                    lst.Add(new Question(dr));
                }
                dbhAssessments.Dispose();
            }
            return lst;
        }

        public List<Question> SaveQuestions(int AssessmentID, int GROUPID, string QUESTIONLIST, string DISPLAYORDER, int CurrentUserId)
        {
            List<Question> lst = new List<Question>();
            using (dbhAssessments = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessments.AddParameter("@ASSESSMENT_ID", AssessmentID);
                dbhAssessments.AddParameter("@QUESTION_GROUP_ID", GROUPID);
                dbhAssessments.AddParameter("@QUESTIONS_LIST", QUESTIONLIST);
                dbhAssessments.AddParameter("@DISPLAY_ORDER", DISPLAYORDER);
                dbhAssessments.AddParameter("@CURRENTUSERID", CurrentUserId);

                IDataReader reader = dbhAssessments.ExecuteReader("INSERTUPDATE_ASSESSMENT_QUESTIONS");
                while (reader.Read())
                {
                    lst.Add(new Question(reader));
                }
            }
            return lst;
        }
    }
}
