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
    public partial class frmPersonelİstatistik : Form
    {
        public frmPersonelİstatistik()
        {
            InitializeComponent();
        }
        DbisTakipEntities db=new DbisTakipEntities();


        private void btnPersonelİstatistk_Load(object sender, EventArgs e)
        {
            lblToplamDepartman.Text=db.Tbl_Departmanlar.Count().ToString();
            lblFirmaSayisi.Text = db.Tbl_Firmalar.Count().ToString();
            lblTolamPersonel.Text=db.Tbl_Personel.Count().ToString();
            lblAktifİs.Text=db.Tbl_Gorevler.Count(x=> x.Durum==true).ToString();
            lblPasifİs.Text=db.Tbl_Gorevler.Count(x=>x.Durum==false).ToString();
            lblSonGorev.Text = db.Tbl_Gorevler.OrderByDescending(x => x.Id).Select (x=>x.Aciklama).FirstOrDefault();
            lblSonGorevDetayi.Text= db.Tbl_Gorevler.OrderByDescending(x=> x.Id).Select(x=> x.Tarih).FirstOrDefault().ToString();
            lblİsYapilanSehir.Text=db.Tbl_Firmalar.Select(x=> x.İl).Distinct().Count().ToString();
            lblSektorSayisi.Text=db.Tbl_Firmalar.Select(x=> x.Sektor).Distinct().Count().ToString();
            DateTime bugun = DateTime.Today;
            lbl10.Text=db.Tbl_Gorevler.Count(x=>x.Tarih==bugun).ToString();
            var d1=db.Tbl_Gorevler.GroupBy(x=> x.GorevAlan).OrderByDescending(z=> z.Count()).Select(y=> y.Key).FirstOrDefault();
            lblAyinPersoneli.Text=db.Tbl_Personel.Where(x=> x .Id==d1).Select(y=>y.Ad+" "+y.Soyad).FirstOrDefault().ToString();
            lblAyinDepartmani.Text=db.Tbl_Departmanlar.Where(x=> x.Id==db.Tbl_Personel.Where(t=>t.Id==d1).Select(z=>z.Departman).FirstOrDefault()).Select(y=>y.Ad).FirstOrDefault().ToString();

        }
    }
}
