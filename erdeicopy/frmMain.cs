// Developer:       Plant, James
// Last Updated:    2025.04.20


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        private Dictionary<int, clsAdvisors> dctAdvisors = new Dictionary<int, clsAdvisors>();

        private Dictionary<int, clsStudents> dctStudents = new Dictionary<int, clsStudents>();

        private Dictionary<int, clsAvailability> dctAvailability = new Dictionary<int, clsAvailability>();

        public frmMain()
        {
            InitializeComponent();
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            populateAdvisorDictionary(ref dctAdvisors);
            refreshAdvisorsListview();
            advisorInformation_Update_ClearTextboxes();

            populateStudentDictionary(ref dctStudents);
            refreshStudentsListview();
            studentInformation_Update_ClearTextboxes();

            populateAvailabilityDictionary(ref dctAvailability);
            refreshAvailabilityListview();
            availabilityInformation_Update_ClearTextboxes();

        }


        //ADVISORS*******************************************************************************************************************************************


        
        private void populateAdvisorDictionary(ref Dictionary<int, clsAdvisors> dctAdvisors)
        {

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetAdvisor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dctAdvisors.Clear();

                        while (rdr.Read() == true)
                        {
                            clsAdvisors currentAdvisor = new clsAdvisors();
                            currentAdvisor.AdvisorID = (int)rdr["AdvisorID"];
                            currentAdvisor.AdvisorFName = clsDBUtil.convertFromDBType_VarcharToString(rdr["AdvisorFName"]);
                            currentAdvisor.AdvisorLName = clsDBUtil.convertFromDBType_VarcharToString(rdr["AdvisorLName"]);
                            currentAdvisor.AdvisorEmail = clsDBUtil.convertFromDBType_VarcharToString(rdr["AdvisorEmail"]);


                            dctAdvisors.Add(currentAdvisor.AdvisorID, currentAdvisor);
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
        
        private bool updateAdvisor(clsAdvisors currentAdvisor)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateAdvisor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdvisorID", currentAdvisor.AdvisorID);
                    cmd.Parameters.AddWithValue("@AdvisorFName", currentAdvisor.AdvisorFName);
                    cmd.Parameters.AddWithValue("@AdvisorLName", currentAdvisor.AdvisorLName);
                    cmd.Parameters.AddWithValue("@AdvisorEmail", currentAdvisor.AdvisorEmail);


                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        
        private void refreshAdvisorsListview()
        {
            // REMEMBER: the View property of the listview must be set to 'List'
            lvwAdvisors.Clear();
            clsAdvisors currentAdvisor = new clsAdvisors();
            foreach (KeyValuePair<int, clsAdvisors> kvp in dctAdvisors)
            {
                currentAdvisor = kvp.Value;
                ListViewItem item = new ListViewItem(currentAdvisor.AdvisorLName);
                item.Tag = currentAdvisor;
                lvwAdvisors.Items.Add(item);
            }
        }
        
        private void lvwAdvisors_Update_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection itemIsSelected = lvwAdvisors.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsAdvisors currentAdvisor = (clsAdvisors)item.Tag;
                displayAdvisorInformation_update(currentAdvisor);
            }
        }
        
        private void displayAdvisorInformation_update(clsAdvisors currentAdvisor)
        {
            txtAdvisorID.Text = currentAdvisor.AdvisorID.ToString();
            txtAdvisorFName.Text = currentAdvisor.AdvisorFName;
            txtAdvisorLName.Text = currentAdvisor.AdvisorLName;
            txtAdvisorEmail.Text = currentAdvisor.AdvisorEmail;    //.ToString();

        }
        
        
        private void advisorInformation_Update_ClearTextboxes()
        {
            txtAdvisorID.Clear();
            txtAdvisorID.ReadOnly = true;

            txtAdvisorFName.Clear();
            txtAdvisorFName.ReadOnly = true;

            txtAdvisorLName.Clear();
            txtAdvisorLName.ReadOnly = true;

            txtAdvisorEmail.Clear();
            txtAdvisorEmail.ReadOnly = true;


            txtAdvisorIDInsert.Clear();

            txtAdvisorFNameInsert.Clear();

            txtAdvisorLNameInsert.Clear();

            txtAdvisorEmailInsert.Clear();







            btnEditAdvisorInfo.Visible = true;
            btnUpdateAdvisorInfo.Visible = false;
            btnDeleteAdvisorInfo.Visible = false;
            btnInsertAdvisorInfo.Visible = true;


        }
        


        #region Private Helper Methods: general purpose

        private void messageBoxOK(string msg)
        {
            MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DialogResult messageBoxYesNo(string msg)
        {
            return MessageBox.Show(msg, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        #endregion

        private void btnEditAdvisorInfo_Click(object sender, EventArgs e)
        {
            if (txtAdvisorID.Text == "")
            {
                return;
            }

            txtAdvisorFName.ReadOnly = false;
            txtAdvisorLName.ReadOnly = false;
            txtAdvisorEmail.ReadOnly = false;
            

            btnEditAdvisorInfo.Visible = false;
            btnUpdateAdvisorInfo.Visible = true;
            btnDeleteAdvisorInfo.Visible = true;
        }



        

        #region edit delete insert

        
        private void btnUpdateAdvisorInfo_Click(object sender, EventArgs e)
        {
            clsAdvisors currentAdvisor = new clsAdvisors();

            #region Validate user input & assigning to Advisor properties

            if (int.TryParse(txtAdvisorID.Text, out int AdvisorID))
            {
                currentAdvisor.AdvisorID = AdvisorID;
            }
            else
            {
                messageBoxOK("Invalid Advisor ID.");
                txtAdvisorID.Focus();
            }

            currentAdvisor.AdvisorFName = txtAdvisorFName.Text;
            currentAdvisor.AdvisorLName = txtAdvisorLName.Text;
            currentAdvisor.AdvisorEmail = txtAdvisorEmail.Text;




            /*
            if (txtAdvisorEmail.Text == "")
            {
                currentAdvisor.AdvisorEmail = "";
            }
            else if (DateTime.TryParse(txtAdvisorEmail.Text, out DateTime BirthDate))
            {
                currentAdvisor.AdvisorEmail = txtAdvisorEmail.Text;
            }
            else 
            {
                messageBoxOK("Invalid Birth Date.");
                txtAdvisorEmail.Focus();
            }
            */
            /*
            if (Double.TryParse(txtWeight.Text, out double Weight))
            {
                currentAdvisor.Weight = Weight;
            }
            else
            {
                messageBoxOK("Invalid Weight.");
                txtWeight.Focus();
            }
            */
            #endregion



            if (updateAdvisor(currentAdvisor) == true)
            {

                populateAdvisorDictionary(ref dctAdvisors);
                refreshAdvisorsListview();



                messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully updated.");
                advisorInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("Update Failed for advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ").");
            }
            ;


        }






        private bool deleteAdvisor(clsAdvisors currentAdvisor)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteAdvisor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdvisorID", currentAdvisor.AdvisorID);
                    /*
                    cmd.Parameters.AddWithValue("@AdvisorFName", currentAdvisor.AdvisorFName);
                    cmd.Parameters.AddWithValue("@AdvisorLName", currentAdvisor.AdvisorLName);
                    cmd.Parameters.AddWithValue("@AdvisorEmail", currentAdvisor.AdvisorEmail);
                    */

                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }







        private void btnDelete_Click(object sender, EventArgs e)
        {


            /*
            if (txtAdvisorID.Text == "")
            {
                return;
            }
            string query = "Delete from Advisors where AdvisorID= '" + txtAdvisorID.Text + "'";
            */


            clsAdvisors currentAdvisor = new clsAdvisors();



            if (int.TryParse(txtAdvisorID.Text, out int AdvisorID))
            {
                currentAdvisor.AdvisorID = AdvisorID;
            }
            else
            {
                messageBoxOK("Invalid Advisor ID.");
                txtAdvisorID.Focus();
            }

            currentAdvisor.AdvisorFName = txtAdvisorFName.Text;
            currentAdvisor.AdvisorLName = txtAdvisorLName.Text;
            currentAdvisor.AdvisorEmail = txtAdvisorEmail.Text;




            if (deleteAdvisor(currentAdvisor) == true)
            {

                populateAdvisorDictionary(ref dctAdvisors);
                refreshAdvisorsListview();



                messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully deleted.");
                advisorInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("delete Failed for advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ").");
            }
            ;
        }


        private bool InsertAdvisor(clsAdvisors currentAdvisor)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertAdvisor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@AdvisorID", currentAdvisor.AdvisorID);

                    cmd.Parameters.AddWithValue("@AdvisorFName", currentAdvisor.AdvisorFName);
                    cmd.Parameters.AddWithValue("@AdvisorLName", currentAdvisor.AdvisorLName);
                    cmd.Parameters.AddWithValue("@AdvisorEmail", currentAdvisor.AdvisorEmail);


                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }




        private void btnInsertAdvisorInfo_Click(object sender, EventArgs e)
        {


            clsAdvisors currentAdvisor = new clsAdvisors();

            

            if (int.TryParse(txtAdvisorID.Text, out int AdvisorID))
            {
                currentAdvisor.AdvisorID = AdvisorID;
            }
            else
            {
                messageBoxOK("Invalid Advisor ID.");
                txtAdvisorID.Focus();
            }

            currentAdvisor.AdvisorFName = txtAdvisorFNameInsert.Text;
            currentAdvisor.AdvisorLName = txtAdvisorLNameInsert.Text;
            currentAdvisor.AdvisorEmail = txtAdvisorEmailInsert.Text;




            if (InsertAdvisor(currentAdvisor) == true)
            {

                populateAdvisorDictionary(ref dctAdvisors);
                refreshAdvisorsListview();



                messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully updated.");
                advisorInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("Update Failed for advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ").");
            }
            ;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertAdvisorInfo_Click_1(object sender, EventArgs e)
        {






            clsAdvisors currentAdvisor = new clsAdvisors();


            /*
            if (int.TryParse(txtAdvisorID.Text, out int AdvisorID))
            {
                currentAdvisor.AdvisorID = AdvisorID;
            }
            else
            {
                messageBoxOK("Invalid Advisor ID.");
                txtAdvisorID.Focus();
            }
            */

            currentAdvisor.AdvisorFName = txtAdvisorFNameInsert.Text;
            currentAdvisor.AdvisorLName = txtAdvisorLNameInsert.Text;
            currentAdvisor.AdvisorEmail = txtAdvisorEmailInsert.Text;




            if (InsertAdvisor(currentAdvisor) == true)
            {

                populateAdvisorDictionary(ref dctAdvisors);
                refreshAdvisorsListview();



                messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully updated.");
                advisorInformation_Update_ClearTextboxes();



            }

            else
            {
                messageBoxOK("Update Failed for advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ").");
            }
            ;
        }
        #endregion




        //STUDENTS*****************************************************************************************************************************************






        private void populateStudentDictionary(ref Dictionary<int, clsStudents> dctStudents)
        {

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dctStudents.Clear();

                        while (rdr.Read() == true)
                        {
                            clsStudents currentStudent = new clsStudents();
                            currentStudent.StudentID = (int)rdr["StudentID"];
                            currentStudent.StudentFName = clsDBUtil.convertFromDBType_VarcharToString(rdr["StudentFName"]);
                            currentStudent.StudentLName = clsDBUtil.convertFromDBType_VarcharToString(rdr["StudentLName"]);
                            currentStudent.Year = (int)rdr["Year"];


                            dctStudents.Add(currentStudent.StudentID, currentStudent);
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



        private bool updateStudent(clsStudents currentStudent)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", currentStudent.StudentID);
                    cmd.Parameters.AddWithValue("@StudentFName", currentStudent.StudentFName);
                    cmd.Parameters.AddWithValue("@StudentLName", currentStudent.StudentLName);
                    cmd.Parameters.AddWithValue("@Year", currentStudent.Year);


                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }



        private void refreshStudentsListview()
        {
            // REMEMBER: the View property of the listview must be set to 'List'
            lvwStudents.Clear();
            clsStudents currentStudent = new clsStudents();
            foreach (KeyValuePair<int, clsStudents> kvp in dctStudents)
            {
                currentStudent = kvp.Value;
                ListViewItem item = new ListViewItem(currentStudent.StudentLName);
                item.Tag = currentStudent;
                lvwStudents.Items.Add(item);
            }
        }




        private void lvwStudents_Update_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection itemIsSelected = lvwStudents.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsStudents currentStudent = (clsStudents)item.Tag;
                displayStudentInformation_update(currentStudent);
            }
        }

        private void displayStudentInformation_update(clsStudents currentStudent)
        {
            txtStudentID.Text = currentStudent.StudentID.ToString();
            txtStudentFName.Text = currentStudent.StudentFName;
            txtStudentLName.Text = currentStudent.StudentLName;
            txtYear.Text = currentStudent.Year.ToString();

        }

        private void studentInformation_Update_ClearTextboxes()
        {
            txtStudentID.Clear();
            txtStudentID.ReadOnly = true;

            txtStudentFName.Clear();
            txtStudentFName.ReadOnly = true;

            txtStudentLName.Clear();
            txtStudentLName.ReadOnly = true;

            txtYear.Clear();
            txtYear.ReadOnly = true;

            txtStudentIDInsert.Clear();
            

            txtStudentFNameInsert.Clear();
            

            txtStudentLNameInsert.Clear();
            

            txtYearInsert.Clear();
           




            /*
            txtWeight.Clear();
            txtWeight.ReadOnly = true;
            */

            btnStudentEdit.Visible = true;
            btnStudentUpdate.Visible = false;
            btnStudentDelete.Visible = false;
            //btnInsertAdvisorInfo.Visible = true;


        }



        private void btnStudentEdit_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                return;
            }

            txtStudentFName.ReadOnly = false;
            txtStudentLName.ReadOnly = false;
            txtYear.ReadOnly = false;

            btnStudentEdit.Visible = false;
            btnStudentUpdate.Visible = true;
            btnStudentDelete.Visible = true;

        }

        private void btnStudentUpdate_Click(object sender, EventArgs e)
        {
            clsStudents currentStudent = new clsStudents();

            #region Validate user input & assigning to Advisor properties

            if (int.TryParse(txtStudentID.Text, out int StudentID))
            {
                currentStudent.StudentID = StudentID;
            }
            else
            {
                messageBoxOK("Invalid Student ID.");
                txtAdvisorID.Focus();
            }





            currentStudent.StudentFName = txtStudentFName.Text;
            currentStudent.StudentLName = txtStudentLName.Text;




            if (int.TryParse(txtYear.Text, out int Year))
            {
                currentStudent.Year = Year;
            }
            else
            {
                messageBoxOK("Invalid Year.");
                txtYear.Focus();
                return;
            }




            #endregion



            if (updateStudent(currentStudent) == true)
            {

                populateStudentDictionary(ref dctStudents);
                refreshStudentsListview();



                messageBoxOK("The student (ID: " + currentStudent.StudentID.ToString() + ") successfully updated.");
                studentInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("Update Failed for student (ID: " + currentStudent.StudentID.ToString() + ").");
            }
            ;

        }



        private bool deleteStudent(clsStudents currentStudent)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", currentStudent.StudentID);
                    /*
                    cmd.Parameters.AddWithValue("@AdvisorFName", currentAdvisor.AdvisorFName);
                    cmd.Parameters.AddWithValue("@AdvisorLName", currentAdvisor.AdvisorLName);
                    cmd.Parameters.AddWithValue("@AdvisorEmail", currentAdvisor.AdvisorEmail);
                    */

                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }









        private bool InsertStudent(clsStudents currentStudent)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@AdvisorID", currentAdvisor.AdvisorID);

                    cmd.Parameters.AddWithValue("@StudentFName", currentStudent.StudentFName);
                    cmd.Parameters.AddWithValue("@StudentLName", currentStudent.StudentLName);
                    cmd.Parameters.AddWithValue("@Year", currentStudent.Year);


                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;
                
                }
                finally
                {
                    conn.Close();
                }
            }

        }




        private void btnInsertStudentInfo_Click_1(object sender, EventArgs e)
        {

            clsStudents currentStudent = new clsStudents();


          
            currentStudent.StudentFName = txtStudentFNameInsert.Text;
            currentStudent.StudentLName = txtStudentLNameInsert.Text;



           


            if (int.TryParse(txtYearInsert.Text, out int year) && year >= 0 && year <= 4)
            {
                currentStudent.Year = year;
            }
            else
            {
                messageBoxOK("Invalid Year. Please enter a number between 0 and 4.");
                txtYear.Focus();
                return;
            }




            if (InsertStudent(currentStudent) == true)
            {

                populateStudentDictionary(ref dctStudents);
                refreshStudentsListview();



                messageBoxOK("The student (ID: " + currentStudent.StudentID.ToString() + ") successfully updated.");
                studentInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("Update Failed for student (ID: " + currentStudent.StudentID.ToString() + ").");
            }
            ;


        }

        private void btnStudentDelete_Click(object sender, EventArgs e)
        {

            clsStudents currentStudent = new clsStudents();



            if (int.TryParse(txtStudentID.Text, out int StudentID))
            {
                currentStudent.StudentID = StudentID;
            }
            else
            {
                messageBoxOK("Invalid Student ID.");
                txtStudentID.Focus();
            }

            currentStudent.StudentFName = txtStudentFName.Text;
            currentStudent.StudentLName = txtStudentLName.Text;


            if (int.TryParse(txtYear.Text, out int Year))
            {
                currentStudent.Year = Year;
            }
            else
            {
                messageBoxOK("Invalid Year.");
                txtYear.Focus();
                return;
            }
            //currentStudent.Year = txtYear.Text;

            // currentStudent.AdvisorEmail = txtAdvisorEmail.Text;




            if (deleteStudent(currentStudent) == true)
            {

                populateStudentDictionary(ref dctStudents);
                refreshStudentsListview();



                messageBoxOK("The advisor (ID: " + currentStudent.StudentID.ToString() + ") successfully deleted.");
                studentInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("delete Failed for student (ID: " + currentStudent.StudentID.ToString() + ").");
            }
            ;
        }

    }



    //Availability*****************************************************************************************************






            private void populateAvailabilityDictionary(ref Dictionary<int, clsAvailability> dctAvailability)
        {

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetAvailability", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dctAvailability.Clear();

                        while (rdr.Read() == true)
                        {
                            clsAvailability currentAvailability = new clsAvailability();
                            currentAvailability.AvailabilityID = (int)rdr["AvailabilityID"];
                            currentAvailability.AdvisorID = (int)rdr["AdvisorID"];
                            //currentAvailability.Date = clsDBUtil.convertFromDBType_DateTimeToString(rdr["Date"]);
                            //Date in the SQL database has been changed into DateTime from DATE and probably should not saty this way.
                            //It was only changed so this would possibly work
                            currentAvailability.Date = (DateTime)rdr["Date"];
                            currentAvailability.TimeID = (int)rdr["TimeID"];
                            currentAvailability.LocationID = (int)rdr["LocationID"];
                            currentAvailability.IsTaken = (bool)rdr["IsTaken"];


                            dctAvailability.Add(currentAvailability.AvailabilityID, currentAvailability);
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



        private bool updateAvailability(clsAvailability currentAvailability)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateAvailability", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AvailabilityID", currentAvailability.AvailabilityID);
                    cmd.Parameters.AddWithValue("@AdvisorID", currentAvailability.AdvisorID);
                    cmd.Parameters.AddWithValue("@Date", currentAvailability.Date);
                    cmd.Parameters.AddWithValue("@TimeID", currentAvailability.TimeID);
                    cmd.Parameters.AddWithValue("@LocationID", currentAvailability.LocationID);
                    cmd.Parameters.AddWithValue("@IsTaken", currentAvailability.IsTaken);


                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }



        private void refreshAvailabilityListview()
        {
            // REMEMBER: the View property of the listview must be set to 'List'
            lvwAvailability.Clear();
            clsAvailability currentAvailability = new clsAvailability();
            foreach (KeyValuePair<int, clsAvailability> kvp in dctAvailability)
            {
                currentAvailability = kvp.Value;
                ListViewItem item = new ListViewItem(Convert.ToString(currentAvailability.AvailabilityID));//currentAvailability.AvailabilityID);
                item.Tag = currentAvailability;
                lvwAvailability.Items.Add(item);
            }
        }




        private void lvwAvailability_Update_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection itemIsSelected = lvwAvailability.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsAvailability currentAvailability = (clsAvailability)item.Tag;
                displayAvailabilityInformation_update(currentAvailability);
            }
        }

        private void displayAvailabilityInformation_update(clsAvailability currentAvailability)
        {
            txtAvailabilityID.Text = currentAvailability.AvailabilityID.ToString();
            txtAdvisorID.Text = currentAvailability.AdvisorID.ToString();
            txtDate.Text = currentAvailability.Date.ToString();
            txtTime.Text = currentAvailability.TimeID.ToString();
            txtLocationID.Text = currentAvailability.LocationID.ToString();
            


        }

        private void availabilityInformation_Update_ClearTextboxes()
        {
            txtAvailabilityID.Clear();
            txtAvailabilityID.ReadOnly = true;

            txtAdvisorID.Clear();
            txtAdvisorID.ReadOnly = true;

            txtDate.Clear();
            txtDate.ReadOnly = true;

            txtTime.Clear();
            txtTime.ReadOnly = true;

            txtLocationID.Clear();
            txtLocationID.ReadOnly = true;

        



            txtStudentIDInsert.Clear();


            txtStudentFNameInsert.Clear();


            txtStudentLNameInsert.Clear();


            txtYearInsert.Clear();





            /*
            txtWeight.Clear();
            txtWeight.ReadOnly = true;
            */

            btnStudentEdit.Visible = true;
            btnStudentUpdate.Visible = false;
            btnStudentDelete.Visible = false;
            //btnInsertAdvisorInfo.Visible = true;


        }


        private void btnStudentEdit_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                return;
            }

            txtStudentFName.ReadOnly = false;
            txtStudentLName.ReadOnly = false;
            txtYear.ReadOnly = false;

            btnStudentEdit.Visible = false;
            btnStudentUpdate.Visible = true;
            btnStudentDelete.Visible = true;

        }

        private void btnStudentUpdate_Click(object sender, EventArgs e)
        {
            clsStudents currentAvailability = new clsStudents();

            #region Validate user input & assigning to Advisor properties

            if (int.TryParse(txtStudentID.Text, out int StudentID))
            {
                currentAvailability.StudentID = StudentID;
            }
            else
            {
                messageBoxOK("Invalid Student ID.");
                txtAdvisorID.Focus();
            }





            currentAvailability.StudentFName = txtStudentFName.Text;
            currentAvailability.StudentLName = txtStudentLName.Text;




            if (int.TryParse(txtYear.Text, out int Year))
            {
                currentAvailability.Year = Year;
            }
            else
            {
                messageBoxOK("Invalid Year.");
                txtYear.Focus();
                return;
            }




            #endregion



            if (updateAvailability(currentAvailability) == true)
            {

                populateStudentDictionary(ref dctAvailability);
                refreshStudentsListview();



                messageBoxOK("The student (ID: " + currentAvailability.StudentID.ToString() + ") successfully updated.");
                studentInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("Update Failed for student (ID: " + currentAvailability.StudentID.ToString() + ").");
            }
            ;

        }



        private bool deleteStudent(clsStudents currentAvailability)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", currentAvailability.StudentID);
                    /*
                    cmd.Parameters.AddWithValue("@AdvisorFName", currentAdvisor.AdvisorFName);
                    cmd.Parameters.AddWithValue("@AdvisorLName", currentAdvisor.AdvisorLName);
                    cmd.Parameters.AddWithValue("@AdvisorEmail", currentAdvisor.AdvisorEmail);
                    */
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }









        private bool InsertStudent(clsStudents currentAvailability)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@AdvisorID", currentAdvisor.AdvisorID);

                    cmd.Parameters.AddWithValue("@StudentFName", currentAvailability.StudentFName);
                    cmd.Parameters.AddWithValue("@StudentLName", currentAvailability.StudentLName);
                    cmd.Parameters.AddWithValue("@Year", currentAvailability.Year);


                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    messageBoxOK(ex.Message);
                    return false;

                }
                finally
                {
                    conn.Close();
                }
            }

        }




        private void btnInsertStudentInfo_Click_1(object sender, EventArgs e)
        {

            clsStudents currentAvailability = new clsStudents();



            currentAvailability.StudentFName = txtStudentFNameInsert.Text;
            currentAvailability.StudentLName = txtStudentLNameInsert.Text;






            if (int.TryParse(txtYearInsert.Text, out int year) && year >= 0 && year <= 4)
            {
                currentAvailability.Year = year;
            }
            else
            {
                messageBoxOK("Invalid Year. Please enter a number between 0 and 4.");
                txtYear.Focus();
                return;
            }




            if (InsertAvailability(currentAvailability) == true)
            {

                populateStudentDictionary(ref dctAvailability);
                refreshStudentsListview();



                messageBoxOK("The student (ID: " + currentAvailability.StudentID.ToString() + ") successfully updated.");
                studentInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("Update Failed for student (ID: " + currentAvailability.StudentID.ToString() + ").");
            }
            ;


        }

        private void btnStudentDelete_Click(object sender, EventArgs e)
        {

            clsStudents currentAvailability = new clsStudents();



            if (int.TryParse(txtStudentID.Text, out int StudentID))
            {
                currentAvailability.StudentID = StudentID;
            }
            else
            {
                messageBoxOK("Invalid Student ID.");
                txtStudentID.Focus();
            }

            currentAvailability.StudentFName = txtStudentFName.Text;
            currentAvailability.StudentLName = txtStudentLName.Text;


            if (int.TryParse(txtYear.Text, out int Year))
            {
                currentAvailability.Year = Year;
            }
            else
            {
                messageBoxOK("Invalid Year.");
                txtYear.Focus();
                return;
            }
            //currentStudent.Year = txtYear.Text;

            // currentStudent.AdvisorEmail = txtAdvisorEmail.Text;




            if (deleteAvailability(currentAvailability) == true)
            {

                populateStudentDictionary(ref dctAvailability);
                refreshStudentsListview();



                messageBoxOK("The advisor (ID: " + currentAvailability.StudentID.ToString() + ") successfully deleted.");
                studentInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("delete Failed for student (ID: " + currentAvailability.StudentID.ToString() + ").");
            }
            ;
        }


    }
















































}




//MEETINGS******************************************************************************************************



