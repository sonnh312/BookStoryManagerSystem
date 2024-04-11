using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSys.DTO
{
    public class ImportTicket
    {
        private int idImportForm;
        private DateTime? importDate;
        private int idpublisher;
        private string personRecipient;
        private int idBook;
        private int importQuantity;
        private float totalAmount;
        private string importNote;

        public int IdImportForm { get => idImportForm; set => idImportForm = value; }
        public DateTime? ImportDate { get => importDate; set => importDate = value; }
        public int Idpublisher { get => idpublisher; set => idpublisher = value; }
        public string PersonRecipient { get => personRecipient; set => personRecipient = value; }
        public int IdBook { get => idBook; set => idBook = value; }
        public float TotalAmount { get => totalAmount; set => totalAmount = value; }
        public string ImportNote { get => importNote; set => importNote = value; }
        public int ImportQuantity { get => importQuantity; set => importQuantity = value; }

        public ImportTicket(int idImportForm, DateTime? importDate, int idpublisher, string personRecipient, int idBook, int importQuantity, float totalAmount, string importNote)
        {

            this.IdImportForm = idImportForm;
            this.ImportDate = importDate;
            this.Idpublisher = idpublisher;
            this.PersonRecipient = personRecipient;
            this.IdBook = idBook;
            this.ImportQuantity = importQuantity;
            this.TotalAmount = totalAmount;
            this.ImportNote = importNote;
        }

        public ImportTicket(DataRow row)
        {
            this.IdImportForm = (int)row["IdImportFrom"];
            this.ImportDate = (DateTime?)row["importDate"];
            this.PersonRecipient = row["personRecipient"].ToString();
            this.IdBook = (int)row["IdBook"];
            this.ImportQuantity = (int)row["importQuantity"];
            float totalAmount;
            if (float.TryParse(row["totalAmount"].ToString(), out totalAmount))
            {
                this.TotalAmount = totalAmount;
            }
            else
            {
                
                this.TotalAmount = 0; 
                throw new InvalidCastException();
            }
            this.ImportNote = row["importNote"].ToString();

        }
    }
}
