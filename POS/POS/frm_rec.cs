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
    public partial class frm_rec : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_rec()
        {
            InitializeComponent();
            cmb_customers.DataSource = obj_helper.GetAllCustomerNames();
            cmb_customers.SelectedItem = null;
            cmb_PaymentMethods.DataSource = Enum.GetValues(typeof(PaymentMethods));
            cmb_banks.SelectedItem = null;
            cmb_banks.DataSource = obj_helper.GetAllBanks();
            cmb_banks.SelectedItem = null;
        }

      

        private void cmb_PaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_PaymentMethods.Text == PaymentMethods.Cash.ToString())
            {
                cmb_banks.Enabled = false;
            }
            else
            {
                cmb_banks.Enabled = true;
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
        private void btn_Pay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_AmountPaid.Text!=string.Empty  && cmb_PaymentMethods.Text != string.Empty && cmb_customers.Text != string.Empty )
                {
                    using (var context = new POS_dbEntities())
                    {
                        var customerName = cmb_customers.Text;
                        var customerID = obj_helper.GetCustomerID(customerName);
                        int Invoice = GetInvoice();
                        var obj_Recieving = new Recieving();
                        obj_Recieving.Amount = Convert.ToDouble(txt_AmountPaid.Text);
                        obj_Recieving.Customer_FK = customerID;
                        obj_Recieving.Date = dtp_RecDate.Value.Date;
                        obj_Recieving.Description = rxt_desc.Text;
                        obj_Recieving.Openning = Convert.ToDouble(txt_openningBalance.Text);
                        obj_Recieving.PaymentMethod = cmb_PaymentMethods.Text;
                        obj_Recieving.Remaining = Convert.ToDouble(txt_remaining.Text);
                        obj_Recieving.Invoice = Invoice;
                        obj_Recieving.User_FK = Login.userID;
                        DialogResult obj_dialogue = MessageBox.Show("Do You Confirm Recieving ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (obj_dialogue == DialogResult.Yes)
                        {
                            context.Recievings.Add(obj_Recieving);
                            context.SaveChanges();
                            #region Bank
                            if (obj_Recieving.PaymentMethod == PaymentMethods.Bank.ToString())
                            {
                                var bank = cmb_banks.Text;
                                var bankID = obj_helper.GetBankIdFromAccount(bank);
                                var obj_bank = new BankRecord();
                                obj_bank.Date = obj_Recieving.Date;
                                obj_bank.Bank_FK = bankID;
                                obj_bank.Credit = 0;
                                obj_bank.Debit = obj_Recieving.Amount;
                                obj_bank.Description = obj_Recieving.Description;
                                var balance = obj_helper.GetBankLastBalance();
                                obj_bank.Balance = balance + obj_bank.Debit;
                                obj_bank.User_FK = Login.userID;
                                context.BankRecords.Add(obj_bank);
                                context.SaveChanges();
                            }
                            #endregion
                            #region Cash
                            else if (cmb_PaymentMethods.Text == PaymentMethods.Cash.ToString())
                            {
                                var obj_cash = new Cash();
                                obj_cash.Credit = 0;
                                obj_cash.Debit = obj_Recieving.Amount;
                                obj_cash.Date = obj_Recieving.Date;
                                obj_cash.Description = obj_Recieving.Description;
                                var balance = obj_helper.GetCashLastBalance();
                                obj_cash.Balance = balance + obj_cash.Debit;
                                context.Cashes.Add(obj_cash);
                                context.SaveChanges();
                            }
                            #endregion
                            #region Dues
                            var obj_dues = obj_helper.GetCustomerDues(customerID);
                            if (obj_dues!=null)
                            {
                                obj_dues.Amount -= obj_Recieving.Amount;
                                context.Entry(obj_dues).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();
                            }
                           
                           
                            #endregion
                            MessageBox.Show("Payment Recieved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AllClear();
                            rxt_desc.Clear();
                            txt_openningBalance.Clear();
                            txt_remaining.Clear();
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

        private void txt_AmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var totalDue = Convert.ToDouble(lblTotalDue.Text);
                if (totalDue==0)
                {
                    txt_remaining.Text = 0.ToString();
                }
                else
                {
                    txt_remaining.Text = (totalDue - Convert.ToDouble(txt_AmountPaid.Text)).ToString();
                }
                 
                
                
            }
            catch (Exception)
            {
                txt_remaining.Text = lblTotalDue.Text;
            }
        }

        private void cmb_customers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var customerName = cmb_customers.Text;
                var customerID = obj_helper.GetCustomerID(customerName);
                var obj_due = obj_helper.GetCustomerDues(customerID);
                if (obj_due != null)
                {
                    lblTotalDue.Text = obj_due.Amount.ToString();
                    MessageBox.Show("Total Due For \n" + customerName + "\n Is\n" + obj_due.Amount.ToString(),
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_openningBalance.Text = obj_due.Amount.ToString();
                }
                else
                {
                    lblTotalDue.Text = 0.ToString();
                    //MessageBox.Show("No Due Exists For This Customer",
                    //    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_openningBalance.Text = 0.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int GetInvoice()
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    var Invoice = (from c in context.Recievings
                                   select c.Invoice).LastOrDefault();
                   
                        return Invoice + 1;
                    
                   

                }

            }
            catch (Exception)
            {

                return 1;
            }
           

        }
    }
}
