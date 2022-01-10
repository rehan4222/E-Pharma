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
    public partial class frm_Sales : Form
    {
        HelperClass obj_helper = new HelperClass();
        List<string> BatchNoList = new List<string>();
        string productName;
        double granTotal=0.0f;
        public frm_Sales()
        {
            InitializeComponent();
            cmb_name.DataSource = obj_helper.GetAllProductName();
            cmb_name.SelectedItem = null;
            cmb_banks.DataSource = obj_helper.GetAllBanks();
            cmb_banks.SelectedItem = null;
            
            cmb_PerCust.DataSource = obj_helper.GetAllCustomerNames();
            cmb_PerCust.SelectedItem = null;
            txt_BarCode.Visible = false;
           
        }
        private void cmb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var context=new POS_dbEntities())
                {
                    if (cmb_name.Text == string.Empty)
                    {
                        dgv_sales.Rows.Clear();
                    }
                    else
                    {
                        var productname = cmb_name.Text;
                        var productId=  obj_helper.GetPrdocuctNameFormID(productname);
                        var product = obj_helper.GetPrdocuctFormID(productId);
                        var subcategory_name = obj_helper.GetSubCategoryNameFromID(product.Product_Sub_Category_FK);
                        var categoryid = obj_helper.GetCatIDFromSubCatID(product.Product_Sub_Category_FK);
                        var category_name = obj_helper.GetCategoryNameFromID(categoryid);
                        var unitprice = (from c in context.Products
                                         where c.Name==productname
                                         select c.Sale_Cost).SingleOrDefault();
                       

                        dgv_sales.Rows.Add(product.Name, category_name, subcategory_name, unitprice);
                        
                        
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dgv_sales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new POS_dbEntities())
            {
                if (e.RowIndex == dgv_sales.NewRowIndex || e.RowIndex < 0)
                {
                    return;
                }
                else
                {
                    if (e.ColumnIndex==0)
                    {
                        try
                        {
                            var prodname = dgv_sales.Rows[e.RowIndex].Cells[0].Value.ToString();
                            var query = (from c in context.Products
                                         where c.Name==prodname
                                         select c).SingleOrDefault();
                            var prodsubID = query.Product_Sub_Category_FK;
                            var CatID = obj_helper.GetCatIDFromSubCatID(prodsubID);
                            var prodsubname = obj_helper.GetSubCategoryNameFromID(prodsubID);
                            var CatName = obj_helper.GetCategoryNameFromID(CatID);
                            var unitprice = query.Sale_Cost;
                            dgv_sales.Rows[e.RowIndex].Cells[1].Value = CatName;
                            dgv_sales.Rows[e.RowIndex].Cells[2].Value = prodsubname;
                            dgv_sales.Rows[e.RowIndex].Cells[3].Value = unitprice;
                            var prodID = obj_helper.GetProductIDFromName(prodname);
                           
                        }
                        catch (Exception)
                        {
                            var prodname = dgv_sales.Rows[e.RowIndex].Cells[0].Value.ToString();
                            var query = (from c in context.Products
                                         where c.Name == prodname
                                         select c).SingleOrDefault();
                            var prodsubID = query.Product_Sub_Category_FK;
                            var CatID = obj_helper.GetCatIDFromSubCatID(prodsubID);
                            var prodsubname = obj_helper.GetSubCategoryNameFromID(prodsubID);
                            var CatName = obj_helper.GetCategoryNameFromID(CatID);
                            var unitprice = query.Sale_Cost;
                            dgv_sales.Rows[e.RowIndex].Cells[1].Value = CatName;
                            dgv_sales.Rows[e.RowIndex].Cells[2].Value = prodsubname;
                            dgv_sales.Rows[e.RowIndex].Cells[3].Value = unitprice;
                            var prodID = obj_helper.GetProductIDFromName(prodname);
                           


                        }
                    }
                    if (e.ColumnIndex == 4)
                    {
                        try
                        {
                            var quantity = Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[4].Value.ToString());
                            var rate = Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[3].Value.ToString());
                            var discount = Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[5].Value.ToString());
                            var totalrate = rate * quantity;
                            var totalbill = (totalrate - discount);
                            dgv_sales.Rows[e.RowIndex].Cells[6].Value = totalbill;
                            double TotalBillShown = 0.0f;
                            foreach (DataGridViewRow item in dgv_sales.Rows)
                            {
                                TotalBillShown += Convert.ToDouble(item.Cells[6].Value);
                            }
                            txt_grandtotal.Text = TotalBillShown.ToString();
                            granTotal = TotalBillShown;
                        }
                        catch (Exception )
                        {
                            var quantity = Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[4].Value.ToString());
                            var rate = Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[3].Value.ToString());
                            var totalrate = rate * quantity;
                            dgv_sales.Rows[e.RowIndex].Cells[6].Value = totalrate;
                            double TotalBillShown = 0.0f;
                            foreach (DataGridViewRow item in dgv_sales.Rows)
                            {
                                TotalBillShown += Convert.ToDouble(item.Cells[6].Value);
                            }
                            txt_grandtotal.Text = TotalBillShown.ToString();
                            granTotal = TotalBillShown;
                        }
                    }
                    else if (e.ColumnIndex==5)
                    {
                        var quantity = Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[4].Value.ToString());
                        var rate = Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[3].Value.ToString());
                        var discount = Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[5].Value.ToString());
                        var totalrate = rate * quantity;
                        var totalbill = (totalrate - discount);
                        dgv_sales.Rows[e.RowIndex].Cells[6].Value = totalbill;
                        double TotalBillShown = 0.0f;
                        foreach (DataGridViewRow item in dgv_sales.Rows)
                        {
                            TotalBillShown += Convert.ToDouble(item.Cells[6].Value);
                        }
                        txt_grandtotal.Text = TotalBillShown.ToString();
                        granTotal = TotalBillShown;
                    }

                }
            }
        }
        private void txt_BarCode_TextChanged(object sender, EventArgs e)
        {
            var barCode = txt_BarCode.Text;
            productName = obj_helper.GetProductNameFromBarCode(barCode);
            cmb_name.SelectedItem = productName;
        }
        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double discount = Convert.ToDouble(txt_discount.Text);
                txt_grandtotal.Text = (granTotal - discount).ToString();

            }
            catch (Exception)
            {
                txt_grandtotal.Text = (granTotal).ToString();

            }
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            var obj_form = new frm_SalesReciptCrystalReport(obj_globalSales);
           
            obj_form.Show();

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
                   
                    else
                        func(control.Controls);
                dgv_sales.Rows.Clear();
            };

            func(Controls);
            
        }
        private void cmb_Payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Payment.Text=="Cash")
            {
                cmb_banks.Enabled = false;
            }
            else if (cmb_Payment.Text == "Bank")
            {
                cmb_banks.Enabled = true;
            }
            else if (cmb_Payment.Text == "Credit")
            {
                //if (cmb_PerCust.Text==string.Empty)
                //{
                   cmb_banks.Enabled = false;
                    //var obj_form = new frm_Customers();
                    //obj_form.Show();
                    //txt_Customer.Text = frm_Customers.customerName;

                //}
                
               
            }
        }

        private void txt_grandtotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_remaining.Text = txt_grandtotal.Text;
            }
            catch (Exception)
            {
                txt_remaining.Text = string.Empty;
            }
        }

        private void txt_maountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_remaining.Text = (Convert.ToDouble(txt_grandtotal.Text) - Convert.ToDouble(txt_maountPaid.Text)).ToString(); 
            }
            catch (Exception)
            {
                txt_remaining.Text = txt_grandtotal.Text;
            }
        }

      

       

        private void chk_Existing_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Existing.Checked==true)
            {
                txt_Customer.Enabled = false;
                cmb_PerCust.Enabled = true;
            }
            else
            {
                txt_Customer.Enabled = true;
                cmb_PerCust.Enabled = false;
            }
        }
        double TotalBil=0.0f,amountrecv=0.0f,bakaya=0.0f;
        List<Sale> obj_globalSales = new List<Sale>();
        private void btn_clear_Click(object sender, EventArgs e)
        {

            try
            {
               
                using (var context = new POS_dbEntities())
                {
                    List<Sale> printList = new List<Sale>();
                    var invoice = obj_helper.GetLastSaleInvoice();
                    int index = 0;
                    foreach (DataGridViewRow item in dgv_sales.Rows)
                    {

                        #region Dgv Loop
                        if (item.Index != dgv_sales.NewRowIndex )
                        {
                            var prodName = item.Cells[0].Value.ToString();
                            var subCatName = item.Cells[2].Value.ToString();
                            var prodID = obj_helper.GetProductIDFromName(prodName);
                            var SubcatIDD = (from c in context.Products
                                             where c.Name==prodName
                                             select c.Product_Sub_Category_FK).SingleOrDefault();
                            var subCatID = SubcatIDD;
                            var obj_sales = new Sale();
                            if (chk_Existing.Checked == true || cmb_Payment.Text == "Credit")
                            {
                                obj_sales.Customer_Name = cmb_PerCust.Text;
                            }
                            else
                            {
                                obj_sales.Customer_Name = txt_Customer.Text;
                            }
                           
                            obj_sales.Date = dtm_date.Value.Date;
                            var disocunt = item.Cells[5].Value;
                            if (disocunt == null)
                            {
                                obj_sales.Discount = 0;
                            }
                            else
                            {
                                obj_sales.Discount = Convert.ToDouble(disocunt);
                            }
                            obj_sales.Invoice = invoice;
                            var misc = txt_discount.Text;
                            if (misc == string.Empty)
                            {
                                obj_sales.Misc = 0;
                            }
                            else
                            {
                                obj_sales.Misc = Convert.ToDouble(misc);
                            }
                            obj_sales.Product_FK = prodID;
                            obj_sales.Quantity = Convert.ToInt32(item.Cells[4].Value.ToString());
                            obj_sales.Total = Convert.ToDouble(item.Cells[6].Value.ToString());
                            obj_sales.Unit_Price = Convert.ToDouble(item.Cells[3].Value.ToString());
                           
                            obj_sales.User_FK = Login.userID;
                            obj_sales.Supplier_FK = obj_helper.GetSupplierIDFromName("Atech");
                            obj_sales.PaymentMethod = cmb_Payment.Text;
                            obj_sales.Description = rxtdsc.Text;

                            var stock = obj_helper.GetProductStock(obj_sales.Product_FK);
                            if (stock == null)
                            {
                                MessageBox.Show("You haven't Purchased This \n" + obj_helper.GetProductNameFromID(obj_sales.Product_FK), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (stock.Quantity == 0)
                            {
                                MessageBox.Show("Stock For \n" + obj_helper.GetProductNameFromID(obj_sales.Product_FK) + " \n is Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                context.Sales.Add(obj_sales);
                                printList.Add(obj_sales);
                                #region Stock
                                stock.Quantity -= obj_sales.Quantity;
                                context.Entry(stock).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();
                                #endregion
                            }
                            index++;
                        }
                        else if(index==0)
                        {
                            MessageBox.Show("Plesase Select Any Item To Sale", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        #endregion

                    }
                    DialogResult obj_dialogue = MessageBox.Show("Do You Confirm This Sales", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (obj_dialogue == DialogResult.Yes)
                    {
                        #region Cash
                        if (cmb_Payment.Text == "Cash")
                        {
                            if (Convert.ToDouble(txt_maountPaid.Text) == Convert.ToDouble(txt_grandtotal.Text))
                            {
                                var obj_cash = new Cash();
                                obj_cash.Credit = 0;
                                obj_cash.Debit = Convert.ToDouble(txt_grandtotal.Text);
                                obj_cash.Date = dtm_date.Value.Date;
                                obj_cash.Description = "Sale";
                                var balance = obj_helper.GetCashLastBalance();
                                obj_cash.Balance = balance + obj_cash.Debit;
                                context.Cashes.Add(obj_cash);
                            }
                            else if (Convert.ToDouble(txt_maountPaid.Text) > Convert.ToDouble(txt_grandtotal.Text))
                            {
                                MessageBox.Show("Amount is Exceeding than Total Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else if (Convert.ToDouble(txt_maountPaid.Text) < Convert.ToDouble(txt_grandtotal.Text))
                            {
                                MessageBox.Show("Amount is Lower than Total Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        #endregion

                        #region Bank
                        else if (cmb_Payment.Text == "Bank")
                        {
                            if (Convert.ToDouble(txt_maountPaid.Text) == Convert.ToDouble(txt_grandtotal.Text))
                            {
                                var bank = cmb_banks.Text;
                                var bankID = obj_helper.GetBankIdFromAccount(bank);
                                var obj_bank = new BankRecord();
                                obj_bank.Date = dtm_date.Value.Date;
                                obj_bank.Bank_FK = bankID;
                                obj_bank.Credit = 0;
                                obj_bank.Debit = Convert.ToDouble(txt_grandtotal.Text);
                                obj_bank.Description = "Sale";
                                var balance = obj_helper.GetBankLastBalance();
                                obj_bank.Balance = balance + obj_bank.Debit;
                                obj_bank.User_FK = Login.userID;
                                context.BankRecords.Add(obj_bank);
                            }
                            else if (Convert.ToDouble(txt_maountPaid.Text) > Convert.ToDouble(txt_grandtotal.Text))
                            {
                                MessageBox.Show("Amount is Exceeding than Total Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else if (Convert.ToDouble(txt_maountPaid.Text) < Convert.ToDouble(txt_grandtotal.Text))
                            {
                                MessageBox.Show("Amount is Lower than Total Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        #endregion

                        #region Credit
                        else if (cmb_Payment.Text == "Credit")
                        {
                            if (Convert.ToDouble(txt_maountPaid.Text) == 0)
                            {
                                var customerName = cmb_PerCust.Text;
                                var customerID = obj_helper.GetCustomerID(customerName);
                                var customerDue = obj_helper.GetCustomerDues(customerID);
                                if (customerDue == null)
                                {
                                    customerDue = new CustomerDue();
                                    customerDue.Amount = Convert.ToDouble(txt_grandtotal.Text);
                                    customerDue.Customer_FK = customerID;
                                    context.CustomerDues.Add(customerDue);
                                }
                                else
                                {
                                    customerDue.Amount += Convert.ToDouble(txt_grandtotal.Text);
                                    context.Entry(customerDue).State = System.Data.Entity.EntityState.Modified;
                                }
                            }
                            else if (Convert.ToDouble(txt_maountPaid.Text) > 0 && Convert.ToDouble(txt_maountPaid.Text) < Convert.ToDouble(txt_grandtotal.Text))
                            {
                                var obj_cash = new Cash();
                                obj_cash.Credit = 0;
                                obj_cash.Debit = Convert.ToDouble(txt_maountPaid.Text);
                                obj_cash.Date = dtm_date.Value.Date;
                                obj_cash.Description = "Sale";
                                context.Cashes.Add(obj_cash);
                                var customerName = cmb_PerCust.Text;
                                var customerID = obj_helper.GetCustomerID(customerName);
                                var customerDue = obj_helper.GetCustomerDues(customerID);
                                if (customerDue == null)
                                {
                                    customerDue = new CustomerDue();
                                    customerDue.Amount = Convert.ToDouble(txt_remaining.Text);
                                    customerDue.Customer_FK = customerID;
                                    context.CustomerDues.Add(customerDue);
                                }
                                else
                                {
                                    customerDue.Amount += Convert.ToDouble(txt_remaining.Text);
                                    context.Entry(customerDue).State = System.Data.Entity.EntityState.Modified;
                                }
                            }
                        }
                        #endregion
                        context.SaveChanges();
                        obj_globalSales = printList;
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AllClear();
            rxtdsc.Clear();
        }

       

        private void dgv_sales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgv_sales.CurrentCell.ColumnIndex==0)
                {
                    TextBox prodname = e.Control as TextBox;
                    if (prodname!=null)
                    {
                        prodname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodname.AutoCompleteCustomSource = ClientListDropDown();
                        prodname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (dgv_sales.CurrentCell.ColumnIndex==7)
                {
                    TextBox prodname = e.Control as TextBox;
                    if (prodname != null)
                    {
                        prodname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodname.AutoCompleteCustomSource = BatchNoDropDown();
                        prodname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }

                }
                else
                {
                    TextBox prodname = e.Control as TextBox;
                    if (prodname != null)
                    {
                        prodname.AutoCompleteMode = AutoCompleteMode.None;
                       
                    }

                }

            }
            catch (Exception)
            {

               
            }
        }

        private void txt_recvamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TotalBil = Convert.ToDouble(txt_grandtotal.Text);
                amountrecv = Convert.ToDouble(txt_recvamount.Text);
                bakaya = TotalBil - amountrecv;
                txt_bakaya.Text = bakaya.ToString();

            }
            catch (Exception)
            {
              txt_bakaya.Text = string.Empty;
            }
        }

        private void frm_Sales_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var obj_form = new frm_Sales();
            obj_form.Size = this.Size;
            obj_form.Show();
        }

        public AutoCompleteStringCollection ClientListDropDown()
        {
            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
            try
            {
                using (var context=new POS_dbEntities())
                {
                    var query = (from c in context.Products
                                 select c.Name).ToList();
                    foreach (var item in query)
                    {
                        asc.Add(item);
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            return asc;
        }
        public AutoCompleteStringCollection BatchNoDropDown()
        {
            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
            try
            {
                using (var context = new POS_dbEntities())
                {

                    foreach (var item in BatchNoList)
                    {
                        asc.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return asc;
        }
    }
}
