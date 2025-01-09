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
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();
        private void frmAnaForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_Gorevler
                                       select new
                                       {
                                              x.Aciklama,
                                              Personel=x.Tbl_Personel.Ad+x.Tbl_Personel.Soyad,
                                              x.Durum
                                       }).Where (y=>y.Durum==true).ToList();
            gridView1.Columns["Durum"].Visible = false;

            //Bugün Yapılan Görevler 
            DateTime bugun= DateTime.Parse(DateTime.Now.ToString());
            //MessageBox.Show(bugun.Tostring());
            gridControl2.DataSource=(from x in db.Tbl_GorevDetaylar
                                    select new
                                    {
                                        Görev=x.Tbl_Gorevler.Aciklama,
                                        x.Aciklama,
                                        x.Tarih
                                    }).Where(x=>x.Tarih==bugun).ToList();
            //Aktif Çağrı Listesi
            gridControl3.DataSource = (from x in db.Tbl_Cagrilar
                                       select new
                                       {
                                           x.Tbl_Firmalar.Ad,
                                           x.Konu,
                                           x.Tarih,
                                           x.Durum
                                       }).Where(x => x.Durum == true).ToList();
            gridView3.Columns["Durum"].Visible=false;

            //Fihrist komutları
            gridControl4.DataSource=(from x in db.Tbl_Firmalar
                                     select new
                                     {
                                         x.Ad,
                                         x.Telefon,
                                         x.Mail
                                     }).ToList();

            //Çağrı Grafikleri
            int aktif_cagrilar = db.Tbl_Cagrilar.Where(x => x.Durum == true).Count();
            int pasif_cagrilar = db.Tbl_Cagrilar.Where(x => x.Durum == false).Count();

            chartControl1.Series["Series 1"].Points.AddPoint("Aktif çağrılar", aktif_cagrilar);
            chartControl1.Series["Series 1"].Points.AddPoint("Pasif çağrılar", pasif_cagrilar);
        }
    }
}
