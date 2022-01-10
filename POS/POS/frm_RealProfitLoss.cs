using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frm_RealProfitLoss : Form
    {
        public frm_RealProfitLoss()
        {
            InitializeComponent();
        }
        public frm_RealProfitLoss(double sales , double purchases , double exp)
        {
            InitializeComponent();
            lbl_date.Text = System.DateTime.Now.Date.ToShortDateString();
            lbl_totalsales.Text = sales.ToString();
            lbl_grosssales.Text = sales.ToString();
            lbl_totalpurchases.Text = purchases.ToString();
            lbl_grosspurchases.Text = purchases.ToString();
            lbl_totalexpenses.Text = exp.ToString();
            lbl_grossexp.Text = exp.ToString();
            double netprofit = sales - (purchases+exp);
            lbl_netincome.Text = netprofit.ToString();
        }

        private void frm_RealProfitLoss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                printDocument1.PrintPage += new PrintPageEventHandler(PrintImage);
                printDocument1.Print();

            }

        }
        private void PrintImage(object sender, PrintPageEventArgs e)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int width = this.Width;
            int height = this.Height;

            Rectangle bounds = new Rectangle(x, y, width, height);

            Bitmap img = new Bitmap(width, height);

            this.DrawToBitmap(img, bounds);
            Point p = new Point(0, 0);
            e.Graphics.DrawImage(img, p);
            this.Close();
        }
    }
}
