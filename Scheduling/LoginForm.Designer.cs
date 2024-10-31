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
            this.labelUserState = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.dropdownLanguage = new System.Windows.Forms.ComboBox();
            this.txtbxPassword = new System.Windows.Forms.TextBox();
            this.txtbxUsername = new System.Windows.Forms.TextBox();
            this.pnlLoginLeft = new System.Windows.Forms.Panel();
            this.lblUserCountry = new System.Windows.Forms.Label();
            this.lblUserCity = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.iconLogin = new System.Windows.Forms.PictureBox();
            this.passwordIcon = new System.Windows.Forms.PictureBox();
            this.usernameIcon = new System.Windows.Forms.PictureBox();
            this.lblInvalidCreds = new System.Windows.Forms.Label();
            this.lblLangSelect = new System.Windows.Forms.Label();
            this.pnlLoginLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserState
            // 
            this.labelUserState.AutoSize = true;
            this.labelUserState.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelUserState.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelUserState.Location = new System.Drawing.Point(34, 159);
            this.labelUserState.Name = "labelUserState";
            this.labelUserState.Size = new System.Drawing.Size(68, 29);
            this.labelUserState.TabIndex = 9;
            this.labelUserState.Text = "State";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(97)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(394, 330);
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
            "ES",
            "FR"});
            this.dropdownLanguage.Location = new System.Drawing.Point(12, 373);
            this.dropdownLanguage.Name = "dropdownLanguage";
            this.dropdownLanguage.Size = new System.Drawing.Size(75, 21);
            this.dropdownLanguage.TabIndex = 13;
            this.dropdownLanguage.SelectedIndexChanged += new System.EventHandler(this.dropdownLanguage_SelectedIndexChanged);
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
            this.txtbxUsername.Location = new System.Drawing.Point(365, 253);
            this.txtbxUsername.Name = "txtbxUsername";
            this.txtbxUsername.Size = new System.Drawing.Size(176, 26);
            this.txtbxUsername.TabIndex = 14;
            this.txtbxUsername.WordWrap = false;
            // 
            // pnlLoginLeft
            // 
            this.pnlLoginLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(72)))), ((int)(((byte)(87)))));
            this.pnlLoginLeft.Controls.Add(this.lblLangSelect);
            this.pnlLoginLeft.Controls.Add(this.lblUserCountry);
            this.pnlLoginLeft.Controls.Add(this.lblUserCity);
            this.pnlLoginLeft.Controls.Add(this.pictureBox2);
            this.pnlLoginLeft.Controls.Add(this.dropdownLanguage);
            this.pnlLoginLeft.Controls.Add(this.labelUserState);
            this.pnlLoginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLoginLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLoginLeft.Name = "pnlLoginLeft";
            this.pnlLoginLeft.Size = new System.Drawing.Size(236, 406);
            this.pnlLoginLeft.TabIndex = 17;
            this.pnlLoginLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLoginLeft_Paint);
            // 
            // lblUserCountry
            // 
            this.lblUserCountry.AutoSize = true;
            this.lblUserCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCountry.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblUserCountry.Location = new System.Drawing.Point(34, 188);
            this.lblUserCountry.Name = "lblUserCountry";
            this.lblUserCountry.Size = new System.Drawing.Size(95, 29);
            this.lblUserCountry.TabIndex = 16;
            this.lblUserCountry.Text = "Country";
            this.lblUserCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserCity
            // 
            this.lblUserCity.AutoSize = true;
            this.lblUserCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCity.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblUserCity.Location = new System.Drawing.Point(34, 130);
            this.lblUserCity.Name = "lblUserCity";
            this.lblUserCity.Size = new System.Drawing.Size(53, 29);
            this.lblUserCity.TabIndex = 15;
            this.lblUserCity.Text = "City";
            this.lblUserCity.Click += new System.EventHandler(this.lblUserCity_Click);
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
            this.usernameIcon.Location = new System.Drawing.Point(333, 253);
            this.usernameIcon.Name = "usernameIcon";
            this.usernameIcon.Size = new System.Drawing.Size(26, 26);
            this.usernameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.usernameIcon.TabIndex = 18;
            this.usernameIcon.TabStop = false;
            // 
            // lblInvalidCreds
            // 
            this.lblInvalidCreds.AutoSize = true;
            this.lblInvalidCreds.BackColor = System.Drawing.Color.MistyRose;
            this.lblInvalidCreds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalidCreds.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidCreds.Location = new System.Drawing.Point(345, 373);
            this.lblInvalidCreds.Name = "lblInvalidCreds";
            this.lblInvalidCreds.Padding = new System.Windows.Forms.Padding(5);
            this.lblInvalidCreds.Size = new System.Drawing.Size(196, 26);
            this.lblInvalidCreds.TabIndex = 20;
            this.lblInvalidCreds.Text = "Invalid username or password";
            this.lblInvalidCreds.Visible = false;
            // 
            // lblLangSelect
            // 
            this.lblLangSelect.AutoSize = true;
            this.lblLangSelect.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLangSelect.Location = new System.Drawing.Point(13, 350);
            this.lblLangSelect.Name = "lblLangSelect";
            this.lblLangSelect.Size = new System.Drawing.Size(91, 13);
            this.lblLangSelect.TabIndex = 17;
            this.lblLangSelect.Text = "Select Language:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(657, 406);
            this.Controls.Add(this.lblInvalidCreds);
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
            this.Load += new System.EventHandler(this.LoginForm_Load);
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
        private System.Windows.Forms.Label labelUserState;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox dropdownLanguage;
        private System.Windows.Forms.TextBox txtbxPassword;
        private System.Windows.Forms.TextBox txtbxUsername;
        private System.Windows.Forms.Panel pnlLoginLeft;
        private System.Windows.Forms.PictureBox iconLogin;
        private System.Windows.Forms.PictureBox usernameIcon;
        private System.Windows.Forms.PictureBox passwordIcon;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUserCity;
        private System.Windows.Forms.Label lblUserCountry;
        private System.Windows.Forms.Label lblInvalidCreds;
        private System.Windows.Forms.Label lblLangSelect;
    }
}

