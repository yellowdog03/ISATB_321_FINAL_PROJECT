// Developer:       Erdei, Ronald
// Last Updated:    2025.04.16


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

       
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            populatePetDictionary(ref dctAdvisors);
            refreshPetsListview();
            petInformation_Update_ClearTextboxes();

            populateStudentDictionary(ref dctStudents);
            refreshStudentsListview();
            studentInformation_Update_ClearTextboxes();



        }
        
        private void populatePetDictionary(ref Dictionary<int, clsAdvisors> dctAdvisors)
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
        
        private bool updatePet(clsAdvisors currentAdvisor)
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
        
        private void refreshPetsListview()
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
        
        private void lvwPets_Update_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection itemIsSelected = lvwAdvisors.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsAdvisors currentAdvisor = (clsAdvisors)item.Tag;
                displayPetInformation_update(currentAdvisor);
            }
        }
        
        private void displayPetInformation_update(clsAdvisors currentAdvisor)
        {
            txtAdvisorID.Text = currentAdvisor.AdvisorID.ToString();
            txtAdvisorFName.Text = currentAdvisor.AdvisorFName;
            txtAdvisorLName.Text = currentAdvisor.AdvisorLName;
            txtAdvisorEmail.Text = currentAdvisor.AdvisorEmail;    //.ToString();

        }
        
        
        private void petInformation_Update_ClearTextboxes()
        {
            txtAdvisorID.Clear();
            txtAdvisorID.ReadOnly = true;

            txtAdvisorFName.Clear();
            txtAdvisorFName.ReadOnly = true;

            txtAdvisorLName.Clear();
            txtAdvisorLName.ReadOnly = true;

            txtAdvisorEmail.Clear();
            txtAdvisorEmail.ReadOnly = true;


            

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

        private void btnEditPetInfo_Click(object sender, EventArgs e)
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

        
        private void btnUpdatePetInfo_Click(object sender, EventArgs e)
        {
            clsAdvisors currentAdvisor = new clsAdvisors();

            #region Validate user input & assigning to Pet properties

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



            if (updatePet(currentAdvisor) == true)
            {

                populatePetDictionary(ref dctAdvisors);
                refreshPetsListview();



                messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully updated.");
                petInformation_Update_ClearTextboxes();



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

                populatePetDictionary(ref dctAdvisors);
                refreshPetsListview();



                messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully deleted.");
                petInformation_Update_ClearTextboxes();



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

                populatePetDictionary(ref dctAdvisors);
                refreshPetsListview();



                messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully updated.");
                petInformation_Update_ClearTextboxes();



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

                populatePetDictionary(ref dctAdvisors);
                refreshPetsListview();



                messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully updated.");
                petInformation_Update_ClearTextboxes();



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

            #region Validate user input & assigning to Pet properties

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

}