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
    public partial class frm_CashReport : Form
    {
        public frm_CashReport()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context= new POS_dbEntities())
                {
                    var dataSource = (from c in context.Cashes
                                      where c.Date >= dtp_From.Value.Date
                                      && c.Date <= dtp_To.Value.Date
                                      select new
                                      {
                                          c.Date,
                                          c.Credit,
                                          c.Debit,
                                          c.Description,
                                          c.Balance,
                                      }).ToList();
                    CrystalReportCash obj_report = new CrystalReportCash();
                    obj_report.SetDataSource(dataSource);
                    crystalReportViewer1.ReportSource = obj_report;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
