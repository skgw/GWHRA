using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseCore;
using System.Data;
using DAL;

namespace HRACore
{
    public class Member
    {
        private int mCurrentUserID;
        private int mID;
        private DBHelper dbhMember;
        private int mSalutation;
        private string mFirstname;
        private string mLastname;
        private string mMiddleName;
        private string mSex;
        private DateTime mDOB;
        private int mEthnicity;
        private int mHeight_Feet;
        private int mHeight_Inches;
        private int mWeight;
        private int mOccupation;
        private int mMaritalStatus;
        private string mMemberID;
        private string mHICN;
        private int mHandedness;
        private string mEmail;
        private Address mWorkAddress;
        private Address mHomeAddress;
        #region Public Properties

        public int Salutation
        {
            get
            {
                return mSalutation;
            }
            set
            {
                mSalutation = value;
            }
        }
        public string Firstname
        {
            get
            {
                return mFirstname;
            }
            set
            {
                mFirstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return mMiddleName;
            }
            set
            {
                mMiddleName = value;
            }
        }
        public string Lastname
        {
            get
            {
                return mLastname;
            }
            set
            {
                mLastname = value;
            }
        }
        public int Ethnicity
        {
            get
            {
                return mEthnicity;
            }
            set
            {
                mEthnicity = value;
            }
        }
        public int Height_Feet
        {
            get
            {
                return mHeight_Feet;
            }
            set
            {
                mHeight_Feet = value;
            }
        }
        public int Height_Inches
        {
            get
            {
                return mHeight_Inches;
            }
            set
            {
                mHeight_Inches = value;
            }
        }
        public int Weight
        {
            get
            {
                return mWeight;
            }
            set
            {
                mWeight = value;
            }
        }
        public int Occupation
        {
            get
            {
                return mOccupation;
            }
            set
            {
                mOccupation = value;
            }
        }
        public int MaritalStatus
        {
            get
            {
                return mMaritalStatus;
            }
            set
            {
                mMaritalStatus = value;
            }
        }
        public string MemberID
        {
            get
            {
                return mMemberID;
            }
            set
            {
                mMemberID = value;
            }
        }
        public string HICN
        {
            get
            {
                return mHICN;
            }
            set
            {
                mHICN = value;
            }
        }
        public int Handedness
        {
            get
            {
                return mHandedness;
            }
            set
            {
                mHandedness = value;
            }
        }
        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = value;
            }
        }
        public Address WorkAddress
        {
            get
            {
                return mWorkAddress;
            }
            set
            {
                mWorkAddress = value;
            }
        }
        public Address HomeAddress
        {
            get
            {
                return mHomeAddress;
            }
            set
            {
                mHomeAddress = value;
            }
        }
        public string Sex
        {
            get
            {
                return mSex;
            }
            set
            {
                mSex = value;
            }
        }
        public DateTime DOB
        {
            get
            {
                return mDOB;
            }
            set
            {
                mDOB = value;
            }
        }

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        #endregion

        public void LoadBasicInfo(IDataReader reader)
        {
            ID = Int32.Parse(reader[0].ToString());
            Salutation = Int32.Parse(reader[1].ToString());
            Firstname = reader[2].ToString();
            Middlename = reader[3].ToString();
            Lastname = reader[4].ToString();
            Ethnicity = Int32.Parse(reader[5].ToString());
            Height_Feet = Int32.Parse(reader[6].ToString());
            Height_Inches = Int32.Parse(reader[7].ToString());
            Weight = Int32.Parse(reader[8].ToString());
            Occupation = Int32.Parse(reader[9].ToString());
            MaritalStatus = Int32.Parse(reader[10].ToString());
            MemberID = reader[11].ToString();
            HICN = reader[12].ToString();
            Handedness = Int32.Parse(reader[13].ToString());
            Email = reader[14].ToString();
            Sex = reader[15].ToString();
            DOB = DateTime.Parse(reader[16].ToString());
        }
        public Member(int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
            HomeAddress = new Address(CurrentUserID);
            WorkAddress = new Address(CurrentUserID);
        }
        public Member(int MasterID, int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
            HomeAddress = new Address(CurrentUserID);
            WorkAddress = new Address(CurrentUserID);
            ID = MasterID;

            string procName = "GET_MEMBERDETAIL_BY_MASTER_ID";
            using (dbhMember = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhMember.AddParameter("@MemberMasterID", ID);
                dbhMember.AddParameter("@CURRENTUSERID", @mCurrentUserID);

                IDataReader reader = dbhMember.ExecuteReader(procName);
                while (reader.Read())
                {
                    LoadBasicInfo(reader);
                    if (reader.NextResult())
                    {

                        WorkAddress = new Address(reader);
                        if (reader.NextResult())
                        {
                            HomeAddress = new Address(reader);
                        }
                    }
                }
            }
        }
        public Member(string memberID, int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
            HomeAddress = new Address(CurrentUserID);
            WorkAddress = new Address(CurrentUserID);
            MemberID = memberID;

            string procName = "GET_MEMBER_BY_MEMBERID";
            using (dbhMember = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhMember.AddParameter("@MemberID", MemberID);
                dbhMember.AddParameter("@CURRENTUSERID", @mCurrentUserID);

                IDataReader reader = dbhMember.ExecuteReader(procName);
                while (reader.Read())
                {
                    LoadBasicInfo(reader);
                    reader.NextResult();
                    WorkAddress = new Address(reader);
                    reader.NextResult();
                    HomeAddress = new Address(reader);
                }
            }
        }
        public void Save()
        {
            using (dbhMember = new DBHelper(ConnectionStrings.DefaultDBConnection))
            {
                dbhMember.AddParameter("@ID", this.ID);
                dbhMember.AddParameter("@SALUTATION", this.Salutation);
                dbhMember.AddParameter("@FIRSTNAME", this.Firstname);
                dbhMember.AddParameter("@MIDDLENAME", this.Middlename);
                dbhMember.AddParameter("@LASTNAME", this.Lastname);
                dbhMember.AddParameter("@SEX", this.Sex);
                dbhMember.AddParameter("@MEMBER_ID", this.MemberID);
                dbhMember.AddParameter("@HICN", this.HICN);
                dbhMember.AddParameter("@SUBSCRIBER_ID", this.MemberID);
                dbhMember.AddParameter("@DOB", this.DOB);
                dbhMember.AddParameter("@EMAIL", this.Email);
                dbhMember.AddParameter("@ETHNICITY", this.Ethnicity);
                dbhMember.AddParameter("@MARITAL_STATUS", this.MaritalStatus);
                dbhMember.AddParameter("@HANDEDNESS", this.Handedness);
                dbhMember.AddParameter("@OCCUPATION", this.Occupation);
                dbhMember.AddParameter("@HEIGHT_FEET", this.Height_Feet);
                dbhMember.AddParameter("@HEIGHT_INCHES", this.Height_Inches);
                dbhMember.AddParameter("@WEIGHT_LBS", this.Weight);
                dbhMember.AddParameter("@WADDRESS1", this.WorkAddress.Address1);
                dbhMember.AddParameter("@WADDRESS2", this.WorkAddress.Address2);
                dbhMember.AddParameter("@WCITY", this.WorkAddress.City);
                dbhMember.AddParameter("@WSTATE", this.WorkAddress.State);
                dbhMember.AddParameter("@WZIPCODE", this.WorkAddress.Zipcode);
                dbhMember.AddParameter("@HADDRESS1", this.HomeAddress.Address1);
                dbhMember.AddParameter("@HADDRESS2", this.HomeAddress.Address2);
                dbhMember.AddParameter("@HCITY", this.HomeAddress.City);
                dbhMember.AddParameter("@HSTATE", this.HomeAddress.State);
                dbhMember.AddParameter("@HZIPCODE", this.HomeAddress.Zipcode);
                dbhMember.AddParameter("@CURRENTUSERID", mCurrentUserID);

                IDataReader reader = dbhMember.ExecuteReader("INSERTUPDATE_MEMBER_MASTER_INFO");
                while (reader.Read())
                {
                    ID = Convert.ToInt32(reader[0].ToString());
                    //LoadBasicInfo(reader);
                    //reader.NextResult();
                    //WorkAddress = new Address(reader);
                    //reader.NextResult();
                    //HomeAddress = new Address(reader);
                }
            }
        }

    }
}
