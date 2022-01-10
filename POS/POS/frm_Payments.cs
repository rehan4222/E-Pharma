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
    enum PaymentMethods
    {
        Cash,Bank
    };
    public partial class frm_Payments : Form
    {
        HelperClass obj_helper = new HelperClass();
        double opening;
        public frm_Payments()
        {
            InitializeComponent();
            cmb_suppliers.DataSource = obj_helper.GetAllSupplierNames();
            cmb_suppliers.SelectedItem = null;
            cmb_PaymentMethods.DataSource = Enum.GetValues(typeof(PaymentMethods));
            cmb_banks.SelectedItem = null;
            cmb_banks.DataSource = obj_helper.GetAllBanks();
            cmb_banks.SelectedItem = null;
        }
       
        private void cmb_PaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_PaymentMethods.Text== PaymentMethods.Cash.ToString())
            {
                cmb_banks.Enabled = false;
            }
            else
            {
                cmb_banks.Enabled = true;
            }
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_AmountPaid.Text!=string.Empty  && cmb_suppliers.Text != string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var supplierName = cmb_suppliers.Text;
                        var supplierID = obj_helper.GetSupplierIDFromName(supplierName);
                        var obj_dues = obj_helper.GetSupplierDue(supplierID);
                        if (obj_dues.Amount > 0)
                        {
                            #region Payment
                            var obj_payment = new Payment();
                            obj_payment.Amount = Convert.ToDouble(txt_AmountPaid.Text);
                            obj_payment.Date = dtp_paymentDate.Value.Date;
                            obj_payment.Openning = Convert.ToDouble(txt_openningBalance.Text);
                            obj_payment.Remaining = Convert.ToDouble(txt_remaining.Text);
                            obj_payment.Supplier_FK = supplierID;
                            obj_payment.PaymentMethod = cmb_PaymentMethods.Text;
                            obj_payment.Description = rxt_desc.Text;
                            obj_payment.Invoice = obj_helper.GetLastPaymentInvoice();
                            obj_payment.User_FK = Login.userID;
                            DialogResult obj_dialogue = MessageBox.Show("Do You Confirm Payment of \n" + obj_payment.Amount.ToString() + "\n Against \n" + supplierName + " ??", "Confrimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (obj_dialogue == DialogResult.Yes)
                            {
                                context.Payments.Add(obj_payment);
                                #region Bank
                                if (obj_payment.PaymentMethod == "Bank")
                                {
                                    var bank = cmb_banks.Text;
                                    var bankID = obj_helper.GetBankIdFromAccount(bank);
                                    var obj_bank = new BankRecord();
                                    obj_bank.Date = obj_payment.Date;
                                    obj_bank.Bank_FK = bankID;
                                    obj_bank.Credit = obj_payment.Amount;
                                    obj_bank.Debit = 0;
                                    obj_bank.Description = obj_payment.Description;
                                    var balance = obj_helper.GetBankLastBalance();
                                    obj_bank.Balance = balance - obj_bank.Credit;
                                    obj_bank.User_FK = Login.userID;
                                    context.BankRecords.Add(obj_bank);
                                }
                                #endregion

                                #region Cash
                                else if (cmb_PaymentMethods.Text == PaymentMethods.Cash.ToString())
                                {
                                    var obj_cash = new Cash();
                                    obj_cash.Credit = obj_payment.Amount;
                                    obj_cash.Debit = 0;
                                    obj_cash.Date = obj_payment.Date;
                                    obj_cash.Description = obj_payment.Description;
                                    var balance = obj_helper.GetCashLastBalance();
                                    obj_cash.Balance = balance - obj_cash.Credit;
                                    context.Cashes.Add(obj_cash);
                                }
                                #endregion

                                #region Dues
                                obj_dues.Amount -= obj_payment.Amount;
                                context.Entry(obj_dues).State = System.Data.Entity.EntityState.Modified;

                                #endregion
                                #region PaymentLdgr
                                var obj_paymentLdgr = new PaymentsLedger();
                                obj_paymentLdgr.Amount = Convert.ToDouble(txt_AmountPaid.Text);
                                obj_paymentLdgr.Date = dtp_paymentDate.Value.Date;
                                obj_paymentLdgr.Openning = Convert.ToDouble(txt_openningBalance.Text);
                                obj_paymentLdgr.Remaining = Convert.ToDouble(txt_remaining.Text);
                                obj_paymentLdgr.Supplier_FK = supplierID;
                                obj_paymentLdgr.PaymentMethod = cmb_PaymentMethods.Text; ;
                                obj_paymentLdgr.Description = rxt_desc.Text;
                                obj_paymentLdgr.Invoice = obj_helper.GetLastPaymentInvoice();
                                obj_paymentLdgr.User_FK = Login.userID;
                                context.PaymentsLedgers.Add(obj_paymentLdgr);
                                context.SaveChanges();
                                #endregion
                                MessageBox.Show("Payment Paid Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AllClear();
                            }
                            #endregion
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please Fill All Fields");
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
                txt_remaining.Text = (opening - Convert.ToDouble(txt_AmountPaid.Text)).ToString();
            }
            catch (Exception )
            {
                txt_remaining.Text = string.Empty;
            }
        }

        private void cmb_suppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_suppliers.Text != string.Empty)
                {
                    var supplierName = cmb_suppliers.Text;
                    var supplierID = obj_helper.GetSupplierIDFromName(supplierName);
                    var obj_due = obj_helper.GetSupplierDue(supplierID);

                    lblTotalDue.Text = obj_due.Amount.ToString();

                    txt_openningBalance.Text = obj_due.Amount.ToString();
                    opening = obj_due.Amount;
                }
                else
                {
                    lblTotalDue.Text = 0.ToString();
                    txt_openningBalance.Text = 0.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
