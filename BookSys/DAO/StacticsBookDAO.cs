using System;
using BookSys.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DAO
{
    public class StacticsBookDAO
    {
        private static StacticsBookDAO instance;

        public static StacticsBookDAO Instance
        {
            get { if (instance == null) instance = new StacticsBookDAO(); return StacticsBookDAO.instance; }
            set { StacticsBookDAO.instance = value; }
        }

        private StacticsBookDAO() { }
       
    }
}
