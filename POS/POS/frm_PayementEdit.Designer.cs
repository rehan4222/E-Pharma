namespace POS
{
    partial class frm_PayementEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PayementEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_invoice = new System.Windows.Forms.TextBox();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rxt_desc = new System.Windows.Forms.RichTextBox();
            this.dtp_paymentDate = new System.Windows.Forms.DateTimePicker();
            this.txt_remaining = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_AmountPaid = new System.Windows.Forms.TextBox();
            this.txt_openningBalance = new System.Windows.Forms.TextBox();
            this.cmb_banks = new System.Windows.Forms.ComboBox();
            this.cmb_PaymentMethods = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_suppliers = new System.Windows.Forms.ComboBox();
            this.lblTotalDue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice";
            // 
            // txt_invoice
            // 
            this.txt_invoice.Location = new System.Drawing.Point(76, 13);
            this.txt_invoice.Name = "txt_invoice";
            this.txt_invoice.Size = new System.Drawing.Size(144, 20);
            this.txt_invoice.TabIndex = 1;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Edit.FlatAppearance.BorderSize = 0;
            this.btn_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btn_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Location = new System.Drawing.Point(323, 335);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_Edit.TabIndex = 5;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rxt_desc);
            this.groupBox2.Controls.Add(this.btn_Edit);
            this.groupBox2.Controls.Add(this.dtp_paymentDate);
            this.groupBox2.Controls.Add(this.txt_remaining);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_AmountPaid);
            this.groupBox2.Controls.Add(this.txt_openningBalance);
            this.groupBox2.Controls.Add(this.cmb_banks);
            this.groupBox2.Controls.Add(this.cmb_PaymentMethods);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(16, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 371);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Info";
            // 
            // rxt_desc
            // 
            this.rxt_desc.Location = new System.Drawing.Point(136, 215);
            this.rxt_desc.Name = "rxt_desc";
            this.rxt_desc.Size = new System.Drawing.Size(262, 104);
            this.rxt_desc.TabIndex = 8;
            this.rxt_desc.Text = "";
            // 
            // dtp_paymentDate
            // 
            this.dtp_paymentDate.Location = new System.Drawing.Point(87, 19);
            this.dtp_paymentDate.Name = "dtp_paymentDate";
            this.dtp_paymentDate.Size = new System.Drawing.Size(202, 20);
            this.dtp_paymentDate.TabIndex = 7;
            // 
            // txt_remaining
            // 
            this.txt_remaining.Enabled = false;
            this.txt_remaining.Location = new System.Drawing.Point(136, 189);
            this.txt_remaining.Name = "txt_remaining";
            this.txt_remaining.Size = new System.Drawing.Size(153, 20);
            this.txt_remaining.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Remaining";
            // 
            // txt_AmountPaid
            // 
            this.txt_AmountPaid.Location = new System.Drawing.Point(136, 161);
            this.txt_AmountPaid.Name = "txt_AmountPaid";
            this.txt_AmountPaid.Size = new System.Drawing.Size(153, 20);
            this.txt_AmountPaid.TabIndex = 4;
            this.txt_AmountPaid.TextChanged += new System.EventHandler(this.txt_AmountPaid_TextChanged);
            // 
            // txt_openningBalance
            // 
            this.txt_openningBalance.Enabled = false;
            this.txt_openningBalance.Location = new System.Drawing.Point(136, 131);
            this.txt_openningBalance.Name = "txt_openningBalance";
            this.txt_openningBalance.Size = new System.Drawing.Size(153, 20);
            this.txt_openningBalance.TabIndex = 4;
            // 
            // cmb_banks
            // 
            this.cmb_banks.FormattingEnabled = true;
            this.cmb_banks.Location = new System.Drawing.Point(136, 98);
            this.cmb_banks.Name = "cmb_banks";
            this.cmb_banks.Size = new System.Drawing.Size(209, 21);
            this.cmb_banks.TabIndex = 3;
            // 
            // cmb_PaymentMethods
            // 
            this.cmb_PaymentMethods.FormattingEnabled = true;
            this.cmb_PaymentMethods.Items.AddRange(new object[] {
            "Cash",
            "Bank"});
            this.cmb_PaymentMethods.Location = new System.Drawing.Point(136, 65);
            this.cmb_PaymentMethods.Name = "cmb_PaymentMethods";
            this.cmb_PaymentMethods.Size = new System.Drawing.Size(153, 21);
            this.cmb_PaymentMethods.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Amount Paid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Openning Balance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Banks";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Payment Method";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_suppliers);
            this.groupBox1.Controls.Add(this.lblTotalDue);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(16, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier\'s Information";
            // 
            // cmb_suppliers
            // 
            this.cmb_suppliers.FormattingEnabled = true;
            this.cmb_suppliers.Location = new System.Drawing.Point(136, 31);
            this.cmb_suppliers.Name = "cmb_suppliers";
            this.cmb_suppliers.Size = new System.Drawing.Size(262, 21);
            this.cmb_suppliers.TabIndex = 1;
            // 
            // lblTotalDue
            // 
            this.lblTotalDue.AutoSize = true;
            this.lblTotalDue.Location = new System.Drawing.Point(11, 76);
            this.lblTotalDue.Name = "lblTotalDue";
            this.lblTotalDue.Size = new System.Drawing.Size(10, 13);
            this.lblTotalDue.TabIndex = 0;
            this.lblTotalDue.Text = " ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Supplier Name";
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.Control;
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btn_search.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Location = new System.Drawing.Point(230, 10);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // frm_PayementEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(432, 498);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_invoice);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_PayementEdit";
            this.Text = "frm_PayementEdit";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_invoice;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rxt_desc;
        private System.Windows.Forms.DateTimePicker dtp_paymentDate;
        private System.Windows.Forms.TextBox txt_remaining;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_AmountPaid;
        private System.Windows.Forms.TextBox txt_openningBalance;
        private System.Windows.Forms.ComboBox cmb_banks;
        private System.Windows.Forms.ComboBox cmb_PaymentMethods;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_suppliers;
        private System.Windows.Forms.Label lblTotalDue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_search;
    }
}