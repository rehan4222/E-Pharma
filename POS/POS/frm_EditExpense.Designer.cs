namespace POS
{
    partial class frm_EditExpense
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
            this.cmb_banks = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_PaymentMethods = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtb_expense = new System.Windows.Forms.RichTextBox();
            this.cmb_Name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Amount = new System.Windows.Forms.TextBox();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.dtm_Expense = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_banks
            // 
            this.cmb_banks.FormattingEnabled = true;
            this.cmb_banks.Location = new System.Drawing.Point(117, 139);
            this.cmb_banks.Name = "cmb_banks";
            this.cmb_banks.Size = new System.Drawing.Size(192, 21);
            this.cmb_banks.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Banks";
            // 
            // cmb_PaymentMethods
            // 
            this.cmb_PaymentMethods.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_PaymentMethods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_PaymentMethods.FormattingEnabled = true;
            this.cmb_PaymentMethods.Items.AddRange(new object[] {
            "Cash",
            "Bank"});
            this.cmb_PaymentMethods.Location = new System.Drawing.Point(119, 97);
            this.cmb_PaymentMethods.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_PaymentMethods.Name = "cmb_PaymentMethods";
            this.cmb_PaymentMethods.Size = new System.Drawing.Size(122, 21);
            this.cmb_PaymentMethods.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 97);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Payment Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Date";
            // 
            // rtb_expense
            // 
            this.rtb_expense.Location = new System.Drawing.Point(119, 224);
            this.rtb_expense.Margin = new System.Windows.Forms.Padding(2);
            this.rtb_expense.Name = "rtb_expense";
            this.rtb_expense.Size = new System.Drawing.Size(190, 79);
            this.rtb_expense.TabIndex = 25;
            this.rtb_expense.Text = "";
            // 
            // cmb_Name
            // 
            this.cmb_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Name.FormattingEnabled = true;
            this.cmb_Name.Location = new System.Drawing.Point(119, 52);
            this.cmb_Name.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_Name.Name = "cmb_Name";
            this.cmb_Name.Size = new System.Drawing.Size(190, 21);
            this.cmb_Name.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Discription";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 184);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Amount";
            // 
            // txt_Amount
            // 
            this.txt_Amount.Location = new System.Drawing.Point(119, 184);
            this.txt_Amount.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.Size = new System.Drawing.Size(122, 20);
            this.txt_Amount.TabIndex = 20;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Edit.FlatAppearance.BorderSize = 0;
            this.btn_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btn_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Location = new System.Drawing.Point(253, 307);
            this.btn_Edit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(56, 23);
            this.btn_Edit.TabIndex = 21;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // dtm_Expense
            // 
            this.dtm_Expense.Location = new System.Drawing.Point(117, 13);
            this.dtm_Expense.Margin = new System.Windows.Forms.Padding(2);
            this.dtm_Expense.Name = "dtm_Expense";
            this.dtm_Expense.Size = new System.Drawing.Size(192, 20);
            this.dtm_Expense.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Expense Name";
            // 
            // frm_EditExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 340);
            this.Controls.Add(this.cmb_banks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_PaymentMethods);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtb_expense);
            this.Controls.Add(this.cmb_Name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Amount);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.dtm_Expense);
            this.Controls.Add(this.label2);
            this.Name = "frm_EditExpense";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Editing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_banks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_PaymentMethods;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtb_expense;
        private System.Windows.Forms.ComboBox cmb_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Amount;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.DateTimePicker dtm_Expense;
        private System.Windows.Forms.Label label2;
    }
}