using BookSys.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DAO
{
    public class BookDAO
    {
        private static BookDAO instance;

        public static BookDAO Instance
        {
            get { if (instance == null) instance = new BookDAO(); return BookDAO.instance; }
            private set { BookDAO.instance = value; }
        }


        private BookDAO() { }
        //load
        public List<Book> LoadBookInStock()
        {
            List<Book> list = new List<Book>();

            string query = "SELECT * FROM dbo.Book";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);
                list.Add(book);
            }
            return list;
        }
        public List<Book> LoadBookName()
        {
            List<Book> list = new List<Book>();

            string query = "SELECT bookTitle FROM dbo.Book";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);
                list.Add(book);
            }
            return list;
        }

        public bool InsertBook(int idbook, string bookTitle, string authorName, string categoryBook, int quantityInStock, float purchasePrice, float sellingPrice, string status, DateTime? dateimport)
        {
            string dateImportString = dateimport.HasValue ? "'" + dateimport.Value.ToString("yyyy-MM-dd") + "'" : "NULL";
            string query = string.Format("INSERT INTO Book (idbook, bookTitle, authorName, categoryBook, quantityInStock, purchasePrice, sellingPrice, statusBook, dateImportBook) VALUES ({0}, N'{1}', N'{2}', N'{3}', {4}, {5}, {6}, '{7}', {8})", idbook, bookTitle, authorName, categoryBook, quantityInStock, purchasePrice, sellingPrice, status, dateImportString);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


        public bool UpdateBook(int idbook, string bookTitle, string authorName, string categoryBook, int quantityInStock, float purchasePrice, float sellingPrice, string status, DateTime? dateimport)
        {
            string query = string.Format("UPDATE Book SET bookTitle = N'{0}', authorName = N'{1}' ,categoryBook = N'{2}', quantityInStock = {3}, purchasePrice = {4}, sellingPrice = {5} statusBook = {6}, dateImportBook = {7} WHERE idbook = {8} ", bookTitle, authorName, categoryBook, quantityInStock, purchasePrice, sellingPrice, status, dateimport, idbook);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteBook(string bookTitle)
        {
            string query = string.Format("DELETE Book WHERE bookTitle = N'{0}'", bookTitle);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
