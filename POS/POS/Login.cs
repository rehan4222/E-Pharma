using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace POS
{
    public partial class Login : Form
    {
        HelperClass obj_helper = new HelperClass();
        public static int userID;
        public Login()
        {
            InitializeComponent();
            var userName = "harfsol";
            var password = Encrypt("harfsol");
            if (obj_helper.UserExists(userName, password) == false)
            {
                obj_helper.InsertUser(userName, password);
            }

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_username.Text != string.Empty && txt_password.Text != string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var username = txt_username.Text;
                        var pass = Encrypt(txt_password.Text);

                        var result = (from c in context.Users
                                      where c.UserName == username && c.Password == pass
                                      select c).SingleOrDefault();
                        userID = result.UserID;
                        if (result != null)
                        {
                            if (result.UserType == "Admin")
                            {
                                mainform obj_main = new mainform();
                                this.Hide();
                                obj_main.Show();
                            }

                            else if (result.UserType == "Sales Man")
                            {
                                frm_Sales obj_sales = new frm_Sales();
                                this.Hide();
                                obj_sales.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Crediantials");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Please Provide UserName or Password");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt_username.Text != string.Empty && txt_password.Text != string.Empty)
                    {
                        using (var context = new POS_dbEntities())
                        {
                            var username = txt_username.Text;
                            var pass = Encrypt(txt_password.Text);

                            var result = (from c in context.Users
                                          where c.UserName == username && c.Password == pass
                                          select c).SingleOrDefault();
                            userID = result.UserID;
                            if (result != null)
                            {
                                if (result.UserType == "Admin")
                                {
                                    mainform obj_main = new mainform();
                                    this.Hide();
                                    obj_main.Show();
                                }

                                else if (result.UserType == "Sales Man")
                                {
                                    frm_Sales obj_sales = new frm_Sales();
                                    this.Hide();
                                    obj_sales.Show();
                                }
                            }

                            else
                            {
                                MessageBox.Show("Invalid Crediantials");
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Please Provide UserName or Password");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
