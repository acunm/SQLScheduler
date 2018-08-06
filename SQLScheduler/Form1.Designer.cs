namespace SQLScheduler
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.listDatabase = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduledJobs = new System.Windows.Forms.ListView();
            this.jobName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.jobEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.jobLastExec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.jobNextExec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Databases:";
            // 
            // listDatabase
            // 
            this.listDatabase.Location = new System.Drawing.Point(12, 49);
            this.listDatabase.Name = "listDatabase";
            this.listDatabase.Size = new System.Drawing.Size(193, 95);
            this.listDatabase.TabIndex = 6;
            this.listDatabase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.listDatabase_LeftClick);
            this.listDatabase.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.listDatabase_RightClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Jobs:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(779, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newServerToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newServerToolStripMenuItem
            // 
            this.newServerToolStripMenuItem.Name = "newServerToolStripMenuItem";
            this.newServerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newServerToolStripMenuItem.Text = "New Server";
            this.newServerToolStripMenuItem.Click += new System.EventHandler(this.newServerToolStripMenuItem_Click);
            // 
            // scheduledJobs
            // 
            this.scheduledJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.jobName,
            this.jobEnabled,
            this.jobLastExec,
            this.jobNextExec});
            this.scheduledJobs.Location = new System.Drawing.Point(224, 49);
            this.scheduledJobs.MultiSelect = false;
            this.scheduledJobs.Name = "scheduledJobs";
            this.scheduledJobs.Size = new System.Drawing.Size(543, 95);
            this.scheduledJobs.TabIndex = 12;
            this.scheduledJobs.UseCompatibleStateImageBehavior = false;
            this.scheduledJobs.View = System.Windows.Forms.View.Details;
            this.scheduledJobs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scheduledJobs_RightClick);
            // 
            // jobName
            // 
            this.jobName.Text = "Name";
            this.jobName.Width = 100;
            // 
            // jobEnabled
            // 
            this.jobEnabled.Text = "Enabled";
            this.jobEnabled.Width = 83;
            // 
            // jobLastExec
            // 
            this.jobLastExec.Text = "Last Execute";
            this.jobLastExec.Width = 110;
            // 
            // jobNextExec
            // 
            this.jobNextExec.Text = "Next Execute";
            this.jobNextExec.Width = 110;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 173);
            this.Controls.Add(this.scheduledJobs);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listDatabase);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SQLScheduler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView listDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newServerToolStripMenuItem;
        private System.Windows.Forms.ListView scheduledJobs;
        private System.Windows.Forms.ColumnHeader jobName;
        private System.Windows.Forms.ColumnHeader jobEnabled;
        private System.Windows.Forms.ColumnHeader jobLastExec;
        private System.Windows.Forms.ColumnHeader jobNextExec;
    }
}

