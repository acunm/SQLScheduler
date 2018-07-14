namespace SQLScheduler
{
    partial class Form2
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.host = new System.Windows.Forms.Label();
            this.hostname = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.passwordHide = new System.Windows.Forms.CheckBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.hostnameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Username :";
            // 
            // host
            // 
            this.host.AutoSize = true;
            this.host.Location = new System.Drawing.Point(12, 9);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(35, 13);
            this.host.TabIndex = 9;
            this.host.Text = "Host :";
            // 
            // hostname
            // 
            this.hostname.AutoSize = true;
            this.hostname.Location = new System.Drawing.Point(12, 9);
            this.hostname.Name = "hostname";
            this.hostname.Size = new System.Drawing.Size(35, 13);
            this.hostname.TabIndex = 10;
            this.hostname.Text = "Host :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwordHide
            // 
            this.passwordHide.AutoSize = true;
            this.passwordHide.Location = new System.Drawing.Point(292, 64);
            this.passwordHide.Name = "passwordHide";
            this.passwordHide.Size = new System.Drawing.Size(102, 17);
            this.passwordHide.TabIndex = 16;
            this.passwordHide.Text = "Show Password";
            this.passwordHide.UseVisualStyleBackColor = true;
            this.passwordHide.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(79, 61);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = 'x';
            this.passwordBox.Size = new System.Drawing.Size(206, 20);
            this.passwordBox.TabIndex = 15;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(79, 35);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(206, 20);
            this.usernameBox.TabIndex = 14;
            // 
            // hostnameBox
            // 
            this.hostnameBox.Location = new System.Drawing.Point(79, 9);
            this.hostnameBox.Name = "hostnameBox";
            this.hostnameBox.Size = new System.Drawing.Size(206, 20);
            this.hostnameBox.TabIndex = 13;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 146);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.host);
            this.Controls.Add(this.hostname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordHide);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.hostnameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label host;
        private System.Windows.Forms.Label hostname;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox passwordHide;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox hostnameBox;
    }
}