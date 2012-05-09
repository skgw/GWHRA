using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace HRACore
{
    public class AssessmentResponse
    {
        private int mCurrentUserID = 0;
        private DBHelper dbhAssessmentResponse;

        public int MemberMasterID { get; set; }
        public int AssessmentID { get; set; }
        /// <summary>
        /// To save member responses as [MemberMasterID],[SelectedItemValue]
        /// For dropdown or radiobutton, use the value directly.
        /// for checkbox list, use the selected values as csv.
        /// for textbox/area, use the text as is.
        /// </summary>
        public Dictionary<int, string> MemberResponses;
        /// <summary>
        /// To save member responses as [MemberMasterID],[SelectedItemValue]
        /// For dropdown or radiobutton, use the value directly.
        /// for checkbox list, use the selected values as csv.
        /// for textbox/area, use the text as is.
        /// </summary>
        public Dictionary<int, string> FamilyResponses;

        public AssessmentResponse(int currentUserID)
        {
            mCurrentUserID = currentUserID;
        }
        public void SaveMemberResponses()
        {
            //foreach (int id in this.MemberResponses.Keys)
            //{
            //    int xyz = id;
            //}  

            
            string procName = "";
            using (dbhAssessmentResponse = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessmentResponse.AddParameter("@MemberMasterID", this.MemberMasterID);
                dbhAssessmentResponse.AddParameter("@assessment_id", this.AssessmentID);
                dbhAssessmentResponse.AddParameter("@ResponseList", this.MemberResponses);
                dbhAssessmentResponse.AddParameter("@CurrentUserID", this.mCurrentUserID);
                IDataReader dr = dbhAssessmentResponse.ExecuteReader(procName);

                dbhAssessmentResponse.Dispose();
            }
        }
        public void SaveFamilyResponses()
        {
            
        }
        
    }
}
