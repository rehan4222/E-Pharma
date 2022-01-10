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
    public partial class frm_Stock : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_Stock()
        {
            InitializeComponent();
            loadDgv();
           
        }
      

      
        void loadDgv()
        {
            using (var context = new POS_dbEntities())
            {
                var stockData = (from c in context.Product_Stocks
                                 join d in context.Products
                                 on c.Product_FK equals d.Product_ID
                                 join f in context.Suppliers
                                 on c.Supplier_FK equals f.ID
                                 select new
                                 {
                                     c.Quantity,
                                     d.Name,
                                     supplierName = f.Name,
                                     c.Product_FK,
                                 }).ToList();
                foreach (var item in stockData)
                {
                    dgv_Stock.Rows.Add(item.supplierName, item.Name, item.Quantity, obj_helper.Totakworthstock(item.Quantity, item.Product_FK));
                }
                lbl_totaccstock.Text = obj_helper.GetSumAccessoriestock().ToString();
                lbl_totmobstock.Text = obj_helper.GetSumMobilestock().ToString();
                label8.Text = obj_helper.GetAccessoriesWorth().ToString();
                label6.Text = obj_helper.GetmobileWorth().ToString();
            }
        }
       

        
    }
}
