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
 
    public partial class frm_Expenses : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_Expenses()
        {
            InitializeComponent();
            
            cmb_PaymentMethods.DataSource = Enum.GetValues(typeof(PaymentMethods));
            using (var context=new POS_dbEntities())
            {
                var obj = (from c in context.Expense_Categories
                           select c.Category_Name).ToList();
                cmb_Name.DataSource = obj;
                cmb_Name.SelectedItem = null;
                var obj_bank = (from c in context.Banks
                                select c.BankName).ToList();
                cmb_banks.DataSource = obj_bank;
                cmb_banks.SelectedItem = null;
                cmb_PaymentMethods.SelectedItem = null;
            }
        }

        private void btn_AddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Category.Text!=string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var obj = new Expense_Category();
                        obj.Category_Name = txt_Category.Text;
                        DialogResult obj_dialouge = MessageBox.Show("Do you want to save it", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (obj_dialouge == DialogResult.Yes)
                        {
                            context.Expense_Categories.Add(obj);
                            context.SaveChanges();
                            MessageBox.Show("Expense Category Added successfully");
                            GetClear();
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

                MessageBox.Show(ex.Message);
            }
            
        }

      
        void GetClear()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
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

        private void btn_AddExpense_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmb_Name.Text!=string.Empty && cmb_PaymentMethods.Text != string.Empty && txt_Amount.Text != string.Empty && rtb_expense.Text != string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var obj_expense = new Expens();
                        var obj_getid = new HelperClass();
                        obj_expense.Exp_Category_FK = obj_getid.GetExpenseCategoryID(cmb_Name.Text);
                        obj_expense.Date = dtm_Expense.Value.Date;
                        obj_expense.Amount = Convert.ToDouble(txt_Amount.Text);
                        obj_expense.Description = rtb_expense.Text;
                        obj_expense.PaymentMethod = cmb_PaymentMethods.Text;
                        if (obj_expense.PaymentMethod=="Cash")
                        {
                            obj_expense.BankName = "";

                        }
                        else
                        {
                            obj_expense.BankName = cmb_banks.Text;
                        }
                        DialogResult obj_dialouge1 = MessageBox.Show("Do you want to save it", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (obj_dialouge1 == DialogResult.Yes)
                        {
                            context.Expenses.Add(obj_expense);
                            context.SaveChanges();

                            #region Bank
                            if (obj_expense.PaymentMethod == "Bank")
                            {
                                var bank = cmb_banks.Text;
                                var bankID = obj_helper.GetBankIdFromAccount(bank);
                                var obj_bank = new BankRecord();
                                obj_bank.Date = obj_expense.Date;
                                obj_bank.Bank_FK = bankID;
                                obj_bank.User_FK = Login.userID;
                                obj_bank.Credit = obj_expense.Amount;
                                obj_bank.Debit = 0;
                                obj_bank.Description = obj_expense.Description;
                                var balance = obj_helper.GetBankLastBalance();
                                obj_bank.Balance = balance - obj_bank.Credit;
                                context.BankRecords.Add(obj_bank);
                                context.SaveChanges();
                            }
                            #endregion
                            #region Cash
                            else if (cmb_PaymentMethods.Text == "Cash")
                            {
                                var obj_cash = new Cash();
                                obj_cash.Credit = obj_expense.Amount;
                                obj_cash.Debit = 0;
                                obj_cash.Date = obj_expense.Date;
                                
                                obj_cash.Description = obj_expense.Description;
                                var balance = obj_helper.GetCashLastBalance();
                                obj_cash.Balance = balance - obj_cash.Credit;
                                context.Cashes.Add(obj_cash);
                                context.SaveChanges();
                            }
                            #endregion
                            GetClear();
                            cmb_Name.SelectedItem = null;
                            cmb_banks.SelectedItem = null;
                            cmb_PaymentMethods.SelectedItem = null;
                            MessageBox.Show("Expense Recorded successfully");
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
                MessageBox.Show(ex.Message);
            }
                
            
           
            
        }

        private void cmb_PaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

       
    }
}
