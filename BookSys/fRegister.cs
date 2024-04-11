using BookSys.DAO;
using BookSys.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSys
{
    public partial class fRegister : Form
    {
        
        public fRegister()
        {
            InitializeComponent();
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        public class AccountEvent:EventArgs
        {
            private Staff acc;

            public Staff Acc { get => acc; set => acc = value; }

            public AccountEvent(Staff acc)
            {
                this.Acc = acc;

            }
        }

        public void UpdateAccountInfo()
        {
            string displayname = txtDisplayname.Text;
            string password = txtPass.Text;
            string newpassword = txtNewPass.Text;
            string reenterpassword = txtRePass.Text;
            string username = txtUserName.Text;

            if (!newpassword.Equals(reenterpassword))
            {
                MessageBox.Show("Vui lòng nhập 2 mật khẩu giống nhau");
            }
            // event bac 2
            else
            {
                if (StaffDAO.Instance.UpdateAccount(username, displayname, password, newpassword))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(StaffDAO.Instance.GetAccountByUserName(username)));
                    }
                }
                else
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu");
            }
        }



    }
}
