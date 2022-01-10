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
    public partial class frm_SearchExpensecs : Form
    {
        HelperClass obj_helper = new HelperClass();
        int rowIndex = 0;
        int colIndex = 0;
        public frm_SearchExpensecs()
        {
            InitializeComponent();
            using (var context=new POS_dbEntities())
            {
                var cat = (from c in context.Expense_Categories
                           select c.Category_Name).ToList();
                cmb_cat.DataSource = cat;
                cmb_cat.SelectedItem = null;
            }
        }

        private void dtm_search_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dgv_search_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex== dgv_search.NewRowIndex)
                {

                }
                else if (e.ColumnIndex==7)
                {
                    using (var context=new POS_dbEntities())
                    {
                    var ID = Convert.ToInt32(dgv_search.Rows[e.RowIndex].Cells[0].Value);
                    var Data = (from c in context.Expenses
                                where c.ID==ID
                                select c).SingleOrDefault();
                        if (Data.PaymentMethod=="Cash")
                        {
                            var obj_cash = new Cash();//cash reversing
                            obj_cash.Date = Data.Date;
                            obj_cash.Description = "This is reverse entry of expense editing";
                            obj_cash.Debit = Data.Amount;
                            obj_cash.Credit = 0;
                            var balance = obj_helper.GetCashLastBalance();
                            obj_cash.Balance = balance + obj_cash.Debit;
                            context.Cashes.Add(obj_cash);
                            context.SaveChanges();

                        }
                        if (Data.PaymentMethod=="Bank")
                        {
                            var bank = Data.BankName;
                            var bankID = obj_helper.GetBankIdFromAccount(bank);
                            var obj_bank = new BankRecord();
                            obj_bank.Date = Data.Date;
                            obj_bank.Bank_FK = bankID;
                            obj_bank.User_FK = Login.userID;
                            obj_bank.Debit = Data.Amount;
                            obj_bank.Credit = 0;
                            obj_bank.Description = "This is reverse entry of expense editing";
                            var balance = obj_helper.GetBankLastBalance();
                            obj_bank.Balance = balance + obj_bank.Credit;
                            context.BankRecords.Add(obj_bank);
                            context.SaveChanges();
                        }
                  //  dgv_search.Rows[e.RowIndex].Cells[1].Value = EditDate;
                    Data.Date=Convert.ToDateTime(dgv_search.Rows[e.RowIndex].Cells[1].Value);
                    var catName = dgv_search.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Data.Exp_Category_FK = obj_helper.GetExpenseCategoryID(catName);
                    Data.PaymentMethod= dgv_search.Rows[e.RowIndex].Cells[3].Value.ToString();
                        if (Data.PaymentMethod=="Cash")
                        {
                            Data.BankName = "";
                        }
                        else if(Data.PaymentMethod=="Bank")
                        {
                            Data.BankName = dgv_search.Rows[e.RowIndex].Cells[4].Value.ToString();
                        }
                   
                    Data.Description= dgv_search.Rows[e.RowIndex].Cells[5].Value.ToString();
                    Data.Amount = Convert.ToDouble(dgv_search.Rows[e.RowIndex].Cells[6].Value.ToString());
                    context.Entry(Data).State = System.Data.Entity.EntityState.Modified;
                        if (Data.PaymentMethod=="Cash")
                        {
                            var cash = new Cash();//real cash entry again
                            cash.Date = Data.Date;
                            cash.Description = Data.Description;
                            cash.Credit = Data.Amount;
                            cash.Debit = 0;
                            var balancee = obj_helper.GetCashLastBalance();
                            cash.Balance = balancee - cash.Credit;
                            context.Cashes.Add(cash);
                            context.SaveChanges();

                        }
                        if (Data.PaymentMethod=="Bank")
                        {
                            var bank = Data.BankName;
                            var bankID = obj_helper.GetBankIdFromAccount(bank);
                            var obj_bank = new BankRecord();
                            obj_bank.Date = Data.Date;
                            obj_bank.Bank_FK = bankID;
                            obj_bank.User_FK = Login.userID;
                            obj_bank.Credit = Data.Amount;
                            obj_bank.Debit = 0;
                            obj_bank.Description = Data.Description;
                            var balance = obj_helper.GetBankLastBalance();
                            obj_bank.Balance = balance + obj_bank.Credit;
                            context.BankRecords.Add(obj_bank);
                            context.SaveChanges();

                        }

                        MessageBox.Show("Edited..!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        LoadDgv();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            LoadDgv();
        }
        DateTimePicker oDateTimePicker = new DateTimePicker();
        private void dgv_search_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 1)
            {


                dtm_edit.Visible = true;
                rowIndex = e.RowIndex;
                colIndex = e.ColumnIndex;
            
        
                
            }
        }
        DateTime EditDate;
        private void dtm_edit_ValueChanged(object sender, EventArgs e)
        {
            EditDate = dtm_edit.Value.Date;
            dtm_edit.Visible = false;
            if (colIndex!=0)
            {
                dgv_search.Rows[rowIndex].Cells[colIndex].Value = EditDate;

            }
        }


        void LoadDgv()
        {
            try
            {
                if (cmb_cat.Text != string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        dgv_search.Rows.Clear();
                        var date = dtm_search.Value.Date;
                        var catID = obj_helper.GetExpenseCategoryID(cmb_cat.Text);
                        var data = (from c in context.Expenses
                                    where c.Date == date
                                    && c.Exp_Category_FK == catID
                                    select c).ToList();
                        var Bankname = (from c in context.Banks
                                        select c.BankName).ToList();
                        foreach (var banks in Bankname)
                        {
                            Column8.Items.Add(banks);
                        }
                        var AllExpname = (from c in context.Expense_Categories
                                          select c.Category_Name).ToList();
                        foreach (var exp in AllExpname)
                        {
                            Column4.Items.Add(exp);
                        }
                        foreach (var item in data)
                        {
                            var selectedbank = (from c in context.Banks
                                                where c.BankName == item.BankName
                                                select c.BankName).SingleOrDefault();
                            dgv_search.Rows.Add(item.ID, item.Date.ToShortDateString(), Column4.DisplayMember = obj_helper.GetExpenseCatNameFromID(item.Exp_Category_FK), Column7.DisplayMember = item.PaymentMethod, Column8.DisplayMember = item.BankName, item.Description, item.Amount);
                        }
                        var Date = dtm_search.Value.Date;
                        dtm_edit.Value =Date;
                    }

                }
                else
                {
                    using (var context = new POS_dbEntities())
                    {
                        dgv_search.Rows.Clear();
                        var date = dtm_search.Value.Date;

                        var data = (from c in context.Expenses
                                    where c.Date == date
                                    select c).ToList();
                        var Bankname = (from c in context.Banks
                                        select c.BankName).ToList();
                        foreach (var banks in Bankname)
                        {
                            Column8.Items.Add(banks);
                        }
                        var AllExpname = (from c in context.Expense_Categories
                                          select c.Category_Name).ToList();
                        foreach (var exp in AllExpname)
                        {
                            Column4.Items.Add(exp);
                        }
                        foreach (var item in data)
                        {
                            dgv_search.Rows.Add(item.ID, item.Date.ToShortDateString(), Column4.DisplayMember = obj_helper.GetExpenseCatNameFromID(item.Exp_Category_FK), Column7.DisplayMember = item.PaymentMethod, item.BankName, item.Description, item.Amount);
                        }
                        var Date = dtm_search.Value.Date;
                        dtm_edit.Value = Date;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
