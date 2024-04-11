using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DTO
{
    public class ExportForm
    {
        private int idExportForm;
        private DateTime? exportDate;
        private int idDistributor;
        private string personDelivering;
        private int idBook;
        private int exportQuantity;
        private float totalAmount;

        public int IdExportForm { get => idExportForm; set => idExportForm = value; }
        public DateTime? ExportDate { get => exportDate; set => exportDate = value; }
        public int IdDistributor { get => idDistributor; set => idDistributor = value; }
        public string PersonDelivering { get => personDelivering; set => personDelivering = value; }
        public int IdBook { get => idBook; set => idBook = value; }
        public int ExportQuantity { get => exportQuantity; set => exportQuantity = value; }
        public float TotalAmount { get => totalAmount; set => totalAmount = value; }

        public ExportForm(int idExportForm, DateTime? exportDate, int idDistributor, string personDelivering, int idBook, int exportQuantity, float totalAmount)
        {

            this.IdExportForm = idExportForm;
            this.ExportDate = exportDate;
            this.IdDistributor = idDistributor;
            this.PersonDelivering = personDelivering;
            this.IdBook = idBook;
            this.ExportQuantity = exportQuantity;
            this.TotalAmount = totalAmount;
        }

        public ExportForm(DataRow row)
        {
            
            this.IdExportForm = (int)row["idExportForm"];
            
            this.ExportDate = (DateTime?)row["exportDate"];
            this.IdDistributor = (int)row["IdDistributor"];
            this.PersonDelivering = row["personDelivering"].ToString();
            this.IdBook = (int)row["IdBook"];
            this.ExportQuantity = (int)row["exportQuantity"];
            float totalAmount;
            if (float.TryParse(row["totalAmount"].ToString(), out totalAmount))
            {
                this.TotalAmount = totalAmount;
            }
            else
            {
                
                this.TotalAmount = 0; 
                throw new InvalidCastException("");
            }
        }
    }
}
