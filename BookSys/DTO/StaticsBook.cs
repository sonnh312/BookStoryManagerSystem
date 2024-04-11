using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DTO
{
    public class StaticsBook
    {
        private int totalImport;
        private int totalExport;

        public int TotalImport { get => totalImport; set => totalImport = value; }
        public int TotalExport { get => totalExport; set => totalExport = value; }

        public StaticsBook(int totalImport, int totalExport)
        {
            this.TotalImport = totalImport;
            this.TotalExport = totalExport;
            
        }

        public StaticsBook(DataRow row)
        {
            this.TotalImport = (int)row["exportQuantity"];
            this.TotalExport = (int)row["importQuantity"];
            
        }
    }
}
