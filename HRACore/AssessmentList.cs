using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BaseCore;

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
    }
}
