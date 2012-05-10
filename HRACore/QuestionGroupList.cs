using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BaseCore;
using DAL;

namespace HRACore
{
    public class QuestionGroupList
    {
        public List<QuestionGroup> GetQuestionGroups(string questionGroupName,char qGroupStatus, int CurrentUserID)
        {
            List<QuestionGroup> items = new List<QuestionGroup>();
            const string procName = "GET_QUESTIONGROUPS";
            using (DBHelper dbObj = new DBHelper(ConnectionStrings.DefaultDBConnection,1))
            {
                dbObj.AddParameter("@name",questionGroupName);
                dbObj.AddParameter("@status", qGroupStatus);
                dbObj.AddParameter("@CurrentUserID", CurrentUserID);
                IDataReader dr = dbObj.ExecuteReader(procName);
                while (dr.Read())
                {
                    items.Add(new QuestionGroup(dr));
                }
            }
            return items;
        }

    
    }
}