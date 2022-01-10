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
    public partial class frm_PaymentLedger : Form
    {
        public frm_PaymentLedger()
        {
            InitializeComponent();
        }
        HelperClass obj = new HelperClass();
        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    var name = obj.GetSupplierIDFromName(cmb_name.Text);
                    var dataSource = (from c in context.PaymentsLedgers
                                      where c.Date >= dtp_From.Value.Date
                                      && c.Date <= dtp_To.Value.Date || c.ID==name
                                      select new
                                      {
                                          c.Date,
                                          c.PaymentMethod,
                                          c.Invoice,
                                          c.Openning,
                                          c.Amount,
                                          c.Remaining,
                                      }).ToList();
                    var obj_crystal = new CrystalReportPayementLedger();
                    obj_crystal.SetDataSource(dataSource);
                    crystalReportViewer1.ReportSource = obj_crystal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
