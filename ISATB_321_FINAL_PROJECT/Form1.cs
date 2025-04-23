using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace ISATB_321_FINAL_PROJECT
{
    public partial class frmMain : Form
    {

        private Dictionary<int, clsAdvisors> dctAdvisors = new Dictionary<int, clsAdvisors>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            

        }

        private void messageBoxOK(string msg)
        {
            MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            string conString = clsEmrysDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Students";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dctAdvisors.Clear();

                        while (rdr.Read() == true)
                        {
                            //                  clsAdvisors currentAdvisor = new clsAdvisors();
                            //                  currentAdvisor.AdvisorID = (int)rdr["AdvisorID"];
                            //                  currentAdvisor.AdvisorFName = clsEmrysDBUtil.convertFromDBType_VarcharToString(rdr["AdvisorFName"]);
                            //                  currentAdvisor.AdvisorLName = clsEmrysDBUtil.convertFromDBType_VarcharToString(rdr["AdvisorLName"]);
                            //                  currentAdvisor.AdvisorEmail = clsEmrysDBUtil.convertFromDBType_VarcharToString(rdr["AdvisorEmail"]);

                                
                            //                  dctAdvisors.Add(currentAdvisor.AdvisorID, currentAdvisor);

                            lstStudentView.Items.Add(rdr["StudentFName, StudentLName, Year, AdvisorID"]);


                        }

                    }

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
