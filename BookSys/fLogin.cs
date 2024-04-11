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
    public partial class fLogin : Form
    {
        public fLogin()
        {

            InitializeComponent();
        }


        private void fLogin_Load(object sender, EventArgs e)
        {
            
        }
        bool Login(string username, string password)
        {
            return StaffDAO.Instance.Login(username, password);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
            string username = txtUsername.Text;
            string passwork = txtPass.Text;
            if (Login(username, passwork) == true)
            {
                Staff loginAccount = StaffDAO.Instance.GetAccountByUserName(username);
                fHomePage f = new fHomePage(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai ten dang nhap hoac mat khau");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fRegister f = new fRegister();
            f.ShowDialog();
        }

        
    }
}
