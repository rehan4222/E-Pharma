namespace POS
{
    partial class frm_rec
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Pay = new System.Windows.Forms.Button();
            this.rxt_desc = new System.Windows.Forms.RichTextBox();
            this.dtp_RecDate = new System.Windows.Forms.DateTimePicker();
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
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_customers = new System.Windows.Forms.ComboBox();
            this.lblTotalDue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Pay);
            this.groupBox2.Controls.Add(this.rxt_desc);
            this.groupBox2.Controls.Add(this.dtp_RecDate);
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
            this.groupBox2.Location = new System.Drawing.Point(3, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 352);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Info";
            // 
            // btn_Pay
            // 
            this.btn_Pay.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Pay.FlatAppearance.BorderSize = 0;
            this.btn_Pay.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btn_Pay.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btn_Pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pay.Location = new System.Drawing.Point(258, 325);
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(75, 23);
            this.btn_Pay.TabIndex = 4;
            this.btn_Pay.Text = "Recieve";
            this.btn_Pay.UseVisualStyleBackColor = false;
            this.btn_Pay.Click += new System.EventHandler(this.btn_Pay_Click);
            // 
            // rxt_desc
            // 
            this.rxt_desc.Location = new System.Drawing.Point(136, 242);
            this.rxt_desc.Name = "rxt_desc";
            this.rxt_desc.Size = new System.Drawing.Size(197, 77);
            this.rxt_desc.TabIndex = 6;
            this.rxt_desc.Text = "";
            // 
            // dtp_RecDate
            // 
            this.dtp_RecDate.Location = new System.Drawing.Point(136, 20);
            this.dtp_RecDate.Name = "dtp_RecDate";
            this.dtp_RecDate.Size = new System.Drawing.Size(202, 20);
            this.dtp_RecDate.TabIndex = 2;
            // 
            // txt_remaining
            // 
            this.txt_remaining.Enabled = false;
            this.txt_remaining.Location = new System.Drawing.Point(136, 206);
            this.txt_remaining.Name = "txt_remaining";
            this.txt_remaining.Size = new System.Drawing.Size(153, 20);
            this.txt_remaining.TabIndex = 6;
            this.txt_remaining.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Remaining";
            // 
            // txt_AmountPaid
            // 
            this.txt_AmountPaid.Location = new System.Drawing.Point(136, 171);
            this.txt_AmountPaid.Name = "txt_AmountPaid";
            this.txt_AmountPaid.Size = new System.Drawing.Size(153, 20);
            this.txt_AmountPaid.TabIndex = 5;
            this.txt_AmountPaid.TextChanged += new System.EventHandler(this.txt_AmountPaid_TextChanged);
            // 
            // txt_openningBalance
            // 
            this.txt_openningBalance.Enabled = false;
            this.txt_openningBalance.Location = new System.Drawing.Point(136, 131);
            this.txt_openningBalance.Name = "txt_openningBalance";
            this.txt_openningBalance.Size = new System.Drawing.Size(153, 20);
            this.txt_openningBalance.TabIndex = 65;
            this.txt_openningBalance.TabStop = false;
            // 
            // cmb_banks
            // 
            this.cmb_banks.FormattingEnabled = true;
            this.cmb_banks.Location = new System.Drawing.Point(136, 98);
            this.cmb_banks.Name = "cmb_banks";
            this.cmb_banks.Size = new System.Drawing.Size(197, 21);
            this.cmb_banks.TabIndex = 4;
            // 
            // cmb_PaymentMethods
            // 
            this.cmb_PaymentMethods.FormattingEnabled = true;
            this.cmb_PaymentMethods.Location = new System.Drawing.Point(136, 65);
            this.cmb_PaymentMethods.Name = "cmb_PaymentMethods";
            this.cmb_PaymentMethods.Size = new System.Drawing.Size(153, 21);
            this.cmb_PaymentMethods.TabIndex = 3;
            this.cmb_PaymentMethods.SelectedIndexChanged += new System.EventHandler(this.cmb_PaymentMethods_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 171);
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
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmb_customers);
            this.groupBox1.Controls.Add(this.lblTotalDue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 106);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer\'s Information";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Due";
            // 
            // cmb_customers
            // 
            this.cmb_customers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_customers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_customers.FormattingEnabled = true;
            this.cmb_customers.Location = new System.Drawing.Point(94, 31);
            this.cmb_customers.Name = "cmb_customers";
            this.cmb_customers.Size = new System.Drawing.Size(224, 21);
            this.cmb_customers.TabIndex = 1;
            this.cmb_customers.SelectedIndexChanged += new System.EventHandler(this.cmb_customers_SelectedIndexChanged);
            // 
            // lblTotalDue
            // 
            this.lblTotalDue.AutoSize = true;
            this.lblTotalDue.Location = new System.Drawing.Point(133, 66);
            this.lblTotalDue.Name = "lblTotalDue";
            this.lblTotalDue.Size = new System.Drawing.Size(10, 13);
            this.lblTotalDue.TabIndex = 0;
            this.lblTotalDue.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            // 
            // frm_rec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 488);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_rec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recieving";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rxt_desc;
        private System.Windows.Forms.DateTimePicker dtp_RecDate;
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
        private System.Windows.Forms.ComboBox cmb_customers;
        private System.Windows.Forms.Label lblTotalDue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Pay;
        private System.Windows.Forms.Label label9;
    }
}