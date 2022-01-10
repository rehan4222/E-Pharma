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
    public partial class frm_Recievings : Form
    {
        HelperClass obj_helper = new HelperClass();
        Recieving obj_recievingEdit;
        public frm_Recievings()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_invoice.Text!=string.Empty)
                {
                    var invoice = Convert.ToInt32(txt_invoice.Text);
                    var recievings = obj_helper.GetRecievingDetails(invoice);
                    if (recievings!=null)
                    {
                        txt_AmountPaid.Text = recievings.Amount.ToString();
                        txt_openningBalance.Text = recievings.Openning.ToString();
                        txt_remaining.Text = recievings.Remaining.ToString();
                        cmb_customers.SelectedItem = obj_helper.GetCustomerName(recievings.Customer_FK);
                        cmb_PaymentMethods.SelectedItem = recievings.PaymentMethod;
                        rxt_desc.Text = recievings.Description;
                        obj_recievingEdit = recievings;

                    }
                    else
                    {
                        MessageBox.Show("There is no Recievings against this Invoice...!");
                    }
                    

                }
                else
                {
                    MessageBox.Show("Please Enter Invoice Number");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context= new POS_dbEntities())
                {
                    if (obj_recievingEdit.Customer_FK!= obj_helper.GetCustomerID(cmb_customers.Text))
                    {
                        var customerDue = obj_helper.GetCustomerDues(obj_recievingEdit.Customer_FK);
                        customerDue.Amount += obj_recievingEdit.Amount;
                        context.Entry(customerDue).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        customerDue = new CustomerDue();
                        obj_recievingEdit.Amount = Convert.ToDouble(txt_AmountPaid.Text);
                        customerDue = obj_helper.GetCustomerDues(obj_helper.GetCustomerID(cmb_customers.Text));
                        customerDue.Amount -= obj_recievingEdit.Amount;
                        context.Entry(customerDue).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        var customerDue = obj_helper.GetCustomerDues(obj_recievingEdit.Customer_FK);
                        customerDue.Amount += obj_recievingEdit.Amount;
                        context.Entry(customerDue).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        customerDue = new CustomerDue();
                        obj_recievingEdit.Amount = Convert.ToDouble(txt_AmountPaid.Text);
                        customerDue.Amount -= obj_recievingEdit.Amount;
                        context.Entry(customerDue).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    obj_recievingEdit.Customer_FK = obj_helper.GetCustomerID(cmb_customers.Text);
                    obj_recievingEdit.Date = dtp_RecDate.Value.Date;
                    obj_recievingEdit.Description = rxt_desc.Text;
                    obj_recievingEdit.Openning = Convert.ToDouble(txt_openningBalance.Text);
                    obj_recievingEdit.PaymentMethod = cmb_PaymentMethods.Text;
                    obj_recievingEdit.Remaining = Convert.ToDouble(txt_remaining.Text);
                    obj_recievingEdit.User_FK = Login.userID;
                    context.Entry(obj_recievingEdit).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    MessageBox.Show("Invoice Edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
    }
}
