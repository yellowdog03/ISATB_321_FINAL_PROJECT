using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class clsAvailability
    {
        private int mAvailabilityID;
        private int mAdvisorID;
        //private DateTime mDate;
        private DateTime mDate;
        private int mTime;
        private int mLocationID;
        private bool mIsTaken;





        public int AvailabilityID
        {
            get { return mAvailabilityID; }
            set { mAvailabilityID = value; }
        }


        public int AdvisorID
        {
            get { return mAdvisorID; }
            set { mAdvisorID = value; }
        }
        /*
        public DateTime Date
        {
            get { return mDate; }
            set { mDate = value; }
        }
        */

        public DateTime Date
        {
            get { return mDate; }
            set { mDate = value; }
        }

        public int TimeID
        {
            get { return mTime; }
            set { mTime = value; }
        }

        public int LocationID
        {
            get { return mLocationID; }
            set { mLocationID = value; }
        }

        public bool IsTaken
        {
            get { return mIsTaken; }
            set { mIsTaken = value; }
        }



        //public DateTime Date { get; }




        public clsAvailability() { }

    }
}
