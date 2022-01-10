using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS{
    public partial class frm_Purchases : Form
    {
        HelperClass obj_helper = new HelperClass();
        
        double grandTotal = 0.0f;
        public frm_Purchases()
        {
            InitializeComponent();
           
            cmb_Supplier.DataSource = obj_helper.GetAllSupplierNames();
            cmb_Supplier.SelectedItem = null;
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
                    else if (control is RichTextBox)

                    {
                        (control as RichTextBox).Clear();
                    }
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void btn_Purchases_Click(object sender, EventArgs e)
        {
            try
            {

                using (var context = new POS_dbEntities())
                    {
                        #region Purchases
                        List<Purchase> printData = new List<Purchase>();
                        foreach (DataGridViewRow item in dgv_Purchases.Rows)
                        {
                            if (item.IsNewRow == false)
                            {
                                
                                    var obj_Purchase = new Purchase();
                                    obj_Purchase.Date = dtp_Purchases.Value.Date;
                                    obj_Purchase.Description = rtxt_decs.Text;
                                    obj_Purchase.Product_FK = obj_helper.GetProductIDFromName(item.Cells[0].Value.ToString());
                                    obj_Purchase.Supplier_FK = obj_helper.GetSupplierIDFromName(cmb_Supplier.Text);
                                    obj_Purchase.Quantity = Convert.ToInt32(item.Cells[5].Value.ToString());
                                    obj_Purchase.Total = Convert.ToDouble(item.Cells[6].Value.ToString());
                                    obj_Purchase.User_FK = Login.userID;
                                  
                                    obj_Purchase.Invoice = Convert.ToInt32(txt_invoice.Text);
                                  

                                    context.Purchases.Add(obj_Purchase);
                      
                                    printData.Add(obj_Purchase);


                                    #region Stock
                                    var obj_stock = obj_helper.GetProductStock(obj_Purchase.Product_FK);
                                    if (obj_stock == null || obj_stock.Quantity<0)
                                    {
                                        obj_stock = new Product_Stock();
                                        obj_stock.Product_FK = obj_Purchase.Product_FK;
                                        obj_stock.Quantity = obj_Purchase.Quantity;
                                        context.Product_Stocks.Add(obj_stock);
                           
 
                                    }
                                    else if(obj_stock.Quantity>=0)
                                    {
                                        obj_stock.Quantity += obj_Purchase.Quantity;
                                        context.Entry(obj_stock).State = System.Data.Entity.EntityState.Modified;
                           
                                    }
                                    #endregion
                               
                            }
                           

                        }
                        DialogResult obj_dialogueResult = MessageBox.Show("Do You Confirm This Purchase?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (obj_dialogueResult == DialogResult.Yes)
                        {
                            context.SaveChanges();
                            var obj_due = obj_helper.GetSupplierDue(obj_helper.GetSupplierIDFromName(cmb_Supplier.Text));
                            #region PaymentLdgr
                            var obj_payment = new PaymentsLedger();
                            obj_payment.Amount = Convert.ToDouble(txt_Total.Text);
                            obj_payment.Date = dtp_Purchases.Value.Date;
                            var opening = obj_helper.GetPaymentLedgerLastRemaining();
                            if (opening == 0)
                            {
                                opening = obj_payment.Amount;
                            }
                            obj_payment.Openning = opening;
                            if (opening == 0)
                            {
                                obj_payment.Remaining = obj_payment.Amount;
                            }
                            else
                            {
                                obj_payment.Remaining = obj_payment.Openning + obj_payment.Amount;
                            }
                            obj_payment.Supplier_FK = obj_helper.GetSupplierIDFromName(cmb_Supplier.Text);
                            obj_payment.PaymentMethod = "Purchase";
                            obj_payment.Description = rtxt_decs.Text;
                            obj_payment.Invoice = Convert.ToInt32(txt_invoice.Text);
                            obj_payment.User_FK = Login.userID;
                            context.PaymentsLedgers.Add(obj_payment);
                            context.SaveChanges();
                            #endregion
                            #region Dues
                            if (obj_due == null)
                            {
                                obj_due = new SupplierDue();
                                obj_due.Amount = Convert.ToDouble(txt_Total.Text);
                                obj_due.Supplier_FK = obj_helper.GetSupplierIDFromName(cmb_Supplier.Text);
                                context.SupplierDues.Add(obj_due);
                                context.SaveChanges();
                            }
                            else if (obj_due.Amount == 0)
                            {
                                obj_due.Amount = Convert.ToDouble(txt_Total.Text);
                                context.Entry(obj_due).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();

                            }
                            else if (obj_due.Amount > 0)
                            {
                                obj_due.Amount += Convert.ToDouble(txt_Total.Text);
                                context.Entry(obj_due).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();

                            }
                            #endregion
                            context.SaveChanges();
                            MessageBox.Show("Purchase Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            grandTotal = 0.0f;
                        }
                        #endregion


                    }
                AllClear();
                dgv_Purchases.Rows.Clear();

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

       
    
        private void dgv_Purchases_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex==dgv_Purchases.NewRowIndex)
            {
                return;
            }
            else
            {
                
                try
                {
                    using (var context=new POS_dbEntities())
                    {
                        if (e.ColumnIndex==0)
                        {
                            var prodname = dgv_Purchases.Rows[e.RowIndex].Cells[0].Value.ToString();
                            var query = (from c in context.Products
                                         where c.Name == prodname
                                         select c).SingleOrDefault();
                            var prodsubID = query.Product_Sub_Category_FK;
                            var CatID = obj_helper.GetCatIDFromSubCatID(prodsubID);
                            var prodsubname = obj_helper.GetSubCategoryNameFromID(prodsubID);
                            var CatName = obj_helper.GetCategoryNameFromID(CatID);
                            var unitprice = query.Purchase_Cost;
                            dgv_Purchases.Rows[e.RowIndex].Cells[1].Value = CatName;
                            dgv_Purchases.Rows[e.RowIndex].Cells[2].Value = prodsubname;
                            dgv_Purchases.Rows[e.RowIndex].Cells[3].Value = unitprice;


                        }

                    }
                    
                    
                   

                }
                catch (Exception)
                {
                    

                }
                if (e.ColumnIndex==5)
                {
                    try
                    {
                        var qty = Convert.ToDouble(dgv_Purchases.Rows[e.RowIndex].Cells[5].Value.ToString());
                        var unitPrice = Convert.ToDouble(dgv_Purchases.Rows[e.RowIndex].Cells[3].Value.ToString());
                        var total = qty * unitPrice;
                        dgv_Purchases.Rows[e.RowIndex].Cells[6].Value = total.ToString();
                    }
                    catch (Exception)
                    {

                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    try
                    {
                        grandTotal += Convert.ToDouble(dgv_Purchases.Rows[e.RowIndex].Cells[6].Value.ToString());
                        txt_Total.Text = grandTotal.ToString();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        public AutoCompleteStringCollection ProductListDropDown()
        {
            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
            try
            {
                using (var context = new POS_dbEntities())
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

        private void dgv_Purchases_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgv_Purchases.CurrentCell.ColumnIndex == 0)
                {
                    TextBox prodname = e.Control as TextBox;
                    if (prodname != null)
                    {
                        prodname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodname.AutoCompleteCustomSource = ProductListDropDown();
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
    }
}
