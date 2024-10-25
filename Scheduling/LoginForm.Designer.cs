namespace Scheduling
{
    partial class LoginForm
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
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelUserLocation = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.dropdownLanguage = new System.Windows.Forms.ComboBox();
            this.txtbxPassword = new System.Windows.Forms.TextBox();
            this.txtbxUsername = new System.Windows.Forms.TextBox();
            this.pnlLoginLeft = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.iconLogin = new System.Windows.Forms.PictureBox();
            this.passwordIcon = new System.Windows.Forms.PictureBox();
            this.usernameIcon = new System.Windows.Forms.PictureBox();
            this.pnlLoginLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelTime.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelTime.Location = new System.Drawing.Point(47, 257);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(113, 29);
            this.labelTime.TabIndex = 11;
            this.labelTime.Text = "12:00 PM";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelDate.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelDate.Location = new System.Drawing.Point(12, 169);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(193, 29);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "Tuesday, Oct. 22";
            // 
            // labelUserLocation
            // 
            this.labelUserLocation.AutoSize = true;
            this.labelUserLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelUserLocation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelUserLocation.Location = new System.Drawing.Point(47, 128);
            this.labelUserLocation.Name = "labelUserLocation";
            this.labelUserLocation.Size = new System.Drawing.Size(116, 29);
            this.labelUserLocation.TabIndex = 9;
            this.labelUserLocation.Text = "Louisiana";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(97)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(380, 330);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(127, 34);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // dropdownLanguage
            // 
            this.dropdownLanguage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dropdownLanguage.BackColor = System.Drawing.Color.White;
            this.dropdownLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownLanguage.FormattingEnabled = true;
            this.dropdownLanguage.Items.AddRange(new object[] {
            "EN",
            "ES"});
            this.dropdownLanguage.Location = new System.Drawing.Point(12, 373);
            this.dropdownLanguage.Name = "dropdownLanguage";
            this.dropdownLanguage.Size = new System.Drawing.Size(75, 21);
            this.dropdownLanguage.TabIndex = 13;
            // 
            // txtbxPassword
            // 
            this.txtbxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxPassword.Location = new System.Drawing.Point(366, 298);
            this.txtbxPassword.Name = "txtbxPassword";
            this.txtbxPassword.PasswordChar = '●';
            this.txtbxPassword.Size = new System.Drawing.Size(175, 26);
            this.txtbxPassword.TabIndex = 15;
            // 
            // txtbxUsername
            // 
            this.txtbxUsername.AccessibleName = "username input box";
            this.txtbxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxUsername.Location = new System.Drawing.Point(365, 260);
            this.txtbxUsername.Name = "txtbxUsername";
            this.txtbxUsername.Size = new System.Drawing.Size(176, 26);
            this.txtbxUsername.TabIndex = 14;
            this.txtbxUsername.WordWrap = false;
            // 
            // pnlLoginLeft
            // 
            this.pnlLoginLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(72)))), ((int)(((byte)(87)))));
            this.pnlLoginLeft.Controls.Add(this.pictureBox2);
            this.pnlLoginLeft.Controls.Add(this.dropdownLanguage);
            this.pnlLoginLeft.Controls.Add(this.labelDate);
            this.pnlLoginLeft.Controls.Add(this.labelUserLocation);
            this.pnlLoginLeft.Controls.Add(this.labelTime);
            this.pnlLoginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLoginLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLoginLeft.Name = "pnlLoginLeft";
            this.pnlLoginLeft.Size = new System.Drawing.Size(236, 406);
            this.pnlLoginLeft.TabIndex = 17;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Scheduling.Properties.Resources.location_icon1;
            this.pictureBox2.Location = new System.Drawing.Point(90, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 53);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // iconLogin
            // 
            this.iconLogin.Image = global::Scheduling.Properties.Resources.user_icon;
            this.iconLogin.Location = new System.Drawing.Point(380, 49);
            this.iconLogin.Name = "iconLogin";
            this.iconLogin.Size = new System.Drawing.Size(141, 149);
            this.iconLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconLogin.TabIndex = 14;
            this.iconLogin.TabStop = false;
            // 
            // passwordIcon
            // 
            this.passwordIcon.Image = global::Scheduling.Properties.Resources.password_icon;
            this.passwordIcon.Location = new System.Drawing.Point(333, 298);
            this.passwordIcon.Name = "passwordIcon";
            this.passwordIcon.Size = new System.Drawing.Size(26, 26);
            this.passwordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordIcon.TabIndex = 19;
            this.passwordIcon.TabStop = false;
            // 
            // usernameIcon
            // 
            this.usernameIcon.Image = global::Scheduling.Properties.Resources.username_icon;
            this.usernameIcon.Location = new System.Drawing.Point(333, 260);
            this.usernameIcon.Name = "usernameIcon";
            this.usernameIcon.Size = new System.Drawing.Size(26, 26);
            this.usernameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.usernameIcon.TabIndex = 18;
            this.usernameIcon.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(657, 406);
            this.Controls.Add(this.iconLogin);
            this.Controls.Add(this.passwordIcon);
            this.Controls.Add(this.usernameIcon);
            this.Controls.Add(this.pnlLoginLeft);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtbxPassword);
            this.Controls.Add(this.txtbxUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.pnlLoginLeft.ResumeLayout(false);
            this.pnlLoginLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelUserLocation;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox dropdownLanguage;
        private System.Windows.Forms.TextBox txtbxPassword;
        private System.Windows.Forms.TextBox txtbxUsername;
        private System.Windows.Forms.Panel pnlLoginLeft;
        private System.Windows.Forms.PictureBox iconLogin;
        private System.Windows.Forms.PictureBox usernameIcon;
        private System.Windows.Forms.PictureBox passwordIcon;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

