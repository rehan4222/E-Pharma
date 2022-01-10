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
    public partial class FixAssets : Form
    {
        public FixAssets()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Assetname.Text!=string.Empty && txt_AssetWorth.Text!=string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var ifasset = (from c in context.Fix_Assets
                                       where c.Asset_Name==txt_Assetname.Text
                                       select c).SingleOrDefault();
                        if (ifasset==null)
                        {
                            var obj_asset = new Fix_Asset();
                            obj_asset.Asset_Name = txt_Assetname.Text;
                            obj_asset.Asset_Worth = Convert.ToDouble(txt_AssetWorth.Text);

                            DialogResult obj_dialouge = MessageBox.Show("Do you want to save it", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (obj_dialouge == DialogResult.Yes)
                            {
                                context.Fix_Assets.Add(obj_asset);
                                context.SaveChanges();
                                MessageBox.Show("Added Successfully");
                                GetClear();
                            }

                        }
                        else
                        {
                            MessageBox.Show("This asset already exists...!");
                        }
                       
                    }

                }
                else
                {
                    MessageBox.Show("Please Fill all Fields");
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
    }
}
