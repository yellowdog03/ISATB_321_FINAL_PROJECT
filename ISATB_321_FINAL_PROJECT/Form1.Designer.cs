namespace ISATB_321_FINAL_PROJECT
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabMain = new TabControl();
            tabPage1 = new TabPage();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            btnClearAppt = new Button();
            btnMakeAppt = new Button();
            txtProfLName = new TextBox();
            txtProfFName = new TextBox();
            lblProfLName = new Label();
            lblProfFName = new Label();
            lblAdvisor = new Label();
            txtStudentLName = new TextBox();
            lblStudentLName = new Label();
            lblStudent = new Label();
            txtStudentFName = new TextBox();
            lblStudentFName = new Label();
            tabPage2 = new TabPage();
            btnDelete = new Button();
            btnUpdate = new Button();
            txtAppointmentID = new TextBox();
            lblAppointmentID = new Label();
            lblAppointment = new Label();
            monthCalendar2 = new MonthCalendar();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox4 = new TextBox();
            label6 = new Label();
            tabPage6 = new TabPage();
            lsvAddPerson = new ListView();
            btnClearFormAdd = new Button();
            btnSubmitNew = new Button();
            txtEmailNew = new TextBox();
            lblEmailNew = new Label();
            txtYearNew = new TextBox();
            lblYearNew = new Label();
            lblLeaveBlank = new Label();
            txtLNameNew = new TextBox();
            lblLastNameNew = new Label();
            lblFirstNameNew = new Label();
            txtFNameNew = new TextBox();
            lblInfo = new Label();
            radAdvisorNew = new RadioButton();
            radStudentNew = new RadioButton();
            lblStudentAdvisor = new Label();
            tabPage5 = new TabPage();
            txtNewEmail = new TextBox();
            lblNewEmail = new Label();
            txtOldEmail = new TextBox();
            lblOldEmail = new Label();
            lsvChangePerson = new ListView();
            txtOldYear = new TextBox();
            lblOldYear = new Label();
            label7 = new Label();
            txtOldID = new TextBox();
            lblOldID = new Label();
            btnChangePersonClearForm = new Button();
            btnSubmitChanges = new Button();
            txtNewYear = new TextBox();
            txtNewLName = new TextBox();
            txtNewFName = new TextBox();
            lblNewYear = new Label();
            lblNewLastName = new Label();
            lblNewFirstName = new Label();
            lblNewInfo = new Label();
            txtOldLName = new TextBox();
            lblOldLName = new Label();
            lblOldFName = new Label();
            txtOldFName = new TextBox();
            lblCurrentInfo = new Label();
            radChangeAdvisor = new RadioButton();
            radChangeStudent = new RadioButton();
            btnStudentAdvisorSelect = new Label();
            tabPage8 = new TabPage();
            lsvDeletePerson = new ListView();
            txtDeleteYear = new TextBox();
            lblDeleteYear = new Label();
            txtDeleteEmail = new TextBox();
            lblDeleteEmail = new Label();
            txtPersonID = new TextBox();
            lblPersonID = new Label();
            btnDeletePersonClearForm = new Button();
            btnDeletePerson = new Button();
            txtDeleteLName = new TextBox();
            label9 = new Label();
            label10 = new Label();
            txtDeleteFName = new TextBox();
            label11 = new Label();
            radDeleteAdvisor = new RadioButton();
            radDeleteStudent = new RadioButton();
            label12 = new Label();
            tabPage3 = new TabPage();
            lsvCreateAvailability = new ListView();
            tabPage7 = new TabPage();
            lsvChangeAvailability = new ListView();
            tabPage4 = new TabPage();
            lsvDeleteAvailability = new ListView();
            tabMain.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage6.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage8.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage7.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabPage1);
            tabMain.Controls.Add(tabPage2);
            tabMain.Controls.Add(tabPage6);
            tabMain.Controls.Add(tabPage5);
            tabMain.Controls.Add(tabPage8);
            tabMain.Controls.Add(tabPage3);
            tabMain.Controls.Add(tabPage7);
            tabMain.Controls.Add(tabPage4);
            tabMain.Location = new Point(15, 15);
            tabMain.Margin = new Padding(4);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1246, 532);
            tabMain.TabIndex = 91;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dateTimePicker2);
            tabPage1.Controls.Add(dateTimePicker1);
            tabPage1.Controls.Add(btnClearAppt);
            tabPage1.Controls.Add(btnMakeAppt);
            tabPage1.Controls.Add(txtProfLName);
            tabPage1.Controls.Add(txtProfFName);
            tabPage1.Controls.Add(lblProfLName);
            tabPage1.Controls.Add(lblProfFName);
            tabPage1.Controls.Add(lblAdvisor);
            tabPage1.Controls.Add(txtStudentLName);
            tabPage1.Controls.Add(lblStudentLName);
            tabPage1.Controls.Add(lblStudent);
            tabPage1.Controls.Add(txtStudentFName);
            tabPage1.Controls.Add(lblStudentFName);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(1238, 494);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Schedule Appointment";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Location = new Point(448, 204);
            dateTimePicker2.Margin = new Padding(4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(312, 31);
            dateTimePicker2.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(52, 204);
            dateTimePicker1.Margin = new Padding(4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(312, 31);
            dateTimePicker1.TabIndex = 13;
            // 
            // btnClearAppt
            // 
            btnClearAppt.Location = new Point(789, 139);
            btnClearAppt.Margin = new Padding(4);
            btnClearAppt.Name = "btnClearAppt";
            btnClearAppt.Size = new Size(139, 91);
            btnClearAppt.TabIndex = 12;
            btnClearAppt.Text = "Clear Form";
            btnClearAppt.UseVisualStyleBackColor = true;
            // 
            // btnMakeAppt
            // 
            btnMakeAppt.Location = new Point(789, 19);
            btnMakeAppt.Margin = new Padding(4);
            btnMakeAppt.Name = "btnMakeAppt";
            btnMakeAppt.Size = new Size(139, 91);
            btnMakeAppt.TabIndex = 11;
            btnMakeAppt.Text = "Make Appointment";
            btnMakeAppt.UseVisualStyleBackColor = true;
            // 
            // txtProfLName
            // 
            txtProfLName.Location = new Point(585, 102);
            txtProfLName.Margin = new Padding(4);
            txtProfLName.Name = "txtProfLName";
            txtProfLName.Size = new Size(155, 31);
            txtProfLName.TabIndex = 9;
            // 
            // txtProfFName
            // 
            txtProfFName.Location = new Point(585, 55);
            txtProfFName.Margin = new Padding(4);
            txtProfFName.Name = "txtProfFName";
            txtProfFName.Size = new Size(155, 31);
            txtProfFName.TabIndex = 8;
            // 
            // lblProfLName
            // 
            lblProfLName.AutoSize = true;
            lblProfLName.Location = new Point(475, 106);
            lblProfLName.Margin = new Padding(4, 0, 4, 0);
            lblProfLName.Name = "lblProfLName";
            lblProfLName.Size = new Size(99, 25);
            lblProfLName.TabIndex = 7;
            lblProfLName.Text = "Last Name:";
            // 
            // lblProfFName
            // 
            lblProfFName.AutoSize = true;
            lblProfFName.Location = new Point(475, 55);
            lblProfFName.Margin = new Padding(4, 0, 4, 0);
            lblProfFName.Name = "lblProfFName";
            lblProfFName.Size = new Size(101, 25);
            lblProfFName.TabIndex = 6;
            lblProfFName.Text = "First Name:";
            // 
            // lblAdvisor
            // 
            lblAdvisor.AutoSize = true;
            lblAdvisor.Location = new Point(448, 19);
            lblAdvisor.Margin = new Padding(4, 0, 4, 0);
            lblAdvisor.Name = "lblAdvisor";
            lblAdvisor.Size = new Size(73, 25);
            lblAdvisor.TabIndex = 5;
            lblAdvisor.Text = "Advisor";
            // 
            // txtStudentLName
            // 
            txtStudentLName.Location = new Point(191, 104);
            txtStudentLName.Margin = new Padding(4);
            txtStudentLName.Name = "txtStudentLName";
            txtStudentLName.Size = new Size(163, 31);
            txtStudentLName.TabIndex = 4;
            // 
            // lblStudentLName
            // 
            lblStudentLName.AutoSize = true;
            lblStudentLName.Location = new Point(81, 108);
            lblStudentLName.Margin = new Padding(4, 0, 4, 0);
            lblStudentLName.Name = "lblStudentLName";
            lblStudentLName.Size = new Size(99, 25);
            lblStudentLName.TabIndex = 3;
            lblStudentLName.Text = "Last Name:";
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(52, 19);
            lblStudent.Margin = new Padding(4, 0, 4, 0);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(73, 25);
            lblStudent.TabIndex = 2;
            lblStudent.Text = "Student";
            // 
            // txtStudentFName
            // 
            txtStudentFName.Location = new Point(192, 51);
            txtStudentFName.Margin = new Padding(4);
            txtStudentFName.Name = "txtStudentFName";
            txtStudentFName.Size = new Size(162, 31);
            txtStudentFName.TabIndex = 1;
            // 
            // lblStudentFName
            // 
            lblStudentFName.AutoSize = true;
            lblStudentFName.Location = new Point(81, 55);
            lblStudentFName.Margin = new Padding(4, 0, 4, 0);
            lblStudentFName.Name = "lblStudentFName";
            lblStudentFName.Size = new Size(101, 25);
            lblStudentFName.TabIndex = 0;
            lblStudentFName.Text = "First Name:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnDelete);
            tabPage2.Controls.Add(btnUpdate);
            tabPage2.Controls.Add(txtAppointmentID);
            tabPage2.Controls.Add(lblAppointmentID);
            tabPage2.Controls.Add(lblAppointment);
            tabPage2.Controls.Add(monthCalendar2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(label6);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(1238, 494);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Change Appointment";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(820, 344);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(125, 44);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(618, 344);
            btnUpdate.Margin = new Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(125, 44);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtAppointmentID
            // 
            txtAppointmentID.Location = new Point(222, 390);
            txtAppointmentID.Margin = new Padding(4);
            txtAppointmentID.Name = "txtAppointmentID";
            txtAppointmentID.Size = new Size(155, 31);
            txtAppointmentID.TabIndex = 24;
            // 
            // lblAppointmentID
            // 
            lblAppointmentID.AutoSize = true;
            lblAppointmentID.Location = new Point(66, 394);
            lblAppointmentID.Margin = new Padding(4, 0, 4, 0);
            lblAppointmentID.Name = "lblAppointmentID";
            lblAppointmentID.Size = new Size(145, 25);
            lblAppointmentID.TabIndex = 23;
            lblAppointmentID.Text = "Appointment ID:";
            // 
            // lblAppointment
            // 
            lblAppointment.AutoSize = true;
            lblAppointment.Location = new Point(38, 355);
            lblAppointment.Margin = new Padding(4, 0, 4, 0);
            lblAppointment.Name = "lblAppointment";
            lblAppointment.Size = new Size(118, 25);
            lblAppointment.TabIndex = 22;
            lblAppointment.Text = "Appointment";
            // 
            // monthCalendar2
            // 
            monthCalendar2.Location = new Point(496, 48);
            monthCalendar2.Margin = new Padding(11);
            monthCalendar2.Name = "monthCalendar2";
            monthCalendar2.TabIndex = 21;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(176, 269);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 31);
            textBox1.TabIndex = 20;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(176, 221);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(155, 31);
            textBox2.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 272);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 18;
            label1.Text = "Last Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 221);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 17;
            label2.Text = "First Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 184);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 16;
            label3.Text = "Professor";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(176, 100);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(163, 31);
            textBox3.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 104);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(99, 25);
            label4.TabIndex = 14;
            label4.Text = "Last Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 15);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(73, 25);
            label5.TabIndex = 13;
            label5.Text = "Student";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(178, 48);
            textBox4.Margin = new Padding(4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(162, 31);
            textBox4.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(66, 51);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(101, 25);
            label6.TabIndex = 11;
            label6.Text = "First Name:";
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(lsvAddPerson);
            tabPage6.Controls.Add(btnClearFormAdd);
            tabPage6.Controls.Add(btnSubmitNew);
            tabPage6.Controls.Add(txtEmailNew);
            tabPage6.Controls.Add(lblEmailNew);
            tabPage6.Controls.Add(txtYearNew);
            tabPage6.Controls.Add(lblYearNew);
            tabPage6.Controls.Add(lblLeaveBlank);
            tabPage6.Controls.Add(txtLNameNew);
            tabPage6.Controls.Add(lblLastNameNew);
            tabPage6.Controls.Add(lblFirstNameNew);
            tabPage6.Controls.Add(txtFNameNew);
            tabPage6.Controls.Add(lblInfo);
            tabPage6.Controls.Add(radAdvisorNew);
            tabPage6.Controls.Add(radStudentNew);
            tabPage6.Controls.Add(lblStudentAdvisor);
            tabPage6.Location = new Point(4, 34);
            tabPage6.Margin = new Padding(4);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1238, 494);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Add Person";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // lsvAddPerson
            // 
            lsvAddPerson.Location = new Point(630, 4);
            lsvAddPerson.Margin = new Padding(4);
            lsvAddPerson.Name = "lsvAddPerson";
            lsvAddPerson.Size = new Size(595, 483);
            lsvAddPerson.TabIndex = 43;
            lsvAddPerson.UseCompatibleStateImageBehavior = false;
            lsvAddPerson.View = View.List;
            // 
            // btnClearFormAdd
            // 
            btnClearFormAdd.Location = new Point(259, 412);
            btnClearFormAdd.Margin = new Padding(4);
            btnClearFormAdd.Name = "btnClearFormAdd";
            btnClearFormAdd.Size = new Size(176, 52);
            btnClearFormAdd.TabIndex = 42;
            btnClearFormAdd.Text = "Clear Form";
            btnClearFormAdd.UseVisualStyleBackColor = true;
            // 
            // btnSubmitNew
            // 
            btnSubmitNew.Location = new Point(26, 412);
            btnSubmitNew.Margin = new Padding(4);
            btnSubmitNew.Name = "btnSubmitNew";
            btnSubmitNew.Size = new Size(199, 52);
            btnSubmitNew.TabIndex = 41;
            btnSubmitNew.Text = "Submit New Person";
            btnSubmitNew.UseVisualStyleBackColor = true;
            btnSubmitNew.Click += btnSubmitNew_Click;
            // 
            // txtEmailNew
            // 
            txtEmailNew.Location = new Point(140, 261);
            txtEmailNew.Margin = new Padding(4);
            txtEmailNew.Name = "txtEmailNew";
            txtEmailNew.Size = new Size(155, 31);
            txtEmailNew.TabIndex = 40;
            // 
            // lblEmailNew
            // 
            lblEmailNew.AutoSize = true;
            lblEmailNew.Location = new Point(51, 265);
            lblEmailNew.Margin = new Padding(4, 0, 4, 0);
            lblEmailNew.Name = "lblEmailNew";
            lblEmailNew.Size = new Size(58, 25);
            lblEmailNew.TabIndex = 39;
            lblEmailNew.Text = "Email:";
            // 
            // txtYearNew
            // 
            txtYearNew.Location = new Point(140, 220);
            txtYearNew.Margin = new Padding(4);
            txtYearNew.Name = "txtYearNew";
            txtYearNew.Size = new Size(155, 31);
            txtYearNew.TabIndex = 38;
            // 
            // lblYearNew
            // 
            lblYearNew.AutoSize = true;
            lblYearNew.Location = new Point(58, 224);
            lblYearNew.Margin = new Padding(4, 0, 4, 0);
            lblYearNew.Name = "lblYearNew";
            lblYearNew.Size = new Size(53, 25);
            lblYearNew.TabIndex = 37;
            lblYearNew.Text = "Year: ";
            // 
            // lblLeaveBlank
            // 
            lblLeaveBlank.AutoSize = true;
            lblLeaveBlank.Location = new Point(26, 100);
            lblLeaveBlank.Margin = new Padding(4, 0, 4, 0);
            lblLeaveBlank.Name = "lblLeaveBlank";
            lblLeaveBlank.Size = new Size(433, 25);
            lblLeaveBlank.TabIndex = 36;
            lblLeaveBlank.Text = "Leave the box blank if not changing or not applicable";
            // 
            // txtLNameNew
            // 
            txtLNameNew.Location = new Point(140, 179);
            txtLNameNew.Margin = new Padding(4);
            txtLNameNew.Name = "txtLNameNew";
            txtLNameNew.Size = new Size(155, 31);
            txtLNameNew.TabIndex = 28;
            // 
            // lblLastNameNew
            // 
            lblLastNameNew.AutoSize = true;
            lblLastNameNew.Location = new Point(30, 182);
            lblLastNameNew.Margin = new Padding(4, 0, 4, 0);
            lblLastNameNew.Name = "lblLastNameNew";
            lblLastNameNew.Size = new Size(99, 25);
            lblLastNameNew.TabIndex = 27;
            lblLastNameNew.Text = "Last Name:";
            // 
            // lblFirstNameNew
            // 
            lblFirstNameNew.AutoSize = true;
            lblFirstNameNew.Location = new Point(29, 141);
            lblFirstNameNew.Margin = new Padding(4, 0, 4, 0);
            lblFirstNameNew.Name = "lblFirstNameNew";
            lblFirstNameNew.Size = new Size(101, 25);
            lblFirstNameNew.TabIndex = 26;
            lblFirstNameNew.Text = "First Name:";
            // 
            // txtFNameNew
            // 
            txtFNameNew.Location = new Point(140, 138);
            txtFNameNew.Margin = new Padding(4);
            txtFNameNew.Name = "txtFNameNew";
            txtFNameNew.Size = new Size(155, 31);
            txtFNameNew.TabIndex = 25;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(4, 75);
            lblInfo.Margin = new Padding(4, 0, 4, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(106, 25);
            lblInfo.TabIndex = 24;
            lblInfo.Text = "Information";
            // 
            // radAdvisorNew
            // 
            radAdvisorNew.AutoSize = true;
            radAdvisorNew.Location = new Point(138, 29);
            radAdvisorNew.Margin = new Padding(4);
            radAdvisorNew.Name = "radAdvisorNew";
            radAdvisorNew.Size = new Size(91, 29);
            radAdvisorNew.TabIndex = 23;
            radAdvisorNew.Text = "Advisor";
            radAdvisorNew.UseVisualStyleBackColor = true;
            radAdvisorNew.CheckedChanged += radAdvisorNew_CheckedChanged;
            // 
            // radStudentNew
            // 
            radStudentNew.AutoSize = true;
            radStudentNew.Checked = true;
            radStudentNew.Location = new Point(29, 29);
            radStudentNew.Margin = new Padding(4);
            radStudentNew.Name = "radStudentNew";
            radStudentNew.Size = new Size(91, 29);
            radStudentNew.TabIndex = 22;
            radStudentNew.TabStop = true;
            radStudentNew.Text = "Student";
            radStudentNew.UseVisualStyleBackColor = true;
            radStudentNew.CheckedChanged += radStudentNew_CheckedChanged;
            // 
            // lblStudentAdvisor
            // 
            lblStudentAdvisor.AutoSize = true;
            lblStudentAdvisor.Location = new Point(4, 0);
            lblStudentAdvisor.Margin = new Padding(4, 0, 4, 0);
            lblStudentAdvisor.Name = "lblStudentAdvisor";
            lblStudentAdvisor.Size = new Size(169, 25);
            lblStudentAdvisor.TabIndex = 21;
            lblStudentAdvisor.Text = "Student or Advisor?";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(txtNewEmail);
            tabPage5.Controls.Add(lblNewEmail);
            tabPage5.Controls.Add(txtOldEmail);
            tabPage5.Controls.Add(lblOldEmail);
            tabPage5.Controls.Add(lsvChangePerson);
            tabPage5.Controls.Add(txtOldYear);
            tabPage5.Controls.Add(lblOldYear);
            tabPage5.Controls.Add(label7);
            tabPage5.Controls.Add(txtOldID);
            tabPage5.Controls.Add(lblOldID);
            tabPage5.Controls.Add(btnChangePersonClearForm);
            tabPage5.Controls.Add(btnSubmitChanges);
            tabPage5.Controls.Add(txtNewYear);
            tabPage5.Controls.Add(txtNewLName);
            tabPage5.Controls.Add(txtNewFName);
            tabPage5.Controls.Add(lblNewYear);
            tabPage5.Controls.Add(lblNewLastName);
            tabPage5.Controls.Add(lblNewFirstName);
            tabPage5.Controls.Add(lblNewInfo);
            tabPage5.Controls.Add(txtOldLName);
            tabPage5.Controls.Add(lblOldLName);
            tabPage5.Controls.Add(lblOldFName);
            tabPage5.Controls.Add(txtOldFName);
            tabPage5.Controls.Add(lblCurrentInfo);
            tabPage5.Controls.Add(radChangeAdvisor);
            tabPage5.Controls.Add(radChangeStudent);
            tabPage5.Controls.Add(btnStudentAdvisorSelect);
            tabPage5.Location = new Point(4, 34);
            tabPage5.Margin = new Padding(4);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1238, 494);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Change Person";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtNewEmail
            // 
            txtNewEmail.Location = new Point(458, 404);
            txtNewEmail.Margin = new Padding(4);
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.Size = new Size(155, 31);
            txtNewEmail.TabIndex = 33;
            // 
            // lblNewEmail
            // 
            lblNewEmail.AutoSize = true;
            lblNewEmail.Location = new Point(346, 412);
            lblNewEmail.Margin = new Padding(4, 0, 4, 0);
            lblNewEmail.Name = "lblNewEmail";
            lblNewEmail.Size = new Size(63, 25);
            lblNewEmail.TabIndex = 32;
            lblNewEmail.Text = "Email: ";
            // 
            // txtOldEmail
            // 
            txtOldEmail.Location = new Point(112, 404);
            txtOldEmail.Margin = new Padding(4);
            txtOldEmail.Name = "txtOldEmail";
            txtOldEmail.Size = new Size(155, 31);
            txtOldEmail.TabIndex = 31;
            // 
            // lblOldEmail
            // 
            lblOldEmail.AutoSize = true;
            lblOldEmail.Location = new Point(4, 408);
            lblOldEmail.Margin = new Padding(4, 0, 4, 0);
            lblOldEmail.Name = "lblOldEmail";
            lblOldEmail.Size = new Size(58, 25);
            lblOldEmail.TabIndex = 30;
            lblOldEmail.Text = "Email:";
            // 
            // lsvChangePerson
            // 
            lsvChangePerson.Location = new Point(649, 4);
            lsvChangePerson.Margin = new Padding(4);
            lsvChangePerson.Name = "lsvChangePerson";
            lsvChangePerson.Size = new Size(576, 483);
            lsvChangePerson.TabIndex = 29;
            lsvChangePerson.UseCompatibleStateImageBehavior = false;
            lsvChangePerson.View = View.List;
            lsvChangePerson.SelectedIndexChanged += lsvChangePerson_SelectedIndexChanged;
            // 
            // txtOldYear
            // 
            txtOldYear.Location = new Point(112, 361);
            txtOldYear.Margin = new Padding(4);
            txtOldYear.Name = "txtOldYear";
            txtOldYear.Size = new Size(155, 31);
            txtOldYear.TabIndex = 5;
            // 
            // lblOldYear
            // 
            lblOldYear.AutoSize = true;
            lblOldYear.Location = new Point(4, 370);
            lblOldYear.Margin = new Padding(4, 0, 4, 0);
            lblOldYear.Name = "lblOldYear";
            lblOldYear.Size = new Size(53, 25);
            lblOldYear.TabIndex = 26;
            lblOldYear.Text = "Year: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(-4, 169);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(433, 25);
            label7.TabIndex = 23;
            label7.Text = "Leave the box blank if not changing or not applicable";
            // 
            // txtOldID
            // 
            txtOldID.Location = new Point(112, 244);
            txtOldID.Margin = new Padding(2);
            txtOldID.Name = "txtOldID";
            txtOldID.Size = new Size(155, 31);
            txtOldID.TabIndex = 2;
            // 
            // lblOldID
            // 
            lblOldID.AutoSize = true;
            lblOldID.Location = new Point(4, 248);
            lblOldID.Margin = new Padding(2, 0, 2, 0);
            lblOldID.Name = "lblOldID";
            lblOldID.Size = new Size(104, 25);
            lblOldID.TabIndex = 21;
            lblOldID.Text = "Person's ID:";
            // 
            // btnChangePersonClearForm
            // 
            btnChangePersonClearForm.Location = new Point(478, 4);
            btnChangePersonClearForm.Margin = new Padding(4);
            btnChangePersonClearForm.Name = "btnChangePersonClearForm";
            btnChangePersonClearForm.Size = new Size(145, 71);
            btnChangePersonClearForm.TabIndex = 12;
            btnChangePersonClearForm.Text = "Clear Form";
            btnChangePersonClearForm.UseVisualStyleBackColor = true;
            btnChangePersonClearForm.Click += btnChangePersonClearForm_Click;
            // 
            // btnSubmitChanges
            // 
            btnSubmitChanges.Location = new Point(325, 4);
            btnSubmitChanges.Margin = new Padding(4);
            btnSubmitChanges.Name = "btnSubmitChanges";
            btnSubmitChanges.Size = new Size(145, 71);
            btnSubmitChanges.TabIndex = 11;
            btnSubmitChanges.Text = "Submit Changes";
            btnSubmitChanges.UseVisualStyleBackColor = true;
            btnSubmitChanges.Click += btnSubmitChanges_Click;
            // 
            // txtNewYear
            // 
            txtNewYear.Location = new Point(458, 361);
            txtNewYear.Margin = new Padding(4);
            txtNewYear.Name = "txtNewYear";
            txtNewYear.Size = new Size(155, 31);
            txtNewYear.TabIndex = 9;
            // 
            // txtNewLName
            // 
            txtNewLName.Location = new Point(458, 318);
            txtNewLName.Margin = new Padding(4);
            txtNewLName.Name = "txtNewLName";
            txtNewLName.Size = new Size(155, 31);
            txtNewLName.TabIndex = 8;
            // 
            // txtNewFName
            // 
            txtNewFName.Location = new Point(458, 276);
            txtNewFName.Margin = new Padding(4);
            txtNewFName.Name = "txtNewFName";
            txtNewFName.Size = new Size(155, 31);
            txtNewFName.TabIndex = 7;
            // 
            // lblNewYear
            // 
            lblNewYear.AutoSize = true;
            lblNewYear.Location = new Point(346, 370);
            lblNewYear.Margin = new Padding(4, 0, 4, 0);
            lblNewYear.Name = "lblNewYear";
            lblNewYear.Size = new Size(53, 25);
            lblNewYear.TabIndex = 12;
            lblNewYear.Text = "Year: ";
            // 
            // lblNewLastName
            // 
            lblNewLastName.AutoSize = true;
            lblNewLastName.Location = new Point(342, 326);
            lblNewLastName.Margin = new Padding(4, 0, 4, 0);
            lblNewLastName.Name = "lblNewLastName";
            lblNewLastName.Size = new Size(104, 25);
            lblNewLastName.TabIndex = 11;
            lblNewLastName.Text = "Last Name: ";
            // 
            // lblNewFirstName
            // 
            lblNewFirstName.AutoSize = true;
            lblNewFirstName.Location = new Point(342, 285);
            lblNewFirstName.Margin = new Padding(4, 0, 4, 0);
            lblNewFirstName.Name = "lblNewFirstName";
            lblNewFirstName.Size = new Size(101, 25);
            lblNewFirstName.TabIndex = 10;
            lblNewFirstName.Text = "First Name:";
            // 
            // lblNewInfo
            // 
            lblNewInfo.AutoSize = true;
            lblNewInfo.Location = new Point(338, 204);
            lblNewInfo.Margin = new Padding(4, 0, 4, 0);
            lblNewInfo.Name = "lblNewInfo";
            lblNewInfo.Size = new Size(146, 25);
            lblNewInfo.TabIndex = 9;
            lblNewInfo.Text = "New Information";
            // 
            // txtOldLName
            // 
            txtOldLName.Location = new Point(112, 322);
            txtOldLName.Margin = new Padding(4);
            txtOldLName.Name = "txtOldLName";
            txtOldLName.Size = new Size(155, 31);
            txtOldLName.TabIndex = 4;
            // 
            // lblOldLName
            // 
            lblOldLName.AutoSize = true;
            lblOldLName.Location = new Point(4, 326);
            lblOldLName.Margin = new Padding(4, 0, 4, 0);
            lblOldLName.Name = "lblOldLName";
            lblOldLName.Size = new Size(99, 25);
            lblOldLName.TabIndex = 7;
            lblOldLName.Text = "Last Name:";
            // 
            // lblOldFName
            // 
            lblOldFName.AutoSize = true;
            lblOldFName.Location = new Point(4, 285);
            lblOldFName.Margin = new Padding(4, 0, 4, 0);
            lblOldFName.Name = "lblOldFName";
            lblOldFName.Size = new Size(101, 25);
            lblOldFName.TabIndex = 6;
            lblOldFName.Text = "First Name:";
            // 
            // txtOldFName
            // 
            txtOldFName.Location = new Point(112, 282);
            txtOldFName.Margin = new Padding(4);
            txtOldFName.Name = "txtOldFName";
            txtOldFName.Size = new Size(155, 31);
            txtOldFName.TabIndex = 3;
            // 
            // lblCurrentInfo
            // 
            lblCurrentInfo.AutoSize = true;
            lblCurrentInfo.Location = new Point(-6, 204);
            lblCurrentInfo.Margin = new Padding(4, 0, 4, 0);
            lblCurrentInfo.Name = "lblCurrentInfo";
            lblCurrentInfo.Size = new Size(169, 25);
            lblCurrentInfo.TabIndex = 4;
            lblCurrentInfo.Text = "Current Information";
            // 
            // radChangeAdvisor
            // 
            radChangeAdvisor.AutoSize = true;
            radChangeAdvisor.Location = new Point(138, 29);
            radChangeAdvisor.Margin = new Padding(4);
            radChangeAdvisor.Name = "radChangeAdvisor";
            radChangeAdvisor.Size = new Size(91, 29);
            radChangeAdvisor.TabIndex = 3;
            radChangeAdvisor.Text = "Advisor";
            radChangeAdvisor.UseVisualStyleBackColor = true;
            radChangeAdvisor.CheckedChanged += radChangeAdvisor_CheckedChanged;
            // 
            // radChangeStudent
            // 
            radChangeStudent.AutoSize = true;
            radChangeStudent.Checked = true;
            radChangeStudent.Location = new Point(29, 29);
            radChangeStudent.Margin = new Padding(4);
            radChangeStudent.Name = "radChangeStudent";
            radChangeStudent.Size = new Size(91, 29);
            radChangeStudent.TabIndex = 1;
            radChangeStudent.TabStop = true;
            radChangeStudent.Text = "Student";
            radChangeStudent.UseVisualStyleBackColor = true;
            radChangeStudent.CheckedChanged += radChangeStudent_CheckedChanged;
            // 
            // btnStudentAdvisorSelect
            // 
            btnStudentAdvisorSelect.AutoSize = true;
            btnStudentAdvisorSelect.Location = new Point(4, 0);
            btnStudentAdvisorSelect.Margin = new Padding(4, 0, 4, 0);
            btnStudentAdvisorSelect.Name = "btnStudentAdvisorSelect";
            btnStudentAdvisorSelect.Size = new Size(169, 25);
            btnStudentAdvisorSelect.TabIndex = 1;
            btnStudentAdvisorSelect.Text = "Student or Advisor?";
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(lsvDeletePerson);
            tabPage8.Controls.Add(txtDeleteYear);
            tabPage8.Controls.Add(lblDeleteYear);
            tabPage8.Controls.Add(txtDeleteEmail);
            tabPage8.Controls.Add(lblDeleteEmail);
            tabPage8.Controls.Add(txtPersonID);
            tabPage8.Controls.Add(lblPersonID);
            tabPage8.Controls.Add(btnDeletePersonClearForm);
            tabPage8.Controls.Add(btnDeletePerson);
            tabPage8.Controls.Add(txtDeleteLName);
            tabPage8.Controls.Add(label9);
            tabPage8.Controls.Add(label10);
            tabPage8.Controls.Add(txtDeleteFName);
            tabPage8.Controls.Add(label11);
            tabPage8.Controls.Add(radDeleteAdvisor);
            tabPage8.Controls.Add(radDeleteStudent);
            tabPage8.Controls.Add(label12);
            tabPage8.Location = new Point(4, 34);
            tabPage8.Margin = new Padding(2);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1238, 494);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "Delete Person";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // lsvDeletePerson
            // 
            lsvDeletePerson.Location = new Point(620, 9);
            lsvDeletePerson.Margin = new Padding(4);
            lsvDeletePerson.Name = "lsvDeletePerson";
            lsvDeletePerson.Size = new Size(605, 478);
            lsvDeletePerson.TabIndex = 25;
            lsvDeletePerson.UseCompatibleStateImageBehavior = false;
            lsvDeletePerson.View = View.List;
            lsvDeletePerson.SelectedIndexChanged += lsvDeletePerson_SelectedIndexChanged;
            // 
            // txtDeleteYear
            // 
            txtDeleteYear.Location = new Point(144, 250);
            txtDeleteYear.Margin = new Padding(2);
            txtDeleteYear.Name = "txtDeleteYear";
            txtDeleteYear.Size = new Size(155, 31);
            txtDeleteYear.TabIndex = 6;
            // 
            // lblDeleteYear
            // 
            lblDeleteYear.AutoSize = true;
            lblDeleteYear.Location = new Point(32, 256);
            lblDeleteYear.Margin = new Padding(2, 0, 2, 0);
            lblDeleteYear.Name = "lblDeleteYear";
            lblDeleteYear.Size = new Size(48, 25);
            lblDeleteYear.TabIndex = 24;
            lblDeleteYear.Text = "Year:";
            // 
            // txtDeleteEmail
            // 
            txtDeleteEmail.Location = new Point(144, 210);
            txtDeleteEmail.Margin = new Padding(2);
            txtDeleteEmail.Name = "txtDeleteEmail";
            txtDeleteEmail.Size = new Size(155, 31);
            txtDeleteEmail.TabIndex = 5;
            // 
            // lblDeleteEmail
            // 
            lblDeleteEmail.AutoSize = true;
            lblDeleteEmail.Location = new Point(32, 212);
            lblDeleteEmail.Margin = new Padding(2, 0, 2, 0);
            lblDeleteEmail.Name = "lblDeleteEmail";
            lblDeleteEmail.Size = new Size(58, 25);
            lblDeleteEmail.TabIndex = 22;
            lblDeleteEmail.Text = "Email:";
            // 
            // txtPersonID
            // 
            txtPersonID.Location = new Point(142, 288);
            txtPersonID.Margin = new Padding(2);
            txtPersonID.Name = "txtPersonID";
            txtPersonID.Size = new Size(156, 31);
            txtPersonID.TabIndex = 7;
            // 
            // lblPersonID
            // 
            lblPersonID.AutoSize = true;
            lblPersonID.Location = new Point(28, 288);
            lblPersonID.Margin = new Padding(2, 0, 2, 0);
            lblPersonID.Name = "lblPersonID";
            lblPersonID.Size = new Size(104, 25);
            lblPersonID.TabIndex = 20;
            lblPersonID.Text = "Person's ID:";
            // 
            // btnDeletePersonClearForm
            // 
            btnDeletePersonClearForm.Location = new Point(468, 106);
            btnDeletePersonClearForm.Margin = new Padding(4);
            btnDeletePersonClearForm.Name = "btnDeletePersonClearForm";
            btnDeletePersonClearForm.Size = new Size(145, 71);
            btnDeletePersonClearForm.TabIndex = 9;
            btnDeletePersonClearForm.Text = "Clear Form";
            btnDeletePersonClearForm.UseVisualStyleBackColor = true;
            btnDeletePersonClearForm.Click += btnDeletePersonClearForm_Click;
            // 
            // btnDeletePerson
            // 
            btnDeletePerson.Location = new Point(468, 18);
            btnDeletePerson.Margin = new Padding(4);
            btnDeletePerson.Name = "btnDeletePerson";
            btnDeletePerson.Size = new Size(145, 71);
            btnDeletePerson.TabIndex = 8;
            btnDeletePerson.Text = "Delete Person";
            btnDeletePerson.UseVisualStyleBackColor = true;
            btnDeletePerson.Click += btnDeletePerson_Click;
            // 
            // txtDeleteLName
            // 
            txtDeleteLName.Location = new Point(144, 168);
            txtDeleteLName.Margin = new Padding(4);
            txtDeleteLName.Name = "txtDeleteLName";
            txtDeleteLName.Size = new Size(155, 31);
            txtDeleteLName.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 170);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(99, 25);
            label9.TabIndex = 15;
            label9.Text = "Last Name:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(32, 129);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(101, 25);
            label10.TabIndex = 14;
            label10.Text = "First Name:";
            // 
            // txtDeleteFName
            // 
            txtDeleteFName.Location = new Point(144, 125);
            txtDeleteFName.Margin = new Padding(4);
            txtDeleteFName.Name = "txtDeleteFName";
            txtDeleteFName.Size = new Size(155, 31);
            txtDeleteFName.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 84);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(169, 25);
            label11.TabIndex = 12;
            label11.Text = "Current Information";
            // 
            // radDeleteAdvisor
            // 
            radDeleteAdvisor.AutoSize = true;
            radDeleteAdvisor.Location = new Point(142, 38);
            radDeleteAdvisor.Margin = new Padding(4);
            radDeleteAdvisor.Name = "radDeleteAdvisor";
            radDeleteAdvisor.Size = new Size(91, 29);
            radDeleteAdvisor.TabIndex = 2;
            radDeleteAdvisor.Text = "Advisor";
            radDeleteAdvisor.UseVisualStyleBackColor = true;
            radDeleteAdvisor.CheckedChanged += radDeleteAdvisor_CheckedChanged;
            // 
            // radDeleteStudent
            // 
            radDeleteStudent.AutoSize = true;
            radDeleteStudent.Checked = true;
            radDeleteStudent.Location = new Point(32, 38);
            radDeleteStudent.Margin = new Padding(4);
            radDeleteStudent.Name = "radDeleteStudent";
            radDeleteStudent.Size = new Size(91, 29);
            radDeleteStudent.TabIndex = 1;
            radDeleteStudent.TabStop = true;
            radDeleteStudent.Text = "Student";
            radDeleteStudent.UseVisualStyleBackColor = true;
            radDeleteStudent.CheckedChanged += radDeleteStudent_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(8, 9);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(169, 25);
            label12.TabIndex = 9;
            label12.Text = "Student or Advisor?";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(lsvCreateAvailability);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1238, 494);
            tabPage3.TabIndex = 8;
            tabPage3.Text = "Create Availability";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // lsvCreateAvailability
            // 
            lsvCreateAvailability.Location = new Point(667, 3);
            lsvCreateAvailability.Name = "lsvCreateAvailability";
            lsvCreateAvailability.Size = new Size(568, 488);
            lsvCreateAvailability.TabIndex = 1;
            lsvCreateAvailability.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(lsvChangeAvailability);
            tabPage7.Location = new Point(4, 34);
            tabPage7.Margin = new Padding(4);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1238, 494);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Change Availability";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // lsvChangeAvailability
            // 
            lsvChangeAvailability.Location = new Point(667, 3);
            lsvChangeAvailability.Name = "lsvChangeAvailability";
            lsvChangeAvailability.Size = new Size(568, 488);
            lsvChangeAvailability.TabIndex = 0;
            lsvChangeAvailability.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lsvDeleteAvailability);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1238, 494);
            tabPage4.TabIndex = 9;
            tabPage4.Text = "Delete Availability";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lsvDeleteAvailability
            // 
            lsvDeleteAvailability.Location = new Point(667, 3);
            lsvDeleteAvailability.Name = "lsvDeleteAvailability";
            lsvDeleteAvailability.Size = new Size(568, 488);
            lsvDeleteAvailability.TabIndex = 1;
            lsvDeleteAvailability.UseCompatibleStateImageBehavior = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 562);
            Controls.Add(tabMain);
            Margin = new Padding(4);
            Name = "frmMain";
            Text = "Appointments";
            Load += Form1_Load;
            tabMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabMain;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtStudentFName;
        private Label lblStudentFName;
        private TextBox txtStudentLName;
        private Label lblStudentLName;
        private Label lblStudent;
        private Label lblProfLName;
        private Label lblProfFName;
        private Label lblAdvisor;
        private TextBox txtProfLName;
        private TextBox txtProfFName;
        private MonthCalendar monthCalendar2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Label label5;
        private TextBox textBox4;
        private Label label6;
        private Button btnUpdate;
        private TextBox txtAppointmentID;
        private Label lblAppointmentID;
        private Label lblAppointment;
        private Button btnDelete;
        private TabPage tabPage5;
        private Button btnClearAppt;
        private Button btnMakeAppt;
        private RadioButton radChangeAdvisor;
        private RadioButton radChangeStudent;
        private Label btnStudentAdvisorSelect;
        private Label lblNewFirstName;
        private Label lblNewInfo;
        private TextBox txtOldLName;
        private Label lblOldLName;
        private Label lblOldFName;
        private TextBox txtOldFName;
        private Label lblCurrentInfo;
        private Label lblNewLastName;
        private Button btnChangePersonClearForm;
        private Button btnSubmitChanges;
        private TextBox txtNewYear;
        private TextBox txtNewLName;
        private TextBox txtNewFName;
        private Label lblNewYear;
        private TabPage tabPage6;
        private TextBox txtEmailNew;
        private Label lblEmailNew;
        private TextBox txtYearNew;
        private Label lblYearNew;
        private Label lblLeaveBlank;
        private TextBox txtLNameNew;
        private Label lblLastNameNew;
        private Label lblFirstNameNew;
        private TextBox txtFNameNew;
        private Label lblInfo;
        private RadioButton radAdvisorNew;
        private RadioButton radStudentNew;
        private Label lblStudentAdvisor;
        private Button btnClearFormAdd;
        private Button btnSubmitNew;
        private DateTimePicker dateTimePicker1;
        private TabPage tabPage7;
        private DateTimePicker dateTimePicker2;
        private TabPage tabPage8;
        private Button btnDeletePersonClearForm;
        private Button btnDeletePerson;
        private TextBox txtDeleteLName;
        private Label label9;
        private Label label10;
        private TextBox txtDeleteFName;
        private Label label11;
        private RadioButton radDeleteAdvisor;
        private RadioButton radDeleteStudent;
        private Label label12;
        private TextBox txtPersonID;
        private Label lblPersonID;
        private TextBox txtDeleteEmail;
        private Label lblDeleteEmail;
        private TextBox txtDeleteYear;
        private Label lblDeleteYear;
        private Label lblOldID;
        private TextBox txtOldID;
        private TextBox txtOldYear;
        private Label lblOldYear;
        private Label label7;
        private ListView lsvAddPerson;
        private ListView lsvChangePerson;
        private ListView lsvDeletePerson;
        private TextBox txtOldEmail;
        private Label lblOldEmail;
        private TextBox txtNewEmail;
        private Label lblNewEmail;
        private TabPage tabPage3;
        private ListView lsvChangeAvailability;
        private TabPage tabPage4;
        private ListView lsvCreateAvailability;
        private ListView lsvDeleteAvailability;
    }
}
