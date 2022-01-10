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
    public partial class BankAddition : Form
    {
        public BankAddition()
        {
            InitializeComponent();
        }

        private void btn_BankAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_bankname.Text!=string.Empty && txt_accountnumber.Text!=string.Empty && txt_initialbalance.Text!=string.Empty)
                {
                    using (var context = new POS_dbEntities())
                    {
                        var obj_bank = (from c in context.Banks
                                        where c.BankName==txt_bankname.Text
                                        select c).SingleOrDefault();
                        if (obj_bank == null)
                        {
                            var obj = new Bank();
                            obj.BankName = txt_bankname.Text;
                            obj.AccountNumber = txt_accountnumber.Text;
                            context.Banks.Add(obj);
                            context.SaveChanges();
                            var obj_initialbalance = new BankRecord();
                            obj_initialbalance.Debit = Convert.ToDouble(txt_initialbalance.Text);
                            obj_initialbalance.Credit = 0;
                            obj_initialbalance.Date = DateTime.Now.Date;
                            obj_initialbalance.Balance = Convert.ToDouble(txt_initialbalance.Text);
                            obj_initialbalance.Description = "initial balance";
                            obj_initialbalance.Bank_FK = obj.ID;
                            obj_initialbalance.User_FK = Login.userID;

                            DialogResult obj_dialouge = MessageBox.Show("Do you want to save it", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (obj_dialouge == DialogResult.Yes)
                            {
                                context.BankRecords.Add(obj_initialbalance);
                                context.SaveChanges();
                                MessageBox.Show("recorded successfully");
                                AllClear();
                            }

                        }
                        else
                        {
                            MessageBox.Show("This Bank Already Exists");
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
                MessageBox.Show(ex.Message);
               
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
    }
}
