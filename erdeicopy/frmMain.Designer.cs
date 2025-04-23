namespace WindowsFormsApp1
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabAdvisors = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDeleteAdvisorInfo = new System.Windows.Forms.Button();
            this.btnUpdateAdvisorInfo = new System.Windows.Forms.Button();
            this.btnEditAdvisorInfo = new System.Windows.Forms.Button();
            this.txtAdvisorEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdvisorLName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwAdvisors = new System.Windows.Forms.ListView();
            this.txtAdvisorFName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdvisorID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdvisorEmailInsert = new System.Windows.Forms.TextBox();
            this.txtAdvisorFNameInsert = new System.Windows.Forms.TextBox();
            this.txtAdvisorLNameInsert = new System.Windows.Forms.TextBox();
            this.txtAdvisorIDInsert = new System.Windows.Forms.TextBox();
            this.btnInsertAdvisorInfo = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnStudentDelete = new System.Windows.Forms.Button();
            this.btnStudentUpdate = new System.Windows.Forms.Button();
            this.btnStudentEdit = new System.Windows.Forms.Button();
            this.txtStudentAdvisorID = new System.Windows.Forms.TextBox();
            this.lblStudentAdvisorID = new System.Windows.Forms.Label();
            this.lblStudentLName = new System.Windows.Forms.Label();
            this.txtStudentLName = new System.Windows.Forms.TextBox();
            this.lblStudents = new System.Windows.Forms.Label();
            this.lvwStudents = new System.Windows.Forms.ListView();
            this.txtStudentFName = new System.Windows.Forms.TextBox();
            this.lblStudentFName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabAdvisors.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAdvisors
            // 
            this.tabAdvisors.Controls.Add(this.tabPage1);
            this.tabAdvisors.Controls.Add(this.tabPage2);
            this.tabAdvisors.Controls.Add(this.tabPage3);
            this.tabAdvisors.Controls.Add(this.tabPage4);
            this.tabAdvisors.Location = new System.Drawing.Point(21, 45);
            this.tabAdvisors.Name = "tabAdvisors";
            this.tabAdvisors.SelectedIndex = 0;
            this.tabAdvisors.Size = new System.Drawing.Size(903, 513);
            this.tabAdvisors.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDeleteAdvisorInfo);
            this.tabPage1.Controls.Add(this.btnUpdateAdvisorInfo);
            this.tabPage1.Controls.Add(this.btnEditAdvisorInfo);
            this.tabPage1.Controls.Add(this.txtAdvisorEmail);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtAdvisorLName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lvwAdvisors);
            this.tabPage1.Controls.Add(this.txtAdvisorFName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtAdvisorID);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(895, 480);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Current Advisors";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnDeleteAdvisorInfo
            // 
            this.btnDeleteAdvisorInfo.Location = new System.Drawing.Point(615, 343);
            this.btnDeleteAdvisorInfo.Name = "btnDeleteAdvisorInfo";
            this.btnDeleteAdvisorInfo.Size = new System.Drawing.Size(136, 44);
            this.btnDeleteAdvisorInfo.TabIndex = 19;
            this.btnDeleteAdvisorInfo.Text = "Delete";
            this.btnDeleteAdvisorInfo.UseVisualStyleBackColor = true;
            this.btnDeleteAdvisorInfo.Visible = false;
            this.btnDeleteAdvisorInfo.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdateAdvisorInfo
            // 
            this.btnUpdateAdvisorInfo.Location = new System.Drawing.Point(615, 293);
            this.btnUpdateAdvisorInfo.Name = "btnUpdateAdvisorInfo";
            this.btnUpdateAdvisorInfo.Size = new System.Drawing.Size(136, 44);
            this.btnUpdateAdvisorInfo.TabIndex = 18;
            this.btnUpdateAdvisorInfo.Text = "Update";
            this.btnUpdateAdvisorInfo.UseVisualStyleBackColor = true;
            this.btnUpdateAdvisorInfo.Visible = false;
            this.btnUpdateAdvisorInfo.Click += new System.EventHandler(this.btnUpdatePetInfo_Click);
            // 
            // btnEditAdvisorInfo
            // 
            this.btnEditAdvisorInfo.Location = new System.Drawing.Point(473, 293);
            this.btnEditAdvisorInfo.Name = "btnEditAdvisorInfo";
            this.btnEditAdvisorInfo.Size = new System.Drawing.Size(136, 44);
            this.btnEditAdvisorInfo.TabIndex = 17;
            this.btnEditAdvisorInfo.Text = "Edit";
            this.btnEditAdvisorInfo.UseVisualStyleBackColor = true;
            this.btnEditAdvisorInfo.Click += new System.EventHandler(this.btnEditPetInfo_Click);
            // 
            // txtAdvisorEmail
            // 
            this.txtAdvisorEmail.Location = new System.Drawing.Point(473, 208);
            this.txtAdvisorEmail.Name = "txtAdvisorEmail";
            this.txtAdvisorEmail.ReadOnly = true;
            this.txtAdvisorEmail.Size = new System.Drawing.Size(243, 26);
            this.txtAdvisorEmail.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Last Name:";
            // 
            // txtAdvisorLName
            // 
            this.txtAdvisorLName.Location = new System.Drawing.Point(473, 172);
            this.txtAdvisorLName.Name = "txtAdvisorLName";
            this.txtAdvisorLName.ReadOnly = true;
            this.txtAdvisorLName.Size = new System.Drawing.Size(243, 26);
            this.txtAdvisorLName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Advisors:";
            // 
            // lvwAdvisors
            // 
            this.lvwAdvisors.HideSelection = false;
            this.lvwAdvisors.Location = new System.Drawing.Point(34, 49);
            this.lvwAdvisors.Name = "lvwAdvisors";
            this.lvwAdvisors.Size = new System.Drawing.Size(227, 377);
            this.lvwAdvisors.TabIndex = 1;
            this.lvwAdvisors.UseCompatibleStateImageBehavior = false;
            this.lvwAdvisors.View = System.Windows.Forms.View.List;
            this.lvwAdvisors.SelectedIndexChanged += new System.EventHandler(this.lvwPets_Update_SelectedIndexChanged);
            // 
            // txtAdvisorFName
            // 
            this.txtAdvisorFName.Location = new System.Drawing.Point(473, 136);
            this.txtAdvisorFName.Name = "txtAdvisorFName";
            this.txtAdvisorFName.ReadOnly = true;
            this.txtAdvisorFName.Size = new System.Drawing.Size(243, 26);
            this.txtAdvisorFName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "First Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID:";
            // 
            // txtAdvisorID
            // 
            this.txtAdvisorID.Location = new System.Drawing.Point(473, 100);
            this.txtAdvisorID.Name = "txtAdvisorID";
            this.txtAdvisorID.Size = new System.Drawing.Size(243, 26);
            this.txtAdvisorID.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtAdvisorEmailInsert);
            this.tabPage2.Controls.Add(this.txtAdvisorFNameInsert);
            this.tabPage2.Controls.Add(this.txtAdvisorLNameInsert);
            this.tabPage2.Controls.Add(this.txtAdvisorIDInsert);
            this.tabPage2.Controls.Add(this.btnInsertAdvisorInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(895, 480);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Insert New Advisor";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(330, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(292, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Last Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "First Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "ID:";
            // 
            // txtAdvisorEmailInsert
            // 
            this.txtAdvisorEmailInsert.Location = new System.Drawing.Point(400, 225);
            this.txtAdvisorEmailInsert.Name = "txtAdvisorEmailInsert";
            this.txtAdvisorEmailInsert.Size = new System.Drawing.Size(186, 26);
            this.txtAdvisorEmailInsert.TabIndex = 25;
            // 
            // txtAdvisorFNameInsert
            // 
            this.txtAdvisorFNameInsert.Location = new System.Drawing.Point(400, 136);
            this.txtAdvisorFNameInsert.Name = "txtAdvisorFNameInsert";
            this.txtAdvisorFNameInsert.Size = new System.Drawing.Size(186, 26);
            this.txtAdvisorFNameInsert.TabIndex = 24;
            // 
            // txtAdvisorLNameInsert
            // 
            this.txtAdvisorLNameInsert.Location = new System.Drawing.Point(400, 181);
            this.txtAdvisorLNameInsert.Name = "txtAdvisorLNameInsert";
            this.txtAdvisorLNameInsert.Size = new System.Drawing.Size(186, 26);
            this.txtAdvisorLNameInsert.TabIndex = 23;
            this.txtAdvisorLNameInsert.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtAdvisorIDInsert
            // 
            this.txtAdvisorIDInsert.Location = new System.Drawing.Point(400, 93);
            this.txtAdvisorIDInsert.Name = "txtAdvisorIDInsert";
            this.txtAdvisorIDInsert.ReadOnly = true;
            this.txtAdvisorIDInsert.Size = new System.Drawing.Size(186, 26);
            this.txtAdvisorIDInsert.TabIndex = 22;
            // 
            // btnInsertAdvisorInfo
            // 
            this.btnInsertAdvisorInfo.Location = new System.Drawing.Point(423, 289);
            this.btnInsertAdvisorInfo.Name = "btnInsertAdvisorInfo";
            this.btnInsertAdvisorInfo.Size = new System.Drawing.Size(136, 44);
            this.btnInsertAdvisorInfo.TabIndex = 21;
            this.btnInsertAdvisorInfo.Text = "Insert";
            this.btnInsertAdvisorInfo.UseVisualStyleBackColor = true;
            this.btnInsertAdvisorInfo.Click += new System.EventHandler(this.btnInsertAdvisorInfo_Click_1);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtYear);
            this.tabPage3.Controls.Add(this.lblYear);
            this.tabPage3.Controls.Add(this.btnStudentDelete);
            this.tabPage3.Controls.Add(this.btnStudentUpdate);
            this.tabPage3.Controls.Add(this.btnStudentEdit);
            this.tabPage3.Controls.Add(this.txtStudentAdvisorID);
            this.tabPage3.Controls.Add(this.lblStudentAdvisorID);
            this.tabPage3.Controls.Add(this.lblStudentLName);
            this.tabPage3.Controls.Add(this.txtStudentLName);
            this.tabPage3.Controls.Add(this.lblStudents);
            this.tabPage3.Controls.Add(this.lvwStudents);
            this.tabPage3.Controls.Add(this.txtStudentFName);
            this.tabPage3.Controls.Add(this.lblStudentFName);
            this.tabPage3.Controls.Add(this.lblStudentID);
            this.tabPage3.Controls.Add(this.txtStudentID);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(895, 480);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Current Students";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(530, 262);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(243, 26);
            this.txtYear.TabIndex = 34;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(421, 265);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(47, 20);
            this.lblYear.TabIndex = 33;
            this.lblYear.Text = "Year:";
            // 
            // btnStudentDelete
            // 
            this.btnStudentDelete.Location = new System.Drawing.Point(672, 360);
            this.btnStudentDelete.Name = "btnStudentDelete";
            this.btnStudentDelete.Size = new System.Drawing.Size(136, 44);
            this.btnStudentDelete.TabIndex = 32;
            this.btnStudentDelete.Text = "Delete";
            this.btnStudentDelete.UseVisualStyleBackColor = true;
            this.btnStudentDelete.Visible = false;
            // 
            // btnStudentUpdate
            // 
            this.btnStudentUpdate.Location = new System.Drawing.Point(672, 310);
            this.btnStudentUpdate.Name = "btnStudentUpdate";
            this.btnStudentUpdate.Size = new System.Drawing.Size(136, 44);
            this.btnStudentUpdate.TabIndex = 31;
            this.btnStudentUpdate.Text = "Update";
            this.btnStudentUpdate.UseVisualStyleBackColor = true;
            this.btnStudentUpdate.Visible = false;
            this.btnStudentUpdate.Click += new System.EventHandler(this.btnStudentUpdate_Click);
            // 
            // btnStudentEdit
            // 
            this.btnStudentEdit.Location = new System.Drawing.Point(530, 310);
            this.btnStudentEdit.Name = "btnStudentEdit";
            this.btnStudentEdit.Size = new System.Drawing.Size(136, 44);
            this.btnStudentEdit.TabIndex = 30;
            this.btnStudentEdit.Text = "Edit";
            this.btnStudentEdit.UseVisualStyleBackColor = true;
            this.btnStudentEdit.Click += new System.EventHandler(this.btnStudentEdit_Click);
            // 
            // txtStudentAdvisorID
            // 
            this.txtStudentAdvisorID.Location = new System.Drawing.Point(530, 225);
            this.txtStudentAdvisorID.Name = "txtStudentAdvisorID";
            this.txtStudentAdvisorID.ReadOnly = true;
            this.txtStudentAdvisorID.Size = new System.Drawing.Size(243, 26);
            this.txtStudentAdvisorID.TabIndex = 29;
            // 
            // lblStudentAdvisorID
            // 
            this.lblStudentAdvisorID.AutoSize = true;
            this.lblStudentAdvisorID.Location = new System.Drawing.Point(421, 228);
            this.lblStudentAdvisorID.Name = "lblStudentAdvisorID";
            this.lblStudentAdvisorID.Size = new System.Drawing.Size(82, 20);
            this.lblStudentAdvisorID.TabIndex = 28;
            this.lblStudentAdvisorID.Text = "AdvisorID:";
            // 
            // lblStudentLName
            // 
            this.lblStudentLName.AutoSize = true;
            this.lblStudentLName.Location = new System.Drawing.Point(421, 192);
            this.lblStudentLName.Name = "lblStudentLName";
            this.lblStudentLName.Size = new System.Drawing.Size(90, 20);
            this.lblStudentLName.TabIndex = 27;
            this.lblStudentLName.Text = "Last Name:";
            // 
            // txtStudentLName
            // 
            this.txtStudentLName.Location = new System.Drawing.Point(530, 189);
            this.txtStudentLName.Name = "txtStudentLName";
            this.txtStudentLName.ReadOnly = true;
            this.txtStudentLName.Size = new System.Drawing.Size(243, 26);
            this.txtStudentLName.TabIndex = 26;
            // 
            // lblStudents
            // 
            this.lblStudents.AutoSize = true;
            this.lblStudents.Location = new System.Drawing.Point(86, 38);
            this.lblStudents.Name = "lblStudents";
            this.lblStudents.Size = new System.Drawing.Size(78, 20);
            this.lblStudents.TabIndex = 25;
            this.lblStudents.Text = "Students:";
            // 
            // lvwStudents
            // 
            this.lvwStudents.HideSelection = false;
            this.lvwStudents.Location = new System.Drawing.Point(91, 66);
            this.lvwStudents.Name = "lvwStudents";
            this.lvwStudents.Size = new System.Drawing.Size(227, 377);
            this.lvwStudents.TabIndex = 20;
            this.lvwStudents.UseCompatibleStateImageBehavior = false;
            this.lvwStudents.View = System.Windows.Forms.View.List;
            this.lvwAdvisors.SelectedIndexChanged += new System.EventHandler(this.lvwStudents_Update_SelectedIndexChanged);//PIN********************

            // 
            // txtStudentFName
            // 
            this.txtStudentFName.Location = new System.Drawing.Point(530, 153);
            this.txtStudentFName.Name = "txtStudentFName";
            this.txtStudentFName.ReadOnly = true;
            this.txtStudentFName.Size = new System.Drawing.Size(243, 26);
            this.txtStudentFName.TabIndex = 24;
            // 
            // lblStudentFName
            // 
            this.lblStudentFName.AutoSize = true;
            this.lblStudentFName.Location = new System.Drawing.Point(421, 156);
            this.lblStudentFName.Name = "lblStudentFName";
            this.lblStudentFName.Size = new System.Drawing.Size(90, 20);
            this.lblStudentFName.TabIndex = 23;
            this.lblStudentFName.Text = "First Name:";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(421, 120);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(30, 20);
            this.lblStudentID.TabIndex = 22;
            this.lblStudentID.Text = "ID:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(530, 117);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(243, 26);
            this.txtStudentID.TabIndex = 21;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(895, 480);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Insert New Student";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 674);
            this.Controls.Add(this.tabAdvisors);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "B321 - ICE: Database Connectivity";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabAdvisors.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabAdvisors;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtAdvisorFName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdvisorID;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvwAdvisors;
        private System.Windows.Forms.TextBox txtAdvisorLName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdvisorEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditAdvisorInfo;
        private System.Windows.Forms.Button btnUpdateAdvisorInfo;
        private System.Windows.Forms.Button btnDeleteAdvisorInfo;
        private System.Windows.Forms.Button btnInsertAdvisorInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAdvisorEmailInsert;
        private System.Windows.Forms.TextBox txtAdvisorFNameInsert;
        private System.Windows.Forms.TextBox txtAdvisorLNameInsert;
        private System.Windows.Forms.TextBox txtAdvisorIDInsert;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnStudentDelete;
        private System.Windows.Forms.Button btnStudentUpdate;
        private System.Windows.Forms.Button btnStudentEdit;
        private System.Windows.Forms.TextBox txtStudentAdvisorID;
        private System.Windows.Forms.Label lblStudentAdvisorID;
        private System.Windows.Forms.Label lblStudentLName;
        private System.Windows.Forms.TextBox txtStudentLName;
        private System.Windows.Forms.Label lblStudents;
        private System.Windows.Forms.ListView lvwStudents;
        private System.Windows.Forms.TextBox txtStudentFName;
        private System.Windows.Forms.Label lblStudentFName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblYear;
    }
}

