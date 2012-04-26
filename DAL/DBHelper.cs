using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    [Serializable]
    public class DBHelper : IDisposable
    {
        public readonly List<SqlParameter> SqlParameters = new List<SqlParameter>();
        private readonly int currentUserID = -1;
        private string currentConnectionString = string.Empty;
        private SqlConnection currentSqlConnection;
        private SqlTransaction currentSqlTransation;

        #region Constructors

        /// <summary>
        /// Default Constructor connects to the Default Database
        /// </summary>
        public DBHelper()
        {
            OpenConnection(
                ConfigurationManager.ConnectionStrings[ConnectionStrings.DefaultDBConnection.ToString()].
                    ConnectionString);
        }

        /// <summary>
        /// Default Constructor connects to the Default Database with user ID
        /// </summary>
        /// <param name="userID"></param>
        public DBHelper(int userID)
        {
            currentUserID = userID;
            OpenConnection(
                ConfigurationManager.ConnectionStrings[ConnectionStrings.DefaultDBConnection.ToString()].
                    ConnectionString);
        }

        /// <summary>
        /// Initializes the SqlConnection with the connectionstring provided
        /// </summary>
        /// <param name="connStringsDB">Enum that define the connection string to use</param>
        public DBHelper(ConnectionStrings connStringsDB)
        {
            OpenConnection(ConfigurationManager.ConnectionStrings[connStringsDB.ToString()].ConnectionString);
        }

        /// <summary>
        ///  Constructor with connection string as enum value and user ID
        /// </summary>
        /// <param name="connStringsDB">Enum that define the connection string to use</param>
        /// <param name="userID">User ID</param>
        public DBHelper(ConnectionStrings connStringsDB, int userID)
        {
            currentUserID = userID;
            OpenConnection(ConfigurationManager.ConnectionStrings[connStringsDB.ToString()].ConnectionString);
        }

        /// <summary>
        /// Constructor with connection string and user ID
        /// </summary>
        /// <param name="connectionString">Connection string to use</param>
        /// <param name="userID"></param>
        public DBHelper(string connectionString, int userID)
        {
            currentUserID = userID;
            OpenConnection(connectionString);
        }

        /// <summary>
        /// Resource factory design time uses this constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public DBHelper(string connectionString)
        {
            OpenConnection(connectionString);
        }

        #endregion

        #region Misc

        public void Dispose()
        {
            DisposeConnection();
        }

        private void OpenConnection(string connectionString)
        {
            currentConnectionString = connectionString;
            currentSqlConnection = new SqlConnection(currentConnectionString);
            currentSqlConnection.Open();
        }

        /// <summary>
        /// Begins the current transaction
        /// </summary>
        public void BeginTransaction()
        {
            currentSqlTransation = currentSqlConnection.BeginTransaction();
        }

        /// <summary>
        /// Commits the current transactions and closes it
        /// </summary>
        public void Commit()
        {
            if (null != currentSqlTransation.Connection)
            {
                try
                {
                    currentSqlTransation.Commit();
                }
                finally
                {
                    currentSqlTransation.Dispose();
                }
            }
        }

        public void Rollback()
        {
            if (null != currentSqlTransation.Connection)
                try
                {
                    currentSqlTransation.Rollback();
                }
                finally
                {
                    currentSqlTransation.Dispose();
                }
        }


        private void DisposeConnection()
        {
            if (null != currentSqlConnection)
            {
                if (null != currentSqlTransation && null !=
                    currentSqlTransation.Connection)
                    Rollback();
                if (currentSqlConnection.State != ConnectionState.Closed)
                {
                    currentSqlConnection.Close();
                    currentSqlConnection.Dispose();
                }
            }
        }

        #endregion

        #region Add parameters

        public void AddParameter(string parameterName, SqlDbType dbType)
        {
            SqlParameters.Add(new SqlParameter(parameterName, dbType));
        }

        public void AddParameter(string parameterName, object obj)
        {
            SqlParameters.Add(new SqlParameter(parameterName, obj));
        }

        //       public void AddParameter(string parameterName, SqlDbType type,
        //ParameterDirection direction)
        //       {
        //           SqlParameters.Add(new SqlParameter((parameterName, type, direction));
        //       }


        public void AddParameter(string parameterName, object obj, ParameterDirection direction)
        {
            SqlParameter tmp = new SqlParameter(parameterName,obj);
            tmp.Direction = direction;
            SqlParameters.Add(tmp);            
        }

        public void AddParameter(string parameterName, SqlDbType type, int size)
        {
            SqlParameters.Add(new SqlParameter(parameterName,type, size));
        }

        #endregion

        #region Execute Reader

        public IDataReader ExecuteReader(string procedureName)
        {
            return ExecuteReader(procedureName, CommandBehavior.Default);
        }

     

        public IDataReader ExecuteReader(string procedureName, CommandBehavior commandBehavior)
        {
            return Execute(procedureName, ExecuteType.Reader, commandBehavior, false);
        }

        #endregion

        public int ExecuteCommand(string procedureName, bool closeConnection = true)
        {
            return Execute(procedureName, ExecuteType.Command, CommandBehavior.Default, closeConnection);
        }

        private dynamic Execute(string procedureName, ExecuteType returnType, CommandBehavior commandBehavior,
                                bool closeConnection = true)
        {
            dynamic returnObject = null;
            if (string.IsNullOrEmpty(procedureName))
                throw new
                    ArgumentNullException(procedureName, "Procedure name cannot be null or empty.");
            using (SqlCommand cmd = currentSqlConnection.CreateCommand())
            {
                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();


                //If currentuserId is passed in constructor it will add to DBHelper
               // if (-1 != currentUserID)
                    //SqlParameters.Add(new SqlParameter("@CurrentUserID", SqlDbType.Int, currentUserID));

                //adds refcursor to SqlParameters
                //CreateRefCursors(refCursorCount);

                //adds  parameters to command
                if (SqlParameters.Count > 0)
                {
                    foreach (SqlParameter parameter in SqlParameters)
                        cmd.Parameters.Add(parameter);
                }
               // cmd.Parameters.Add(new SqlParameter("@CurrentUserID", SqlDbType.Int, currentUserID));

                try
                {
                    switch (returnType)
                    {
                        case ExecuteType.Command:
                            {
                                returnObject = cmd.ExecuteNonQuery();
                                break;
                            }
                        case ExecuteType.Dataset:
                            {
                                var dataset = new DataSet();
                                var dataAdapter = new SqlDataAdapter(cmd);
                                dataAdapter.Fill(dataset);
                                returnObject = dataset;
                                break;
                            }
                        case ExecuteType.Reader:
                            {
                                returnObject =
                                    cmd.ExecuteReader(commandBehavior);
                                break;
                            }
                    }
                }
                finally
                {
                    if (closeConnection)
                        DisposeConnection();
                }
            }
            return returnObject;
        }

        #region Helpers

        /// <summary>
        /// Returns output parameter value
        /// </summary>
        /// <typeparam name="T">type to be converted</typeparam>
        /// <param name="sqlParameterName">Name of the parameter</param>
        /// <returns></returns>
        public T GetOutputParameterValue<T>(string sqlParameterName)
        {
            SqlParameter oraPar = SqlParameters.Single(e => e.ParameterName == sqlParameterName);
            if (null == oraPar)
            {
                return default(T);
            }
            return (T) Convert.ChangeType(oraPar.Value.ToString(), typeof (T));
        }

        public void ClearParameters()
        {
            SqlParameters.Clear();
        }

        #region Indexbased reader conversions

        /// <summary>
        ///  Gets the string value of the specific field  from the reader
        /// </summary>
        /// <param name="reader">source reader to fetch the value from</param>
        /// <param name="index">Zero based column index</param>
        /// <param name="defaultEmptyValue">Default null value to be assigned</param>
        /// <returns></returns>
        public static string GetStringByIndex(IDataRecord
                                                  reader, int index, string defaultEmptyValue)
        {
            return (DBNull.Value == reader[index])
                       ? defaultEmptyValue
                       : (reader[index]).ToString();
        }

        /// <summary>
        /// Gets the string value of the specific field  from the reader
        /// </summary>
        /// <param name="reader">source reader to fetch the value from</param>
        /// <param name="index">Zero based column index</param>
        /// <returns></returns>
        public static string GetStringByIndex(IDataRecord
                                                  reader, int index)
        {
            return GetStringByIndex(reader, index, string.Empty);
        }

        /// <summary>
        /// Gets the integer value of the specific field  from the reader
        /// </summary>
        /// <param name="reader">source reader</param>
        /// <param name="index">Zero based column index</param>
        /// <returns></returns>
        public static int
            GetIntegerValueByIndex(IDataRecord reader, int index)
        {
            int returnValue = 0;
            int.TryParse(GetStringByIndex(reader, index), out returnValue);
            return returnValue;
        }

        /// <summary>
        /// Gets the long value of the specific field  from the reader
        /// </summary>
        /// <param name="reader">source reader</param>
        /// <param name="index">Zero based column index</param>
        /// <returns></returns>
        public static Int64
            GetLongValueByIndex(IDataRecord reader, int index)
        {
            Int64 returnValue = 0;
            Int64.TryParse(GetStringByIndex(reader, index), out returnValue);
            return returnValue;
        }

        /// <summary>
        /// Gets the datetime value of the specific field  from the reader
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="index">Zero based column index</param>
        /// <returns></returns>
        public static DateTime
            GetDateValueByIndex(IDataRecord reader, int index)
        {
            DateTime returnValue;
            DateTime.TryParse(GetStringByIndex(reader, index), out returnValue);
            return returnValue;
        }

        /// <summary>
        /// Gets the string decimal of the specific field  from the reader
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="index">Zero based column index</param>
        /// <returns></returns>
        public static decimal
            GetDecimalValueByIndex(IDataRecord reader, int index)
        {
            decimal returnValue = 0;
            decimal.TryParse(GetStringByIndex(reader, index), out returnValue);
            return returnValue;
        }

        /// <summary>
        /// Gets the Boolean value of the specific field  from the reader
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="index">Zero based column index</param>
        /// <returns></returns>
        public static bool
            GetBooleanValueByIndex(IDataRecord reader, int index)
        {
            //bool ReturnValue = false;
            //bool.TryParse(GetStringByIndex(reader, index), out ReturnValue);
            return (GetIntegerValueByIndex(reader, index) == 1);
        }

        #endregion

        //private void CreateRefCursors(Int16 refCursorCount)
        //{
        //    for (Int16 i = 1; i <= refCursorCount; i++)
        //    {
        //        AddRefCursorToParameters("IO_REFCURSOR_" + i);
        //    }
        //}

        //private void AddRefCursorToParameters(string refCursorName)
        //{
        //    SqlParameters.Add(new SqlParameter(refCursorName, SqlDbType.RefCursor, ParameterDirection.InputOutput));
        //}

        #endregion

        #region  ExecuteDataset

        public DataSet ExecuteDataSet(string procedureName)
        {
            return Execute(procedureName, ExecuteType.Dataset, CommandBehavior.Default, false);
        }

        //       public DataSet ExecuteDataSet(string procedureName, Int16
        //refCursorCount)
        //       {
        //           return Execute(procedureName, refCursorCount,
        //ExecuteType.Dataset, CommandBehavior.Default, false);

        //       }

        #endregion
    }

    public enum ExecuteType
    {
        Command,
        Dataset,
        Reader
    }


    //public enum SqlDbType
    //{
    //    BFile = 101,
    //    Blob = 102,
    //    Byte = 103,
    //    Char = 104,
    //    Clob = 105,
    //    Date = 106,
    //    Decimal = 107,
    //    Double = 108,
    //    Long = 109,
    //    LongRaw = 110,
    //    Int16 = 111,
    //    Int32 = 112,
    //    Int64 = 113,
    //    IntervalDS = 114,
    //    IntervalYM = 115,
    //    NClob = 116,
    //    NChar = 117,
    //    NVarchar2 = 119,
    //    Raw = 120,
    //    RefCursor = 121,
    //    Single = 122,
    //    TimeStamp = 123,
    //    TimeStampLTZ = 124,
    //    TimeStampTZ = 125,
    //    Varchar2 = 126,
    //    XmlType = 127,
    //    Array = 128,
    //    Object = 129,
    //    Ref = 130,
    //    BinaryDouble = 132,
    //    BinaryFloat = 133,
    //}
}