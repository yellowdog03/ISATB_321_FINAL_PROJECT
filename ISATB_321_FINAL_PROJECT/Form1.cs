using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

/*
    TODO:
        - Emrys: Resolve bug where inserting a new person does not display correct ID
        - James: Add Availability functionality
        - James: Availability time implementation
            - James: 15 minute intervals, Availability table lists each interval as it's own entry,
              Meetings table will have several entries with the same StudentID but diff AvailabilityID             
        - James: Add front-end to Manage Availability

    DONE:
        - Emrys: Add ListView to Add Person, Change Person, and Delete Person
            - Emrys: Remove View Advisors and View Students once done
 */

namespace ISATB_321_FINAL_PROJECT
{
    public partial class frmMain : Form
    {
        // Variables used across the entire form
        private Dictionary<int, clsAdvisors> dctAdvisors = new Dictionary<int, clsAdvisors>();

        private Dictionary<int, clsStudents> dctStudents = new Dictionary<int, clsStudents>();

        private DateTimePicker timePicker;



        // Necessary functions for the form to even load
        public frmMain()
        {
            InitializeComponent();

            // tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            timePicker.Location = new Point(25, 129);
            timePicker.Width = 284;
            Controls.Add(timePicker);



            populateAdvisorDictionary(ref dctAdvisors);
            refreshAdvisorsListview();
            personInformation_ClearTextboxes();

            populateStudentDictionary(ref dctStudents);
            refreshStudentsListview();
            personInformation_ClearTextboxes();


        }



        // Functions for loading and refreshing the Advisors and Students dictionaries
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

        private void refreshAdvisorsListview()
        {

            switch (tabMain.SelectedTab.Name)
            {
                case "tabPage6":
                    lsvAddPerson.Clear();
                    clsAdvisors newCurrentAdvisor = new clsAdvisors();
                    foreach (KeyValuePair<int, clsAdvisors> kvp in dctAdvisors)
                    {
                        newCurrentAdvisor = kvp.Value;
                        ListViewItem item = new ListViewItem(newCurrentAdvisor.AdvisorLName);
                        item.Tag = newCurrentAdvisor;
                        lsvAddPerson.Items.Add(item);
                    }
                    break;
                case "tabPage5":
                    lsvChangePerson.Clear();
                    clsAdvisors changeCurrentAdvisor = new clsAdvisors();
                    foreach (KeyValuePair<int, clsAdvisors> kvp in dctAdvisors)
                    {
                        changeCurrentAdvisor = kvp.Value;
                        ListViewItem item = new ListViewItem(changeCurrentAdvisor.AdvisorLName);
                        item.Tag = changeCurrentAdvisor;
                        lsvChangePerson.Items.Add(item);
                    }
                    break;
                case "tabPage8":
                    lsvDeletePerson.Clear();
                    clsAdvisors deleteCurrentAdvisor = new clsAdvisors();
                    foreach (KeyValuePair<int, clsAdvisors> kvp in dctAdvisors)
                    {
                        deleteCurrentAdvisor = kvp.Value;
                        ListViewItem item = new ListViewItem(deleteCurrentAdvisor.AdvisorLName);
                        item.Tag = deleteCurrentAdvisor;
                        lsvDeletePerson.Items.Add(item);
                    }
                    break;

            }

        }

        private void refreshStudentsListview()
        {

            switch (tabMain.SelectedTab.Name)
            {
                case "tabPage6":
                    lsvAddPerson.Clear();
                    clsStudents newCurrentStudent = new clsStudents();
                    foreach (KeyValuePair<int, clsStudents> kvp in dctStudents)
                    {
                        newCurrentStudent = kvp.Value;
                        ListViewItem item = new ListViewItem(newCurrentStudent.StudentLName);
                        item.Tag = newCurrentStudent;
                        lsvAddPerson.Items.Add(item);
                    }
                    break;
                case "tabPage5":
                    lsvChangePerson.Clear();
                    clsStudents changeCurrentStudent = new clsStudents();
                    foreach (KeyValuePair<int, clsStudents> kvp in dctStudents)
                    {
                        changeCurrentStudent = kvp.Value;
                        ListViewItem item = new ListViewItem(changeCurrentStudent.StudentLName);
                        item.Tag = changeCurrentStudent;
                        lsvChangePerson.Items.Add(item);
                    }
                    break;
                case "tabPage8":
                    lsvDeletePerson.Clear();
                    clsStudents deleteCurrentStudent = new clsStudents();
                    foreach (KeyValuePair<int, clsStudents> kvp in dctStudents)
                    {
                        deleteCurrentStudent = kvp.Value;
                        ListViewItem item = new ListViewItem(deleteCurrentStudent.StudentLName);
                        item.Tag = deleteCurrentStudent;
                        lsvDeletePerson.Items.Add(item);
                    }
                    break;
            }

        }



        // Updating the ListViews for Advisors and Students on Add Person, Change Person, and Delete Person
        // Insert Person
        private void radStudentNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radStudentNew.Checked == true)
            {

                refreshStudentsListview();

            }

        }

        private void radAdvisorNew_CheckedChanged(object sender, EventArgs e)
        {

            if (radAdvisorNew.Checked == true)
            {

                refreshAdvisorsListview();

            }

        }

        // Update Person
        private void radChangeStudent_CheckedChanged(object sender, EventArgs e)
        {

            if (radChangeStudent.Checked == true)
            {

                refreshStudentsListview();

            }

        }

        private void radChangeAdvisor_CheckedChanged(object sender, EventArgs e)
        {

            if (radChangeAdvisor.Checked == true)
            {

                refreshAdvisorsListview();

            }

        }

        // Delete Person
        private void radDeleteStudent_CheckedChanged(object sender, EventArgs e)
        {

            if (radDeleteStudent.Checked == true)
            {

                refreshStudentsListview();

            }

        }

        private void radDeleteAdvisor_CheckedChanged(object sender, EventArgs e)
        {

            if (radDeleteAdvisor.Checked == true)
            {

                refreshAdvisorsListview();

            }

        }


        // Functions for adding people
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

        private void btnSubmitNew_Click(object sender, EventArgs e)
        {

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {

                    if (radAdvisorNew.Checked)
                    {

                        clsAdvisors currentAdvisor = new clsAdvisors();

                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_GetAdvisor", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();

                        currentAdvisor.AdvisorFName = txtFNameNew.Text;
                        currentAdvisor.AdvisorLName = txtLNameNew.Text;
                        currentAdvisor.AdvisorEmail = txtEmailNew.Text;

                        if (InsertAdvisor(currentAdvisor) == true)
                        {

                            populateAdvisorDictionary(ref dctAdvisors);
                            refreshAdvisorsListview();

                            messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully added.");
                            personInformation_ClearTextboxes();

                        }
                        else
                        {
                            messageBoxOK("Creation failed for advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ").");
                        }
            ;

                    }
                    else if (radStudentNew.Checked)
                    {

                        clsStudents currentStudent = new clsStudents();


                        currentStudent.StudentFName = txtFNameNew.Text;
                        currentStudent.StudentLName = txtLNameNew.Text;


                        if (int.TryParse(txtYearNew.Text, out int year) && year >= 0 && year <= 4)
                        {
                            currentStudent.Year = year;
                        }
                        else
                        {
                            messageBoxOK("Invalid Year. Please enter a number between 0 and 4.");
                            txtYearNew.Focus();
                            return;
                        }

                        if (InsertStudent(currentStudent) == true)
                        {

                            populateStudentDictionary(ref dctStudents);
                            refreshStudentsListview();

                            messageBoxOK("The student (ID: " + currentStudent.StudentID.ToString() + ") successfully added.");
                            personInformation_ClearTextboxes();

                        }
                        else
                        {

                            messageBoxOK("Creation failed for student (ID: " + currentStudent.StudentID.ToString() + ").");

                        }
                    ;
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



        // Functions for updating people
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

        private void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            if (radChangeAdvisor.Checked == true)
            {

                clsAdvisors currentAdvisor = new clsAdvisors();

                if (int.TryParse(txtOldID.Text, out int AdvisorID))
                {
                    currentAdvisor.AdvisorID = AdvisorID;
                }
                else
                {
                    messageBoxOK("Invalid Advisor ID.");
                    txtOldID.Focus();
                }

                currentAdvisor.AdvisorFName = txtNewFName.Text;
                currentAdvisor.AdvisorLName = txtNewLName.Text;
                currentAdvisor.AdvisorEmail = txtNewEmail.Text;



                if (updateAdvisor(currentAdvisor) == true)
                {

                    populateAdvisorDictionary(ref dctAdvisors);
                    refreshAdvisorsListview();



                    messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully updated.");
                    personInformation_ClearTextboxes();



                }
                else
                {
                    messageBoxOK("Update Failed for advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ").");
                }
            ;
            }
            else if (radChangeStudent.Checked == true)
            {

                clsStudents currentStudent = new clsStudents();


                if (int.TryParse(txtOldID.Text, out int StudentID))
                {
                    currentStudent.StudentID = StudentID;
                }
                else
                {
                    messageBoxOK("Invalid Student ID.");
                    txtOldID.Focus();
                }





                currentStudent.StudentFName = txtNewFName.Text;
                currentStudent.StudentLName = txtNewLName.Text;




                if (int.TryParse(txtNewYear.Text, out int Year))
                {
                    currentStudent.Year = Year;
                }
                else
                {
                    messageBoxOK("Invalid Year.");
                    txtNewYear.Focus();
                    return;
                }

                if (updateStudent(currentStudent) == true)
                {

                    populateStudentDictionary(ref dctStudents);
                    refreshStudentsListview();



                    messageBoxOK("The student (ID: " + currentStudent.StudentID.ToString() + ") successfully updated.");
                    personInformation_ClearTextboxes();



                }
                else
                {
                    messageBoxOK("Update Failed for student (ID: " + currentStudent.StudentID.ToString() + ").");
                }
            ;


            }
        }



        // Functions used for deletion
        private bool deleteAdvisor(clsAdvisors delCurrentAdvisor)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteAdvisor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdvisorID", delCurrentAdvisor.AdvisorID);
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

        private bool deleteStudent(clsStudents delCurrentStudent)
        {

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", delCurrentStudent.StudentID);
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

        private void btnDeletePerson_Click(object sender, EventArgs e)
        {

            if (radDeleteAdvisor.Checked)
            {

                clsAdvisors currentAdvisor = new clsAdvisors();



                if (int.TryParse(txtPersonID.Text, out int AdvisorID))
                {
                    currentAdvisor.AdvisorID = AdvisorID;
                }
                else
                {
                    messageBoxOK("Invalid Advisor ID.");
                    txtPersonID.Focus();
                }

                currentAdvisor.AdvisorFName = txtDeleteFName.Text;
                currentAdvisor.AdvisorLName = txtDeleteLName.Text;
                currentAdvisor.AdvisorEmail = txtDeleteEmail.Text;




                if (deleteAdvisor(currentAdvisor) == true)
                {

                    messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully deleted.");

                    txtDeleteFName.Clear();

                    txtDeleteLName.Clear();

                    txtDeleteEmail.Clear();

                    txtPersonID.Clear();

                }
                else
                {

                    messageBoxOK("delete Failed for advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ").");

                }

            }
            else if (radDeleteStudent.Checked)
            {

                clsStudents currentStudent = new clsStudents();



                if (int.TryParse(txtPersonID.Text, out int StudentID))
                {
                    currentStudent.StudentID = StudentID;
                }
                else
                {
                    messageBoxOK("Invalid Student ID.");
                    txtPersonID.Focus();
                }

                currentStudent.StudentFName = txtStudentFName.Text;
                currentStudent.StudentLName = txtStudentLName.Text;


                if (int.TryParse(txtDeleteYear.Text, out int Year))
                {
                    currentStudent.Year = Year;
                }
                else
                {
                    messageBoxOK("Invalid Year.");
                    txtDeleteYear.Focus();
                    return;
                }
                //currentStudent.Year = txtYear.Text;

                // currentStudent.AdvisorEmail = txtAdvisorEmail.Text;




                if (deleteStudent(currentStudent) == true)
                {

                    populateStudentDictionary(ref dctStudents);
                    refreshStudentsListview();



                    messageBoxOK("The student (ID: " + currentStudent.StudentID.ToString() + ") successfully deleted.");
                    personInformation_ClearTextboxes();



                }
                else
                {
                    messageBoxOK("delete Failed for student (ID: " + currentStudent.StudentID.ToString() + ").");
                }
            ;

            }
            else
            {

                messageBoxOK("Delete failed. Please select Student or Advisor.");

            }



        }




        // Clear Form Functions
        private void personInformation_ClearTextboxes()
        {

            txtOldFName.Clear();

            txtOldLName.Clear();


            txtNewYear.Clear();

            txtNewFName.Clear();

            txtNewLName.Clear();

            txtNewEmail.Clear();







            /*            btnEditAdvisorInfo.Visible = true;
                        btnUpdateAdvisorInfo.Visible = false;
                        btnDeleteAdvisorInfo.Visible = false;
                        btnInsertAdvisorInfo.Visible = true;*/


        }

        private void btnChangePersonClearForm_Click(object sender, EventArgs e)
        {

            txtOldFName.Clear();

            txtOldLName.Clear();



            txtNewFName.Clear();

            txtNewLName.Clear();

            txtNewYear.Clear();

            txtNewEmail.Clear();



            if (radChangeStudent.Checked)
            {

                radChangeStudent.Checked = false;

            }
            if (radChangeAdvisor.Checked)
            {

                radChangeAdvisor.Checked = false;

            }


        }

        private void btnDeletePersonClearForm_Click(object sender, EventArgs e)
        {
            txtDeleteFName.Clear();

            txtDeleteLName.Clear();

            txtDeleteEmail.Clear();

            txtPersonID.Clear();
        }





        // DialogBoxes
        private void messageBoxOK(string msg)
        {
            MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DialogResult messageBoxYesNo(string msg)
        {
            return MessageBox.Show(msg, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

            messageBoxOK("The current tab is " + tabMain.SelectedTab + ".");

        }


    }
}
