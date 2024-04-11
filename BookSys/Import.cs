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
        public partial class Import : Form
        {
            BindingSource importlist = new BindingSource();
            public Import()
            {
            InitializeComponent();
            dgvImport.DataSource = importlist;
            LoadImport();
            AddBinding();
            LoadCus();


            }

        void LoadImport()
        {
            List<ImportTicket> list = ImportDAO.Instance.LoadForm();
            importlist.DataSource = list;
        }

        void AddBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", importlist, "IdImportForm", true, DataSourceUpdateMode.OnValidation));
            dtpImport.DataBindings.Add(new Binding("Value", importlist, "ImportDate", true, DataSourceUpdateMode.OnValidation));
            nmBook.DataBindings.Add(new Binding("Value", importlist, "ImportQuantity", true, DataSourceUpdateMode.OnValidation));
            txtRecipient.DataBindings.Add(new Binding("Text", importlist, "PersonRecipient", true, DataSourceUpdateMode.OnValidation));
            txtTotalAmount.DataBindings.Add(new Binding("Text", importlist, "TotalAmount", true, DataSourceUpdateMode.OnValidation));
            cbBookTitle.DataBindings.Add(new Binding("Text", importlist, "IdBook", true, DataSourceUpdateMode.OnValidation));
            cbPubName.DataBindings.Add(new Binding("Text", importlist, "Idpublisher", true, DataSourceUpdateMode.OnValidation));
            txtNote.DataBindings.Add(new Binding("Text", importlist, "ImportNote", true, DataSourceUpdateMode.OnValidation));
        }
        void LoadCus()
        {
            List<Book> listId = BookDAO.Instance.LoadBookInStock();
            cbBookTitle.DataSource = listId;
            cbBookTitle.DisplayMember = "IdBook";


            cbBookTitle.SelectedIndexChanged += (sender, e) =>
            {
                if (cbBookTitle.SelectedIndex >= 0)
                {
                    Book selectedCustomer = (Book)cbBookTitle.SelectedItem;
                    txtBook.Text = selectedCustomer.Booktitle;
                }
            };
            List<Publisher> listDtb = PublisherDAO.Instance.LoadPub();
            cbPubName.DataSource = listDtb;
            cbPubName.DisplayMember = "IdPublisher";


            cbPubName.SelectedIndexChanged += (sender, e) =>
            {
                if (cbPubName.SelectedIndex >= 0)
                {
                    Publisher selectedCustomer = (Publisher)cbPubName.SelectedItem;
                    txtPub.Text = selectedCustomer.Address;
                }
            };
        }


        void AddImport(int idImportForm, DateTime? importDate, int idpublisher, string personRecipient, int idBook, int importQuantity, float totalAmount, string importNote)
        {
            if (ImportDAO.Instance.InsertTicket(idImportForm, importDate, idpublisher, personRecipient, idBook, importQuantity, totalAmount, importNote))
            {
                MessageBox.Show("Add success");
            }
            else
            {
                MessageBox.Show("Fault.Try again");
            }
            LoadImport();
        }

        void UpdateImport(int idImportForm, DateTime? importDate, int idpublisher, string personRecipient, int idBook, int importQuantity, float totalAmount, string importNote)
        {
            if (ImportDAO.Instance.UpdateTicket(idImportForm, importDate, idpublisher, personRecipient, idBook, importQuantity, totalAmount, importNote))
            {
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadImport();
        }

        void DeleteImport(int del)
        {
            if (ImportDAO.Instance.DeleteTicket(del))
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadImport();
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int idImportForm = Int32.Parse(txtID.Text);
            int idBook = int.Parse(cbBookTitle.Text);
            int idpublisher = int.Parse(cbPubName.Text);
            DateTime importDate = dtpImport.Value;
            int importQuantity = (int)nmBook.Value;
            float totalAmount = float.Parse(txtTotalAmount.Text);
            string personRecipient = txtRecipient.Text;
            string importNote = txtNote.Text;
            AddImport(idImportForm, importDate, idpublisher, personRecipient, idBook, importQuantity, totalAmount, importNote);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idImportForm = Int32.Parse(txtID.Text);
            int idBook = int.Parse(cbBookTitle.Text);
            int idpublisher = int.Parse(cbPubName.Text);
            DateTime importDate = dtpImport.Value;
            int importQuantity = (int)nmBook.Value;
            float totalAmount = float.Parse(txtTotalAmount.Text);
            string personRecipient = txtRecipient.Text;
            string importNote = txtNote.Text;
            UpdateImport(idImportForm, importDate, idpublisher, personRecipient, idBook, importQuantity, totalAmount, importNote);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtID.Text);
            DeleteImport(id);
        }
    }
}
