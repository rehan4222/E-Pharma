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
    public partial class frm_ProfitLoss : Form
    {
        HelperClass obj_helper = new HelperClass();
        List<rpt_ProfitLoss> Mydata = new List<rpt_ProfitLoss>();
        public frm_ProfitLoss()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    double exp = 0.0f, prof = 0.0f, result = 0.0f;
                    var expense = (from c in context.Expenses
                                   where c.Date >= dtp_From.Value.Date
                                          && c.Date <= dtp_To.Value.Date
                                   select c.Amount).ToList();
                    exp = expense.Sum();
                    var Sales = (from c in context.Sales
                                 where c.Date >= dtp_From.Value.Date
                                        && c.Date <= dtp_To.Value.Date
                                        select c).ToList();
                    foreach (var item in Sales)
                    {
                        var productName = obj_helper.GetProductNameFromID(item.Product_FK);
                        var qty = item.Quantity;
                        var purchaseCost = (from c in context.Products
                                            where c.Product_ID == item.Product_FK
                                            select c.Purchase_Cost).SingleOrDefault();
                        var totpurchase = purchaseCost * qty;
                        var salecost = item.Unit_Price;
                        var totsale = salecost * qty;
                        var profit = totsale - totpurchase;
                        var obj_profit = new rpt_ProfitLoss();
                        obj_profit.Date = item.Date.ToShortDateString();
                        obj_profit.Product = productName;
                        obj_profit.Profit = profit;
                        prof += profit;
                        obj_profit.Quantity = qty;
                        obj_profit.TotalPurchase = totpurchase;
                        obj_profit.TotalSale = totsale;
                        context.rpt_ProfitLoss.Add(obj_profit);
                        context.SaveChanges();
                    }
               
                var finalDataSource = (from c in context.rpt_ProfitLoss

                                       select c).ToList();
                    result = prof - exp;
                    var obj_crystal = new CrystalReportProfitLoss();
                    obj_crystal.SetDataSource(finalDataSource);
                    obj_crystal.SetParameterValue("pExpense",exp);
                    obj_crystal.SetParameterValue("pProfit", result);
                    crystalReportViewer1.ReportSource = obj_crystal;
                    context.rpt_ProfitLoss.RemoveRange(finalDataSource);
                    context.SaveChanges();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
    }
}
