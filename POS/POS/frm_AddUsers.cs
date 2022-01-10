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
    public partial class frm_AddUsers : Form
    {
        public frm_AddUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_username.Text!=string.Empty && txt_password.Text!=string.Empty && txt_contact.Text!=string.Empty && cmb_type.Text!=string.Empty && rtx_address.Text!=string.Empty)
            {
                using (var context = new POS_dbEntities())
                {
                    var ifuser = (from c in context.Users
                                  where c.UserName==txt_username.Text
                                  select c).SingleOrDefault();
                    if (ifuser==null)
                    {
                        User obj_adduser = new User();
                        obj_adduser.UserName = txt_username.Text;
                        string pass = Encrypt(txt_password.Text);
                        obj_adduser.Password = pass;
                        obj_adduser.UserType = cmb_type.Text;
                        obj_adduser.Contact = txt_contact.Text;
                        obj_adduser.Address = rtx_address.Text;
                        context.Users.Add(obj_adduser);
                        context.SaveChanges();
                        MessageBox.Show("User Add Successfully");
                        AllClear();
                    }
                    else
                    {
                        MessageBox.Show("This Name already exists");
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
    }
}
