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
    public partial class frm_ProductEdit : Form
    {
        HelperClass obj_helper = new HelperClass();
        Product obj_ProdEdit;
        public frm_ProductEdit()
        {
            InitializeComponent();
            cmb_Prods.DataSource = obj_helper.GetAllProductName();
            cmb_Prods.SelectedItem = null;
            cmb_Cats.DataSource = obj_helper.GetAllCats();
            cmb_SubCats.DataSource = obj_helper.GetAllSubCats();
            cmb_Cats.SelectedItem = null;
            cmb_SubCats.SelectedItem = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context=new POS_dbEntities())
            {
                try
                {
                    var prod_id = obj_helper.GetProductIDFromName(cmb_Prods.Text);
                    var prod = obj_helper.GetPrdocuctFormID(prod_id);
                    txt_Name.Text = prod.Name;
                    txt_PurchaseCost.Text = (prod.Purchase_Cost).ToString();
                    txt_Salecost.Text = (prod.Sale_Cost).ToString();
                    cmb_SubCats.SelectedItem = obj_helper.GetSubCategoryNameFromID(prod.Product_Sub_Category_FK);
                    var catID = obj_helper.GetCatIDFromSubCatID(prod.Product_Sub_Category_FK);
                    cmb_Cats.SelectedItem = obj_helper.GetCategoryNameFromID(catID);
                    cmb_company.Text = obj_helper.GetCompanyNameFromID(prod.Product_Company_FK);
                    obj_ProdEdit = prod;
                }
                catch (Exception)
                {
                    AllClear();
                }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    obj_ProdEdit.Name = txt_Name.Text;
                    obj_ProdEdit.Purchase_Cost = Convert.ToDouble(txt_PurchaseCost.Text);
                    obj_ProdEdit.Sale_Cost = Convert.ToDouble(txt_Salecost.Text);
                    obj_ProdEdit.Product_Sub_Category_FK = obj_helper.GetSubCategoryIDFromName(cmb_SubCats.Text);
                    obj_ProdEdit.Product_Company_FK = obj_helper.GetCompanyIdFromName(cmb_company.Text);
                    var ifPRod = (from c in context.Products
                                  where c.Name == obj_ProdEdit.Name && c.Product_Sub_Category_FK == obj_ProdEdit.Product_Sub_Category_FK
                                  select c).SingleOrDefault();
                    if (ifPRod == null)
                    {
                        var IfComp = (from c in context.Products
                                      where c.Name == obj_ProdEdit.Name && c.Product_Company_FK == obj_ProdEdit.Product_Company_FK
                                      select c).SingleOrDefault();
                        if (IfComp == null)
                        {
                            context.Entry(obj_ProdEdit).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                            MessageBox.Show("Product Edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AllClear();
                        }
                        else
                        {
                            MessageBox.Show("This Product with same Company Name already exists");
                        }


                    }
                    else
                    {
                        MessageBox.Show("This PRoducts with same category and sub category already exists");
                    }

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Name.Text!=string.Empty && txt_PurchaseCost.Text!=string.Empty && txt_Salecost.Text!=string.Empty && cmb_Cats.Text!=string.Empty
                    && cmb_SubCats.Text!=string.Empty)
                {
                    DialogResult obj = MessageBox.Show("Do you confirm to Delete it..." , "Confirmation ", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (obj==DialogResult.Yes)
                    {
                        using (var context = new POS_dbEntities())
                        {
                            string name = txt_Name.Text;
                            var ProdID = (from c in context.Products
                                          where c.Name == name
                                          select c).SingleOrDefault();
                            context.Products.Remove(ProdID);
                            context.SaveChanges();
                            AllClear();
                        }

                    }
                   
                }
                else
                {
                    MessageBox.Show("Please Enter Complete Details");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
