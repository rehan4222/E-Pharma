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
    public partial class frm_PurchaseReturn : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_PurchaseReturn()
        {
            InitializeComponent();
        }

        private void frm_PurchaseReturn_Load(object sender, EventArgs e)
        {

        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Invoice.Text!=string.Empty)
                {
                    FillDgv();
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
        void FillDgv()
        {
            dgv_sales.Rows.Clear();
            var purchase = obj_helper.GetPurchaseDetailFromInvoice(Convert.ToInt32(txt_Invoice.Text));
            if (purchase==null)
            {
                MessageBox.Show("There is no Purchase against this Invoice");
            }
            else
            {
                foreach (var item in purchase)
                {
                    var prod_name = obj_helper.GetProductNameFromID(item.Product_FK);
                    var supplierName = obj_helper.GetSupplierNameFromID(item.Supplier_FK);
                    var subCatID = obj_helper.GetSubCategoryIdFromProdId(item.Product_FK);
                    var subCatName = obj_helper.GetSubCategoryNameFromID(subCatID);
                    var catID = obj_helper.GetCatIDFromSubCatID(subCatID);
                    var catName = obj_helper.GetCategoryNameFromID(catID);
                    var unitPrice = obj_helper.GetPurchaseCostFromCatID(item.Product_FK);
                    dgv_sales.Rows.Add(item.ID, item.Date.ToShortDateString(), supplierName, prod_name, catName, subCatName, unitPrice, item.Quantity, item.Total);
                }

            }
          
        }
        private void dgv_sales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex== dgv_sales.NewRowIndex)
            {
                return;
            }
            else
            {
                if (e.ColumnIndex==9)
                {
                    using (var context= new POS_dbEntities())
                    {
                        var purchaseID = Convert.ToInt32(dgv_sales.Rows[e.RowIndex].Cells[0].Value.ToString());
                        var purchase = (from c in context.Purchases
                                        where c.ID== purchaseID
                                        select c).SingleOrDefault();
                        var qty = Convert.ToInt32(dgv_sales.Rows[e.RowIndex].Cells[7].Value.ToString());
                        var prod = obj_helper.GetProductDetails(purchase.Product_FK);
                        if (qty == purchase.Quantity)
                        {
                            #region Stcok Maintenance
                            var prodStock = obj_helper.GetProductStock(purchase.Product_FK);
                            prodStock.Quantity -= purchase.Quantity;
                            DialogResult obj_dialogue = MessageBox.Show("Do You Confirm Return of This Purchase", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (obj_dialogue == DialogResult.Yes)
                            {
                                context.Entry(prodStock).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();
                                context.Purchases.Remove(purchase);
                                context.SaveChanges();
                                var supplierDue = obj_helper.GetSupplierDue(purchase.Supplier_FK);
                                supplierDue.Amount -= purchase.Total;
                                context.Entry(supplierDue).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();
                                MessageBox.Show("Purchase has been returned", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FillDgv();
                            }
                            else
                            {
                                MessageBox.Show("Operation Aborted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            #endregion
                        }
                        else if (qty < purchase.Quantity)
                        {
                            var difference = purchase.Quantity - qty;

                            #region Stcok Maintenance
                            var prodStock = obj_helper.GetProductStock(purchase.Product_FK);
                            prodStock.Quantity -= difference;
                            DialogResult obj_dialogue = MessageBox.Show("Do You Confirm Partial Return of This Purchase", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (obj_dialogue == DialogResult.Yes)
                            {
                                context.Entry(prodStock).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();
                                purchase.Quantity =difference;
                                purchase.Total=qty* Convert.ToDouble(dgv_sales.Rows[e.RowIndex].Cells[7].Value.ToString());
                                context.Entry(purchase).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();
                                var purchaseCost = prod.Purchase_Cost;
                                var returnAmount = purchaseCost * difference;
                                var supplierDue = obj_helper.GetSupplierDue(purchase.Supplier_FK);
                                supplierDue.Amount -= returnAmount;
                                context.Entry(supplierDue).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();
                                MessageBox.Show("Purchase has been returned", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FillDgv();
                            }
                            else
                            {
                                MessageBox.Show("Operation Aborted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            #endregion
                        }
                    }
                }
            }
        }

        private void txt_Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                try
                {
                    if (txt_Invoice.Text != string.Empty)
                    {
                        FillDgv();
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
        }
        
    }
}
