using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseCore;
using System.Data;

namespace HRACore
{
    public class Member
    {
        private int mCurrentUserID;
        private DBHelper dbhMember;
        private int mSalutation;
        private string mFirstname;
        private string mLastname;
        private string mMiddleName;
        private int mSex;
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
        public int Sex
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
        public void LoadBasicInfo(IDataReader reader)
        {
            Salutation = Int32.Parse(reader[0].ToString());
            Firstname = reader[1].ToString();
            Middlename = reader[2].ToString();
            Lastname = reader[3].ToString();
            Ethnicity = Int32.Parse(reader[4].ToString());
            Height_Feet = Int32.Parse(reader[5].ToString());
            Height_Inches = Int32.Parse(reader[6].ToString());
            Weight = Int32.Parse(reader[7].ToString());
            Occupation = Int32.Parse(reader[8].ToString());
            MaritalStatus = Int32.Parse(reader[9].ToString());
            MemberID = reader[10].ToString();
            HICN = reader[11].ToString();
            Handedness = Int32.Parse(reader[12].ToString());
            Email = reader[13].ToString();
            Sex = Int32.Parse(reader[14].ToString());
            DOB = DateTime.Parse(reader[15].ToString());
        }
        
    }
}
