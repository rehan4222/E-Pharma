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
    public partial class frm_ProductCategories : Form
    {
        HelperClass obj_helper = new HelperClass();
        public frm_ProductCategories()
        {
            InitializeComponent();
            FillSubCats();
        }
        
        #region Add Cats
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_CatName.Text!=string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var catName = txt_CatName.Text;
                        var obj_cats = new Products_Category();
                        obj_cats.Category_Name = catName;
                        if (obj_helper.CategoryExists(catName) == false)
                        {
                            context.Products_Categories.Add(obj_cats);
                            context.SaveChanges();
                            txt_CatName.Clear();
                            MessageBox.Show("Product Category Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillSubCats();
                        }
                        else
                        {
                            MessageBox.Show("Product Category Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_CatName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode== Keys.Enter)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var catName = txt_CatName.Text;
                        var obj_cats = new Products_Category();
                        obj_cats.Category_Name = catName;
                        if (obj_helper.CategoryExists(catName)==false)
                        {
                            context.Products_Categories.Add(obj_cats);
                            context.SaveChanges();
                            txt_CatName.Clear();
                            MessageBox.Show("Product Category Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillSubCats();
                        }
                        else
                        {
                            MessageBox.Show("Product Category Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Add Sub-Cats
        private void btn_SubCats_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_SubCatName.Text!=string.Empty && cmb_ParentCats.Text!=string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var subCatName = txt_SubCatName.Text;
                        var ifsubcat = (from c in context.Product_Sub_Categories
                                        where c.Sub_Category_Name==subCatName
                                        select c).SingleOrDefault();
                        if (ifsubcat==null)
                        {
                            var catName = cmb_ParentCats.Text;
                            var catID = obj_helper.GetCategoryIDFromName(catName);
                            var obj_subCat = new Product_Sub_Category();
                            obj_subCat.Sub_Category_Name = subCatName;
                            obj_subCat.Product_Category_FK = catID;
                            context.Product_Sub_Categories.Add(obj_subCat);
                            context.SaveChanges();
                            MessageBox.Show("Sub Category Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_SubCatName.Clear();
                            var cmb_DataSource = obj_helper.GetAllCats();
                            cmb_ParentCats.DataSource = cmb_DataSource;
                            cmb_ParentCats.SelectedItem = null;

                        }
                        else
                        {
                            MessageBox.Show("This Sub-Cateogry already exists");
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void FillSubCats()
        {
            cmb_ParentCats.DataSource= obj_helper.GetAllCats();
            cmb_ParentCats.SelectedItem = null;
        }
        #endregion

        #region View Cats
        private void btn_showParentCats_Click(object sender, EventArgs e)
        {
            try
            {
                FillShowParentsCats();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_showAllCats_Click(object sender, EventArgs e)
        {
            try
            {
                FillShowAllCats();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_showSubCats_Click(object sender, EventArgs e)
        {
            try
            {
                FillShowSubCats();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void FillShowParentsCats()
        {
            dgv_ShowParentCats.Rows.Clear();
            var allCats = obj_helper.GetAllCats();
            foreach (var item in allCats)
            {
                dgv_ShowParentCats.Rows.Add(item);
            }
        }
        void FillShowAllCats()
        {
            dgv_AllCats.Rows.Clear();
            var allCats = obj_helper.GetAllCats();
            foreach (var item in allCats)
            {
                var catID = obj_helper.GetCategoryIDFromName(item);
                var subCats = obj_helper.GetSubCatsFromCatID(catID);
                if (subCats!=null)
                {
                    foreach (var item1 in subCats)
                    {
                        dgv_AllCats.Rows.Add(item, item1);
                    }
                }
            }
        }
        void FillShowSubCats()
        {
            dgv_ShowSubCats.Rows.Clear();
            var subcats = obj_helper.GetAllSubCats();
            foreach (var item in subcats)
            {
                dgv_ShowSubCats.Rows.Add(item);
            }
        }
        #endregion

        #region Delete Cats
        private void dgv_ShowParentCats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == dgv_ShowParentCats.NewRowIndex && e.RowIndex < 0)
                {
                    return;
                }
                else
                {
                    if (e.ColumnIndex == 2)
                    {
                        var catName = dgv_ShowParentCats.Rows[e.RowIndex].Cells[1].Value.ToString();
                        var catID = Convert.ToInt32(dgv_ShowParentCats.Rows[e.RowIndex].Cells[0].Value.ToString());
                        DialogResult obj_dalogueResult = MessageBox.Show("Do Confirm Deleting \n" + catName + " \nFrom Categories List?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (obj_dalogueResult == DialogResult.Yes)
                        {
                            if (obj_helper.DeleteSubCatsForCat(catID) == true)
                            {
                                if (obj_helper.DeleteCat(catID) == true)
                                {
                                    MessageBox.Show("Category Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    FillShowParentsCats();
                                    FillSubCats();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_ShowSubCats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == dgv_ShowSubCats.NewRowIndex && e.RowIndex < 0)
                {
                    return;
                }
                else
                {
                    var subCatName = dgv_ShowSubCats.Rows[e.RowIndex].Cells[1].Value.ToString();
                    var subCatID = Convert.ToInt32(dgv_ShowSubCats.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DialogResult obj_dalogueResult = MessageBox.Show("Do Confirm Deleting \n" + subCatName + " \nFrom Categories List?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (obj_dalogueResult == DialogResult.Yes)
                    {
                        if (obj_helper.DeleteProductsFromSubCat(subCatID)==true)
                        {
                            if (obj_helper.DeleteSubCat(subCatID) == true)
                            {
                                MessageBox.Show("Sub-Category Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FillShowSubCats();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
