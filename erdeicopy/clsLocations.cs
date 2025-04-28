using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class clsLocations
    {

        private int mLocationID;
        private string mDescription;


        public int LoactionID
        {
            get { return mLocationID; }
            set { mLocationID = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }








        public clsLocations() { }
    }
}
