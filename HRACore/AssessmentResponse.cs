using System;
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
            
        }
        
    }
}
