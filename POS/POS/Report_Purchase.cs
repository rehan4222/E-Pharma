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
    public partial class Report_Purchase : Form
    {
        HelperClass obj_helper = new HelperClass();
        public Report_Purchase()
        {
            InitializeComponent();
            using (var context=new POS_dbEntities())
            {
                var obj = (from c in context.Suppliers
                           select c.Name).ToList();
                cmb_Type.DataSource = obj;
            }
        }

        private void btn_loads_Click(object sender, EventArgs e)
        {
            using (var context=new POS_dbEntities())
            {
                var supplierid = obj_helper.GetSupplierIDFromName(cmb_Type.Text);
                var result = (from c in context.Purchases
                              where c.Supplier_FK == supplierid
                              select c).ToList();
                foreach (var item in result)
                {
                    
                }
                //var suppliername = obj_helper.GetSupplierNameFromID(result);
            }
        }
    }
}
