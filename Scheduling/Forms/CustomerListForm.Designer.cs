namespace Scheduling.Forms
{
    partial class CustomerListForm
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
            this.lblCustomers = new System.Windows.Forms.Label();
            this.tlpCustomerOptions = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.tlpLogoutOption = new System.Windows.Forms.TableLayoutPanel();
            this.btnCustomerListCnl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpDataTable = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtAppointmentSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutAppointments.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.tlpCustomerOptions.SuspendLayout();
            this.tlpLogoutOption.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpDataTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
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
            this.tableLayoutAppointments.Size = new System.Drawing.Size(1416, 720);
            this.tableLayoutAppointments.TabIndex = 3;
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(72)))), ((int)(((byte)(87)))));
            this.pnlContainer.Controls.Add(this.lblCustomers);
            this.pnlContainer.Controls.Add(this.tlpCustomerOptions);
            this.pnlContainer.Controls.Add(this.tlpLogoutOption);
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlContainer.Size = new System.Drawing.Size(283, 726);
            this.pnlContainer.TabIndex = 0;
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.ForeColor = System.Drawing.Color.White;
            this.lblCustomers.Location = new System.Drawing.Point(81, 148);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(115, 25);
            this.lblCustomers.TabIndex = 8;
            this.lblCustomers.Text = "Customers";
            // 
            // tlpCustomerOptions
            // 
            this.tlpCustomerOptions.AutoSize = true;
            this.tlpCustomerOptions.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCustomerOptions.ColumnCount = 1;
            this.tlpCustomerOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCustomerOptions.Controls.Add(this.btnAddCustomer, 0, 0);
            this.tlpCustomerOptions.Controls.Add(this.btnUpdateCustomer, 0, 1);
            this.tlpCustomerOptions.Controls.Add(this.btnDeleteCustomer, 0, 2);
            this.tlpCustomerOptions.Location = new System.Drawing.Point(21, 181);
            this.tlpCustomerOptions.Name = "tlpCustomerOptions";
            this.tlpCustomerOptions.RowCount = 3;
            this.tlpCustomerOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCustomerOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCustomerOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCustomerOptions.Size = new System.Drawing.Size(240, 158);
            this.tlpCustomerOptions.TabIndex = 7;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(97)))));
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(5, 5);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(230, 44);
            this.btnAddCustomer.TabIndex = 0;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdateCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateCustomer.FlatAppearance.BorderSize = 0;
            this.btnUpdateCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCustomer.Location = new System.Drawing.Point(5, 57);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(230, 44);
            this.btnUpdateCustomer.TabIndex = 1;
            this.btnUpdateCustomer.Text = "Edit";
            this.btnUpdateCustomer.UseVisualStyleBackColor = false;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCustomer.FlatAppearance.BorderSize = 0;
            this.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.Location = new System.Drawing.Point(5, 109);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(230, 44);
            this.btnDeleteCustomer.TabIndex = 4;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click_1);
            // 
            // tlpLogoutOption
            // 
            this.tlpLogoutOption.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpLogoutOption.ColumnCount = 1;
            this.tlpLogoutOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLogoutOption.Controls.Add(this.btnCustomerListCnl, 0, 0);
            this.tlpLogoutOption.Location = new System.Drawing.Point(21, 645);
            this.tlpLogoutOption.Name = "tlpLogoutOption";
            this.tlpLogoutOption.RowCount = 1;
            this.tlpLogoutOption.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogoutOption.Size = new System.Drawing.Size(240, 63);
            this.tlpLogoutOption.TabIndex = 5;
            // 
            // btnCustomerListCnl
            // 
            this.btnCustomerListCnl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCustomerListCnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCustomerListCnl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerListCnl.FlatAppearance.BorderSize = 0;
            this.btnCustomerListCnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerListCnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerListCnl.ForeColor = System.Drawing.Color.Black;
            this.btnCustomerListCnl.Location = new System.Drawing.Point(5, 5);
            this.btnCustomerListCnl.Name = "btnCustomerListCnl";
            this.btnCustomerListCnl.Size = new System.Drawing.Size(230, 53);
            this.btnCustomerListCnl.TabIndex = 4;
            this.btnCustomerListCnl.Text = "Cancel";
            this.btnCustomerListCnl.UseVisualStyleBackColor = false;
            this.btnCustomerListCnl.Click += new System.EventHandler(this.btnCustomerListCnl_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpDataTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(286, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 801);
            this.panel1.TabIndex = 1;
            // 
            // tlpDataTable
            // 
            this.tlpDataTable.ColumnCount = 1;
            this.tlpDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataTable.Controls.Add(this.dgvCustomers, 0, 1);
            this.tlpDataTable.Controls.Add(this.pnlSearch, 0, 0);
            this.tlpDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataTable.Location = new System.Drawing.Point(0, 0);
            this.tlpDataTable.Name = "tlpDataTable";
            this.tlpDataTable.RowCount = 2;
            this.tlpDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDataTable.Size = new System.Drawing.Size(1127, 801);
            this.tlpDataTable.TabIndex = 4;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeColumns = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 43);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1121, 755);
            this.dgvCustomers.TabIndex = 4;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pnlSearch.Controls.Add(this.txtAppointmentSearch);
            this.pnlSearch.Controls.Add(this.button1);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(3, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1121, 34);
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
            // CustomerListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 720);
            this.Controls.Add(this.tableLayoutAppointments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerListForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CustomerListForm";
            this.Load += new System.EventHandler(this.CustomerListForm_Load);
            this.tableLayoutAppointments.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.tlpCustomerOptions.ResumeLayout(false);
            this.tlpLogoutOption.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tlpDataTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutAppointments;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.TableLayoutPanel tlpCustomerOptions;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.TableLayoutPanel tlpLogoutOption;
        private System.Windows.Forms.Button btnCustomerListCnl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpDataTable;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtAppointmentSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
    }
}