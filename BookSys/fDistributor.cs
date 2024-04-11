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
    public partial class fDistributor : Form
    {
        BindingSource dtblist = new BindingSource();
        public fDistributor()
        {
            InitializeComponent();
            LoadDtb();
            dgvDtb.DataSource = dtblist;
            AddBindingDtb();
            
        }

        private void fDistributor_Load(object sender, EventArgs e)
        {

        }
        #region Method
        void LoadDtb()
        {
            List<Distributor> list = new List<Distributor>();
            dtblist.DataSource = DistributorDAO.Instance.LoadDtb();
        }
        void AddBindingDtb()
        {
            txtIdDtb.DataBindings.Add(new Binding("Text", dtblist, "IdDistributor", true, DataSourceUpdateMode.Never));
            txtDtbName.DataBindings.Add(new Binding("Text", dtblist, "distributorName", true, DataSourceUpdateMode.Never));
            txtPhoneDtb.DataBindings.Add(new Binding("Text", dtblist, "phoneNum", true, DataSourceUpdateMode.Never));
            txtAddress.DataBindings.Add(new Binding("Text", dtblist, "address", true, DataSourceUpdateMode.Never));
            txtBookSend.DataBindings.Add(new Binding("Text", dtblist, "amountPaid", true, DataSourceUpdateMode.Never));
            txtremainingDebt.DataBindings.Add(new Binding("Text", dtblist, "remaniningDebt", true, DataSourceUpdateMode.Never));
        }
        void AddDtb(int iddistributor, string distributorname, int phonenum, string address, float amountpaid, float remaniningdebt)
        {
            if (DistributorDAO.Instance.InsertDtb( iddistributor,  distributorname,  phonenum,  address,  amountpaid,  remaniningdebt))
            {
                MessageBox.Show("Add success");
            }
            else
            {
                MessageBox.Show("Fault.Try again");
            }
            LoadDtb();
        }

        void UpdateDtb(int iddistributor, string distributorname, int phonenum, string address, float amountpaid, float remaniningdebt)
        {
            if (DistributorDAO.Instance.UpdateDtb( iddistributor,  distributorname,  phonenum,  address,  amountpaid,  remaniningdebt))
            {
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadDtb();
        }

        void DeleteDtb(string distributorName)
        {
            if (DistributorDAO.Instance.DeleteDtb(distributorName))
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadDtb();
        }

        
        #endregion

        #region Event

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int iddistributor = Int32.Parse(txtIdDtb.Text);
            string distributorname = txtDtbName.Text;
            int phonenum = Int32.Parse(txtPhoneDtb.Text);
            string address = txtAddress.Text;
            float amountpaid = float.Parse(txtBookSend.Text);
            float remaniningdebt = float.Parse(txtremainingDebt.Text);
            AddDtb(iddistributor, distributorname, phonenum, address, amountpaid, remaniningdebt);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int iddistributor = Int32.Parse(txtIdDtb.Text);
            string distributorname = txtDtbName.Text;
            int phonenum = Int32.Parse(txtPhoneDtb.Text);
            string address = txtAddress.Text;
            float amountpaid = float.Parse(txtBookSend.Text);
            float remaniningdebt = float.Parse(txtremainingDebt.Text);
            UpdateDtb(iddistributor, distributorname, phonenum, address, amountpaid, remaniningdebt);
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            string distributorName = txtDtbName.Text;
            DeleteDtb(distributorName);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtIdDtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtDtbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneDtb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
