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
            String Response = GetMemberResponseXML();
            string procName = "INSERTUPDATE_MEMBER_RESPONSE";
            using (dbhAssessmentResponse = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhAssessmentResponse.AddParameter("@CurrentUserID", this.mCurrentUserID);
                dbhAssessmentResponse.AddParameter("@ResponseXML", Response);
                dbhAssessmentResponse.AddParameter("@AssessmentID", this.AssessmentID);
                dbhAssessmentResponse.AddParameter("@MemberMasterID", this.MemberMasterID);
                IDataReader dr = dbhAssessmentResponse.ExecuteReader(procName);
                dbhAssessmentResponse.Dispose();
            }
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
        private string GetMemberResponseXML()
        {
            StringBuilder responseXML = new StringBuilder("<MEMBER_RESPONSE>");
            foreach (KeyValuePair<int, string> item in this.MemberResponses)
            {
                responseXML.Append("<RESPONSE>");
                responseXML.Append("<QUESTION_ID>" + item.Key.ToString() + "</QUESTION_ID>");
                responseXML.Append("<ANSWER>" + item.Value.ToString() + "</ANSWER>");
                responseXML.Append("</RESPONSE>");
            }
            responseXML.Append("</MEMBER_RESPONSE>");
            return responseXML.ToString();
        }
        private string GetFamilyResponseXML ()
        {
            StringBuilder responseXML = new StringBuilder("<FAMILY_RESPONSE>");

            foreach (int id in this.FamilyResponses.Keys)
            {
                string[] MemberIds = FamilyResponses[id].Split(",".ToCharArray());
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

        public List<Tuple<int, int>> GetFamilyHRAResponse(int MemberMasterID, int AssessmentId, int CurrentUserID)
        {
            List<Tuple<int, int>> lst = new List<Tuple<int, int>>();
            mCurrentUserID = CurrentUserID;
            using (dbhAssessmentResponse = new DBHelper(ConnectionStrings.DefaultDBConnection, mCurrentUserID))
            {
                dbhAssessmentResponse.AddParameter("@MemberMasterID", MemberMasterID);
                dbhAssessmentResponse.AddParameter("@assessment_id", AssessmentId);
                dbhAssessmentResponse.AddParameter("@CurrentUserID", mCurrentUserID);
                IDataReader reader = dbhAssessmentResponse.ExecuteReader("GET_FAMILY_HRA_RESPONSES");
                while (reader.Read())
                {
                    lst.Add(Tuple.Create<int, int>(Convert.ToInt32(reader["MEMBER_MASTER_ID_REF"]), Convert.ToInt32(reader["FAM_QUESTION_ID_REF"])));
                }
            }
            return lst;
        }
        public List<Tuple<int, string>> GetMemberHRAResponse(int MemberMasterID, int AssessmentId, int CurrentUserID)
        {
            List<Tuple<int, string>> lst = new List<Tuple<int, string>>();
            mCurrentUserID = CurrentUserID;
            using (dbhAssessmentResponse = new DBHelper(ConnectionStrings.DefaultDBConnection, mCurrentUserID))
            {
                dbhAssessmentResponse.AddParameter("@MemberMasterID", MemberMasterID);
                dbhAssessmentResponse.AddParameter("@assessment_id", AssessmentId);
                dbhAssessmentResponse.AddParameter("@CURRENTUSERID", mCurrentUserID);
                IDataReader reader = dbhAssessmentResponse.ExecuteReader("GET_MEMBER_HRA_RESPONSES");
                while (reader.Read())
                {
                    lst.Add(Tuple.Create<int, string>(Convert.ToInt32(reader["QUESTION_ID_REF"]), reader["RESPONSE"].ToString()));
                }
            }
            return lst;
        }
    }
}
