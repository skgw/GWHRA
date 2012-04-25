using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace HRACore
{
    public class Address
    {
        private int mCurrentUserID;
        private int mAddressType;
        private string mAddress1;
        private string mAddress2;
        private string mCity;
        private string mState;
        private string mZipCode;

        public int AddressType
        {
            get { return mAddressType; }
            set
            {
                mAddressType = value;
            }
        }
        public string Address1
        {
            get
            {
                return mAddress1;
            }
            set
            {
                mAddress1 = value;
            }
        }
        public string Address2
        {
            get
            {
                return mAddress2;
            }
            set
            {
                mAddress2 = value;
            }
        }
        public string City
        {
            get
            {
                return mCity;
            }
            set
            {
                mCity = value;
            }
        }
        public string State
        {
            get { return mState; }
            set { mState = value; }
        }
        public string Zipcode
        {
            get { return mZipCode; }
            set { mZipCode = value; }
        }
        public void LoadReader(IDataReader reader)
        {
            AddressType = Int32.Parse(reader[0].ToString());
            Address1 = reader[1].ToString();
            Address2 = reader[2].ToString();
            City = reader[3].ToString();
            State = reader[4].ToString();
            Zipcode = reader[5].ToString();
        }
        public Address(int CurrentUserID)
        {
            mCurrentUserID = CurrentUserID;
        }
        public Address(IDataReader reader)
        {
            LoadReader(reader);
        }
    }

}
