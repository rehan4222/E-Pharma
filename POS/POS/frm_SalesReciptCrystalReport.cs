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
    public partial class frm_SalesReciptCrystalReport: Form
    {
        HelperClass obj_helper = new HelperClass();
        List<Sale> _PrintData = new List<Sale>();
        public frm_SalesReciptCrystalReport()
        {
            InitializeComponent();
        }
        double totalamount = 0.0f,totalamountwarranty=0.0f;
        public frm_SalesReciptCrystalReport(List<Sale>PrintData)
        {
            InitializeComponent();
            _PrintData = PrintData;
            using (var context = new POS_dbEntities())
            {
                foreach (var item in _PrintData)
                {

                    var obj_rptsale = new rpt_Sale();
                    obj_rptsale.Date = item.Date.ToShortDateString();
                    obj_rptsale.Product = obj_helper.GetProductNameFromID(item.Product_FK);
                    obj_rptsale.Quantity = item.Quantity;
                    obj_rptsale.Discount = item.Discount;
                    obj_rptsale.Total = item.Total;
                    totalamount += obj_rptsale.Total;
                    obj_rptsale.UnitPrice = item.Unit_Price;
                   
                    context.rpt_Sale.Add(obj_rptsale);
                    context.SaveChanges();

                }
                var data = (from c in context.rpt_Sale
                            select c).ToList();


                var obj = new CrystalReportSalesRecpt();
                obj.SetDataSource(data);
                obj.SetParameterValue("pInvoice", _PrintData[0].Invoice);
                obj.SetParameterValue("pCustomer", _PrintData[0].Customer_Name);
                obj.SetParameterValue("pDate", _PrintData[0].Date);
                obj.SetParameterValue("pMisc", _PrintData[0].Misc);
                obj.SetParameterValue("pTotal", totalamount);
                crystalReportViewer1.ReportSource = obj;
                context.rpt_Sale.RemoveRange(data);
                context.SaveChanges();


            }
        }
        public frm_SalesReciptCrystalReport(List<Sale> PrintData,bool a)
        {
            InitializeComponent();
            _PrintData = PrintData;
            using (var context = new POS_dbEntities())
            {
                foreach (var item in _PrintData)
                {

                    var obj_rptsale = new rpt_Sale();
                    obj_rptsale.Date = item.Date.ToShortDateString();
                    obj_rptsale.Product = obj_helper.GetProductNameFromID(item.Product_FK);
                    obj_rptsale.Quantity = item.Quantity;
                    obj_rptsale.Discount = item.Discount;
                    obj_rptsale.Total = item.Total;
                    totalamountwarranty += obj_rptsale.Total;
                    obj_rptsale.UnitPrice = item.Unit_Price;
                    obj_rptsale.Customer = "";
                    context.rpt_Sale.Add(obj_rptsale);
                    context.SaveChanges();

                }
                var data = (from c in context.rpt_Sale
                            select c).ToList();


                var obj = new CrystalReportSalesrecptwarranty();
                obj.SetDataSource(data);
                obj.SetParameterValue("pInvoice", _PrintData[0].Invoice);
                obj.SetParameterValue("pCustomer", _PrintData[0].Customer_Name);
                obj.SetParameterValue("pDate", _PrintData[0].Date);
                obj.SetParameterValue("pMisc", _PrintData[0].Misc);
                obj.SetParameterValue("pTotal", totalamountwarranty);
                crystalReportViewer1.ReportSource = obj;
                context.rpt_Sale.RemoveRange(data);
                context.SaveChanges();


            }
        }
        public frm_SalesReciptCrystalReport(List<Sale> PrintData, int a)
        {
            InitializeComponent();
            _PrintData = PrintData;
            using (var context = new POS_dbEntities())
            {
                foreach (var item in _PrintData)
                {

                    var obj_rptsale = new rpt_Sale();
                    obj_rptsale.Date = item.Date.ToShortDateString();
                    obj_rptsale.Product = obj_helper.GetProductNameFromID(item.Product_FK);
                    obj_rptsale.Quantity = item.Quantity;
                    obj_rptsale.Discount = item.Discount;
                    obj_rptsale.Total = item.Total;
                    obj_rptsale.UnitPrice = item.Unit_Price;
                    obj_rptsale.Customer = "";
                    context.rpt_Sale.Add(obj_rptsale);
                    context.SaveChanges();

                }
                var data = (from c in context.rpt_Sale
                            select c).ToList();


                var obj = new CrystalReportDeliveryChallan();
                obj.SetDataSource(data);
                obj.SetParameterValue("pInvoice", _PrintData[0].Invoice);
                obj.SetParameterValue("pCustomer", _PrintData[0].Customer_Name);
                obj.SetParameterValue("pDate", _PrintData[0].Date);
              
                crystalReportViewer1.ReportSource = obj;
                context.rpt_Sale.RemoveRange(data);
                context.SaveChanges();


            }
        }

        private void frm_SalesReciptCrystalReport_Load(object sender, EventArgs e)
        {
           
        }
    }
}
