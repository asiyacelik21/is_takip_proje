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

namespace ıs_takip_proje.Formlar
{
    public partial class frmGorevListesi : Form
    {
        public frmGorevListesi()
        {
            InitializeComponent();
        }
        DbisTakipEntities db=new DbisTakipEntities();
        private void frmGorevListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_Gorevler
                                       select new
                                       {
                                           x.Aciklama
                                       }).ToList();

            lblAktifGorev.Text=db.Tbl_Gorevler.Where(x=> x.Durum==true).Count().ToString();
            lblPasifGorev.Text = db.Tbl_Gorevler.Where(x => x.Durum == false).Count().ToString();
            lblToplamDepartman.Text = db.Tbl_Gorevler.Count().ToString();

            chartControl1.Series["Durum"].Points.AddPoint("Aktif Görevler",int.Parse(lblAktifGorev.Text));
            chartControl1.Series["Durum"].Points.AddPoint("Pasif Görevler",int.Parse(lblPasifGorev.Text));
            
        }
    }
}
