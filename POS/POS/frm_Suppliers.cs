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
    public partial class frm_Suppliers : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_Suppliers()
        {
            InitializeComponent();
            using (var context = new POS_dbEntities())
            {
                var name = (from c in context.Suppliers
                            select c.Name).ToList();
                cmb_name.DataSource = name;
                cmb_name.SelectedItem = null;
            }
        }
        void AllClear()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }

                    else if (control is ComboBox)

                    {
                        (control as ComboBox).SelectedItem = null;
                    }
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text != string.Empty && txt_Contact.Text != string.Empty && rtxt_Addr.Text != string.Empty)
            {
                using (var context = new POS_dbEntities())
                {
                    Supplier obj_supplier = new Supplier();
                    obj_supplier.Name = txt_Name.Text;
                    obj_supplier.Address = rtxt_Addr.Text;
                    obj_supplier.Contact_No = txt_Contact.Text;
                    context.Suppliers.Add(obj_supplier);
                    context.SaveChanges();
                    MessageBox.Show("Supplier Added Successfully", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    rtxt_Addr.Clear();
                    AllClear();
                }
            }
            else
            {
                MessageBox.Show("Please Provide Complete Data");
            }
        }
        
        private void btn_edit_Click(object sender, EventArgs e)
        {
            txt_editcont.Enabled = true;
            txt_editname.Enabled = true;
            rxt_editadd.Enabled = true;
            cmb_name.DataSource = obj_helper.GetAllSupplierNames();
        }

        private void btn_editsave_Click(object sender, EventArgs e)
        {
            using (var context = new POS_dbEntities())
            {
                var obj_name = (from c in context.Suppliers
                                where c.Name == cmb_name.Text
                                select c).SingleOrDefault();
                if (txt_editname.Text != string.Empty && txt_editcont.Text != string.Empty && rxt_editadd.Text != string.Empty)
                {
                    obj_name.Name = txt_editname.Text;
                    obj_name.Contact_No = txt_editcont.Text;
                    obj_name.Address = rxt_editadd.Text;
                    context.Entry(obj_name).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    MessageBox.Show("Data Modified", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_editcont.Clear();
                    txt_editname.Clear();
                    rxt_editadd.Clear();
                }
                else
                {
                    MessageBox.Show("Please Fill all Fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        private void cmb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new POS_dbEntities())
            {
                try
                {
                    var Editdata = (from c in context.Suppliers
                                    where c.Name == cmb_name.Text
                                    select c).SingleOrDefault();
                    txt_editname.Text = Editdata.Name;
                    txt_editcont.Text = Editdata.Contact_No;
                    rxt_editadd.Text = Editdata.Address;

                }
                catch (Exception)
                {
                    txt_editcont.Clear();
                    txt_editname.Clear();
                    rxt_editadd.Clear();

                }


            }

        }
    }
}
