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
            this.btnGetPet = new System.Windows.Forms.Button();
            this.tabAdvisors = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDeleteAdvisorInfo = new System.Windows.Forms.Button();
            this.btnUpdateAdvisorInfo = new System.Windows.Forms.Button();
            this.btnEditAdvisorInfo = new System.Windows.Forms.Button();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.btnInsertAdvisorInfo = new System.Windows.Forms.Button();
            this.tabAdvisors.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetPet
            // 
            this.btnGetPet.Location = new System.Drawing.Point(0, 0);
            this.btnGetPet.Name = "btnGetPet";
            this.btnGetPet.Size = new System.Drawing.Size(75, 23);
            this.btnGetPet.TabIndex = 0;
            // 
            // tabAdvisors
            // 
            this.tabAdvisors.Controls.Add(this.tabPage1);
            this.tabAdvisors.Controls.Add(this.tabPage2);
            this.tabAdvisors.Location = new System.Drawing.Point(21, 45);
            this.tabAdvisors.Name = "tabAdvisors";
            this.tabAdvisors.SelectedIndex = 0;
            this.tabAdvisors.Size = new System.Drawing.Size(903, 513);
            this.tabAdvisors.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnInsertAdvisorInfo);
            this.tabPage1.Controls.Add(this.btnDeleteAdvisorInfo);
            this.tabPage1.Controls.Add(this.btnUpdateAdvisorInfo);
            this.tabPage1.Controls.Add(this.btnEditAdvisorInfo);
            this.tabPage1.Controls.Add(this.txtWeight);
            this.tabPage1.Controls.Add(this.label6);
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
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(473, 244);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Size = new System.Drawing.Size(243, 26);
            this.txtWeight.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Weight:";
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
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(895, 480);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Insert New Advisor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnInsertAdvisorInfo
            // 
            this.btnInsertAdvisorInfo.Location = new System.Drawing.Point(473, 343);
            this.btnInsertAdvisorInfo.Name = "btnInsertAdvisorInfo";
            this.btnInsertAdvisorInfo.Size = new System.Drawing.Size(136, 44);
            this.btnInsertAdvisorInfo.TabIndex = 20;
            this.btnInsertAdvisorInfo.Text = "Insert";
            this.btnInsertAdvisorInfo.UseVisualStyleBackColor = true;
            this.btnInsertAdvisorInfo.Visible = false;
            this.btnInsertAdvisorInfo.Click += new System.EventHandler(this.btnInsertAdvisorInfo_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 674);
            this.Controls.Add(this.tabAdvisors);
            this.Controls.Add(this.btnGetPet);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGetPet;
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
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEditAdvisorInfo;
        private System.Windows.Forms.Button btnUpdateAdvisorInfo;
        private System.Windows.Forms.Button btnDeleteAdvisorInfo;
        private System.Windows.Forms.Button btnInsertAdvisorInfo;
    }
}

