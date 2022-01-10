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
    public partial class frm_BankReport : Form
    {
        public frm_BankReport()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    var bankData = (from c in context.BankRecords
                                      join d in context.Banks
                                      on c.Bank_FK equals d.ID
                                      where c.Date >= dtp_From.Value.Date
                                      && c.Date <= dtp_To.Value.Date
                                      select new
                                      {
                                          d.BankName,
                                          c.Date,
                                          c.Credit,
                                          c.Debit,
                                          c.Description,
                                          c.Balance,
                                      }).ToList();
                    foreach (var item in bankData)
                    {
                        var obj_bank = new rpt_Bank();
                        obj_bank.Balance = item.Balance;
                        obj_bank.Bank = item.BankName;
                        obj_bank.Credit = item.Credit;
                        obj_bank.Date = item.Date.ToShortDateString();
                        obj_bank.Debit = item.Debit;
                        obj_bank.Description = item.Description;
                        context.rpt_Bank.Add(obj_bank);
                        context.SaveChanges();
                    }
                    var dataSource = (from c in context.rpt_Bank
                                      select c).ToList();
                    CrystalReportBank obj_report = new CrystalReportBank();
                    obj_report.SetDataSource(dataSource);
                    crystalReportViewer1.ReportSource = obj_report;
                    context.rpt_Bank.RemoveRange(dataSource);
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
