using BookSys.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DAO
{
    public class ExportTicketDAO
    {
        private static ExportTicketDAO instance;

        public static ExportTicketDAO Instance
        {
            get { if (instance == null) instance = new ExportTicketDAO(); return ExportTicketDAO.instance; }
            private set { ExportTicketDAO.instance = value; }
        }


        private ExportTicketDAO() { }
        //load
        public List<ExportForm> LoadExportForm()
        {
            List<ExportForm> list = new List<ExportForm>();

            string query = "SELECT * FROM dbo.ExportForm";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ExportForm export = new ExportForm(item);
                list.Add(export);
            }
            return list;
        }
        public List<ExportForm> LoadListBookInf()
        {
            List<ExportForm> list = new List<ExportForm>();

            string query = "SELECT b.bookTitle,b.categoryBook  FROM Book AS b, Distributor AS d,ExportForm as ex  WHERE b.IdBook = ex.IdBook  AND ex.IdDistributor = d.IdDistributor AND b.quantityInStock>0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ExportForm export = new ExportForm(item);
                list.Add(export);
            }
            return list;
        }
        public List<ExportForm> LoadStatic()
        {
            List<ExportForm> list = new List<ExportForm>();

            string query = "SELECT COUNT(idExportForm) AS nm FROM ExportForm";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ExportForm export = new ExportForm(item);
                list.Add(export);
            }
            return list;
        }
        public bool InsertTicket(int idExportForm, DateTime? exportDate, int idDistributor, string personDelivering, int idBook, int exportQuantity, float totalAmount)
        {
            string query = string.Format("INSERT INTO ExportFrom (idExportForm , exportDate , idDistributor , personDelivering , idBook, exportQuantity , totalAmount)VALUES({0} , {1}, N'{2}' , N'{3}' , {4} , {5}, {6} )", idExportForm , exportDate , idDistributor  , personDelivering , idBook , exportQuantity , totalAmount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTicket(int idExportForm, DateTime? exportDate, int idDistributor, string personDelivering, int idBook, int exportQuantity, float totalAmount)
        {
            string query = string.Format("UPDATE ExportFrom SET exportDate = {0}, idDistributor = {1} ,personDelivering = N'{2}', idBook = {3}, exportQuantity = {4}, totalAmount ={5} WHERE idExportForm = {6} ", exportDate, idDistributor, personDelivering, idBook, exportQuantity, totalAmount, idExportForm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTicket(string idExportForm)
        {
            string query = string.Format("DELETE ExportFrom WHERE idExportForm = {0}", idExportForm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
