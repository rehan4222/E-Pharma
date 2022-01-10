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
    public partial class frm_PayementEdit : Form
    {
        HelperClass obj_helper = new HelperClass();
        Payment obj_paymentEdit;
        double openning;
        public frm_PayementEdit()
        {
            InitializeComponent();
            cmb_suppliers.DataSource = obj_helper.GetAllSupplierNames();
            cmb_suppliers.SelectedItem = null;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_invoice.Text!=string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var invoice = Convert.ToInt32(txt_invoice.Text);
                        var payment = obj_helper.GetPaymentDetails(invoice);
                        if (payment==null)
                        {
                            MessageBox.Show("There is no Payment Recorded against this Invoice");
                        }
                        else
                        {
                            cmb_suppliers.SelectedItem = obj_helper.GetSupplierNameFromID(payment.Supplier_FK);
                            cmb_PaymentMethods.SelectedItem = payment.PaymentMethod;
                            txt_AmountPaid.Text = payment.Amount.ToString();
                            txt_openningBalance.Text = payment.Openning.ToString();
                            txt_remaining.Text = payment.Remaining.ToString();
                            obj_paymentEdit = payment;
                            openning = payment.Openning;
                            rxt_desc.Text = payment.Description;

                        }
                        
                    }

                }
                else
                {
                    MessageBox.Show("Please Fill all Fields");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context= new POS_dbEntities())
                {
                    if (obj_paymentEdit.Supplier_FK!= obj_helper.GetSupplierIDFromName(cmb_suppliers.Text))
                    {
                        var supplierDue = obj_helper.GetSupplierDue(obj_paymentEdit.Supplier_FK);
                        supplierDue.Amount += obj_paymentEdit.Amount;
                        context.Entry(supplierDue).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        supplierDue = new SupplierDue();
                        obj_paymentEdit.Amount = Convert.ToDouble(txt_AmountPaid.Text);
                        supplierDue = obj_helper.GetSupplierDue(obj_helper.GetSupplierIDFromName(cmb_suppliers.Text));
                        supplierDue.Amount -= obj_paymentEdit.Amount;
                        context.Entry(supplierDue).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        var supplierDue = obj_helper.GetSupplierDue(obj_paymentEdit.Supplier_FK);
                        supplierDue.Amount += obj_paymentEdit.Amount;
                        context.Entry(supplierDue).State = System.Data.Entity.EntityState.Modified;
                        obj_paymentEdit.Amount = Convert.ToDouble(txt_AmountPaid.Text);
                        supplierDue.Amount -= obj_paymentEdit.Amount;
                        context.Entry(supplierDue).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    obj_paymentEdit.Amount = Convert.ToDouble(txt_AmountPaid.Text);
                    obj_paymentEdit.Date = dtp_paymentDate.Value.Date;
                    obj_paymentEdit.Description = rxt_desc.Text;
                    obj_paymentEdit.Openning = Convert.ToDouble(txt_openningBalance.Text);
                    obj_paymentEdit.PaymentMethod = cmb_PaymentMethods.Text;
                    obj_paymentEdit.Remaining = Convert.ToDouble(txt_remaining.Text);
                    obj_paymentEdit.Supplier_FK = obj_helper.GetSupplierIDFromName(cmb_suppliers.Text);
                    obj_paymentEdit.User_FK = 1;
                    context.Entry(obj_paymentEdit).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    MessageBox.Show("Payment Edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void txt_AmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_remaining.Text = (openning - Convert.ToDouble(txt_AmountPaid.Text)).ToString();
            }
            catch (Exception)
            {
                txt_remaining.Text = string.Empty;
            }
        }
    }
}
