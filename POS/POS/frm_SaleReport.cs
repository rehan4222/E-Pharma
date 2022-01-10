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
    public partial class frm_SaleReport : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_SaleReport()
        {
            InitializeComponent();
            cmb_Products.DataSource = obj_helper.GetAllProductName();
            cmb_Products.SelectedItem = null;
        }
        private void chk_Products_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Products.Checked==true)
                {
                    cmb_Products.Enabled = false;
                }
                else
                {
                    cmb_Products.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context= new POS_dbEntities())
                {
                    #region All Prods
                    if (chk_Products.Checked == true)
                    {
                        var saleData = (from c in context.Sales
                                        join d in context.Products
                                        on c.Product_FK equals d.Product_ID
                                        where c.Date >= dtp_From.Value.Date
                                        && c.Date <= dtp_To.Value.Date
                                        select new
                                        {
                                            c.Customer_Name,
                                            c.Date,
                                            c.Discount,
                                            c.Quantity,
                                            c.Total,
                                            c.Unit_Price,
                                            d.Name,
                                        }).ToList();
                        foreach (var item in saleData)
                        {
                            var obj_rpt = new rpt_Sale();
                            obj_rpt.Customer = item.Customer_Name;
                            obj_rpt.Date = item.Date.ToShortDateString();
                            obj_rpt.Discount = item.Discount;
                            obj_rpt.Product = item.Name;
                            obj_rpt.Quantity = item.Quantity;
                            obj_rpt.Total = item.Total;
                            obj_rpt.UnitPrice = item.Unit_Price;
                            context.rpt_Sale.Add(obj_rpt);
                            context.SaveChanges();
                        }
                        var dataSource = (from c in context.rpt_Sale
                                          select c).ToList();
                        CrystalReportSale obj_crystal = new CrystalReportSale();
                        obj_crystal.SetDataSource(dataSource);
                        CrystalDecisions.CrystalReports.Engine.TextObject txt;
                        txt = obj_crystal.ReportDefinition.ReportObjects["txtHeader"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        txt.Text = "This Sales Report is From " + dtp_From.Value.Date.ToShortDateString() + " To "
                            + dtp_To.Value.Date.ToShortDateString() + "\n Zahoor Medicose";
                        crystalReportViewer1.ReportSource = obj_crystal;
                        var deleteData = (from c in context.rpt_Sale
                                          select c).ToList();
                        context.rpt_Sale.RemoveRange(deleteData);
                        context.SaveChanges();
                    }
                    #endregion

                    #region Specific Prod
                    else
                    {
                        var prodID = obj_helper.GetProductIDFromName(cmb_Products.Text); 
                        var saleData = (from c in context.Sales
                                        join d in context.Products
                                        on c.Product_FK equals d.Product_ID
                                        where c.Date >= dtp_From.Value.Date
                                        && c.Date <= dtp_To.Value.Date
                                        && c.Product_FK== prodID
                                        select new
                                        {
                                            c.Customer_Name,
                                            c.Date,
                                            c.Discount,
                                            c.Quantity,
                                            c.Total,
                                            c.Unit_Price,
                                            d.Name,
                                        }).ToList();
                        foreach (var item in saleData)
                        {
                            var obj_rpt = new rpt_Sale();
                            obj_rpt.Customer = item.Customer_Name;
                            obj_rpt.Date = item.Date.ToShortDateString();
                            obj_rpt.Discount = item.Discount;
                            obj_rpt.Product = item.Name;
                            obj_rpt.Quantity = item.Quantity;
                            obj_rpt.Total = item.Total;
                            obj_rpt.UnitPrice = item.Unit_Price;
                            context.rpt_Sale.Add(obj_rpt);
                            context.SaveChanges();
                        }
                        var dataSource = (from c in context.rpt_Sale
                                          select c).ToList();
                        CrystalReportSale obj_crystal = new CrystalReportSale();
                        obj_crystal.SetDataSource(dataSource);
                        CrystalDecisions.CrystalReports.Engine.TextObject txt;
                        txt = obj_crystal.ReportDefinition.ReportObjects["txtHeader"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        txt.Text = "This Sales Report is From " + dtp_From.Value.Date.ToShortDateString() + " To "
                            + dtp_To.Value.Date.ToShortDateString() + "\n Zahoor Medicose";
                        crystalReportViewer1.ReportSource = obj_crystal;
                        var deleteData = (from c in context.rpt_Sale
                                          select c).ToList();
                        context.rpt_Sale.RemoveRange(deleteData);
                        context.SaveChanges();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
