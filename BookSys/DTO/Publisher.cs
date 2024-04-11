using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DTO
{
    public class Publisher
    {
        private int idpublisher;
        private string publishername;
        private string address;
        private int phonenum;
        private int accountnum;

        public int Idpublisher { get => idpublisher; set => idpublisher = value; }
        public string PublisherName { get => publishername; set => publishername = value; }
        public string Address { get => address; set => address = value; }
        public int Phonenum { get => phonenum; set => phonenum = value; }
        public int Accountnum { get => accountnum; set => accountnum = value; }

        public Publisher(int idpublisher, string publishername, string address, int phonenum, int accountnum)
        {

            this.Idpublisher = idpublisher;
            this.PublisherName = publishername;
            this.Address = address;
            this.Phonenum = phonenum;
            this.Accountnum = accountnum;

        }

        public Publisher(DataRow row)
        {
            this.Idpublisher = (int)row["IdPublisher"];
            this.PublisherName = row["publisherName"].ToString();
            this.Address = row["address"].ToString();
            this.Phonenum = (int)row["phoneNum"];
            this.Accountnum = (int)row["accountNum"];
        }
    }
}
