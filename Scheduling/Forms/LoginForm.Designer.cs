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
            this.lblState = new System.Windows.Forms.Label();
            this.dropdownLanguage = new System.Windows.Forms.ComboBox();
            this.pnlLoginLeft = new System.Windows.Forms.Panel();
            this.lblLangSelect = new System.Windows.Forms.Label();
            this.lblUserCountry = new System.Windows.Forms.Label();
            this.lblUserCity = new System.Windows.Forms.Label();
            this.pbLocationIcon = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLoginImage = new System.Windows.Forms.Panel();
            this.pbLoginIcon = new System.Windows.Forms.PictureBox();
            this.pnlLoginControls = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.passwordIcon = new System.Windows.Forms.PictureBox();
            this.usernameIcon = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslLoginStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlLoginLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocationIcon)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlLoginImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginIcon)).BeginInit();
            this.pnlLoginControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameIcon)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblState.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblState.Location = new System.Drawing.Point(85, 159);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(68, 29);
            this.lblState.TabIndex = 9;
            this.lblState.Text = "State";
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
            // pnlLoginLeft
            // 
            this.pnlLoginLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(72)))), ((int)(((byte)(87)))));
            this.pnlLoginLeft.Controls.Add(this.lblLangSelect);
            this.pnlLoginLeft.Controls.Add(this.lblUserCountry);
            this.pnlLoginLeft.Controls.Add(this.lblUserCity);
            this.pnlLoginLeft.Controls.Add(this.pbLocationIcon);
            this.pnlLoginLeft.Controls.Add(this.dropdownLanguage);
            this.pnlLoginLeft.Controls.Add(this.lblState);
            this.pnlLoginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLoginLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLoginLeft.Name = "pnlLoginLeft";
            this.pnlLoginLeft.Size = new System.Drawing.Size(236, 406);
            this.pnlLoginLeft.TabIndex = 17;
            // 
            // lblLangSelect
            // 
            this.lblLangSelect.AutoSize = true;
            this.lblLangSelect.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLangSelect.Location = new System.Drawing.Point(9, 357);
            this.lblLangSelect.Name = "lblLangSelect";
            this.lblLangSelect.Size = new System.Drawing.Size(91, 13);
            this.lblLangSelect.TabIndex = 17;
            this.lblLangSelect.Text = "Select Language:";
            // 
            // lblUserCountry
            // 
            this.lblUserCountry.AutoSize = true;
            this.lblUserCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCountry.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblUserCountry.Location = new System.Drawing.Point(69, 188);
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
            this.lblUserCity.Location = new System.Drawing.Point(87, 120);
            this.lblUserCity.Name = "lblUserCity";
            this.lblUserCity.Size = new System.Drawing.Size(53, 29);
            this.lblUserCity.TabIndex = 15;
            this.lblUserCity.Text = "City";
            // 
            // pbLocationIcon
            // 
            this.pbLocationIcon.Image = global::Scheduling.Properties.Resources.location_icon1;
            this.pbLocationIcon.Location = new System.Drawing.Point(90, 49);
            this.pbLocationIcon.Name = "pbLocationIcon";
            this.pbLocationIcon.Size = new System.Drawing.Size(50, 53);
            this.pbLocationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLocationIcon.TabIndex = 14;
            this.pbLocationIcon.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pnlLoginImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlLoginControls, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(236, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(421, 406);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // pnlLoginImage
            // 
            this.pnlLoginImage.Controls.Add(this.pbLoginIcon);
            this.pnlLoginImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoginImage.Location = new System.Drawing.Point(3, 3);
            this.pnlLoginImage.Name = "pnlLoginImage";
            this.pnlLoginImage.Size = new System.Drawing.Size(415, 197);
            this.pnlLoginImage.TabIndex = 0;
            // 
            // pbLoginIcon
            // 
            this.pbLoginIcon.Image = global::Scheduling.Properties.Resources.user_icon;
            this.pbLoginIcon.Location = new System.Drawing.Point(126, 38);
            this.pbLoginIcon.Name = "pbLoginIcon";
            this.pbLoginIcon.Size = new System.Drawing.Size(175, 147);
            this.pbLoginIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoginIcon.TabIndex = 28;
            this.pbLoginIcon.TabStop = false;
            // 
            // pnlLoginControls
            // 
            this.pnlLoginControls.Controls.Add(this.statusStrip1);
            this.pnlLoginControls.Controls.Add(this.txtPassword);
            this.pnlLoginControls.Controls.Add(this.passwordIcon);
            this.pnlLoginControls.Controls.Add(this.usernameIcon);
            this.pnlLoginControls.Controls.Add(this.btnLogin);
            this.pnlLoginControls.Controls.Add(this.txtUsername);
            this.pnlLoginControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoginControls.Location = new System.Drawing.Point(3, 206);
            this.pnlLoginControls.Name = "pnlLoginControls";
            this.pnlLoginControls.Size = new System.Drawing.Size(415, 197);
            this.pnlLoginControls.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(126, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(175, 26);
            this.txtPassword.TabIndex = 30;
            // 
            // passwordIcon
            // 
            this.passwordIcon.Image = global::Scheduling.Properties.Resources.password_icon;
            this.passwordIcon.Location = new System.Drawing.Point(94, 70);
            this.passwordIcon.Name = "passwordIcon";
            this.passwordIcon.Size = new System.Drawing.Size(26, 26);
            this.passwordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordIcon.TabIndex = 33;
            this.passwordIcon.TabStop = false;
            // 
            // usernameIcon
            // 
            this.usernameIcon.Image = global::Scheduling.Properties.Resources.username_icon;
            this.usernameIcon.Location = new System.Drawing.Point(94, 28);
            this.usernameIcon.Name = "usernameIcon";
            this.usernameIcon.Size = new System.Drawing.Size(26, 26);
            this.usernameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.usernameIcon.TabIndex = 32;
            this.usernameIcon.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(97)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(126, 109);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(2);
            this.btnLogin.Size = new System.Drawing.Size(175, 35);
            this.btnLogin.TabIndex = 31;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.AccessibleName = "username input box";
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(126, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(175, 26);
            this.txtUsername.TabIndex = 29;
            this.txtUsername.WordWrap = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslLoginStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 175);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(415, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslLoginStatus
            // 
            this.tsslLoginStatus.Name = "tsslLoginStatus";
            this.tsslLoginStatus.Size = new System.Drawing.Size(37, 17);
            this.tsslLoginStatus.Text = "Login";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(657, 406);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlLoginLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnlLoginLeft.ResumeLayout(false);
            this.pnlLoginLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocationIcon)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlLoginImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginIcon)).EndInit();
            this.pnlLoginControls.ResumeLayout(false);
            this.pnlLoginControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameIcon)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox dropdownLanguage;
        private System.Windows.Forms.Panel pnlLoginLeft;
        private System.Windows.Forms.PictureBox pbLocationIcon;
        private System.Windows.Forms.Label lblUserCity;
        private System.Windows.Forms.Label lblUserCountry;
        private System.Windows.Forms.Label lblLangSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlLoginImage;
        private System.Windows.Forms.PictureBox pbLoginIcon;
        private System.Windows.Forms.Panel pnlLoginControls;
        private System.Windows.Forms.PictureBox usernameIcon;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox passwordIcon;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslLoginStatus;
    }
}

