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
    public partial class frm_PurchaseReport : Form
    {
        public frm_PurchaseReport()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context= new POS_dbEntities())
                {
                    var purchaseData = (from c in context.Purchases
                                        join d in context.Products
                                        on c.Product_FK equals d.Product_ID
                                        where c.Date >= dtp_From.Value.Date
                                        && c.Date <= dtp_To.Value.Date
                                        select new
                                        {
                                            d.Name,
                                            c.Date,
                                            c.Invoice,
                                            c.Quantity,
                                            c.Total,
                                            d.Purchase_Cost,
                                        }).ToList();
                    foreach (var item in purchaseData)
                    {
                        var obj_rpt = new rpt_Purchases();
                        obj_rpt.Total = item.Total;
                        obj_rpt.Quantity = item.Quantity;
                        obj_rpt.ProdName = item.Name;
                        obj_rpt.Invoice = item.Invoice;
                        obj_rpt.Date = item.Date.ToShortDateString();
                        obj_rpt.Cost = item.Purchase_Cost;
                        context.rpt_Purchases.Add(obj_rpt);
                        context.SaveChanges();
                    }
                    var reportData = (from c in context.rpt_Purchases
                                      select c).ToList();
                    CrystalReportPurchases obj_report = new CrystalReportPurchases();
                    CrystalDecisions.CrystalReports.Engine.TextObject txt;
                    txt = obj_report.ReportDefinition.ReportObjects["txtHeader"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    txt.Text = "This Purchase Report is From " + dtp_From.Value.Date.ToShortDateString() + " To "
                        + dtp_To.Value.Date.ToShortDateString() + "\n Zahoor Medicose";
                    obj_report.SetDataSource(reportData);
                    crystalReportViewer1.ReportSource = obj_report;
                    context.rpt_Purchases.RemoveRange(reportData);
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
