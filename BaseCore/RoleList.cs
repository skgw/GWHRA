using System;
using System.Collections.Generic;
using System.Data;
using DAL;

namespace BaseCore
{
    [Serializable]
    public class RoleList
    {
        private DBHelper dbhRole;
        public List<Role> GetRoles(Int32 roleId, Int32 CurrentUserId)
        {
            List<Role> items = new List<Role>();
            const string procName = "GET_ROLES";
            using (dbhRole = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhRole.AddParameter("@RoleId", roleId);
                dbhRole.AddParameter("@CurrentUserID", CurrentUserId);
                IDataReader dr = dbhRole.ExecuteReader(procName);
                while (dr.Read())
                {
                    items.Add(new Role(dr));
                }
                dbhRole.Dispose();
            }
            return items;
        }
    }
}
