using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using BaseCore;
using DAL;

namespace BaseCore
{
    [Serializable]
    public class ModuleInfo
       
    {
        #region Business Methods

        /// <summary>
        /// Unique Identifier
        /// </summary>
        private Int64 mID;

        /// <summary>
        /// Indicates whether Module is enabled
        /// </summary>
        private bool mIsEnabled;

        /// <summary>
        /// Module name
        /// </summary>
        private string mName;

        private string mStatus;

        /// <summary>
        /// Gets or sets the Identity (Primary key)
        /// </summary>
        public Int64 ID
        {
            get
            {
              
                return mID;
            }

            set
            {
               
                mID = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the module
        /// </summary>
        public string Name
        {
            get
            {
               
                return mName;
            }

            set
            {
                
                mName = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsEnabled.
        /// </summary>
        /// <value>
        /// The is enabled.
        /// </value>
        public bool IsEnabled
        {
            get
            {
              
                return mIsEnabled;
            }

            set
            {
                
                mIsEnabled = value;
            }
        }
        /// <summary>
        /// Gets or sets a value status.
        /// </summary>
        /// <value>
        /// This is Active/Inactive.
        /// </value>
        public string Status
        {
            get
            {  return mStatus;  }

            set
            { mStatus = value; }
        }


        #endregion

        #region Factory Methods

        /// <summary>
        /// Prevents a default instance of the ModuleInfo class from being created.
        /// </summary>
        public ModuleInfo()
        {
            // Intentionally left blank to make use of factory methods.
        }

        /// <summary>
        /// Initializes a new instance of the ModuleInfo class (Overloaded constructor)
        /// </summary>
        /// <param name="rdr">
        /// Safe DataReader
        /// </param>
        public ModuleInfo(IDataReader rdr)
        {
          

            mID = rdr.GetInt64(rdr.GetOrdinal("ID"));
            mName = rdr.GetString(rdr.GetOrdinal("ModuleName"));
            // mDescription = rdr.GetString("Description");
            mIsEnabled = rdr.GetString(rdr.GetOrdinal("IsEnabled")).Equals("A");
            mStatus = rdr.GetString(rdr.GetOrdinal("Status"));
        }

        /// <summary>
        /// Return current ID
        /// </summary>
        /// <returns>ID (integer)</returns>
        protected object GetIdValue()
        {
            return mID;
        }

        /// <summary>
        /// Override the ToString() method
        /// </summary>
        /// <returns>returns the name of the module</returns>
        public override string ToString()
        {
            return mName;
        }

        /// <summary>
        /// Factory method to instantiate new ModuleInfo object
        /// </summary>
        /// <returns>an instance of ModuleInfo</returns>
        //public static ModuleInfo NewModuleInfo()
        //{
        //    return DataPortal.Create<ModuleInfo>(null);
        //}

        /// <summary>
        /// Overloaded factory method to instantiate new ModuleInfo object.
        /// </summary>
        /// <param name="dr">
        /// Safe DataReader
        /// </param>
        /// <returns>
        /// an instance of ModuleInfo
        /// </returns>
        public static ModuleInfo NewModuleInfo(IDataReader dr)
        {
            return new ModuleInfo(dr);
        }


        #endregion
    }
}
