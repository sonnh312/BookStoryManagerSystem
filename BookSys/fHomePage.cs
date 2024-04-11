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
    public partial class fHomePage : Form
    {
        private Staff loginAccount;
        public Staff LoginAccount { get => this.loginAccount; set { this.loginAccount = value; ChangeAccount(LoginAccount.Type); } }
        public fHomePage(Staff acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }
        void ChangeAccount(int type)
        {

            UserToolStripMenuItem.Text += "(" + loginAccount.Displayname + ")";

        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            fBook f = new fBook();
            f.ShowDialog();
            
        }
        private void btnShowImport_Click(object sender, EventArgs e)
        {
            Import f = new Import();
            f.ShowDialog();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            fExport f = new fExport();
            f.ShowDialog();
        }
        private void btnStatics_Click(object sender, EventArgs e)
        {
            fReport f = new fReport();
            f.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            fStatics f = new fStatics();
            f.ShowDialog();
        }

        private void btnShowDtb_Click(object sender, EventArgs e)
        {
            fDistributor f = new fDistributor();
            f.ShowDialog();
        }

        private void btnShowPub_Click(object sender, EventArgs e)
        {
            fPublisher f = new fPublisher();
            f.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowStock_Click(object sender, EventArgs e)
        {
            fRegister f = new fRegister();
            f.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
