namespace POS
{
    partial class frm_Expenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Expenses));
            this.btn_AddCategory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Category = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.btn_AddExpense = new System.Windows.Forms.Button();
            this.dtm_Expense = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_AddCategory
            // 
            this.btn_AddCategory.BackColor = System.Drawing.SystemColors.Control;
            this.btn_AddCategory.FlatAppearance.BorderSize = 0;
            this.btn_AddCategory.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btn_AddCategory.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btn_AddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddCategory.Location = new System.Drawing.Point(227, 52);
            this.btn_AddCategory.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AddCategory.Name = "btn_AddCategory";
            this.btn_AddCategory.Size = new System.Drawing.Size(70, 23);
            this.btn_AddCategory.TabIndex = 7;
            this.btn_AddCategory.Text = "Add";
            this.btn_AddCategory.UseVisualStyleBackColor = false;
            this.btn_AddCategory.Click += new System.EventHandler(this.btn_AddCategory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add Category";
            // 
            // txt_Category
            // 
            this.txt_Category.Location = new System.Drawing.Point(91, 19);
            this.txt_Category.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Category.Name = "txt_Category";
            this.txt_Category.Size = new System.Drawing.Size(206, 20);
            this.txt_Category.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-6, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 393);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_AddCategory);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_Category);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Expense Category";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmb_banks);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cmb_PaymentMethods);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.rtb_expense);
            this.tabPage2.Controls.Add(this.cmb_Name);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txt_Amount);
            this.tabPage2.Controls.Add(this.btn_AddExpense);
            this.tabPage2.Controls.Add(this.dtm_Expense);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 367);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Expense Addition";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmb_banks
            // 
            this.cmb_banks.FormattingEnabled = true;
            this.cmb_banks.Location = new System.Drawing.Point(115, 127);
            this.cmb_banks.Name = "cmb_banks";
            this.cmb_banks.Size = new System.Drawing.Size(192, 21);
            this.cmb_banks.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 135);
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
            this.cmb_PaymentMethods.Location = new System.Drawing.Point(115, 93);
            this.cmb_PaymentMethods.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_PaymentMethods.Name = "cmb_PaymentMethods";
            this.cmb_PaymentMethods.Size = new System.Drawing.Size(121, 21);
            this.cmb_PaymentMethods.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 93);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Payment Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Date";
            // 
            // rtb_expense
            // 
            this.rtb_expense.Location = new System.Drawing.Point(115, 220);
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
            this.cmb_Name.Location = new System.Drawing.Point(115, 48);
            this.cmb_Name.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_Name.Name = "cmb_Name";
            this.cmb_Name.Size = new System.Drawing.Size(190, 21);
            this.cmb_Name.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 243);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Discription";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Amount";
            // 
            // txt_Amount
            // 
            this.txt_Amount.Location = new System.Drawing.Point(115, 180);
            this.txt_Amount.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.Size = new System.Drawing.Size(122, 20);
            this.txt_Amount.TabIndex = 20;
            // 
            // btn_AddExpense
            // 
            this.btn_AddExpense.BackColor = System.Drawing.SystemColors.Control;
            this.btn_AddExpense.FlatAppearance.BorderSize = 0;
            this.btn_AddExpense.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btn_AddExpense.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btn_AddExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddExpense.Location = new System.Drawing.Point(230, 314);
            this.btn_AddExpense.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AddExpense.Name = "btn_AddExpense";
            this.btn_AddExpense.Size = new System.Drawing.Size(75, 23);
            this.btn_AddExpense.TabIndex = 21;
            this.btn_AddExpense.Text = "Add";
            this.btn_AddExpense.UseVisualStyleBackColor = false;
            this.btn_AddExpense.Click += new System.EventHandler(this.btn_AddExpense_Click);
            // 
            // dtm_Expense
            // 
            this.dtm_Expense.Location = new System.Drawing.Point(113, 11);
            this.dtm_Expense.Margin = new System.Windows.Forms.Padding(2);
            this.dtm_Expense.Name = "dtm_Expense";
            this.dtm_Expense.Size = new System.Drawing.Size(192, 20);
            this.dtm_Expense.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Expense Name";
            // 
            // frm_Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 385);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_Expenses";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Expenses";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_AddCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Category;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.Button btn_AddExpense;
        private System.Windows.Forms.DateTimePicker dtm_Expense;
        private System.Windows.Forms.Label label2;
    }
}