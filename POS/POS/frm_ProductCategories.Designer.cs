namespace POS
{
    partial class frm_ProductCategories
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_ParentCats = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_showSubCats = new System.Windows.Forms.Button();
            this.dgv_ShowSubCats = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SubCatName = new System.Windows.Forms.TextBox();
            this.btn_SubCats = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_showAllCats = new System.Windows.Forms.Button();
            this.dgv_AllCats = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_CatName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_ShowParentCats = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_showParentCats = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowSubCats)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AllCats)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowParentCats)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmb_ParentCats);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txt_SubCatName);
            this.groupBox3.Controls.Add(this.btn_SubCats);
            this.groupBox3.Location = new System.Drawing.Point(6, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 125);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sub Categories";
            // 
            // cmb_ParentCats
            // 
            this.cmb_ParentCats.FormattingEnabled = true;
            this.cmb_ParentCats.Location = new System.Drawing.Point(119, 60);
            this.cmb_ParentCats.Name = "cmb_ParentCats";
            this.cmb_ParentCats.Size = new System.Drawing.Size(191, 21);
            this.cmb_ParentCats.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parent Category";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_showSubCats);
            this.groupBox5.Controls.Add(this.dgv_ShowSubCats);
            this.groupBox5.Location = new System.Drawing.Point(339, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(317, 445);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "View Sub-Categories";
            // 
            // btn_showSubCats
            // 
            this.btn_showSubCats.Location = new System.Drawing.Point(174, 13);
            this.btn_showSubCats.Name = "btn_showSubCats";
            this.btn_showSubCats.Size = new System.Drawing.Size(125, 44);
            this.btn_showSubCats.TabIndex = 4;
            this.btn_showSubCats.Text = "View Sub-Categories";
            this.btn_showSubCats.UseVisualStyleBackColor = true;
            this.btn_showSubCats.Click += new System.EventHandler(this.btn_showSubCats_Click);
            // 
            // dgv_ShowSubCats
            // 
            this.dgv_ShowSubCats.AllowUserToAddRows = false;
            this.dgv_ShowSubCats.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ShowSubCats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShowSubCats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column5,
            this.dataGridViewButtonColumn1});
            this.dgv_ShowSubCats.Location = new System.Drawing.Point(6, 63);
            this.dgv_ShowSubCats.Name = "dgv_ShowSubCats";
            this.dgv_ShowSubCats.RowHeadersVisible = false;
            this.dgv_ShowSubCats.Size = new System.Drawing.Size(306, 376);
            this.dgv_ShowSubCats.TabIndex = 5;
            this.dgv_ShowSubCats.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ShowSubCats_CellContentClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Sub-Category Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "id";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Delete";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Delete";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sub-Category Name";
            // 
            // txt_SubCatName
            // 
            this.txt_SubCatName.Location = new System.Drawing.Point(119, 28);
            this.txt_SubCatName.Name = "txt_SubCatName";
            this.txt_SubCatName.Size = new System.Drawing.Size(191, 20);
            this.txt_SubCatName.TabIndex = 1;
            // 
            // btn_SubCats
            // 
            this.btn_SubCats.Location = new System.Drawing.Point(191, 87);
            this.btn_SubCats.Name = "btn_SubCats";
            this.btn_SubCats.Size = new System.Drawing.Size(119, 34);
            this.btn_SubCats.TabIndex = 3;
            this.btn_SubCats.Text = "Add Sub-Category";
            this.btn_SubCats.UseVisualStyleBackColor = true;
            this.btn_SubCats.Click += new System.EventHandler(this.btn_SubCats_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_showAllCats);
            this.groupBox4.Controls.Add(this.dgv_AllCats);
            this.groupBox4.Location = new System.Drawing.Point(21, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(683, 434);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "View All Categories";
            // 
            // btn_showAllCats
            // 
            this.btn_showAllCats.Location = new System.Drawing.Point(458, 19);
            this.btn_showAllCats.Name = "btn_showAllCats";
            this.btn_showAllCats.Size = new System.Drawing.Size(98, 40);
            this.btn_showAllCats.TabIndex = 1;
            this.btn_showAllCats.Text = "View Categories";
            this.btn_showAllCats.UseVisualStyleBackColor = true;
            this.btn_showAllCats.Click += new System.EventHandler(this.btn_showAllCats_Click);
            // 
            // dgv_AllCats
            // 
            this.dgv_AllCats.AllowUserToAddRows = false;
            this.dgv_AllCats.BackgroundColor = System.Drawing.Color.White;
            this.dgv_AllCats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AllCats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2});
            this.dgv_AllCats.Location = new System.Drawing.Point(6, 19);
            this.dgv_AllCats.Name = "dgv_AllCats";
            this.dgv_AllCats.RowHeadersVisible = false;
            this.dgv_AllCats.Size = new System.Drawing.Size(408, 404);
            this.dgv_AllCats.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Category Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Sub-Category";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(227, 60);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(84, 34);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Add Category";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_CatName
            // 
            this.txt_CatName.Location = new System.Drawing.Point(120, 35);
            this.txt_CatName.Name = "txt_CatName";
            this.txt_CatName.Size = new System.Drawing.Size(191, 20);
            this.txt_CatName.TabIndex = 1;
            this.txt_CatName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CatName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_CatName);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Category";
            // 
            // dgv_ShowParentCats
            // 
            this.dgv_ShowParentCats.AllowUserToAddRows = false;
            this.dgv_ShowParentCats.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ShowParentCats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShowParentCats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column3});
            this.dgv_ShowParentCats.Location = new System.Drawing.Point(6, 63);
            this.dgv_ShowParentCats.Name = "dgv_ShowParentCats";
            this.dgv_ShowParentCats.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_ShowParentCats.RowHeadersVisible = false;
            this.dgv_ShowParentCats.Size = new System.Drawing.Size(305, 375);
            this.dgv_ShowParentCats.TabIndex = 3;
            this.dgv_ShowParentCats.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ShowParentCats_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Category Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "id";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Delete";
            this.Column3.Name = "Column3";
            this.Column3.Text = "Delete";
            this.Column3.UseColumnTextForButtonValue = true;
            // 
            // btn_showParentCats
            // 
            this.btn_showParentCats.Location = new System.Drawing.Point(213, 13);
            this.btn_showParentCats.Name = "btn_showParentCats";
            this.btn_showParentCats.Size = new System.Drawing.Size(98, 44);
            this.btn_showParentCats.TabIndex = 3;
            this.btn_showParentCats.Text = "View Categories";
            this.btn_showParentCats.UseVisualStyleBackColor = true;
            this.btn_showParentCats.Click += new System.EventHandler(this.btn_showParentCats_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_showParentCats);
            this.groupBox2.Controls.Add(this.dgv_ShowParentCats);
            this.groupBox2.Location = new System.Drawing.Point(342, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 444);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Categories";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 492);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(726, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Categories";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mapping";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(726, 466);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "View";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // frm_ProductCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(749, 502);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_ProductCategories";
            this.Text = "ProductCategoriesForm";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowSubCats)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AllCats)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowParentCats)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SubCatName;
        private System.Windows.Forms.Button btn_SubCats;
        private System.Windows.Forms.ComboBox cmb_ParentCats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv_AllCats;
        private System.Windows.Forms.Button btn_showAllCats;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_CatName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_ShowParentCats;
        private System.Windows.Forms.Button btn_showParentCats;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgv_ShowSubCats;
        private System.Windows.Forms.Button btn_showSubCats;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}