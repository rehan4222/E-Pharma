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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
            //f = new Demo_Screen();
            //f.TopLevel = false;
            //this.panel_main.Controls.Add(f);
            //f.Dock = DockStyle.Fill;
            //f.Show();


        }
        private Form f;
        private void addSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //f.Dispose();
                f = new frm_Suppliers();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                //f.Dispose();
                f = new frm_Products();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_Sales();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_Expenses();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new BankAddition();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_SaleReturn();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_Purchases();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_PurchaseReturn();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_AddUsers();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new BankAddition();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f.Dispose();
                f = new frm_Purchases();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f.Dispose();
                f = new frm_Sales();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //f.Dispose();
                f = new frm_Payments();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void assetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f.Dispose();
                f = new FixAssets();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void recieivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f.Dispose();
                f = new frm_rec();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                f.Dispose();
                f = new frm_PurchaseReturn();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_PayementEdit();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_Recievings();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                //f.Dispose();
                f = new frm_Customers();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                //f.Dispose();
                f = new frm_Suppliers();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_ProductCategories();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_Stock();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new BankAddition();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new FixAssets();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_Expenses();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_EditExpense();
                //f.TopLevel = false;
                //this.panel_main.Controls.Add(f);
                //f.Dock = DockStyle.Fill;
                f.Show();
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
                f.Dispose();
                f = new frm_SaleReport();
                f.TopLevel = false;
                this.panel_main.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
