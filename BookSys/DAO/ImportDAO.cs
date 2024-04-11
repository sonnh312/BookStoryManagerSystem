using BookSys.DAO;
using BookSys.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys
{
    public class ImportDAO
    {
        private static ImportDAO instance;

        public static ImportDAO Instance
        {
            get { if (instance == null) instance = new ImportDAO(); return ImportDAO.instance; }
            private set { ImportDAO.instance = value; }
        }


        private ImportDAO() { }
        //load
        public List<ImportTicket> LoadImportForm()
        {
            List<ImportTicket> list = new List<ImportTicket>();

            string query = "SELECT i.IdImportFrom,b.bookTitle,p.publisherName,p.address,quantityInStock,i.personRecipient,b.statusBook FROM dbo.Book AS b, dbo.ImportForm AS i,dbo.Publisher as p WHERE b.IdBook=i.IdBook AND p.IdPublisher=i.idpublisher";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ImportTicket import = new ImportTicket(row);
                list.Add(import);
            }

            return list;
        }
        public List<ImportTicket> LoadStatic()
        {
            List<ImportTicket> list = new List<ImportTicket>();

            string query = "SELECT COUNT(IdImportFrom) AS nm2 FROM ImportForm";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ImportTicket import = new ImportTicket(item);
                list.Add(import);
            }
            return list;
        }
        public List<ImportTicket> LoadForm()
        {
            List<ImportTicket> list = new List<ImportTicket>();

            string query = "SELECT * FROM ImportForm";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ImportTicket import = new ImportTicket(row);
                list.Add(import);
            }

            return list;
        }





        public bool InsertTicket(int idImportForm, DateTime? importDate, int idpublisher, string personRecipient, int idBook, int importQuantity, float totalAmount, string importNote)
        {
            string query = string.Format("INSERT INTO ImportForm (IdImportFrom , importDate , idpublisher , personRecipient , IdBook, importQuantity , totalAmount, importNote)VALUES({0} , N'{1}', {2} , N'{3}' , {4} , {5}, {6}, N'{7}' )", idImportForm, importDate,  idpublisher, personRecipient, idBook, importQuantity, totalAmount, importNote);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTicket(int idImportForm, DateTime? importDate, int idpublisher, string personRecipient, int idBook, int importQuantity, float totalAmount, string importNote)
        {
            string query = string.Format("UPDATE ImportForm SET importDate = N'{0}', idpublisher = {1} ,personRecipient = N'{2}', IdBook = {3}, importQuantity = {4}, totalAmount ={5}, importNote = N'{6}' WHERE IdImportFrom = {7} ", importDate, idpublisher, personRecipient, idBook, importQuantity, totalAmount, importNote, idImportForm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTicket(int IdImportFrom)
        {
            string query = string.Format("DELETE ImportForm WHERE IdImportFrom = {0}", IdImportFrom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0; 
        }
    }
}
