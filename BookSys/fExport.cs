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
    public partial class fExport : Form
    {
        BindingSource exportlist = new BindingSource();
        public fExport()
        {
            LoadExport();
            InitializeComponent();
            dgvExport.DataSource = exportlist;//binding
            AddBinding();
            LoadCb();
            LoadCus();
           
        }
        void AddExport(int idExportForm, DateTime? exportDate, int idDistributor, string personDelivering, int idBook, int exportQuantity, float totalAmount)
        {
            if (ExportTicketDAO.Instance.InsertTicket(idExportForm, exportDate, idDistributor, personDelivering, idBook, exportQuantity, totalAmount))
            {
                MessageBox.Show("Add success");
            }
            else
            {
                MessageBox.Show("Fault.Try again");
            }
            LoadExport();
        }

        void UpdateExport(int idExportForm, DateTime? exportDate, int idDistributor, string personDelivering, int idBook, int exportQuantity, float totalAmount)
        {
            if (ExportTicketDAO.Instance.UpdateTicket(idExportForm, exportDate, idDistributor, personDelivering, idBook, exportQuantity, totalAmount))
            {
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadExport();
        }

        void DeleteExport(string del)
        {
            if (ExportTicketDAO.Instance.DeleteTicket(del))
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadExport();
        }

        void LoadExport()
        {
            List<ExportForm> list = new List<ExportForm>();
            exportlist.DataSource = ExportTicketDAO.Instance.LoadExportForm();
        }
        void AddBinding()
        {
            txtId.DataBindings.Add(new Binding("Text", exportlist, "idExportForm", true, DataSourceUpdateMode.Never));
            dtpExport.DataBindings.Add(new Binding("Value", exportlist, "exportDate", true, DataSourceUpdateMode.Never));
            nmExport.DataBindings.Add(new Binding("Value", exportlist, "exportQuantity", true, DataSourceUpdateMode.Never));
            txtDelivering.DataBindings.Add(new Binding("Text", exportlist, "personDelivering", true, DataSourceUpdateMode.Never));
            txtTotal.DataBindings.Add(new Binding("Text", exportlist, "totalAmount", true, DataSourceUpdateMode.Never));
            cbIdBook.DataBindings.Add(new Binding("Text", exportlist, "IdBook", true, DataSourceUpdateMode.Never));
            cbIdDtb.DataBindings.Add(new Binding("Text", exportlist, "IdDistributor", true, DataSourceUpdateMode.Never));
        }
        void LoadCb()
        {
            cbIdBook.DataSource = BookDAO.Instance.LoadBookInStock();
            cbIdBook.DisplayMember = "IdBook";
            cbIdDtb.DataSource = DistributorDAO.Instance.LoadDtb();
            cbIdDtb.DisplayMember = "IdDistributor";
        }
        void LoadCus()
        {
            List<Book> listId = BookDAO.Instance.LoadBookInStock();
            cbIdBook.DataSource = listId;
            cbIdBook.DisplayMember = "IdBook";


            cbIdBook.SelectedIndexChanged += (sender, e) =>
            {
                if (cbIdBook.SelectedIndex >= 0)
                {
                    Book selectedCustomer = (Book)cbIdBook.SelectedItem;
                    txtBookName.Text = selectedCustomer.Booktitle;
                }
            };
            List<Distributor> listDtb = DistributorDAO.Instance.LoadDtb();
            cbIdDtb.DataSource = listDtb;
            cbIdDtb.DisplayMember = "IdDistributor";


            cbIdDtb.SelectedIndexChanged += (sender, e) =>
            {
                if (cbIdDtb.SelectedIndex >= 0)
                {
                    Distributor selectedCustomer = (Distributor)cbIdDtb.SelectedItem;
                    txtDtb.Text = selectedCustomer.Address;
                }
            };
        }
        void AddExpot()
        {
            List<ExportForm> lsBill = ExportTicketDAO.Instance.LoadExportForm();
            foreach (ExportForm item in lsBill)
            {
                ListViewItem lvItem = new ListViewItem(item.IdExportForm.ToString());
                lvItem.SubItems.Add(cbIdDtb.SelectedItem.ToString());
                lvItem.SubItems.Add(cbIdDtb.SelectedItem.ToString());
                lvItem.SubItems.Add(txtDtb.ToString());
                lvItem.SubItems.Add(nmExport.ToString());
                lvItem.SubItems.Add(txtDelivering.ToString());
                lvItem.SubItems.Add(txtBookName.ToString());
                lvItem.SubItems.Add(dtpExport.ToString());
              
            }
           



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int idExportForm = Int32.Parse(txtId.Text); 
            int idBook = int.Parse(cbIdBook.Text);
            int idDistributor = int.Parse(cbIdDtb.Text);
            DateTime exportDate = dtpExport.Value;
            int exportQuantity = (int)nmExport.Value;
            float totalAmount = float.Parse(txtTotal.Text);
            string personDelivering = txtDelivering.Text;
            
            AddExport(idExportForm, exportDate, idDistributor, personDelivering, idBook, exportQuantity, totalAmount);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idExportForm = Int32.Parse(txtId.Text);
            int idBook = int.Parse(cbIdBook.Text);
            int idDistributor = int.Parse(cbIdDtb.Text);
            DateTime exportDate = dtpExport.Value;
            int exportQuantity = (int)nmExport.Value;
            float totalAmount = float.Parse(txtTotal.Text);
            string personDelivering = txtDelivering.Text;

            UpdateExport(idExportForm, exportDate, idDistributor, personDelivering, idBook, exportQuantity, totalAmount);
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            string del = txtDelivering.Text;
            DeleteExport(del);
        }
    }
}

