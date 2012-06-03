using System;
using System.Collections.Generic;
using System.Data;
using DAL;

namespace BaseCore
{
    [Serializable]
    public class Role
    {
        #region Private members
        private int mID = -1;
        private string mName = string.Empty;
        private string mDescription = string.Empty;
        private char mStatus;
        private string _mHomepage = string.Empty;

        #endregion

        #region Public properties
        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string Name {
            get { return mName; }
            set { mName = value; }
        }
        public string Description {
            get { return mDescription; }
            set { mDescription = value; }
        }
        public char Status {
            get { return mStatus; }
            set { mStatus = value ;}
        }
        public string Homepage
        {
            get { return _mHomepage; }
            set { _mHomepage = value; }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo"/> class.
        /// </summary>
        /// <param name="rdr">The RDR.</param>
        public Role(IDataReader dr)
        {
            LoadRole(dr);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo"/> class.
        /// </summary>
        public Role()
        {
            
        }
        #endregion
        #region Methods
            private void LoadRole (IDataReader dr) {
                ID = Int32.Parse(dr[0].ToString());
                Name = dr[1].ToString();
                Description = dr[2].ToString();
                Status = Convert.ToChar(dr[3].ToString());
                Homepage = dr[4].ToString();
            }
        #endregion
    }
}
