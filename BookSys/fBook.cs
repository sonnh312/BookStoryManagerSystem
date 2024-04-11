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
    public partial class fBook : Form
    {
        BindingSource booklist = new BindingSource();
        public fBook()
        {
            InitializeComponent();
            dgvBook.DataSource = booklist;//binding
            LoadBook();
            AddBindingBook();
        }

        #region Method
        void LoadBook()
        {
            List<Book> list = new List<Book>();
            booklist.DataSource = BookDAO.Instance.LoadBookInStock();
        }
        void AddBindingBook()
        {
            txtBookID.DataBindings.Add(new Binding("Text", booklist, "IdBook", true, DataSourceUpdateMode.Never));
            txtBookTitle.DataBindings.Add(new Binding("Text", booklist, "bookTitle", true, DataSourceUpdateMode.Never));
            txtAuthor.DataBindings.Add(new Binding("Text", booklist, "authorName", true, DataSourceUpdateMode.Never));
            txtCategoryBook.DataBindings.Add(new Binding("Text", booklist, "categoryBook", true, DataSourceUpdateMode.Never));
            txtPurchasePrice.DataBindings.Add(new Binding("Text", booklist, "purchasePrice", true, DataSourceUpdateMode.Never));
            nmStock.DataBindings.Add(new Binding("Value", booklist, "quantityInStock", true, DataSourceUpdateMode.Never));
            txtStatus.DataBindings.Add(new Binding("Text", booklist, "Status", true, DataSourceUpdateMode.Never));
            txtSellPrice.DataBindings.Add(new Binding("Text", booklist, "sellingPrice", true, DataSourceUpdateMode.Never));
            dtpRelease.DataBindings.Add(new Binding("Value", booklist, "ImportDate", true, DataSourceUpdateMode.Never));
        }
        void AddBook(int idbook, string bookTitle, string authorName, string categoryBook, int quantityInStock, float purchasePrice, float sellingPrice, string status, DateTime? dateimport)
        {
            if (BookDAO.Instance.InsertBook(idbook, bookTitle, authorName, categoryBook, quantityInStock, purchasePrice, sellingPrice, status, dateimport))
            {
                MessageBox.Show("Add success");
            }
            else
            {
                MessageBox.Show("Fault.Try again");
            }
            LoadBook();
        }

        void UpdateBook(int idbook, string bookTitle, string authorName, string categoryBook, int quantityInStock, float purchasePrice, float sellingPrice, string status, DateTime? dateimport)
        {
            if (BookDAO.Instance.UpdateBook(idbook, bookTitle, authorName, categoryBook, quantityInStock, purchasePrice, sellingPrice, status, dateimport))
            {
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadBook();
        }

        void DeleteBook(string bookTitle)
        {
            if (BookDAO.Instance.DeleteBook(bookTitle))
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Fault. Try again");
            }
            LoadBook();
        }
        #endregion

        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {

            int idbook = Int32.Parse(txtBookID.Text);
            string bookTitle = txtBookTitle.Text;
            string authorName = txtAuthor.Text;
            string categoryBook = txtCategoryBook.Text;
            float purchasePrice = float.Parse(txtPurchasePrice.Text);
            float sellingPrice = float.Parse(txtSellPrice.Text);
            int quantityInStock = (int)nmStock.Value;
            string status = txtStatus.Text;
            DateTime dateimport = dtpRelease.Value;
            AddBook(idbook, bookTitle, authorName, categoryBook, quantityInStock, purchasePrice, sellingPrice, status, dateimport);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idbook = Int32.Parse(txtBookID.Text);
            string bookTitle = txtBookTitle.Text;
            string authorName = txtAuthor.Text;
            string categoryBook = txtCategoryBook.Text;
            float purchasePrice = float.Parse(txtPurchasePrice.Text);
            float sellingPrice = float.Parse(txtSellPrice.Text);
            int quantityInStock = (int)nmStock.Value;
            string status = txtStatus.Text;
            DateTime dateimport = dtpRelease.Value;
            UpdateBook(idbook, bookTitle, authorName, categoryBook, quantityInStock, purchasePrice, sellingPrice, status, dateimport);
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            string bookTitle = txtBookTitle.Text;
            DeleteBook(bookTitle);
        }



        #endregion

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
