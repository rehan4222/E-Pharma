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
    public partial class frm_Customers : Form
    {
        public static string customerName = string.Empty;
        HelperClass obj_helper = new HelperClass();
        public frm_Customers()
        {
            InitializeComponent();
            using (var context = new POS_dbEntities())
            {
                var name = (from c in context.Customers
                            select c.Name).ToList();
                cmb_name.DataSource = name;
                cmb_name.SelectedItem = null;
                cmb_existing.DataSource = name;
                cmb_existing.SelectedItem = null;
                
            }


        }
        void GetClear()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }
                    else if (control is RichTextBox)
                    {
                        (control as RichTextBox).Clear();
                    }

                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void frm_Customers_Load(object sender, EventArgs e)
        {

        }
        private void btn_customers_Click_1(object sender, EventArgs e)
        {
            if (txt_Name.Text!=string.Empty && txt_Contactno.Text!=string.Empty && rtb_address.Text!=string.Empty)
            {
                using (var context = new POS_dbEntities())
                {
                    var ifcust = (from c in context.Customers
                                  where c.Name==txt_Name.Text
                                  select c).SingleOrDefault();
                    if (ifcust==null)
                    {
                        var obj = new Customer();
                        obj.Name = txt_Name.Text;
                        obj.Address = rtb_address.Text;
                        obj.Contact_No = txt_Contactno.Text;

                        DialogResult obj_dialouge = MessageBox.Show("Do you want to save it", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (obj_dialouge == DialogResult.Yes)
                        {
                            context.Customers.Add(obj);
                            context.SaveChanges();
                            MessageBox.Show("Added Successfully");
                            AllClear();
                            var data = (from c in context.Customers
                                        select c.Name).ToList();
                            cmb_existing.DataSource = data;
                            cmb_existing.SelectedItem = null;
                            GetClear();
                        }

                    }
                    else
                    {
                        MessageBox.Show("This Name Already Exists");
                    }
                    
                }

            }
            else
            {
                MessageBox.Show("Please Fill all Fields");
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
                    else if (control is RichTextBox)

                    {
                        (control as RichTextBox).Clear();
                    }
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            
            
            txt_editcont.Enabled = true;
            txt_editname.Enabled = true;
            rxt_editadd.Enabled = true;
            cmb_name.DataSource = obj_helper.GetAllCustomerNames();
            cmb_name.SelectedItem = null;
        }
        
        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (var context=new POS_dbEntities())
            {
                var obj_name = (from c in context.Customers
                                where c.Name == cmb_name.Text
                                select c).SingleOrDefault();
                if (txt_editname.Text!=string.Empty && txt_editcont.Text!=string.Empty && rxt_editadd.Text!=string.Empty)
                {
                    var ifname = (from c in context.Customers
                                  where c.Name==txt_editname.Text
                                  select c).SingleOrDefault();
                    if (ifname==null)
                    {
                        obj_name.Name = txt_editname.Text;
                        obj_name.Contact_No = txt_editcont.Text;
                        obj_name.Address = rxt_editadd.Text;
                        context.Entry(obj_name).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        MessageBox.Show("Data Modified", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AllClear();

                    }
                    else
                    {
                        MessageBox.Show("This Name Already Exists");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please Fill all Fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              

            }
        }

        private void cmb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context=new POS_dbEntities())
            {
                try
                {
                    var Editdata = (from c in context.Customers
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

        private void btN_exis_Click(object sender, EventArgs e)
        {
            customerName = cmb_existing.Text;
            this.Close();
        }
    }
}
