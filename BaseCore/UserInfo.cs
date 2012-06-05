using System;
using System.Collections.Generic;
using System.Data;
using DAL;

namespace BaseCore
{
    [Serializable]
    public class UserInfo
    {
        #region Private members

        private List<int> _mAuthorizedOperations = new List<int>();
        private string _mEmail;
        private string _mFirstname;
        private string _mHomepage = string.Empty;
        private DateTime _mLastLoginDate = DateTime.Now;

        private string _mLastname;
        private string _mNpi;

        private Int64 _mRoleID;

        private string _mRoleName;
        private int _mUserID;
        private string _mUsername;
        private Boolean _mIsLocked;

        #endregion

        #region Public properties

        public string Email
        {
            get { return _mEmail; }

            set
            {
                if (value == null)

                    value = string.Empty;

                if (_mEmail != value)
                {
                    _mEmail = value;
                }
            }
        }

        public int UserID
        {
            get { return _mUserID; }

            set
            {
                if (_mUserID != value)
                {
                    _mUserID = value;
                }
            }
        }

        public string Firstname
        {
            get { return _mFirstname; }

            set
            {
                if (value == null)

                    value = string.Empty;

                if (_mFirstname != value)
                {
                    _mFirstname = value;
                }
            }
        }

        public string Lastname
        {
            get { return _mLastname; }

            set
            {
                if (value == null)

                    value = string.Empty;

                if (_mLastname != value)
                {
                    _mLastname = value;
                }
            }
        }

        public Int64 RoleID
        {
            get { return _mRoleID; }

            set
            {
                if (_mRoleID != value)
                {
                    _mRoleID = value;
                }
            }
        }

        public string Username
        {
            get { return _mUsername; }

            set
            {
                if (value == null)

                    value = string.Empty;


                _mUsername = value;
            }
        }

        public DateTime LastLoginDate
        {
            get { return _mLastLoginDate; }

            set
            {
                if (_mLastLoginDate != value)
                {
                    _mLastLoginDate = value;
                }
            }
        }

        public string RoleName
        {
            get { return _mRoleName; }

            set
            {
                if (value == null)

                    value = string.Empty;

                if (_mRoleName != value)
                {
                    _mRoleName = value;
                }
            }
        }

        public string Homepage
        {
            get { return _mHomepage; }

            set { _mHomepage = value; }
        }

        public List<int> AuthorizedOperations
        {
            get { return _mAuthorizedOperations; }

            set { _mAuthorizedOperations = value; }
        }

        public Boolean IsLocked
        {
            get { return _mIsLocked; }

            set
            {
                if (_mIsLocked != value)
                {
                    _mIsLocked = value;
                }
            }
        }
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo"/> class.
        /// </summary>
        /// <param name="rdr">The RDR.</param>
        public UserInfo(IDataReader rdr)
        {
            Fetch(rdr);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo"/> class.
        /// </summary>
        public UserInfo()
        {
            //Initialize data

            UserID = -1;

            Firstname = string.Empty;

            Lastname = string.Empty;

            RoleID = 1;

            Username = string.Empty;

            Email = string.Empty;

            RoleName = string.Empty;

            Homepage = string.Empty;

            AuthorizedOperations = new List<int>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines whether [is null or empty].
        /// </summary>
        /// <returns>
        ///       <c>true</c> if [is null or empty]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsNullOrEmpty()
        {
            return ((UserID <= 0) || (string.IsNullOrEmpty(Firstname)) || string.IsNullOrEmpty(Lastname) ||
                    string.IsNullOrEmpty(Username));
        }


        /// <summary>
        /// Gets the id value.
        /// </summary>
        /// <returns></returns>
        protected object GetIdValue()
        {
            return UserID;
        }


        /// <summary>
        /// Fetches the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void Fetch(IDataReader reader)
        {
            UserID = DBNull.Value == reader["UserID"] ? 0 : Convert.ToInt32(reader["UserID"].ToString());

            Username = DBNull.Value == reader["Username"] ? string.Empty : (reader["Username"].ToString());

            Firstname = DBNull.Value == reader["Firstname"] ? string.Empty : (reader["Firstname"].ToString());

            Lastname = DBNull.Value == reader["Lastname"] ? string.Empty : (reader["Lastname"].ToString());

            RoleID = DBNull.Value == reader["RoleID"] ? 0 : Convert.ToInt64(reader["RoleID"].ToString());

            LastLoginDate = DBNull.Value == reader["LASTLOGINDATE"]
                                ? DateTime.Now
                                : Convert.ToDateTime(reader["LASTLOGINDATE"].ToString());

            Email = DBNull.Value == reader["Email"] ? string.Empty : (reader["Email"].ToString());

            RoleName = DBNull.Value == reader["RoleName"] ? string.Empty : (reader["RoleName"].ToString());

            Homepage = DBNull.Value == reader["Homepage"] ? string.Empty : (reader["Homepage"].ToString());


            string[] tmpAuthOperations = DBNull.Value == reader["AuthorizedOperations"]
                                             ? null
                                             : reader["AuthorizedOperations"].ToString().Split(',');

            //    ((OracleString)rdr.GetString(rdr.GetOrdinal("AuthorizedOperations"))).IsNull ? null : rdr.GetString(rdr.GetOrdinal("AuthorizedOperations")).Split(',');

            if (null != tmpAuthOperations)
            {
                foreach (string currentOperation in tmpAuthOperations)
                {
                    AuthorizedOperations.Add(Int32.Parse(currentOperation));
                }
            }
            IsLocked = DBNull.Value == reader["IsLockedOut"] ? false : (Boolean) reader["IsLockedOut"];
        }


        /// <summary>
        /// Accesses the check.
        /// </summary>
        /// <param name="currentOperation">The current operation.</param>
        /// <returns></returns>
        //public bool AccessCheck(Operations currentOperation)
        //{
        //    return this.AuthorizedOperations.Contains(Convert.ToInt32(currentOperation));
        //}
        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="currentUserID">The current user ID.</param>
        public void GetUserInfo(string username, int currentUserID)
        {
            using (DBHelper dl = new DBHelper(ConnectionStrings.DefaultDBConnection, currentUserID))
            {
                try
                {
                    dl.AddParameter("@username", username);
                    dl.AddParameter("@currentuserid", currentUserID);

                    using (IDataReader reader = dl.ExecuteReader("GET_USERINFO"))
                    {
                        while (reader.Read())
                        {
                            Fetch(reader);
                        }
                    }
                }

                finally
                {
                    dl.Dispose();
                }
            }
        }


        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <returns></returns>
        internal static UserInfo GetUserInfo(IDataReader dr)
        {
            return new UserInfo(dr);
        }


        /// <summary>
        /// Determines whether [is valid username] [the specified m user name].
        /// </summary>
        /// <param name="mUserName">Name of the m user.</param>
        /// <param name="currentUserID">The current user ID.</param>
        /// <returns>
        ///       <c>true</c> if [is valid username] [the specified m user name]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidUsername(String mUserName, int currentUserID)
        {
            bool validUser = false;


            using (var dl = new DBHelper(ConnectionStrings.DefaultDBConnection, currentUserID))
            {
                try
                {
                    dl.AddParameter("@username", mUserName);
                    IDataReader reader = dl.ExecuteReader("VALIDATE_USERNAME");
                    if (reader.Read())
                    {
                        validUser = string.IsNullOrEmpty(reader["IsValidUser"].ToString()) ? false : true;
                    }

                }

                finally
                {
                    dl.Dispose();
                }
            }
            return validUser;
        }


        #endregion
    }
}