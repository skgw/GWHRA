using System.Collections.Generic;
using System.Data;
using BaseCore;
using DAL;

namespace HRACore
{
    public class AssessmentGroupList
    {
        private DBHelper mAGL_DBHelper;
        private int mCurrentUserID;

        public AssessmentGroupList(int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
        }
        public List<AssessmentGroup> GetAssessmentGroups(string assessmentGroupName, bool assessmentGroupStatus)
        {
            List<AssessmentGroup> items = new List<AssessmentGroup>();
            const string procName = "GET_ASSESSMENT_GROUPS";
            using (mAGL_DBHelper = new DBHelper(ConnectionStrings.DefaultDBConnection, mCurrentUserID))
            {
                mAGL_DBHelper.AddParameter("@name", assessmentGroupName);
                mAGL_DBHelper.AddParameter("@status", (assessmentGroupStatus)?'A':'I');
                mAGL_DBHelper.AddParameter("@CurrentUserID", 1);
                IDataReader dr = mAGL_DBHelper.ExecuteReader(procName);
                while(dr.Read())
                {
                    items.Add(new AssessmentGroup(dr));
                }
                mAGL_DBHelper.Dispose();
            }
            return items;
        }
    }
}