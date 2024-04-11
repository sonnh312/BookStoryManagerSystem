using BookSys.DAO;
using BookSys.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSys
{
    public partial class fStatics : Form
    {
        public fStatics()
        {
            InitializeComponent();
            Loaddata();
        }
        void Loaddata()
        {
            List<ExportForm> list1 = ExportTicketDAO.Instance.LoadStatic();
            chart2.DataSource = list1;
            List<ImportTicket> list2 = ImportDAO.Instance.LoadStatic();
            chart3.DataSource = list2;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
