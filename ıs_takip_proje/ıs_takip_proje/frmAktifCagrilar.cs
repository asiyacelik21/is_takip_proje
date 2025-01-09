using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ıs_takip_proje.Entity;

namespace ıs_takip_proje
{
    public partial class frmAktifCagrilar : Form
    {
        public frmAktifCagrilar()
        {
            InitializeComponent();
        }

        private void frmAktifCagrilar_Load(object sender, EventArgs e)
        {
            DbisTakipEntities db = new DbisTakipEntities();
            var degerler=db.Tbl_Cagrilar.Where(x=>x.Durum==true).ToList();
            gridControl1.DataSource = degerler;
        }
    }
}
