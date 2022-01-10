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
    public partial class frm_profitlossfilter : Form
    {
        public frm_profitlossfilter()
        {
            InitializeComponent();
        }
        
        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context=new POS_dbEntities())
                {
                    double sales = 0.0f, purchases = 0.0f, exp = 0.0f;


                    var TotalSales = (from c in context.Sales
                                     where c.Date >= dtm_From.Value.Date && c.Date <= dtm_To.Value.Date
                                     select c.Total).ToList();
                    foreach (var item in TotalSales)
                    {
                        sales += item;
                    }
                     var TotalPurchases = (from c in context.Purchases
                                      where c.Date >= dtm_From.Value.Date && c.Date <= dtm_To.Value.Date
                                      select c.Total).ToList();

                    foreach (var item in TotalPurchases)
                    {
                        purchases += item;
                    }

                    var Expenses = (from c in context.Expenses
                                    where c.Date >= dtm_From.Value.Date && c.Date <= dtm_To.Value.Date
                                    select c.Amount).ToList();
                    foreach (var item in Expenses)
                    {
                        exp += item;
                    }
                    
                    frm_RealProfitLoss obj_profitloss = new frm_RealProfitLoss(sales,purchases,exp);
                    obj_profitloss.Show();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
