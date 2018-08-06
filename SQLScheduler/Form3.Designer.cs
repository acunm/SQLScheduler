namespace SQLScheduler
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.detailsTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.syntaxcheck = new System.Windows.Forms.Button();
            this.sqlcommand = new System.Windows.Forms.TextBox();
            this.scheduleTab = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.hourBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.timeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timeupanddown = new System.Windows.Forms.NumericUpDown();
            this.recurrent = new System.Windows.Forms.RadioButton();
            this.onetime = new System.Windows.Forms.RadioButton();
            this.notificationsTab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.logsTab = new System.Windows.Forms.TabPage();
            this.logBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.detailsTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.scheduleTab.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeupanddown)).BeginInit();
            this.notificationsTab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.logsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTab);
            this.tabControl1.Controls.Add(this.detailsTab);
            this.tabControl1.Controls.Add(this.scheduleTab);
            this.tabControl1.Controls.Add(this.notificationsTab);
            this.tabControl1.Controls.Add(this.logsTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 293);
            this.tabControl1.TabIndex = 10;
            // 
            // generalTab
            // 
            this.generalTab.BackColor = System.Drawing.Color.Transparent;
            this.generalTab.Controls.Add(this.groupBox2);
            this.generalTab.Controls.Add(this.groupBox1);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalTab.Size = new System.Drawing.Size(768, 267);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(78, 72);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(651, 20);
            this.textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(78, 49);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(651, 20);
            this.textBox4.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Password: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Username: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(651, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "SQL Server:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descriptionBox);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Job";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(78, 39);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(651, 66);
            this.descriptionBox.TabIndex = 3;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(78, 13);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(651, 20);
            this.nameBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name: ";
            // 
            // detailsTab
            // 
            this.detailsTab.Controls.Add(this.groupBox3);
            this.detailsTab.Location = new System.Drawing.Point(4, 22);
            this.detailsTab.Name = "detailsTab";
            this.detailsTab.Padding = new System.Windows.Forms.Padding(3);
            this.detailsTab.Size = new System.Drawing.Size(768, 267);
            this.detailsTab.TabIndex = 1;
            this.detailsTab.Text = "Details";
            this.detailsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.syntaxcheck);
            this.groupBox3.Controls.Add(this.sqlcommand);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(756, 255);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SQL";
            // 
            // syntaxcheck
            // 
            this.syntaxcheck.Location = new System.Drawing.Point(665, 226);
            this.syntaxcheck.Name = "syntaxcheck";
            this.syntaxcheck.Size = new System.Drawing.Size(85, 23);
            this.syntaxcheck.TabIndex = 1;
            this.syntaxcheck.Text = "Check Syntax";
            this.syntaxcheck.UseVisualStyleBackColor = true;
            this.syntaxcheck.Click += new System.EventHandler(this.syntaxcheck_Click);
            // 
            // sqlcommand
            // 
            this.sqlcommand.Location = new System.Drawing.Point(7, 20);
            this.sqlcommand.Multiline = true;
            this.sqlcommand.Name = "sqlcommand";
            this.sqlcommand.Size = new System.Drawing.Size(743, 200);
            this.sqlcommand.TabIndex = 0;
            // 
            // scheduleTab
            // 
            this.scheduleTab.Controls.Add(this.groupBox5);
            this.scheduleTab.Controls.Add(this.groupBox4);
            this.scheduleTab.Location = new System.Drawing.Point(4, 22);
            this.scheduleTab.Name = "scheduleTab";
            this.scheduleTab.Size = new System.Drawing.Size(768, 267);
            this.scheduleTab.TabIndex = 2;
            this.scheduleTab.Text = "Schedule";
            this.scheduleTab.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.hourBox);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.endDate);
            this.groupBox5.Controls.Add(this.startDate);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(3, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(762, 85);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Duration";
            // 
            // hourBox
            // 
            this.hourBox.FormattingEnabled = true;
            this.hourBox.Location = new System.Drawing.Point(335, 58);
            this.hourBox.Name = "hourBox";
            this.hourBox.Size = new System.Drawing.Size(63, 21);
            this.hourBox.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(296, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Hour:";
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(494, 19);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 20);
            this.endDate.TabIndex = 5;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(71, 19);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 20);
            this.startDate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(433, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "End Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start Date:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.timeBox);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.timeupanddown);
            this.groupBox4.Controls.Add(this.recurrent);
            this.groupBox4.Controls.Add(this.onetime);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(762, 103);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Type";
            // 
            // timeBox
            // 
            this.timeBox.Enabled = false;
            this.timeBox.FormattingEnabled = true;
            this.timeBox.Location = new System.Drawing.Point(150, 65);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(121, 21);
            this.timeBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "times";
            // 
            // timeupanddown
            // 
            this.timeupanddown.Enabled = false;
            this.timeupanddown.Location = new System.Drawing.Point(71, 66);
            this.timeupanddown.Name = "timeupanddown";
            this.timeupanddown.Size = new System.Drawing.Size(40, 20);
            this.timeupanddown.TabIndex = 2;
            // 
            // recurrent
            // 
            this.recurrent.AutoSize = true;
            this.recurrent.Location = new System.Drawing.Point(7, 43);
            this.recurrent.Name = "recurrent";
            this.recurrent.Size = new System.Drawing.Size(71, 17);
            this.recurrent.TabIndex = 1;
            this.recurrent.TabStop = true;
            this.recurrent.Text = "Recurring";
            this.recurrent.UseVisualStyleBackColor = true;
            this.recurrent.CheckedChanged += new System.EventHandler(this.recurrent_CheckedChanged);
            // 
            // onetime
            // 
            this.onetime.AutoSize = true;
            this.onetime.Checked = true;
            this.onetime.Location = new System.Drawing.Point(7, 20);
            this.onetime.Name = "onetime";
            this.onetime.Size = new System.Drawing.Size(71, 17);
            this.onetime.TabIndex = 0;
            this.onetime.TabStop = true;
            this.onetime.Text = "One Time";
            this.onetime.UseVisualStyleBackColor = true;
            // 
            // notificationsTab
            // 
            this.notificationsTab.Controls.Add(this.groupBox6);
            this.notificationsTab.Location = new System.Drawing.Point(4, 22);
            this.notificationsTab.Name = "notificationsTab";
            this.notificationsTab.Size = new System.Drawing.Size(768, 267);
            this.notificationsTab.TabIndex = 3;
            this.notificationsTab.Text = "Notifications";
            this.notificationsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView1);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(762, 261);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Notifications";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.email});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(750, 236);
            this.dataGridView1.TabIndex = 0;
            // 
            // logsTab
            // 
            this.logsTab.Controls.Add(this.logBox);
            this.logsTab.Location = new System.Drawing.Point(4, 22);
            this.logsTab.Name = "logsTab";
            this.logsTab.Size = new System.Drawing.Size(768, 267);
            this.logsTab.TabIndex = 4;
            this.logsTab.Text = "Logs";
            this.logsTab.UseVisualStyleBackColor = true;
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(3, 3);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(762, 261);
            this.logBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 342);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job";
            this.tabControl1.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.detailsTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.scheduleTab.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeupanddown)).EndInit();
            this.notificationsTab.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.logsTab.ResumeLayout(false);
            this.logsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage detailsTab;
        private System.Windows.Forms.TabPage scheduleTab;
        private System.Windows.Forms.TabPage notificationsTab;
        private System.Windows.Forms.TabPage logsTab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button syntaxcheck;
        private System.Windows.Forms.TextBox sqlcommand;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox timeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown timeupanddown;
        private System.Windows.Forms.RadioButton recurrent;
        private System.Windows.Forms.RadioButton onetime;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.ComboBox hourBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
    }
}