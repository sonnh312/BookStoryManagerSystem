using BookSys.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { StaffDAO.instance = value; }
        }
        public StaffDAO() { }

        public bool Login(string username, string password)
        {
            string query = "exec USP_LoginAccount @username , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }

        //update change pass 
        public bool UpdateAccount(string username, string displayname, string password, string newpassword)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @username , @displayname , @password , @newpassword", new object[] { username, displayname, password, newpassword });
            return result > 0;
        }
        public Staff GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Staff WHERE Username =N'" + username + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Staff(item);
            }
            return null;
        }


        public DataTable InfoStaff()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT (Username,Password,Displayname) FROM Staff");
        }
    }
}
