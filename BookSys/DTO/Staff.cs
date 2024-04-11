using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DTO
{
    public class Staff
    {
        private string username;
        private string password;
        private string displayname;
        private string role;
        private int type;

        public string Username { get => username; set => username = value; }
        public string Displayname { get => displayname; set => displayname = value; }
        public string Role { get => role; set => role = value; }
        public int Type { get => type; set => type = value; }
        public string Password { get => password; set => password = value; }
        
        public Staff(string username, string displayname, string role, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Displayname = displayname;
            this.Role = role;
            this.Type = Type;
        }

        public Staff(DataRow row)
        {
            this.Username = row["Username"].ToString();
            this.Password = row["Password"].ToString();
            this.Displayname = row["Displayername"].ToString();
            this.Role = row["Role"].ToString();
            this.Type = (int)row["Type"];
        }
    }
}
