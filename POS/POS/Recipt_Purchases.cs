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
    public partial class Recipt_Purchases : Form
    {
        HelperClass obj_helper = new HelperClass();
        public Recipt_Purchases()
        {
            InitializeComponent();
        }
        public Recipt_Purchases(List<Purchase> PrintData)
        {
            InitializeComponent();
            label3.Text = PrintData[0].ID.ToString();
            lbl_Invoice.Text = PrintData[0].Invoice.ToString();
            //lbl_Salesman.Text=obj_help
            lbl_date.Text = PrintData[0].Date.ToShortDateString();
            lbl_suppliername.Text = obj_helper.GetSupplierNameFromID(PrintData[0].Supplier_FK).ToString();
            //int index = 1;
            double totalbill = 0.0f;
            foreach (var item in PrintData)
            {
                dgv_saleRecipt.Rows.Add(item.Date, obj_helper.GetProductNameFromID(item.Product_FK), item.Description, item.Quantity,item.Total);


                totalbill += item.Total;
                lbl_GrandTotal.Text = totalbill.ToString();
            }
        }
    }
}
