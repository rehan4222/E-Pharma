using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
namespace POS
{
    public partial class mainform : Form
    {
        private Form form;
        public mainform()
        {
            InitializeComponent();
        }
        private void addSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form!=null)
                {
                    form.Dispose();
                }
                form = new frm_Suppliers();
               
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form!=null)
                {
                    form.Dispose();
                }
                form = new frm_Products();
               
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Sales();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Expenses();
                
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new BankAddition();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_SaleReturn();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Purchases();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_PurchaseReturn();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_AddUsers();
                
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Stock();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Sales();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void assetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new FixAssets();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void recieivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void editPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_PurchaseReturn();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_PayementEdit();
               
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editRecievingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Recievings();
               
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Customers();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Suppliers();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainform_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_ProductCategories();
               
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Stock();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new BankAddition();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fixAssestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new FixAssets();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Expenses();
                
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_SearchExpensecs();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_SaleReport();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_PurchaseReport();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cashREportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_CashReport();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bankReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_BankReport();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
               // form.MdiParent = this;
                form = new frm_ProductEdit();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    string dbname = context.Database.Connection.Database;
                    string sqlCommand = @"BACKUP DATABASE [{0}] TO  DISK = N'{1}'";
                    context.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, dbname, "E:\\backup.bak"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void payementReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_PaymentsReport();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_PaymentLedger();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        HelperClass obj_helper = new HelperClass();
        private void timer_main_Tick(object sender, EventArgs e)
        {
            try
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.stock;
                using (var context = new POS_dbEntities())
                {

                    var ifstock = (from c in context.Product_Stocks
                                   select c.Product_FK).ToList();

                    foreach (var item in ifstock)
                    {
                       
                        var realstock = (from c in context.Product_Stocks
                                         where c.Quantity <= 500
                                         select c.Product_FK).SingleOrDefault();
                        popup.TitleText = "Stock Alert";
                        popup.ContentText = "Stock for " + obj_helper.GetProductNameFromID(item) + "  is in Dangerous Mode. Please Purchase it";
                        popup.AnimationDuration = 500;
                        popup.Popup();
                    }
                }

            }
            catch (Exception)
            {
                
            }
          
           
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_rec();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_Payments();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void profitLossReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_ProfitLoss();
                form.WindowState = FormWindowState.Minimized;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void incomeStatementProfitLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (form != null)
                {
                    form.Dispose();
                }
                form = new frm_profitlossfilter();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
