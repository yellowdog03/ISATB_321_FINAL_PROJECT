using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ISATB_321_FINAL_PROJECT
{
    internal class clsEmrysDBUtil
    {

        public static string getConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "<< database server location here >>";
            builder.InitialCatalog = "ISATB_320_Quick_Emrys";
            builder.UserID = "B321_S25_APP";
            builder.Password = "<<B33pB00p>>";
            builder.Encrypt = false;

            return builder.ConnectionString.ToString();
        }

        #region Private Helper Methods: Data-to-C# Conversion
        public static string convertFromDBType_DateTimeToString(object obj)
        {
            if ((obj == null) || DBNull.Value.Equals(obj))
            {
                return string.Empty;
            }
            else
            {
                DateTime temp = (DateTime)obj;
                return temp.ToString();
            }
        }

        public static int convertFromDBType_IntToInt(object obj, int seed)
        {
            if ((obj == null) || DBNull.Value.Equals(obj))
            {
                return seed;
            }
            else
            {
                int temp = (int)obj;
                return temp;
            }
        }

        public static string convertFromDBType_VarcharToString(object obj)
        {
            if ((obj == null) || DBNull.Value.Equals(obj))
            {
                return string.Empty;
            }
            else
            {
                return (string)obj;
            }
        }

        #endregion



    }
}
