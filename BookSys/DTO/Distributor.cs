using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DTO
{
    public class Distributor
    {
        private int iddistributor;
        private string distributorname;
        private int phonenum;
        private string address;
        private float amountpaid;
        private float remaniningdebt;

        public int Iddistributor { get => iddistributor; set => iddistributor = value; }
        public string DistributorName { get => distributorname; set => distributorname = value; }
        public int Phonenum { get => phonenum; set => phonenum = value; }
        public string Address { get => address; set => address = value; }
        public float Amountpaid { get => amountpaid; set => amountpaid = value; }
        public float Remaniningdebt { get => remaniningdebt; set => remaniningdebt = value; }

        public Distributor(int iddistributor, string distributorname, int phonenum, string address, float amountpaid, float remaniningdebt)
        { 
            this.Iddistributor = iddistributor;
            this.DistributorName = distributorname;
            this.Phonenum = phonenum;
            this.Address = address;
            this.Amountpaid = amountpaid;
            this.Remaniningdebt = remaniningdebt;
            
        }

        public Distributor(DataRow row)
        {

            this.Iddistributor = (int)row["IdDistributor"];
            this.DistributorName = row["distributorName"].ToString();
            this.Phonenum = (int)row["phoneNum"];
            this.Address = row["address"].ToString();
            if (float.TryParse(row["amountPaid"].ToString(), out amountpaid))
            {
                this.Amountpaid = amountpaid;
            }
            else
            {
               
                this.Amountpaid = 0; 
                throw new InvalidCastException();
            }
            if (float.TryParse(row["remaniningDebt"].ToString(), out remaniningdebt))
            {
                this.Remaniningdebt = remaniningdebt;
            }
            else
            {

                this.Remaniningdebt = 0;
                throw new InvalidCastException();
            }


        }
    }
}
