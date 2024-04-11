using BookSys.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DAO
{
    public class DistributorDAO
    {

        private static DistributorDAO instance;

        public static DistributorDAO Instance
        {
            get { if (instance == null) instance = new DistributorDAO(); return DistributorDAO.instance; }
            private set { DistributorDAO.instance = value; }
        }


        private DistributorDAO() { }
        
        public List<Distributor> LoadDtb()
        {
            List<Distributor> list = new List<Distributor>();

            string query = "SELECT * FROM dbo.Distributor";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Distributor dtbt = new Distributor(item);
                list.Add(dtbt);
            }
            return list;
        }
        public List<Distributor> GetListName()
        {
            List<Distributor> lsname = new List<Distributor>();
            string query = "SELECT distributorName FROM dbo.Distributor";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Distributor name = new Distributor(item);
                lsname.Add(name);
            }

            return lsname;
        }

        public List<Distributor> GetDtbByName(string name)
        {
            List<Distributor> list = new List<Distributor>();

            string query = string.Format("SELECT * FROM dbo.Distributor WHERE distributorName like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Distributor dtb = new Distributor(item);
                list.Add(dtb);
            }
            return list;
        }
        public bool InsertDtb(int iddistributor, string distributorName, int phoneNum, string address, float amountPaid, float remaniningDebt)
        {
            string query = string.Format("INSERT INTO Distributor (IdDistributor , distributorName , phoneNum , address , amountPaid , remaniningDebt)VALUES({0} ,N'{1}', {2} , N'{3}' , {4} , {5})", iddistributor, distributorName, phoneNum, address, amountPaid, remaniningDebt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateDtb(int iddistributor, string distributorName, int phoneNum, string address, float amountPaid, float remaniningDebt)
        {
            string query = string.Format("UPDATE Distributor SET distributorName = N'{0}', phoneNum = {1} , address = N'{2}', amountPaid = {3}, remaniningDebt = {4} WHERE IdDistributor = {5} ", distributorName, phoneNum, address, amountPaid, remaniningDebt, iddistributor);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteDtb(string distributorName)
        {
            string query = string.Format("DELETE Distributor WHERE distributorName = N'{0}'", distributorName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
