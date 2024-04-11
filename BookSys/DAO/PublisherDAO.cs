using BookSys.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DAO
{
    public class PublisherDAO
    {
        private static PublisherDAO instance;

        public static PublisherDAO Instance
        {
            get { if (instance == null) instance = new PublisherDAO(); return PublisherDAO.instance; }
            private set { PublisherDAO.instance = value; }
        }


        private PublisherDAO() { }
        //load
        public List<Publisher> LoadPub()
        {
            List<Publisher> list = new List<Publisher>();

            string query = "SELECT * FROM dbo.Publisher";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Publisher pub = new Publisher(item);
                list.Add(pub);
            }
            return list;
        }

        public bool InsertPub(int idpublisher, string publishername, string address, int phonenum, int accountnum)
        {
            string query = string.Format("INSERT INTO Publisher (IdPublisher , publisherName , address , phoneNum , accountNum)VALUES({0} , N'{1}', N'{2}' , {3} , {4})",  idpublisher,  publishername,  address,  phonenum,  accountnum);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdatePub(int idpublisher, string publishername, string address, int phonenum, int accountnum)
        {
            string query = string.Format("UPDATE Publisher SET publisherName = N'{0}', address = N'{1}' , phoneNum = {2}, accountNum = {3} WHERE idpublisher = {4} ", publishername, address, phonenum, accountnum, idpublisher);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeletePub(string publisherName)
        {
            string query = string.Format("DELETE Publisher WHERE publisherName = N'{0}'", publisherName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
