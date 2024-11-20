namespace Scheduling
{
    partial class AppointmentsForm
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
            this.tableLayoutAppointments = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblLoggedInUser = new System.Windows.Forms.Label();
            this.lblAppointments = new System.Windows.Forms.Label();
            this.tlpLogoutOption = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tlpMenuOptions = new System.Windows.Forms.TableLayoutPanel();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpDataTable = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtAppointmentSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutAppointments.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.tlpLogoutOption.SuspendLayout();
            this.tlpMenuOptions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpDataTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutAppointments
            // 
            this.tableLayoutAppointments.AutoSize = true;
            this.tableLayoutAppointments.ColumnCount = 2;
            this.tableLayoutAppointments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutAppointments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutAppointments.Controls.Add(this.pnlContainer, 0, 0);
            this.tableLayoutAppointments.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutAppointments.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutAppointments.Name = "tableLayoutAppointments";
            this.tableLayoutAppointments.RowCount = 1;
            this.tableLayoutAppointments.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutAppointments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutAppointments.Size = new System.Drawing.Size(1515, 807);
            this.tableLayoutAppointments.TabIndex = 2;
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(72)))), ((int)(((byte)(87)))));
            this.pnlContainer.Controls.Add(this.lblLoggedInUser);
            this.pnlContainer.Controls.Add(this.lblAppointments);
            this.pnlContainer.Controls.Add(this.tlpLogoutOption);
            this.pnlContainer.Controls.Add(this.tlpMenuOptions);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlContainer.Size = new System.Drawing.Size(303, 807);
            this.pnlContainer.TabIndex = 0;
            this.pnlContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContainer_Paint);
            // 
            // lblLoggedInUser
            // 
            this.lblLoggedInUser.AutoSize = true;
            this.lblLoggedInUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInUser.ForeColor = System.Drawing.Color.White;
            this.lblLoggedInUser.Location = new System.Drawing.Point(32, 783);
            this.lblLoggedInUser.Name = "lblLoggedInUser";
            this.lblLoggedInUser.Size = new System.Drawing.Size(59, 15);
            this.lblLoggedInUser.TabIndex = 9;
            this.lblLoggedInUser.Text = "Test User";
            // 
            // lblAppointments
            // 
            this.lblAppointments.AutoSize = true;
            this.lblAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointments.ForeColor = System.Drawing.Color.White;
            this.lblAppointments.Location = new System.Drawing.Point(72, 187);
            this.lblAppointments.Name = "lblAppointments";
            this.lblAppointments.Size = new System.Drawing.Size(143, 25);
            this.lblAppointments.TabIndex = 6;
            this.lblAppointments.Text = "Appointments";
            // 
            // tlpLogoutOption
            // 
            this.tlpLogoutOption.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpLogoutOption.ColumnCount = 1;
            this.tlpLogoutOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLogoutOption.Controls.Add(this.btnLogout, 0, 0);
            this.tlpLogoutOption.Location = new System.Drawing.Point(30, 715);
            this.tlpLogoutOption.Name = "tlpLogoutOption";
            this.tlpLogoutOption.RowCount = 1;
            this.tlpLogoutOption.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogoutOption.Size = new System.Drawing.Size(240, 63);
            this.tlpLogoutOption.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(5, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(230, 53);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "&Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tlpMenuOptions
            // 
            this.tlpMenuOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpMenuOptions.AutoSize = true;
            this.tlpMenuOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMenuOptions.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpMenuOptions.ColumnCount = 1;
            this.tlpMenuOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenuOptions.Controls.Add(this.btnCustomers, 0, 4);
            this.tlpMenuOptions.Controls.Add(this.btnDelete, 0, 3);
            this.tlpMenuOptions.Controls.Add(this.btnEdit, 0, 2);
            this.tlpMenuOptions.Controls.Add(this.btnCreate, 0, 0);
            this.tlpMenuOptions.Controls.Add(this.btnDetails, 0, 1);
            this.tlpMenuOptions.Location = new System.Drawing.Point(30, 215);
            this.tlpMenuOptions.Name = "tlpMenuOptions";
            this.tlpMenuOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tlpMenuOptions.RowCount = 5;
            this.tlpMenuOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenuOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenuOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenuOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenuOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenuOptions.Size = new System.Drawing.Size(244, 292);
            this.tlpMenuOptions.TabIndex = 4;
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCustomers.Location = new System.Drawing.Point(5, 237);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(234, 50);
            this.btnCustomers.TabIndex = 4;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(5, 179);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(234, 50);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(5, 121);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(234, 50);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(97)))));
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(5, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(234, 50);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.Location = new System.Drawing.Point(5, 63);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(234, 50);
            this.btnDetails.TabIndex = 3;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpDataTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(306, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1206, 801);
            this.panel1.TabIndex = 1;
            // 
            // tlpDataTable
            // 
            this.tlpDataTable.ColumnCount = 1;
            this.tlpDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataTable.Controls.Add(this.dgvAppointments, 0, 1);
            this.tlpDataTable.Controls.Add(this.pnlSearch, 0, 0);
            this.tlpDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataTable.Location = new System.Drawing.Point(0, 0);
            this.tlpDataTable.Name = "tlpDataTable";
            this.tlpDataTable.RowCount = 2;
            this.tlpDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDataTable.Size = new System.Drawing.Size(1206, 801);
            this.tlpDataTable.TabIndex = 4;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToResizeColumns = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppointments.Location = new System.Drawing.Point(3, 43);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new System.Drawing.Size(1200, 755);
            this.dgvAppointments.TabIndex = 4;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pnlSearch.Controls.Add(this.txtAppointmentSearch);
            this.pnlSearch.Controls.Add(this.button1);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(3, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1200, 34);
            this.pnlSearch.TabIndex = 5;
            // 
            // txtAppointmentSearch
            // 
            this.txtAppointmentSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppointmentSearch.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAppointmentSearch.Location = new System.Drawing.Point(832, 5);
            this.txtAppointmentSearch.Name = "txtAppointmentSearch";
            this.txtAppointmentSearch.Size = new System.Drawing.Size(175, 26);
            this.txtAppointmentSearch.TabIndex = 1;
            this.txtAppointmentSearch.Enter += new System.EventHandler(this.txtAppointmentSearch_Enter);
            this.txtAppointmentSearch.Leave += new System.EventHandler(this.txtAppointmentSearch_Exit);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(97)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1013, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Search";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // AppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 807);
            this.Controls.Add(this.tableLayoutAppointments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AppointmentsForm";
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.AppointmentsForm_Load);
            this.tableLayoutAppointments.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tlpLogoutOption.ResumeLayout(false);
            this.tlpMenuOptions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tlpDataTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutAppointments;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.TableLayoutPanel tlpMenuOptions;
        private System.Windows.Forms.TableLayoutPanel tlpLogoutOption;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblAppointments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpDataTable;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAppointmentSearch;
        private System.Windows.Forms.Label lblLoggedInUser;
        private System.Windows.Forms.Button btnCustomers;
    }
}