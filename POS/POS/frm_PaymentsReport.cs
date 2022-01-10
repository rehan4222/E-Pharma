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
    public partial class frm_PaymentsReport: Form
    {
        public frm_PaymentsReport()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context=new POS_dbEntities())
                {
                    var dataSource = (from c in context.Payments
                                      where c.Date >= dtp_From.Value.Date
                                      && c.Date <= dtp_To.Value.Date
                                      select new
                                      {
                                          c.Date,
                                          c.PaymentMethod,
                                          c.Invoice,
                                          c.Openning,
                                          c.Amount,
                                          c.Remaining,
                                      }).ToList();
                    var obj_crystal = new CrystalReportPayments();
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
