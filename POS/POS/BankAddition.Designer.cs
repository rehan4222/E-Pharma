namespace POS
{
    partial class BankAddition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankAddition));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_bankname = new System.Windows.Forms.TextBox();
            this.txt_accountnumber = new System.Windows.Forms.TextBox();
            this.txt_initialbalance = new System.Windows.Forms.TextBox();
            this.btn_BankAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account Number";
            // 
            // txt_bankname
            // 
            this.txt_bankname.Location = new System.Drawing.Point(154, 24);
            this.txt_bankname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_bankname.Name = "txt_bankname";
            this.txt_bankname.Size = new System.Drawing.Size(292, 20);
            this.txt_bankname.TabIndex = 2;
            // 
            // txt_accountnumber
            // 
            this.txt_accountnumber.Location = new System.Drawing.Point(155, 59);
            this.txt_accountnumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_accountnumber.Name = "txt_accountnumber";
            this.txt_accountnumber.Size = new System.Drawing.Size(176, 20);
            this.txt_accountnumber.TabIndex = 3;
            // 
            // txt_initialbalance
            // 
            this.txt_initialbalance.Location = new System.Drawing.Point(155, 100);
            this.txt_initialbalance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_initialbalance.Name = "txt_initialbalance";
            this.txt_initialbalance.Size = new System.Drawing.Size(176, 20);
            this.txt_initialbalance.TabIndex = 4;
            // 
            // btn_BankAdd
            // 
            this.btn_BankAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btn_BankAdd.FlatAppearance.BorderSize = 0;
            this.btn_BankAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_BankAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_BankAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BankAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BankAdd.ForeColor = System.Drawing.Color.DimGray;
            this.btn_BankAdd.Location = new System.Drawing.Point(253, 134);
            this.btn_BankAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_BankAdd.Name = "btn_BankAdd";
            this.btn_BankAdd.Size = new System.Drawing.Size(78, 24);
            this.btn_BankAdd.TabIndex = 5;
            this.btn_BankAdd.Text = "Add";
            this.btn_BankAdd.UseVisualStyleBackColor = false;
            this.btn_BankAdd.Click += new System.EventHandler(this.btn_BankAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Initial Balance";
            // 
            // BankAddition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_BankAdd);
            this.Controls.Add(this.txt_initialbalance);
            this.Controls.Add(this.txt_accountnumber);
            this.Controls.Add(this.txt_bankname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BankAddition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Addition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_bankname;
        private System.Windows.Forms.TextBox txt_accountnumber;
        private System.Windows.Forms.TextBox txt_initialbalance;
        private System.Windows.Forms.Button btn_BankAdd;
        private System.Windows.Forms.Label label3;
    }
}