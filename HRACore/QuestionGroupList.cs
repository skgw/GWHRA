using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BaseCore;

namespace HRACore
{
    public class QuestionGroupList
    {
        public List<QuestionGroup> GetQuestionGroups(string Name)
        {
            List<QuestionGroup> items = new List<QuestionGroup>();
            string procName = "GET_QUESTIONGROUPS";
            using (DBHelper dbObj = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbObj.AddParameter("@name", Name);
                //DataSet ds = dbObj.ExecuteDataSet(procName);
                IDataReader dr = dbObj.ExecuteReader(procName);
                while (dr.Read())
                {
                    items.Add(new QuestionGroup(dr));
                }
            }
            return items;
        }

        public static QuestionGroup GetQuestionGroup_By_ID(int ID)
        {
            QuestionGroup obj = null;
            string procName = "GET_QUESTIONGROUPS_BY_ID";
            using (DBHelper dbObj = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbObj.AddParameter("@id", ID);
                IDataReader dr = dbObj.ExecuteReader(procName);
                while (dr.Read())
                {
                    obj = (new QuestionGroup(dr));
                }
            }
            return obj;
        }
    }
}