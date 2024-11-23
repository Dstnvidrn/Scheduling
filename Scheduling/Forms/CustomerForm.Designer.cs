namespace Scheduling.Forms
{
    partial class CustomerForm
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
            this.pnlCustomerControls = new System.Windows.Forms.Panel();
            this.tlpCustomerFields = new System.Windows.Forms.TableLayoutPanel();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblStreetAdd1 = new System.Windows.Forms.Label();
            this.lblStreetAdd2 = new System.Windows.Forms.Label();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.lblPostal = new System.Windows.Forms.Label();
            this.txtCustomername = new System.Windows.Forms.TextBox();
            this.txtStreet1 = new System.Windows.Forms.TextBox();
            this.txtStreet2 = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtPostal = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.pnlCustomerMain = new System.Windows.Forms.Panel();
            this.tplBtnControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlCustomerControls.SuspendLayout();
            this.tlpCustomerFields.SuspendLayout();
            this.pnlCustomerMain.SuspendLayout();
            this.tplBtnControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCustomerControls
            // 
            this.pnlCustomerControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pnlCustomerControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomerControls.Controls.Add(this.tlpCustomerFields);
            this.pnlCustomerControls.Location = new System.Drawing.Point(57, 24);
            this.pnlCustomerControls.Name = "pnlCustomerControls";
            this.pnlCustomerControls.Size = new System.Drawing.Size(492, 374);
            this.pnlCustomerControls.TabIndex = 0;
            // 
            // tlpCustomerFields
            // 
            this.tlpCustomerFields.ColumnCount = 2;
            this.tlpCustomerFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCustomerFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCustomerFields.Controls.Add(this.lblCustomerName, 0, 0);
            this.tlpCustomerFields.Controls.Add(this.lblCountry, 0, 5);
            this.tlpCustomerFields.Controls.Add(this.lblCity, 0, 3);
            this.tlpCustomerFields.Controls.Add(this.lblStreetAdd1, 0, 1);
            this.tlpCustomerFields.Controls.Add(this.lblStreetAdd2, 0, 2);
            this.tlpCustomerFields.Controls.Add(this.lblPhoneNo, 0, 6);
            this.tlpCustomerFields.Controls.Add(this.lblPostal, 0, 4);
            this.tlpCustomerFields.Controls.Add(this.txtCustomername, 1, 0);
            this.tlpCustomerFields.Controls.Add(this.txtStreet1, 1, 1);
            this.tlpCustomerFields.Controls.Add(this.txtStreet2, 1, 2);
            this.tlpCustomerFields.Controls.Add(this.txtCity, 1, 3);
            this.tlpCustomerFields.Controls.Add(this.txtPostal, 1, 4);
            this.tlpCustomerFields.Controls.Add(this.txtCountry, 1, 5);
            this.tlpCustomerFields.Controls.Add(this.txtPhoneNo, 1, 6);
            this.tlpCustomerFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCustomerFields.Location = new System.Drawing.Point(0, 0);
            this.tlpCustomerFields.Name = "tlpCustomerFields";
            this.tlpCustomerFields.RowCount = 7;
            this.tlpCustomerFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCustomerFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCustomerFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCustomerFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCustomerFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCustomerFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCustomerFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCustomerFields.Size = new System.Drawing.Size(490, 372);
            this.tlpCustomerFields.TabIndex = 4;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(3, 18);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(109, 16);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name*";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCountry
            // 
            this.lblCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(3, 283);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(109, 16);
            this.lblCountry.TabIndex = 5;
            this.lblCountry.Text = "Country*";
            this.lblCountry.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCity
            // 
            this.lblCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(3, 177);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(109, 16);
            this.lblCity.TabIndex = 3;
            this.lblCity.Text = "City*";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblStreetAdd1
            // 
            this.lblStreetAdd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStreetAdd1.AutoSize = true;
            this.lblStreetAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreetAdd1.Location = new System.Drawing.Point(3, 71);
            this.lblStreetAdd1.Name = "lblStreetAdd1";
            this.lblStreetAdd1.Size = new System.Drawing.Size(109, 16);
            this.lblStreetAdd1.TabIndex = 1;
            this.lblStreetAdd1.Text = "Street Address*";
            this.lblStreetAdd1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblStreetAdd2
            // 
            this.lblStreetAdd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStreetAdd2.AutoSize = true;
            this.lblStreetAdd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreetAdd2.Location = new System.Drawing.Point(3, 124);
            this.lblStreetAdd2.Name = "lblStreetAdd2";
            this.lblStreetAdd2.Size = new System.Drawing.Size(109, 16);
            this.lblStreetAdd2.TabIndex = 2;
            this.lblStreetAdd2.Text = "Address 2";
            this.lblStreetAdd2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNo.Location = new System.Drawing.Point(3, 337);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(109, 16);
            this.lblPhoneNo.TabIndex = 6;
            this.lblPhoneNo.Text = "Phone No.*";
            this.lblPhoneNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblPostal
            // 
            this.lblPostal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostal.AutoSize = true;
            this.lblPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostal.Location = new System.Drawing.Point(3, 230);
            this.lblPostal.Name = "lblPostal";
            this.lblPostal.Size = new System.Drawing.Size(109, 16);
            this.lblPostal.TabIndex = 5;
            this.lblPostal.Text = "Postal Code*";
            this.lblPostal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtCustomername
            // 
            this.txtCustomername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomername.Location = new System.Drawing.Point(125, 13);
            this.txtCustomername.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtCustomername.Name = "txtCustomername";
            this.txtCustomername.Size = new System.Drawing.Size(360, 26);
            this.txtCustomername.TabIndex = 7;
            // 
            // txtStreet1
            // 
            this.txtStreet1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet1.Location = new System.Drawing.Point(125, 66);
            this.txtStreet1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.Size = new System.Drawing.Size(360, 26);
            this.txtStreet1.TabIndex = 8;
            // 
            // txtStreet2
            // 
            this.txtStreet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet2.Location = new System.Drawing.Point(125, 119);
            this.txtStreet2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size(360, 26);
            this.txtStreet2.TabIndex = 9;
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(125, 172);
            this.txtCity.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(360, 26);
            this.txtCity.TabIndex = 10;
            // 
            // txtPostal
            // 
            this.txtPostal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostal.Location = new System.Drawing.Point(125, 225);
            this.txtPostal.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(360, 26);
            this.txtPostal.TabIndex = 11;
            this.txtPostal.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // txtCountry
            // 
            this.txtCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountry.Location = new System.Drawing.Point(125, 278);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(360, 26);
            this.txtCountry.TabIndex = 12;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(125, 332);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(360, 26);
            this.txtPhoneNo.TabIndex = 13;
            // 
            // pnlCustomerMain
            // 
            this.pnlCustomerMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(72)))), ((int)(((byte)(87)))));
            this.pnlCustomerMain.Controls.Add(this.tplBtnControls);
            this.pnlCustomerMain.Controls.Add(this.pnlCustomerControls);
            this.pnlCustomerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomerMain.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomerMain.Name = "pnlCustomerMain";
            this.pnlCustomerMain.Size = new System.Drawing.Size(614, 477);
            this.pnlCustomerMain.TabIndex = 1;
            // 
            // tplBtnControls
            // 
            this.tplBtnControls.ColumnCount = 3;
            this.tplBtnControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplBtnControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tplBtnControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplBtnControls.Controls.Add(this.btnCreate, 0, 0);
            this.tplBtnControls.Controls.Add(this.btnCancel, 2, 0);
            this.tplBtnControls.Location = new System.Drawing.Point(164, 433);
            this.tplBtnControls.Name = "tplBtnControls";
            this.tplBtnControls.RowCount = 1;
            this.tplBtnControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplBtnControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tplBtnControls.Size = new System.Drawing.Size(270, 40);
            this.tplBtnControls.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(97)))));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(3, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(104, 34);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(97)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(163, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(614, 477);
            this.Controls.Add(this.pnlCustomerMain);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.pnlCustomerControls.ResumeLayout(false);
            this.tlpCustomerFields.ResumeLayout(false);
            this.tlpCustomerFields.PerformLayout();
            this.pnlCustomerMain.ResumeLayout(false);
            this.tplBtnControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCustomerControls;
        private System.Windows.Forms.Panel pnlCustomerMain;
        private System.Windows.Forms.TableLayoutPanel tplBtnControls;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblStreetAdd2;
        private System.Windows.Forms.Label lblStreetAdd1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TableLayoutPanel tlpCustomerFields;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.Label lblPostal;
        private System.Windows.Forms.TextBox txtCustomername;
        private System.Windows.Forms.TextBox txtStreet1;
        private System.Windows.Forms.TextBox txtStreet2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtPostal;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtPhoneNo;
    }
}