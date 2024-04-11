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
    public partial class fPublisher : Form
    {
        BindingSource publist = new BindingSource();
        public fPublisher()
        {
            InitializeComponent();
            LoadPub();
            dgvPub.DataSource = publist;
            AddBindingPub();
        }
        #region Method
        void LoadPub()
        {
            List<Publisher> list = new List<Publisher>();
            publist.DataSource = PublisherDAO.Instance.LoadPub();
        }
        void AddBindingPub()
        {
            txtIdPub.DataBindings.Add(new Binding("Text", publist, "IdPublisher", true, DataSourceUpdateMode.Never));
            txtPubName.DataBindings.Add(new Binding("Text", publist, "publisherName", true, DataSourceUpdateMode.Never));
            txtPhone.DataBindings.Add(new Binding("Text", publist, "phoneNum", true, DataSourceUpdateMode.Never));
            txtAddress.DataBindings.Add(new Binding("Text", publist, "address", true, DataSourceUpdateMode.Never));
            txtBank.DataBindings.Add(new Binding("Text", publist, "accountNum", true, DataSourceUpdateMode.Never));
        }
        void AddPub(int idpublisher, string publishername, string address, int phonenum, int accountnum)
        {
            if (PublisherDAO.Instance.InsertPub(idpublisher, publishername, address, phonenum, accountnum))
            {
                MessageBox.Show("Add success");
            }
            else
            {
                MessageBox.Show("Fault.Try again");
            }
            LoadPub();
        }

        void UpdatePub(int idpublisher, string publishername, string address, int phonenum, int accountnum)
        {
            if (PublisherDAO.Instance.UpdatePub(idpublisher, publishername, address, phonenum, accountnum))
            {
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadPub();
        }

        void DeletePub(string distributorName)
        {
            if (PublisherDAO.Instance.DeletePub(distributorName))
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadPub();
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int idpublisher = Int32.Parse(txtIdPub.Text);
            string publishername = txtPubName.Text;
            string address = txtAddress.Text;
            int phonenum = Int32.Parse(txtPhone.Text);
            int bank = Int32.Parse(txtBank.Text);
            
            AddPub(idpublisher, publishername, address, phonenum, bank);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idpublisher = Int32.Parse(txtIdPub.Text);
            string publishername = txtPubName.Text;
            string address = txtAddress.Text;
            int phonenum = Int32.Parse(txtPhone.Text);
            int bank = Int32.Parse(txtBank.Text);

            UpdatePub(idpublisher, publishername, address, phonenum, bank);
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            string pubName = txtPubName.Text;
            DeletePub(pubName);
        }

        

        
    }
}
