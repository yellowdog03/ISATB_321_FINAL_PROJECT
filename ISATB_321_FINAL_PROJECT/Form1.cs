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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using ISATB_321_FINAL_PROJECT;


namespace ISATB_321_FINAL_PROJECT
{
    public partial class frmMain : Form
    {
        // Dictionaries
        private Dictionary<int, clsAdvisors> dctAdvisors = new Dictionary<int, clsAdvisors>();

        private Dictionary<int, clsStudents> dctStudents = new Dictionary<int, clsStudents>();

        private Dictionary<int, clsAvailability> dctAvailability = new Dictionary<int, clsAvailability>();

        private Dictionary<int, clsMeetings> dctMeetings = new Dictionary<int, clsMeetings>();

        private Dictionary<int, clsTimes> dctTimes = new Dictionary<int, clsTimes>();

        // ComboBox Class Definition
        public class ComboBoxItem
        {
            public string DisplayText { get; }
            public object Value { get; }

            public ComboBoxItem(string text, object value)
            {
                DisplayText = text;
                Value = value;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }



        // Necessary functions for the form to even load
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            populateAdvisorDictionary(ref dctAdvisors);
            refreshAdvisorsListview();
            personInformation_ClearTextboxes();

            populateStudentDictionary(ref dctStudents);
            refreshStudentsListview();
            personInformation_ClearTextboxes();

            populateAvailabilityDictionary(ref dctAvailability);
            refreshAvailabilityListView();

            populateStudentsComboBox();
            populateAvailabilityComboBox();

            populateMeetingDictionary(ref dctMeetings);
            refreshMeetingsListView();

            populateTimesDictionary(ref dctTimes);
            populateTimeComboBox();

        }




        // Functions for populating the textboxes
        private void displayAdvisorInformation_Update(clsAdvisors currentAdvisor)
        {
            txtOldID.Text = currentAdvisor.AdvisorID.ToString();
            txtOldFName.Text = currentAdvisor.AdvisorFName;
            txtOldLName.Text = currentAdvisor.AdvisorLName;
            txtOldEmail.Text = currentAdvisor.AdvisorEmail;    //.ToString();

        }

        private void displayStudentInformation_Update(clsStudents currentStudent)
        {

            txtOldID.Text = currentStudent.StudentID.ToString();
            txtOldFName.Text = currentStudent.StudentFName;
            txtOldLName.Text = currentStudent.StudentLName;
            txtOldYear.Text = currentStudent.Year.ToString();

        }

        private void displayAdvisorInformation_Delete(clsAdvisors currentAdvisor)
        {
            txtPersonID.Text = currentAdvisor.AdvisorID.ToString();
            txtDeleteFName.Text = currentAdvisor.AdvisorFName;
            txtDeleteLName.Text = currentAdvisor.AdvisorLName;
            txtDeleteEmail.Text = currentAdvisor.AdvisorEmail;    //.ToString();
        }

        private void displayStudentInformation_Delete(clsStudents currentStudent)
        {

            txtPersonID.Text = currentStudent.StudentID.ToString();
            txtDeleteFName.Text = currentStudent.StudentFName;
            txtDeleteLName.Text = currentStudent.StudentLName;
            txtDeleteYear.Text = currentStudent.Year.ToString();

        }

        private void displayAvailabilityInformation_Update(clsAvailability currentAvailability)
        {

            txtAvailabilityIDChange.Text = currentAvailability.AvailabilityID.ToString();
            txtAdvisorIDChange.Text = currentAvailability.AdvisorID.ToString();
            txtOldDateChange.Text = currentAvailability.Date.ToString();
            txtOldTimeChange.Text = currentAvailability.TimeID.ToString();
            txtOldLocationChange.Text = currentAvailability.LocationID.ToString();

        }

        private void displayAvailabilityInformation_Delete(clsAvailability currentAvailability)
        {

            txtAvailabilityIDDelete.Text = currentAvailability.AvailabilityID.ToString();
            txtAdvisorIDDelete.Text = currentAvailability.AdvisorID.ToString();
            txtDateDelete.Text = currentAvailability.Date.ToString();
            txtTimeDelete.Text = currentAvailability.TimeID.ToString();
            txtLocationDelete.Text = currentAvailability.LocationID.ToString();

        }

        private void displayMeetingInformation_Update(clsMeetings currentMeeting)
        {

            txtChangeApptApptID.Text = currentMeeting.MeetingID.ToString();
            txtChangeApptStudentID.Text = currentMeeting.StudentID.ToString();
            txtChangeApptOldAvailabilityID.Text = currentMeeting.AvailabilityID.ToString();

        }

        private void displayMeetingInformation_Delete(clsMeetings currentDeleteMeeting)
        {

            txtDeleteAppointmentID.Text = currentDeleteMeeting.MeetingID.ToString();
            txtDeleteApptStudentID.Text = currentDeleteMeeting.StudentID.ToString();
            txtDeleteApptAvailabilityID.Text = currentDeleteMeeting.AvailabilityID.ToString();

        }

        private void displayMeetingInformation_update(clsMeetings currentMeeting)
        {

            //txtMeetingID.Text = currentMeeting.MeetingID.ToString();
            txtMeetStudentID.Text = currentMeeting.StudentID.ToString();
            txtMeetAvailabilityID.Text = currentMeeting.AvailabilityID.ToString();

        }



        // Populating Comboboxes
        private void populateTimeComboBox()
        {
            cboTimeBrowse.Items.Clear();
            foreach (var currentTime in dctTimes.Values)
            {
                cboTimeBrowse.Items.Add(new ComboBoxItem(currentTime.StartTime + " - " + currentTime.EndTime, currentTime));
            }
        }
        
        private void populateAvailabilityComboBox()
        {
            cboAvailabilityBrowse.Items.Clear();

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {

                conn.Open();



                foreach (var currentAvailability in dctAvailability.Values)
                {

                    SqlCommand cmdGetTimeOfAvailability = new SqlCommand("SELECT dbo.fnGetTimeOfAvailability(@AvailabilityID)", conn);
                    cmdGetTimeOfAvailability.CommandType = CommandType.Text;

                    cmdGetTimeOfAvailability.Parameters.AddWithValue("@AvailabilityID", currentAvailability.AvailabilityID.ToString());

                    string timeHolder = cmdGetTimeOfAvailability.ExecuteScalar().ToString();



                    cboAvailabilityBrowse.Items.Add(new ComboBoxItem("AvailabilityID: " + currentAvailability.AvailabilityID + ", " + currentAvailability.Date.ToString("MM/dd/yyyy") + ", " + timeHolder, currentAvailability));
                }

                conn.Close();

            }



        }

        private void populateStudentsComboBox()
        {
            cboStudentsBrowse.Items.Clear();
            foreach (var currentStudent in dctStudents.Values)
            {
                cboStudentsBrowse.Items.Add(new ComboBoxItem(currentStudent.StudentID.ToString() + " " + currentStudent.StudentFName + " " + currentStudent.StudentLName, currentStudent));
            }
        }



        // Event handlers for triggering text box population
        private void lsvChangePerson_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (radChangeAdvisor.Checked)
            {

                ListView.SelectedListViewItemCollection itemIsSelected = lsvChangePerson.SelectedItems;
                foreach (ListViewItem item in itemIsSelected)
                {
                    clsAdvisors currentAdvisor = (clsAdvisors)item.Tag;
                    displayAdvisorInformation_Update(currentAdvisor);
                }

            }
            if (radChangeStudent.Checked)
            {

                ListView.SelectedListViewItemCollection itemIsSelected = lsvChangePerson.SelectedItems;
                foreach (ListViewItem item in itemIsSelected)
                {
                    clsStudents currentStudent = (clsStudents)item.Tag;
                    displayStudentInformation_Update(currentStudent);
                }

            }

        }

        private void lsvDeletePerson_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (radDeleteAdvisor.Checked)
            {

                ListView.SelectedListViewItemCollection itemIsSelected = lsvDeletePerson.SelectedItems;
                foreach (ListViewItem item in itemIsSelected)
                {
                    clsAdvisors currentAdvisor = (clsAdvisors)item.Tag;
                    displayAdvisorInformation_Delete(currentAdvisor);
                }

            }
            if (radDeleteStudent.Checked)
            {

                ListView.SelectedListViewItemCollection itemIsSelected = lsvDeletePerson.SelectedItems;
                foreach (ListViewItem item in itemIsSelected)
                {
                    clsStudents currentStudent = (clsStudents)item.Tag;
                    displayStudentInformation_Delete(currentStudent);
                }

            }

        }

        private void lsvChangeAvailability_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection itemIsSelected = lsvChangeAvailability.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsAvailability currentChangeAvailability = (clsAvailability)item.Tag;
                displayAvailabilityInformation_Update(currentChangeAvailability);
            }

        }

        private void lsvDeleteAvailability_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection itemIsSelected = lsvDeleteAvailability.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsAvailability currentDeleteAvailability = (clsAvailability)item.Tag;
                displayAvailabilityInformation_Delete(currentDeleteAvailability);
            }

        }

        private void lsvChangeAppt_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection itemIsSelected = lsvChangeAppt.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsMeetings currentChangeAppt = (clsMeetings)item.Tag;
                displayMeetingInformation_Update(currentChangeAppt);
            }

        }

        private void lsvDeleteAppt_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection itemIsSelected = lsvDeleteAppt.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsMeetings currentDeleteAppt = (clsMeetings)item.Tag;
                displayMeetingInformation_Delete(currentDeleteAppt);
            }

        }

        private void lvwMeetings_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemIsSelected = lvwMeetings.SelectedItems;
            foreach (ListViewItem item in itemIsSelected)
            {
                clsMeetings currentMeeting = (clsMeetings)item.Tag;
                displayMeetingInformation_update(currentMeeting);
            }
        }



        // Event handlers for triggering combobox actions
        private void cboTimeBrowse_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboTimeBrowse.SelectedItem is ComboBoxItem selectedItem)
            {
                clsTimes currentTime = (clsTimes)selectedItem.Value;
                //txtTimeIDInsert.Text = currentTime.TimeID.ToString();
            }

        }

        private void cboAvailabilityBrowse_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboAvailabilityBrowse.SelectedItem is ComboBoxItem selectedItem)
            {

                clsAvailability currentAvailability = (clsAvailability)selectedItem.Value;

                string myConnectionString = clsDBUtil.getConnectionString();

                using (SqlConnection conn = new SqlConnection(myConnectionString))
                {

                    conn.Open();

                    SqlCommand cmdGetAdvisorOfAvailability = new SqlCommand("SELECT dbo.fnGetAdvisorOfAvailability(@AvailabilityID)", conn);
                    cmdGetAdvisorOfAvailability.CommandType = CommandType.Text;

                    cmdGetAdvisorOfAvailability.Parameters.AddWithValue("@AvailabilityID", currentAvailability.AvailabilityID.ToString());

                    string AdvisorName = cmdGetAdvisorOfAvailability.ExecuteScalar().ToString();

                    txtAdvisorAppt.Text = AdvisorName;

                }



            }

        }

        private void cboStudentsBrowse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStudentsBrowse.SelectedItem is ComboBoxItem selectedItem)
            {
                clsStudents currentstudent = (clsStudents)selectedItem.Value;
                txtOldLName.Text = currentstudent.StudentLName;
            }
        }



        // Functions for loading and refreshing the dictionaries and ListViews
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

        private void populateMeetingDictionary(ref Dictionary<int, clsMeetings> dctMeetings)
        {

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetMeeting", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dctMeetings.Clear();

                        while (rdr.Read() == true)
                        {
                            clsMeetings currentMeeting = new clsMeetings();
                            currentMeeting.MeetingID = (int)rdr["MeetingID"];
                            currentMeeting.StudentID = (int)rdr["StudentID"];
                            currentMeeting.AvailabilityID = (int)rdr["AvailabilityID"];



                            dctMeetings.Add(currentMeeting.MeetingID, currentMeeting);
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

        private void populateTimesDictionary(ref Dictionary<int, clsTimes> dctTimes)
        {

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetTime", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dctTimes.Clear();

                        while (rdr.Read() == true)
                        {
                            clsTimes currentTime = new clsTimes();
                            currentTime.TimeID = (int)rdr["TimeID"];
                            currentTime.StartTime = (TimeSpan)rdr["StartTime"];
                            currentTime.EndTime = (TimeSpan)rdr["EndTime"];




                            dctTimes.Add(currentTime.TimeID, currentTime);
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

        private void refreshAvailabilityListView()
        {

            switch (tabMain.SelectedTab.Name)
            {
                case "tabPage3":
                    lsvCreateAvailability.Clear();
                    clsAvailability newAvailability = new clsAvailability();
                    foreach (KeyValuePair<int, clsAvailability> kvp in dctAvailability)
                    {
                        newAvailability = kvp.Value;
                        ListViewItem item = new ListViewItem(Convert.ToString(newAvailability.AvailabilityID));
                        item.Tag = newAvailability;
                        lsvCreateAvailability.Items.Add(item);
                    }
                    populateAvailabilityComboBox();
                    break;
                case "tabPage7":
                    lsvChangeAvailability.Clear();
                    clsAvailability changeCurrentAvailability = new clsAvailability();
                    foreach (KeyValuePair<int, clsAvailability> kvp in dctAvailability)
                    {
                        changeCurrentAvailability = kvp.Value;
                        ListViewItem item = new ListViewItem(Convert.ToString(changeCurrentAvailability.AvailabilityID));
                        item.Tag = changeCurrentAvailability;
                        lsvChangeAvailability.Items.Add(item);
                    }
                    populateAvailabilityComboBox();
                    break;
                case "tabPage4":
                    lsvDeleteAvailability.Clear();
                    clsAvailability deleteAvailability = new clsAvailability();
                    foreach (KeyValuePair<int, clsAvailability> kvp in dctAvailability)
                    {
                        deleteAvailability = kvp.Value;
                        ListViewItem item = new ListViewItem(Convert.ToString(deleteAvailability.AvailabilityID));
                        item.Tag = deleteAvailability;
                        lsvDeleteAvailability.Items.Add(item);
                    }
                    populateAvailabilityComboBox();
                    break;
            }

        }

        private void refreshMeetingsListView()
        {

            switch (tabMain.SelectedTab.Name)
            {
                case "tabPage1":

                    lvwMeetings.Clear();
                    clsMeetings currentNewMeeting = new clsMeetings();
                    foreach (KeyValuePair<int, clsMeetings> kvp in dctMeetings)
                    {
                        currentNewMeeting = kvp.Value;
                        ListViewItem item = new ListViewItem(currentNewMeeting.MeetingID.ToString());
                        item.Tag = currentNewMeeting;
                        lvwMeetings.Items.Add(item);
                    }
                    break;
                case "tabPage2":

                    lsvChangeAppt.Clear();
                    clsMeetings currentChangeMeeting = new clsMeetings();
                    foreach (KeyValuePair<int, clsMeetings> kvp in dctMeetings)
                    {
                        currentChangeMeeting = kvp.Value;
                        ListViewItem item = new ListViewItem(currentChangeMeeting.MeetingID.ToString());
                        item.Tag = currentChangeMeeting;
                        lsvChangeAppt.Items.Add(item);
                    }
                    break;
                case "tabPage9":
                    lsvDeleteAppt.Clear();
                    clsMeetings currentDeleteMeeting = new clsMeetings();
                    foreach (KeyValuePair<int, clsMeetings> kvp in dctMeetings)
                    {
                        currentDeleteMeeting = kvp.Value;
                        ListViewItem item = new ListViewItem(currentDeleteMeeting.MeetingID.ToString());
                        item.Tag = currentDeleteMeeting;
                        lsvDeleteAppt.Items.Add(item);
                    }
                    break;

            }


            // REMEMBER: the View property of the listview must be set to 'List'
            lvwMeetings.Clear();
            clsMeetings currentMeeting = new clsMeetings();
            foreach (KeyValuePair<int, clsMeetings> kvp in dctMeetings)
            {
                currentMeeting = kvp.Value;
                ListViewItem item = new ListViewItem(currentMeeting.MeetingID.ToString());
                item.Tag = currentMeeting;
                lvwMeetings.Items.Add(item);
            }
        }


        // Updating the ListViews
            // Insert Person
        private void btnRefreshAddPerson_Click(object sender, EventArgs e)
        {

            if (radAdvisorNew.Checked == true)
            {

                refreshAdvisorsListview();

            }
            if (radStudentNew.Checked == true)
            {

                refreshStudentsListview();

            }

        }

            // Update Person
        private void btnRefreshChangePerson_Click(object sender, EventArgs e)
        {


            if (radChangeStudent.Checked == true)
            {

                refreshStudentsListview();

            }
            if (radChangeAdvisor.Checked == true)
            {

                refreshAdvisorsListview();

            }

        }

            // Delete Person
        private void btnRefreshDeletePerson_Click(object sender, EventArgs e)
        {

            if (radDeleteStudent.Checked == true)
            {

                refreshStudentsListview();

            }
            if (radDeleteAdvisor.Checked == true)
            {

                refreshAdvisorsListview();

            }

        }



            // Insert Availability
        private void btnRefreshCreateAvail_Click(object sender, EventArgs e)
        {

            refreshAvailabilityListView();

        }


            // Update Availability
        private void btnRefreshAvailChange_Click(object sender, EventArgs e)
        {

            refreshAvailabilityListView();

        }


            // Delete Availability
        private void btnRefreshDeleteAvail_Click(object sender, EventArgs e)
        {

            refreshAvailabilityListView();

        }



            // Insert Meeting


            // Update Meeting
        private void btnRefreshChangeAppt_Click(object sender, EventArgs e)
        {

            refreshMeetingsListView();

        }

            // Delete Meeting
        private void btnDeleteApptRefresh_Click(object sender, EventArgs e)
        {

            refreshMeetingsListView();

        }


        // Functions for adding
            // Adding People
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
                        SqlCommand cmdGetAdvisor = new SqlCommand("sp_GetAdvisor", conn);
                        cmdGetAdvisor.CommandType = CommandType.StoredProcedure;

                        cmdGetAdvisor.ExecuteNonQuery();

                        currentAdvisor.AdvisorFName = txtFNameNew.Text;
                        currentAdvisor.AdvisorLName = txtLNameNew.Text;
                        currentAdvisor.AdvisorEmail = txtEmailNew.Text;



                        if (InsertAdvisor(currentAdvisor) == true)
                        {

                            SqlCommand cmdGetAdvisorID = new SqlCommand("SELECT dbo.fnGetAdvisorID(@AdvisorFName, @AdvisorLName)", conn);
                            cmdGetAdvisorID.CommandType = CommandType.Text;

                            // Adding parameters to the command
                            cmdGetAdvisorID.Parameters.AddWithValue("@AdvisorFName", currentAdvisor.AdvisorFName ?? string.Empty);
                            cmdGetAdvisorID.Parameters.AddWithValue("@AdvisorLName", currentAdvisor.AdvisorLName ?? string.Empty);

                            // Execute the command and store the result
                            int currentAdvisorID = (int)cmdGetAdvisorID.ExecuteScalar();

                            // Setting dct-associated value to result
                            currentAdvisor.AdvisorID = currentAdvisorID;

                            populateAdvisorDictionary(ref dctAdvisors);
                            refreshAdvisorsListview();

                            messageBoxOK("The advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ") successfully added.");
                            personInformation_ClearTextboxes();

                        }
                        else
                        {

                            SqlCommand cmdGetAdvisorID = new SqlCommand("SELECT dbo.fnGetAdvisorID(@AdvisorFName, @AdvisorLName)", conn);
                            cmdGetAdvisorID.CommandType = CommandType.Text;

                            // Adding parameters to the command
                            cmdGetAdvisorID.Parameters.AddWithValue("@AdvisorFName", currentAdvisor.AdvisorFName ?? string.Empty);
                            cmdGetAdvisorID.Parameters.AddWithValue("@AdvisorLName", currentAdvisor.AdvisorLName ?? string.Empty);

                            // Execute the command and store the result
                            int currentAdvisorID = (int)cmdGetAdvisorID.ExecuteScalar();

                            // Setting dct-associated value to result
                            currentAdvisor.AdvisorID = currentAdvisorID;

                            messageBoxOK("Creation failed for advisor (ID: " + currentAdvisor.AdvisorID.ToString() + ").");

                        }
            ;

                    }
                    else if (radStudentNew.Checked)
                    {

                        clsStudents currentStudent = new clsStudents();

                        conn.Open();
                        SqlCommand cmdGetStudent = new SqlCommand("sp_GetStudent", conn);
                        cmdGetStudent.CommandType = CommandType.StoredProcedure;

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

                            SqlCommand cmdGetStudentID = new SqlCommand("SELECT dbo.fnGetStudentID(@StudentFName, @StudentLName)", conn);
                            cmdGetStudentID.CommandType = CommandType.Text;

                            // Adding parameters to the command
                            cmdGetStudentID.Parameters.AddWithValue("@StudentFName", currentStudent.StudentFName ?? string.Empty);
                            cmdGetStudentID.Parameters.AddWithValue("@StudentLName", currentStudent.StudentLName ?? string.Empty);

                            // Execute the command and store the result
                            int currentStudentID = (int)cmdGetStudentID.ExecuteScalar();

                            // Setting dct-associated value to result
                            currentStudent.StudentID = currentStudentID;

                            populateStudentDictionary(ref dctStudents);
                            refreshStudentsListview();

                            messageBoxOK("The student (ID: " + currentStudent.StudentID.ToString() + ") successfully added.");
                            personInformation_ClearTextboxes();

                        }
                        else
                        {

                            SqlCommand cmdGetStudentID = new SqlCommand("SELECT dbo.fnGetStudentID(@StudentFName, @StudentLName)", conn);
                            cmdGetStudentID.CommandType = CommandType.Text;

                            // Adding parameters to the command
                            cmdGetStudentID.Parameters.AddWithValue("@AdvisorFName", currentStudent.StudentFName ?? string.Empty);
                            cmdGetStudentID.Parameters.AddWithValue("@AdvisorLName", currentStudent.StudentLName ?? string.Empty);

                            // Execute the command and store the result
                            int currentStudentID = (int)cmdGetStudentID.ExecuteScalar();

                            // Setting dct-associated value to result
                            currentStudent.StudentID = currentStudentID;

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

            // Adding Availability
        private bool InsertAvailability(clsAvailability currentAvailability)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertAvailability", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdvisorID", currentAvailability.AdvisorID);
                    cmd.Parameters.AddWithValue("@Date", currentAvailability.Date);
                    cmd.Parameters.AddWithValue("@TimeID", currentAvailability.TimeID);
                    cmd.Parameters.AddWithValue("@LocationID", currentAvailability.LocationID);
                    cmd.Parameters.AddWithValue("@IsTaken", currentAvailability.IsTaken);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    // 2627 = primary key
                    // 2601 = duplicate
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        messageBoxOK("This availability slot already exists. Please choose a different date, time, or location.");
                    }
                    else
                    {
                        messageBoxOK("Database error: " + ex.Message);
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    messageBoxOK("Unexpected error: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnNewAvailability_Click(object sender, EventArgs e)
        {


            clsAvailability currentAvailability = new clsAvailability();

            clsStudents currentStudent = new clsStudents();

            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {

                conn.Open();


                if (int.TryParse(txtAvailAdvisorIDInsert.Text, out int AdvisorID))
                {
                    currentAvailability.AdvisorID = AdvisorID;
                }
                else
                {
                    messageBoxOK("Invalid AdvisorID.");
                    txtAvailAdvisorIDInsert.Focus();
                    return;
                }

                if (DateTime.TryParse(txtDateInsert.Text, out DateTime parsedDate))
                {
                    currentAvailability.Date = parsedDate;
                }
                else
                {
                    messageBoxOK("Invalid Date.");
                    txtDateInsert.Focus();
                    return;
                }

                if (cboTimeBrowse.SelectedItem is ComboBoxItem selectedItem &&
                 selectedItem.Value is clsTimes selectedTime)
                {
                    currentAvailability.TimeID = selectedTime.TimeID;
                }
                else
                {
                    messageBoxOK("Please select a valid time slot.");
                    cboTimeBrowse.Focus();
                    return;
                }



                if (int.TryParse(txtLocationIDInsert.Text, out int LocationID))
                {
                    currentAvailability.LocationID = LocationID;
                }
                else
                {
                    messageBoxOK("Invalid locationID .");
                    txtLocationIDInsert.Focus();
                    return;
                }


                if (chkIsTakenInsert.Checked)
                {

                    currentAvailability.IsTaken = chkIsTakenInsert.Checked;

                }
                else
                {

                    chkIsTakenInsert.Focus();

                }



                if (InsertAvailability(currentAvailability) == true)
                {

                    SqlCommand cmdGetAvailabilityID = new SqlCommand("SELECT dbo.fnGetAvailabilityID(@AdvisorID, @Date, @TimeID, @LocationID)", conn);
                    cmdGetAvailabilityID.CommandType = CommandType.Text;

                    // Adding parameters to the command
                    cmdGetAvailabilityID.Parameters.AddWithValue("@AdvisorID", currentAvailability.AdvisorID.ToString());
                    cmdGetAvailabilityID.Parameters.AddWithValue("@Date", currentAvailability.Date.ToString());
                    cmdGetAvailabilityID.Parameters.AddWithValue("@TimeID", currentAvailability.TimeID.ToString());
                    cmdGetAvailabilityID.Parameters.AddWithValue("@LocationID", currentAvailability.LocationID.ToString());

                    // Execute the command and store the result
                    int currentAvailabilityID = (int)cmdGetAvailabilityID.ExecuteScalar();

                    // Setting dct-associated value to result
                    currentAvailability.AvailabilityID = currentAvailabilityID;

                    populateAvailabilityDictionary(ref dctAvailability);
                    refreshAvailabilityListView();



                    messageBoxOK("The Availability (ID: " + currentAvailability.AvailabilityID.ToString() + ") successfully updated.");



                }
                else
                {
                    messageBoxOK("Update Failed for Availability (ID: " + currentAvailability.AvailabilityID.ToString() + ").");
                }
            }
        }

            // Adding Meetings
        private bool InsertMeeting(clsMeetings currentMeeting)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertMeeting", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@StudentID", currentMeeting.StudentID);
                    cmd.Parameters.AddWithValue("@AvailabilityID", currentMeeting.AvailabilityID);



                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        messageBoxOK("A meeting already exists for this student and time. Please choose a different slot.");
                    }
                    else
                    {
                        messageBoxOK("An error occurred while scheduling the meeting: " + ex.Message);
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    messageBoxOK("Unexpected error: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void btnCreateMeeting_Click(object sender, EventArgs e)
        {
            clsMeetings currentMeeting = new clsMeetings();




            if (cboStudentsBrowse.SelectedItem is ComboBoxItem selectedItem &&
            selectedItem.Value is clsStudents selectedStudent)
            {
                currentMeeting.StudentID = selectedStudent.StudentID;
            }
            else
            {
                messageBoxOK("Invalid student selection.");
                cboStudentsBrowse.Focus();
                return;
            }


            if (cboAvailabilityBrowse.SelectedItem is ComboBoxItem selectedAvailabilityItem &&
            selectedAvailabilityItem.Value is clsAvailability selectedAvailability)
            {
                currentMeeting.AvailabilityID = selectedAvailability.AvailabilityID;
            }
            else
            {
                messageBoxOK("Invalid availability selection.");
                cboAvailabilityBrowse.Focus();
                return;
            }





            if (InsertMeeting(currentMeeting) == true)
            {

                string myConnectionString = clsDBUtil.getConnectionString();

                using (SqlConnection conn = new SqlConnection(myConnectionString))
                {

                    conn.Open();

                    SqlCommand cmdGetMeetingID = new SqlCommand("SELECT dbo.fnGetAvailabilityID(@StudentID, @AvailabilityID)", conn);
                    cmdGetMeetingID.CommandType = CommandType.Text;

                    // Adding parameters to the command
                    cmdGetMeetingID.Parameters.AddWithValue("@StudentID", currentMeeting.StudentID.ToString());
                    cmdGetMeetingID.Parameters.AddWithValue("@AvailabilityID", currentMeeting.AvailabilityID.ToString());

                    // Execute the command and store the result
                    int currentAvailabilityID = (int)cmdGetMeetingID.ExecuteScalar();

                    // Setting dct-associated value to result
                    currentMeeting.AvailabilityID = currentAvailabilityID;

                }

                populateMeetingDictionary(ref dctMeetings);
                refreshMeetingsListView();



                messageBoxOK("The meeting (ID: " + currentMeeting.MeetingID.ToString() + ") successfully updated.");
                meetingInformation_Update_ClearTextboxes();



            }

            else
            {
                messageBoxOK("Create Failed for meeting (ID: " + currentMeeting.MeetingID.ToString() + ").");
            }
           ;
        }

        



        // Functions for updating
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

        private bool updateMeeting(clsMeetings currentMeeting)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateMeeting", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MeetingID", currentMeeting.MeetingID);
                    cmd.Parameters.AddWithValue("@StudentID", currentMeeting.StudentID);
                    cmd.Parameters.AddWithValue("@AvailabilityID", currentMeeting.AvailabilityID);

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

        private void btnChangeAvailability_Click(object sender, EventArgs e)
        {

            clsAvailability currentAvailability = new clsAvailability();

            #region Validate user input & assigning to Availability properties

            if (int.TryParse(txtNewAvailability.Text, out int AvailabilityID))
            {
                currentAvailability.AvailabilityID = AvailabilityID;
            }
            else
            {
                messageBoxOK("Invalid Availability ID.");
                txtNewAvailability.Focus();
                return;
            }


            if (int.TryParse(txtNewAdvisorID.Text, out int AdvisorID))
            {
                currentAvailability.AdvisorID = AdvisorID;
            }
            else
            {
                messageBoxOK("Invalid AdvisorID.");
                txtNewAdvisorID.Focus();
                return;
            }



            if (DateTime.TryParse(txtNewDate.Text, out DateTime parsedDate))
            {
                currentAvailability.Date = parsedDate;
            }
            else
            {
                messageBoxOK("Invalid Date.");
                txtNewDate.Focus();
                return;
            }


            if (int.TryParse(txtNewTime.Text, out int TimeID))
            {
                currentAvailability.TimeID = TimeID;
            }
            else
            {
                messageBoxOK("Invalid TimeID ID.");
                txtNewTime.Focus();
                return;
            }

            if (int.TryParse(txtNewLocation.Text, out int LocationID))
            {
                currentAvailability.LocationID = LocationID;
            }
            else
            {
                messageBoxOK("Invalid TimeID ID.");
                txtNewLocation.Focus();
                return;
            }


            if (chkIsTakenUpdateNew.Checked)
            {
                currentAvailability.IsTaken = true;
            }
            else
            {
                currentAvailability.IsTaken = false;

            }


            #endregion

            if (updateAvailability(currentAvailability) == true)
            {

                populateAvailabilityDictionary(ref dctAvailability);
                refreshAvailabilityListView();
                changeAvailabilityClearForm();
                populateAvailabilityComboBox();

                messageBoxOK("The Availability (ID: " + currentAvailability.AvailabilityID.ToString() + ") successfully updated.");

            }
            else
            {
                messageBoxOK("Update Failed for Availability (ID: " + currentAvailability.AvailabilityID.ToString() + ").");
            }
            ;

        }

        private void btnChangeApptSubmit_Click(object sender, EventArgs e)
        {

            clsMeetings currentMeeting = new clsMeetings();

            if (!int.TryParse(txtNewChangeApptAppt.Text, out int meetingID))
            {
                messageBoxOK("Invalid Meeting ID.");
                txtNewChangeApptAppt.Focus();
                return;
            }

            currentMeeting.MeetingID = meetingID;

            if (!int.TryParse(txtNewChangeApptStudentID.Text, out int studentID))
            {
                messageBoxOK("Invalid Student ID.");
                txtNewChangeApptStudentID.Focus();
                return;
            }

            currentMeeting.StudentID = studentID;

            if (!int.TryParse(txtNewChangeApptAvailabilityID.Text, out int availabilityID))
            {
                messageBoxOK("Invalid Availability ID.");
                txtNewChangeApptAvailabilityID.Focus();
                return;
            }

            currentMeeting.AvailabilityID = availabilityID;

            if (updateMeeting(currentMeeting))
            {
                populateMeetingDictionary(ref dctMeetings);
                refreshMeetingsListView();
                messageBoxOK($"The meeting (ID: {currentMeeting.MeetingID}) was successfully updated.");
                meetingInformation_Update_ClearTextboxes();
            }
            else
            {
                messageBoxOK($"Update failed for meeting (ID: {currentMeeting.MeetingID}).");
            }

        }



        // Functions for deleting
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

                currentStudent.StudentFName = txtDeleteFName.Text;
                currentStudent.StudentLName = txtDeleteLName.Text;


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

        private bool deleteAvailability(clsAvailability currentAvailability)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteAvailability", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AvailabilityID", currentAvailability.AvailabilityID);

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

        private void btnDeleteAvailability_Click(object sender, EventArgs e)
        {
            clsAvailability currentAvailability = new clsAvailability();

            if (int.TryParse(txtAvailabilityIDDelete.Text, out int AvailabilityID))
            {
                currentAvailability.AvailabilityID = AvailabilityID;
            }
            else
            {
                messageBoxOK("Invalid AvailabilityID.");
                txtAvailabilityIDDelete.Focus();
                return;
            }


            if (int.TryParse(txtAdvisorIDDelete.Text, out int AdvisorID))
            {
                currentAvailability.AdvisorID = AdvisorID;
            }
            else
            {
                messageBoxOK("Invalid AdvisorID.");
                txtAdvisorIDDelete.Focus();
                return;
            }


            if (DateTime.TryParse(txtDateDelete.Text, out DateTime parsedDate))
            {
                currentAvailability.Date = parsedDate;
            }
            else
            {
                messageBoxOK("Invalid Date.");
                txtDateDelete.Focus();
                return;
            }


            if (int.TryParse(txtTimeDelete.Text, out int TimeID))
            {
                currentAvailability.TimeID = TimeID;
            }
            else
            {
                messageBoxOK("Invalid TimeID ID.");
                txtTimeDelete.Focus();
                return;
            }

            if (int.TryParse(txtLocationDelete.Text, out int LocationID))
            {
                currentAvailability.LocationID = LocationID;
            }
            else
            {
                messageBoxOK("Invalid LocationID ID.");
                txtLocationDelete.Focus();
                return;
            }

            bool isDeleteAvailSuccess = true;

            for (int i = 1; i < dctMeetings.Count; i++)
            {

                clsMeetings meeting = dctMeetings[i];

                if (meeting.AvailabilityID == currentAvailability.AvailabilityID)
                {

                    messageBoxOK("There are still meetings scheduled within this availability, cannot delete.");

                    isDeleteAvailSuccess = false;

                    break;

                }

            }

            if (isDeleteAvailSuccess)
            {

                if (deleteAvailability(currentAvailability) == true)
                {

                    populateAvailabilityDictionary(ref dctAvailability);
                    refreshAvailabilityListView();



                    messageBoxOK("The Availability (ID: " + currentAvailability.AvailabilityID.ToString() + ") successfully deleted.");


                }
                else
                {
                    messageBoxOK("Delete failed for Availability (ID: " + currentAvailability.AvailabilityID.ToString() + ").");
                }

            }
            else
            {
                messageBoxOK("Delete failed for Availability (ID: " + currentAvailability.AvailabilityID.ToString() + ").");
            }


            currentAvailability.AvailabilityID = currentAvailability.AvailabilityID;


            
        }

        private bool deleteMeeting(clsMeetings currentMeeting)
        {
            string myConnectionString = clsDBUtil.getConnectionString();

            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DeleteMeeting", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MeetingID", currentMeeting.MeetingID);


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

        private void btnDeleteMeeting_Click(object sender, EventArgs e)
        {
            clsMeetings currentMeeting = new clsMeetings();



            if (int.TryParse(txtDeleteAppointmentID.Text, out int MeetingID))
            {
                currentMeeting.MeetingID = MeetingID;
            }
            else
            {
                messageBoxOK("Invalid meeting ID.");
                txtDeleteAppointmentID.Focus();
                return;
            }


            if (int.TryParse(txtDeleteApptAvailabilityID.Text, out int AvailabilityID))
            {
                currentMeeting.AvailabilityID = AvailabilityID;
            }
            else
            {
                messageBoxOK("Invalid availability ID.");
                txtDeleteApptAvailabilityID.Focus();
                txtDeleteApptAvailabilityID.Focus();
                return;
            }





            if (deleteMeeting(currentMeeting) == true)
            {

                populateMeetingDictionary(ref dctMeetings);
                refreshMeetingsListView();



                messageBoxOK("The meeting (ID: " + currentMeeting.MeetingID.ToString() + ") successfully deleted.");
                meetingInformation_Update_ClearTextboxes();



            }
            else
            {
                messageBoxOK("delete Failed for meeting (ID: " + currentMeeting.MeetingID.ToString() + ").");
            }
    ;
        }



        // Clear Form Functions
        private void btnClearFormAdd_Click(object sender, EventArgs e)
        {

            radAdvisorNew.Checked = false;
            radStudentNew.Checked = false;

            txtFNameNew.Clear();

            txtLNameNew.Clear();

            txtYearNew.Clear();

            txtEmailNew.Clear();

        }

        private void meetingInformation_Update_ClearTextboxes()
        {

            //txtMeetingID.Clear();
            //txtMeetingID.ReadOnly = true;

            txtMeetStudentID.Clear();
            txtMeetStudentID.ReadOnly = true;

            txtMeetAvailabilityID.Clear();
            txtMeetAvailabilityID.ReadOnly = true;


            cboStudentsBrowse.SelectedIndex = -1;
            cboAvailabilityBrowse.SelectedIndex = -1;

        }

        private void personInformation_ClearTextboxes()
        {

            txtOldFName.Clear();

            txtOldLName.Clear();


            txtNewYear.Clear();

            txtNewFName.Clear();

            txtNewLName.Clear();

            txtNewEmail.Clear();

        }

        private void changeAvailabilityClearForm()
        {

            txtAvailabilityIDChange.Clear();
            txtAdvisorIDChange.Clear();
            txtOldDateChange.Clear();
            txtOldTimeChange.Clear();
            txtOldLocationChange.Clear();

            chkIsTakenUpdateOld.Checked = false;



            txtNewAvailability.Clear();
            txtNewAdvisorID.Clear();
            txtNewDate.Clear();
            txtNewTime.Clear();
            txtNewLocation.Clear();

            chkIsTakenUpdateNew.Checked = false;

        }

        private void btnChangePersonClearForm_Click(object sender, EventArgs e)
        {

            txtOldID.Clear();

            txtOldFName.Clear();

            txtOldLName.Clear();

            txtOldYear.Clear();

            txtOldEmail.Clear();


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
            txtPersonID.Clear();

            txtDeleteFName.Clear();

            txtDeleteLName.Clear();

            txtDeleteEmail.Clear();

            txtDeleteYear.Clear();
        }

        private void btnClearCreateAvail_Click(object sender, EventArgs e)
        {

            //txtAvailabilityID.Clear();

            txtAvailAdvisorIDInsert.Clear();

            txtDateInsert.Clear();

            txtLocationIDInsert.Clear();

            //txtTimeIDInsert.Clear();

            chkIsTakenInsert.Checked = false;

        }

        private void btnClearChange_Click(object sender, EventArgs e)
        {

            txtAvailabilityIDChange.Clear();

            txtAdvisorIDChange.Clear();

            txtOldDateChange.Clear();

            txtOldTimeChange.Clear();

            txtOldLocationChange.Clear();


            txtNewAvailability.Clear();

            txtNewAdvisorID.Clear();

            txtNewDate.Clear();

            txtNewTime.Clear();

            txtNewLocation.Clear();


            chkIsTakenUpdateOld.Checked = false;
            chkIsTakenUpdateNew.Checked = false;

        }

        private void btnClearDelete_Click(object sender, EventArgs e)
        {

            txtAvailabilityIDDelete.Clear();

            txtAdvisorIDDelete.Clear();

            txtDateDelete.Clear();

            txtTimeDelete.Clear();

            txtLocationDelete.Clear();

        }

        private void btnChangeApptClear_Click(object sender, EventArgs e)
        {

            txtChangeApptApptID.Clear();

            txtChangeApptStudentID.Clear();

            txtChangeApptOldAvailabilityID.Clear();

            txtNewChangeApptAppt.Clear();

            txtNewChangeApptStudentID.Clear();

            txtNewChangeApptAvailabilityID.Clear();


        }

        private void btnDeleteApptClear_Click(object sender, EventArgs e)
        {

            txtDeleteAppointmentID.Clear();

            txtDeleteApptStudentID.Clear();

            txtDeleteApptAvailabilityID.Clear();

        }






        // Our bestest friend, the messageBoxOK
        private void messageBoxOK(string msg)
        {
            MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
