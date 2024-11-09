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
            this.pnlCustomerMain = new System.Windows.Forms.Panel();
            this.tplBtnControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlCustomerMain.SuspendLayout();
            this.tplBtnControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCustomerControls
            // 
            this.pnlCustomerControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pnlCustomerControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomerControls.Location = new System.Drawing.Point(87, 24);
            this.pnlCustomerControls.Name = "pnlCustomerControls";
            this.pnlCustomerControls.Size = new System.Drawing.Size(442, 403);
            this.pnlCustomerControls.TabIndex = 0;
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
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(163, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
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
    }
}