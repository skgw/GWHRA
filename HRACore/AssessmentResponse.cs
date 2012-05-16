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
           
        }
        public void SaveFamilyResponses()
        {
            String Response = GetFamilyResponseXML();
            string procName = "INSERTUPDATE_FAMILY_RESPONSE";
            using (dbhAssessmentResponse = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessmentResponse.AddParameter("@CurrentUserID", this.mCurrentUserID);
                dbhAssessmentResponse.AddParameter("@ResponseXML", Response);
                dbhAssessmentResponse.AddParameter("@AssessmentID", this.AssessmentID);
                dbhAssessmentResponse.AddParameter("@SubscriberID", this.MemberMasterID);



                IDataReader dr = dbhAssessmentResponse.ExecuteReader(procName);

                dbhAssessmentResponse.Dispose();
            }
        }
        private string GetFamilyResponseXML ()
        {
            StringBuilder responseXML = new StringBuilder("<FAMILY_RESPONSE>");

            foreach (int id in this.MemberResponses.Keys)
            {
                string[] MemberIds = MemberResponses[id].Split(",".ToCharArray());
                for (int i=0; i < MemberIds.Length; i ++)
                {
                    responseXML.Append("<RESPONSE>");
                    responseXML.Append("<QUESTION_ID>" + id.ToString() + "</QUESTION_ID>");
                    responseXML.Append("<MEMBER_ID>" + MemberIds[i] + "</MEMBER_ID>");
                    responseXML.Append("</RESPONSE>");
                }
            }
            responseXML.Append("</FAMILY_RESPONSE>");
            return responseXML.ToString();
        }

    }
}
