using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frm_EditExpense : Form
    {
        HelperClass obj_helper = new HelperClass();
        Expens editData;
        public frm_EditExpense()
        {
            InitializeComponent();
            using (var context = new POS_dbEntities())
            {
                var cat = (from c in context.Expense_Categories
                           select c.Category_Name).ToList();
                cmb_Name.DataSource = cat;
                cmb_Name.SelectedItem = null;
            }
        }
        public frm_EditExpense(Expens _editData)
        {
            InitializeComponent();
            txt_Amount.Text = editData.Amount.ToString();
            cmb_Name.SelectedItem = obj_helper.GetExpenseCatNameFromID(editData.Exp_Category_FK);
            cmb_PaymentMethods.SelectedItem = editData.PaymentMethod;
            rtb_expense.Text = editData.Description;
            editData = _editData;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context= new POS_dbEntities())
                {
                    var obj_editing = new Expens();
                    obj_editing.Amount = Convert.ToDouble(txt_Amount.Text);
                    obj_editing.Date = dtm_Expense.Value.Date;
                    obj_editing.Description = rtb_expense.Text;
                    obj_editing.Exp_Category_FK = obj_helper.GetExpenseCategoryID(cmb_Name.Text);
                    obj_editing.PaymentMethod = cmb_PaymentMethods.Text;
                    context.Entry(obj_editing).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    MessageBox.Show("Expense Edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AllClear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AllClear()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }

                    else if (control is ComboBox)

                    {
                        (control as ComboBox).SelectedItem = null;
                    }
                    else if (control is RichTextBox)

                    {
                        (control as RichTextBox).Clear();
                    }
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

       
    }
}
