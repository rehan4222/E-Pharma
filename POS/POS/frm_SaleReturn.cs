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
    public partial class frm_SaleReturn : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_SaleReturn()
        {
            InitializeComponent();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if (txt_Invoice.Text!=string.Empty && txt_CustomerName.Text=="")
            {
                LoadDgvInvoice();
            }
            else if (txt_Invoice.Text =="" && txt_CustomerName.Text != string.Empty)
            {
                LoadDgvName();
            }
           
            
           
        }
        private void dgv_sales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex== dgv_sales.NewRowIndex)
                {
                    return;
                }
                else
                {
                    if (e.ColumnIndex==10)
                    {
                        using (var context = new POS_dbEntities())
                        {
                            int Invoice = 0;
                            if (txt_Invoice.Text != string.Empty && txt_CustomerName.Text == "")
                            {
                                Invoice= Convert.ToInt32(txt_Invoice.Text);
                            }
                            else if (txt_Invoice.Text == "" && txt_CustomerName.Text != string.Empty)
                            {
                                Invoice = Convert.ToInt32(dgv_sales.Rows[e.RowIndex].Cells[9].Value.ToString());
                            }
                            var qty = Convert.ToInt32(dgv_sales.Rows[e.RowIndex].Cells[6].Value.ToString());
                            var prodName = dgv_sales.Rows[e.RowIndex].Cells[2].Value.ToString();
                            var prodID = obj_helper.GetProductIDFromName(prodName);
                            var sale = (from c in context.Sales
                                        where c.Invoice == Invoice
                                        && c.Product_FK == prodID
                                        select c).SingleOrDefault();
                            if (qty== sale.Quantity)
                            {
                                #region Credit
                                if (sale.PaymentMethod == "Credit")
                                {
                                    var customerID = obj_helper.GetCustomerID(sale.Customer_Name);
                                    var customerDue = obj_helper.GetCustomerDues(customerID);
                                    var prod_stock = obj_helper.GetProductStock(sale.Product_FK);
                                    prod_stock.Quantity += sale.Quantity;
                                    context.Entry(prod_stock).State = System.Data.Entity.EntityState.Modified;
                                    
                                    customerDue.Amount -= sale.Total;
                                    context.Entry(customerDue).State = System.Data.Entity.EntityState.Modified;
                                    
                                    context.Sales.Remove(sale);
                                    
                                }
                                #endregion

                                #region Cash
                                if (sale.PaymentMethod == "Cash")
                                {
                                    var prod_stock = obj_helper.GetProductStock(sale.Product_FK);
                                    prod_stock.Quantity += sale.Quantity;
                                    context.Entry(prod_stock).State = System.Data.Entity.EntityState.Modified;
                                    
                                    var obj_cash = new Cash();
                                    obj_cash.Credit = sale.Total;
                                    obj_cash.Debit = 0;
                                    obj_cash.Description = "Sale Return";
                                    obj_cash.Date = DateTime.Now.Date;
                                    context.Cashes.Add(obj_cash);
                                    
                                    context.Sales.Remove(sale);
                                }
                                #endregion

                                #region Bank
                                if (sale.PaymentMethod == "Bank")
                                {
                                    var prod_stock = obj_helper.GetProductStock(sale.Product_FK);
                                    prod_stock.Quantity += sale.Quantity;
                                    context.Entry(prod_stock).State = System.Data.Entity.EntityState.Modified;
                                    
                                    var obj_bank = new BankRecord();
                                    obj_bank.Credit = sale.Total;
                                    obj_bank.Debit = 0;
                                    obj_bank.Description = "Sale Return";
                                    obj_bank.Date = DateTime.Now.Date;
                                    context.BankRecords.Add(obj_bank);
                                    context.Sales.Remove(sale);
                                }
                                #endregion
                                 var obj_dialogue = MessageBox.Show("Do You Confirm This Sales Return", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (obj_dialogue== DialogResult.Yes)
                                {
                                    context.SaveChanges();
                                    MessageBox.Show("Sales Returned Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgv_sales.Rows.Clear();
                                }
                            }
                            else if(qty!=sale.Quantity)
                            {
                                #region Credit
                                if (sale.PaymentMethod == "Credit")
                                {
                                    var difference = sale.Quantity - qty;
                                    var prod = obj_helper.GetProductDetails(sale.Product_FK);
                                    var SaleCost = prod.Sale_Cost;
                                    var amountReturn = difference * SaleCost;
                                    var customerID = obj_helper.GetCustomerID(sale.Customer_Name);
                                    var customerDue = obj_helper.GetCustomerDues(customerID);
                                    var prod_stock = obj_helper.GetProductStock(sale.Product_FK);
                                    prod_stock.Quantity += difference;
                                    context.Entry(prod_stock).State = System.Data.Entity.EntityState.Modified;
                                    
                                    customerDue.Amount -= amountReturn;
                                    context.Entry(customerDue).State = System.Data.Entity.EntityState.Modified;
                                    
                                    sale.Quantity = difference;
                                    sale.Total = qty * Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[5].Value.ToString());
                                    context.Entry(sale).State = System.Data.Entity.EntityState.Modified;
                                    
                                }
                                #endregion

                                #region Cash
                                if (sale.PaymentMethod == "Cash")
                                {
                                    var difference = sale.Quantity - qty;
                                    var prod = obj_helper.GetProductDetails(sale.Product_FK);
                                    var purchaseCost = prod.Purchase_Cost;
                                    var amountReturn = difference * purchaseCost;
                                    var prod_stock = obj_helper.GetProductStock(sale.Product_FK);
                                    prod_stock.Quantity += difference;
                                    context.Entry(prod_stock).State = System.Data.Entity.EntityState.Modified;
                                    
                                    var obj_cash = new Cash();
                                    obj_cash.Credit = amountReturn;
                                    obj_cash.Debit = 0;
                                    obj_cash.Description = "Sale Return";
                                    obj_cash.Date = DateTime.Now.Date;
                                    context.Cashes.Add(obj_cash);
                                    sale.Quantity = qty;
                                    sale.Total = qty * purchaseCost;
                                    context.Entry(sale).State = System.Data.Entity.EntityState.Modified;
                                    
                                }
                                #endregion

                                #region Bank
                                if (sale.PaymentMethod == "Bank")
                                {
                                    var difference = sale.Quantity - qty;
                                    var prod = obj_helper.GetProductDetails(sale.Product_FK);
                                    var purchaseCost = prod.Purchase_Cost;
                                    var amountReturn = difference * purchaseCost;
                                    var prod_stock = obj_helper.GetProductStock(sale.Product_FK);
                                    prod_stock.Quantity += difference;
                                    context.Entry(prod_stock).State = System.Data.Entity.EntityState.Modified;
                                    
                                    var obj_bank = new BankRecord();
                                    obj_bank.Credit = amountReturn;
                                    obj_bank.Debit = 0;
                                    obj_bank.Description = "Sale Return";
                                    obj_bank.Date = DateTime.Now.Date;
                                    context.BankRecords.Add(obj_bank);
                                    sale.Quantity = qty;
                                    sale.Total = qty * purchaseCost;
                                    context.Entry(sale).State = System.Data.Entity.EntityState.Modified;
                                }
                                #endregion
                                var obj_dialogue = MessageBox.Show("Do You Confirm This Sales Return", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (obj_dialogue == DialogResult.Yes)
                                {
                                    context.SaveChanges();
                                    MessageBox.Show("Sales Returned Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgv_sales.Rows.Clear();
                                }
                            }
                        }
                    }
                    if (e.ColumnIndex==11)
                    {
                        using (var context=new POS_dbEntities())
                        {
                            if (txt_Invoice.Text != string.Empty && txt_CustomerName.Text == "")
                            {
                                int Invoice = Convert.ToInt32(txt_Invoice.Text);
                                var ReprintData = (from c in context.Sales
                                                   where c.Invoice == Invoice
                                                   select c).ToList();
                                frm_SalesReciptCrystalReport obj_Reprint = new frm_SalesReciptCrystalReport(ReprintData);
                               
                                
                                obj_Reprint.Show();

                            }
                            else if (txt_Invoice.Text == "" && txt_CustomerName.Text != string.Empty)
                            {
                                int Invoice = Convert.ToInt32(dgv_sales.Rows[e.RowIndex].Cells[9].Value.ToString());

                                var ReprintData = (from c in context.Sales
                                                   where c.Customer_Name == txt_CustomerName.Text && c.Invoice==Invoice
                                                   select c).ToList();
                                frm_SalesReciptCrystalReport obj_Reprint = new frm_SalesReciptCrystalReport(ReprintData);
                                
                                obj_Reprint.Show();
                            }
                           

                           

                        }
                    }
                    //if (e.ColumnIndex == 12)
                    //{
                    //    using (var context = new POS_dbEntities())
                    //    {
                    //        if (txt_Invoice.Text != string.Empty && txt_CustomerName.Text == "")
                    //        {
                    //            int Invoice = Convert.ToInt32(txt_Invoice.Text);
                    //            var ReprintData = (from c in context.Sales
                    //                               where c.Invoice == Invoice
                    //                               select c).ToList();
                    //            frm_SalesReciptCrystalReport obj_Reprint = new frm_SalesReciptCrystalReport(ReprintData,true);
                    //            obj_Reprint.WindowState = FormWindowState.Minimized;
                    //            obj_Reprint.WindowState = FormWindowState.Minimized;
                    //            obj_Reprint.Show();

                    //        }
                    //        else if (txt_Invoice.Text == "" && txt_CustomerName.Text != string.Empty)
                    //        {
                    //            int Invoice = Convert.ToInt32(dgv_sales.Rows[e.RowIndex].Cells[9].Value.ToString());

                    //            var ReprintData = (from c in context.Sales
                    //                               where c.Customer_Name == txt_CustomerName.Text && c.Invoice == Invoice
                    //                               select c).ToList();
                    //            frm_SalesReciptCrystalReport obj_Reprint = new frm_SalesReciptCrystalReport(ReprintData,true);
                    //            obj_Reprint.WindowState = FormWindowState.Minimized;
                    //            obj_Reprint.WindowState = FormWindowState.Minimized;
                    //            obj_Reprint.Show();

                    //        }
                           

                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                LoadDgvInvoice();
            }
          
        }
        void LoadDgvInvoice()
        {
            try
            {
                if (txt_Invoice.Text != string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        dgv_sales.Rows.Clear();
                        var sales = obj_helper.Getsalesdetail(Convert.ToInt32(txt_Invoice.Text));
                        if (sales == null)
                        {
                            MessageBox.Show("There is no Sale against this Invoice");
                        }
                        else
                        {
                            foreach (var item in sales)
                            {
                                var productname = obj_helper.GetProductNameFromID(item.Product_FK);
                                var productId = obj_helper.GetPrdocuctNameFormID(productname);
                                var product = obj_helper.GetPrdocuctFormID(productId);
                                var subcategory_name = obj_helper.GetSubCategoryNameFromID(product.Product_Sub_Category_FK);
                                var categoryid = obj_helper.GetCatIDFromSubCatID(product.Product_Sub_Category_FK);
                                var category_name = obj_helper.GetCategoryNameFromID(categoryid);
                                dgv_sales.Rows.Add(item.Date.ToShortDateString(), item.Customer_Name, product.Name, category_name, subcategory_name, item.Unit_Price, item.Quantity, item.Discount, item.Total,item.Invoice);
                            }

                        }

                    }

                }
                else
                {
                    MessageBox.Show("Please Enter some value");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void LoadDgvName()
        {
            try
            {
                if (txt_CustomerName.Text != string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        dgv_sales.Rows.Clear();
                        var sales = obj_helper.GetSalesDetailName(txt_CustomerName.Text);
                        if (sales == null)
                        {
                            MessageBox.Show("There is no Sale against this Customer");
                        }
                        else
                        {
                            foreach (var item in sales)
                            {
                                var productname = obj_helper.GetProductNameFromID(item.Product_FK);
                                var productId = obj_helper.GetPrdocuctNameFormID(productname);
                                var product = obj_helper.GetPrdocuctFormID(productId);
                                var subcategory_name = obj_helper.GetSubCategoryNameFromID(product.Product_Sub_Category_FK);
                                var categoryid = obj_helper.GetCatIDFromSubCatID(product.Product_Sub_Category_FK);
                                var category_name = obj_helper.GetCategoryNameFromID(categoryid);
                                dgv_sales.Rows.Add(item.Date.ToShortDateString(), item.Customer_Name, product.Name, category_name, subcategory_name, item.Unit_Price, item.Quantity, item.Discount, item.Total,item.Invoice);
                            }

                        }

                    }

                }
                else
                {
                    MessageBox.Show("Please Enter some value");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txt_CustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDgvName();
            }

        }
    }
}
