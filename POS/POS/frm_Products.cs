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
    public partial class frm_Products : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_Products()
        {
            InitializeComponent();
            cmb_Cats.DataSource = obj_helper.GetAllCats();
            cmb_Cats.SelectedItem = null;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Name.Text!=string.Empty && txt_Minqty.Text!=string.Empty && txt_PurchaseCost.Text!=string.Empty && txt_salecost.Text!=string.Empty && cmb_Cats.Text!=string.Empty && cmb_SubCats.Text!=string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        if (obj_helper.ProductExists(txt_Name.Text) == false)
                        {
                            var obj_products = new Product();
                            obj_products.Barcode_Value = txt_BarCode.Text;
                            obj_products.Name = txt_Name.Text;
                            obj_products.Product_Sub_Category_FK = obj_helper.GetSubCategoryIDFromName(cmb_SubCats.Text);
                            obj_products.Purchase_Cost = Convert.ToDouble(txt_PurchaseCost.Text);
                            obj_products.Product_Company_FK = obj_helper.GetCompanyIdFromName(cmb_Company.Text);
                            obj_products.Sale_Cost = Convert.ToDouble(txt_salecost.Text);
                            int CatID = obj_helper.GetCatIDFromSubCatID(obj_products.Product_Sub_Category_FK);
                            var ifPRod = (from c in context.Products
                                          where c.Name==obj_products.Name && c.Product_Sub_Category_FK==obj_products.Product_Sub_Category_FK
                                          select c).SingleOrDefault();
                            if (ifPRod==null)
                            {
                                var IfComp = (from c in context.Products
                                               where c.Name == obj_products.Name && c.Product_Company_FK == obj_products.Product_Company_FK
                                               select c).SingleOrDefault();
                                if (IfComp==null)
                                {
                                    context.Products.Add(obj_products);
                                    context.SaveChanges();
                                    MessageBox.Show("Product Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        else
                        {
                            MessageBox.Show("Product Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please Fill All Fields");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void cmb_Cats_SelectedIndexChanged(object sender, EventArgs e)
        {
            var catID = obj_helper.GetCategoryIDFromName(cmb_Cats.Text);
            cmb_SubCats.DataSource = obj_helper.GetSubCatsFromCatID(catID);
            cmb_SubCats.SelectedItem = null;
        }
        
        private void btn_ViewProducts_Click(object sender, EventArgs e)
        {
            try
            {
                FillProductsDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void FillProductsDGV()
        {
            using (var context = new POS_dbEntities())
            {
                dgv_AllProducts.Rows.Clear();
                var allProduct = obj_helper.GetAllProducts();
                foreach (var item in allProduct)
                {
                    var subCatName = obj_helper.GetSubCategoryNameFromID(item.Product_Sub_Category_FK);
                    var catID = obj_helper.GetCatIDFromSubCatID(item.Product_Sub_Category_FK);
                    var catName = obj_helper.GetCategoryNameFromID(catID);
                    dgv_AllProducts.Rows.Add(item.Name, catName, subCatName, item.Purchase_Cost,item.Sale_Cost);
                }
            }
        }

        private void dgv_AllProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex==dgv_AllProducts.NewRowIndex && e.RowIndex<0)
                {
                    return;
                }
                else
                {
                    if (e.ColumnIndex==6)
                    {
                        var prodName = dgv_AllProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var prodID = obj_helper.GetPrdocuctNameFormID(prodName);
                        if (obj_helper.DeleteProduct(prodID)==true)
                        {
                            MessageBox.Show("Prodcut Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillProductsDGV();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
