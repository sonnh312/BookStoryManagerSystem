    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace BookSys.DTO
    {
    public class Book
    {
        private int idbook;
        private string booktitle;
        private string authorname;
        private string categorybook;
        private string status;
        private int quantityinstock;
        private float purchaseprice; 
        private float sellingprice;
        private DateTime? dateimport;

        public int Idbook { get => idbook; set => idbook = value; }
        public string Booktitle { get => booktitle; set => booktitle = value; }
        public string Authorname { get => authorname; set => authorname = value; }
        public string Categorybook { get => categorybook; set => categorybook = value; }
        public int Quantityinstock { get => quantityinstock; set => quantityinstock = value; }
        public float Purchaseprice { get => purchaseprice; set => purchaseprice = value; } 
        public float Sellingprice { get => sellingprice; set => sellingprice = value; } 
        public string Status { get => status; set => status = value; }
        public DateTime? ImportDate { get => dateimport; set => dateimport = value; }

        public Book(int idbook, string booktitle, string authorname, string categorybook, int quantityinstock, float purchaseprice, float sellingprice, string status, DateTime? dateimport) // Chuyển đổi từ int sang float
        {
            this.Idbook = idbook;
            this.Booktitle = booktitle;
            this.Authorname = authorname;
            this.Categorybook = categorybook;
            this.Quantityinstock = quantityinstock;
            this.Purchaseprice = purchaseprice;
            this.Sellingprice = sellingprice;
            this.Status = status;
            this.ImportDate = dateimport;
        }

        public Book(DataRow row)
        {

            this.Idbook = (int)row["IdBook"];
            this.Booktitle = row["bookTitle"].ToString();
            this.Authorname = row["authorName"].ToString();
            this.Categorybook = row["categoryBook"].ToString();
            this.Quantityinstock = (int)row["quantityInStock"];
            this.Purchaseprice = Convert.ToSingle(row["purchasePrice"]);
            this.Sellingprice = Convert.ToSingle(row["sellingPrice"]);
            this.Status = row["statusBook"].ToString();
            this.ImportDate = (DateTime?)row["dateImportBook"];
        }
    }
}
