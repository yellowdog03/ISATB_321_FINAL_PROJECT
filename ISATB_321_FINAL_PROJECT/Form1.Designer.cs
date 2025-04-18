namespace ISATB_321_FINAL_PROJECT
{
    partial class Form1
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
            tabControlMain = new TabControl();
            tabPage1 = new TabPage();
            monthCalendar1 = new MonthCalendar();
            txtProfLName = new TextBox();
            txtProfFName = new TextBox();
            lblProfLName = new Label();
            lblProfFName = new Label();
            lblProfessor = new Label();
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
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            listBox1 = new ListBox();
            tabControlMain.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPage1);
            tabControlMain.Controls.Add(tabPage2);
            tabControlMain.Controls.Add(tabPage3);
            tabControlMain.Controls.Add(tabPage4);
            tabControlMain.Location = new Point(12, 12);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(776, 426);
            tabControlMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(monthCalendar1);
            tabPage1.Controls.Add(txtProfLName);
            tabPage1.Controls.Add(txtProfFName);
            tabPage1.Controls.Add(lblProfLName);
            tabPage1.Controls.Add(lblProfFName);
            tabPage1.Controls.Add(lblProfessor);
            tabPage1.Controls.Add(txtStudentLName);
            tabPage1.Controls.Add(lblStudentLName);
            tabPage1.Controls.Add(lblStudent);
            tabPage1.Controls.Add(txtStudentFName);
            tabPage1.Controls.Add(lblStudentFName);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 393);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Schedule Appointment";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(494, 12);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 10;
            // 
            // txtProfLName
            // 
            txtProfLName.Location = new Point(141, 226);
            txtProfLName.Name = "txtProfLName";
            txtProfLName.Size = new Size(125, 27);
            txtProfLName.TabIndex = 9;
            // 
            // txtProfFName
            // 
            txtProfFName.Location = new Point(141, 188);
            txtProfFName.Name = "txtProfFName";
            txtProfFName.Size = new Size(125, 27);
            txtProfFName.TabIndex = 8;
            // 
            // lblProfLName
            // 
            lblProfLName.AutoSize = true;
            lblProfLName.Location = new Point(53, 229);
            lblProfLName.Name = "lblProfLName";
            lblProfLName.Size = new Size(82, 20);
            lblProfLName.TabIndex = 7;
            lblProfLName.Text = "Last Name:";
            // 
            // lblProfFName
            // 
            lblProfFName.AutoSize = true;
            lblProfFName.Location = new Point(53, 188);
            lblProfFName.Name = "lblProfFName";
            lblProfFName.Size = new Size(83, 20);
            lblProfFName.TabIndex = 6;
            lblProfFName.Text = "First Name:";
            // 
            // lblProfessor
            // 
            lblProfessor.AutoSize = true;
            lblProfessor.Location = new Point(30, 147);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(70, 20);
            lblProfessor.TabIndex = 5;
            lblProfessor.Text = "Professor";
            // 
            // txtStudentLName
            // 
            txtStudentLName.Location = new Point(141, 80);
            txtStudentLName.Name = "txtStudentLName";
            txtStudentLName.Size = new Size(131, 27);
            txtStudentLName.TabIndex = 4;
            // 
            // lblStudentLName
            // 
            lblStudentLName.AutoSize = true;
            lblStudentLName.Location = new Point(53, 83);
            lblStudentLName.Name = "lblStudentLName";
            lblStudentLName.Size = new Size(82, 20);
            lblStudentLName.TabIndex = 3;
            lblStudentLName.Text = "Last Name:";
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(30, 12);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(60, 20);
            lblStudent.TabIndex = 2;
            lblStudent.Text = "Student";
            // 
            // txtStudentFName
            // 
            txtStudentFName.Location = new Point(142, 38);
            txtStudentFName.Name = "txtStudentFName";
            txtStudentFName.Size = new Size(130, 27);
            txtStudentFName.TabIndex = 1;
            // 
            // lblStudentFName
            // 
            lblStudentFName.AutoSize = true;
            lblStudentFName.Location = new Point(53, 41);
            lblStudentFName.Name = "lblStudentFName";
            lblStudentFName.Size = new Size(83, 20);
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
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 393);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Change Appointment";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(656, 275);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(494, 275);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtAppointmentID
            // 
            txtAppointmentID.Location = new Point(178, 312);
            txtAppointmentID.Name = "txtAppointmentID";
            txtAppointmentID.Size = new Size(125, 27);
            txtAppointmentID.TabIndex = 24;
            // 
            // lblAppointmentID
            // 
            lblAppointmentID.AutoSize = true;
            lblAppointmentID.Location = new Point(53, 315);
            lblAppointmentID.Name = "lblAppointmentID";
            lblAppointmentID.Size = new Size(119, 20);
            lblAppointmentID.TabIndex = 23;
            lblAppointmentID.Text = "Appointment ID:";
            // 
            // lblAppointment
            // 
            lblAppointment.AutoSize = true;
            lblAppointment.Location = new Point(30, 284);
            lblAppointment.Name = "lblAppointment";
            lblAppointment.Size = new Size(97, 20);
            lblAppointment.TabIndex = 22;
            lblAppointment.Text = "Appointment";
            // 
            // monthCalendar2
            // 
            monthCalendar2.Location = new Point(494, 12);
            monthCalendar2.Name = "monthCalendar2";
            monthCalendar2.TabIndex = 21;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 215);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 20;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(141, 177);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 218);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 18;
            label1.Text = "Last Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 177);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 17;
            label2.Text = "First Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 147);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 16;
            label3.Text = "Professor";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(141, 80);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(131, 27);
            textBox3.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 83);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 14;
            label4.Text = "Last Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 12);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 13;
            label5.Text = "Student";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(142, 38);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(130, 27);
            textBox4.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(53, 41);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 11;
            label6.Text = "First Name:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(listBox1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(768, 393);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "View Advisors";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(768, 393);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "View Students";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(3, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(762, 384);
            listBox1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlMain);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControlMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControlMain;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox txtStudentFName;
        private Label lblStudentFName;
        private TextBox txtStudentLName;
        private Label lblStudentLName;
        private Label lblStudent;
        private Label lblProfLName;
        private Label lblProfFName;
        private Label lblProfessor;
        private MonthCalendar monthCalendar1;
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
        private ListBox listBox1;
    }
}
