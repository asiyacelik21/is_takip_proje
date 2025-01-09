using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ıs_takip_proje.Entity;

namespace ıs_takip_proje.Formlar
{
    public partial class frmPersoneller : Form
    {
        public frmPersoneller()
        {
            InitializeComponent();
        }
        DbisTakipEntities db=new DbisTakipEntities();

        void personeller()
        {
            var degerler = from x in db.Tbl_Personel
                           select new
                           {
                               x.Id,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               Departman=x.Tbl_Departmanlar.Ad,
                               x.Durum
                           };
            gridControl1.DataSource = degerler. Where(x=>x.Durum==true) .ToList();
        }
        private void frmPersoneller_Load(object sender, EventArgs e)
        {
           personeller();
            var departmanlar = (from x in db.Tbl_Departmanlar
                                select new
                                {
                                    x.Id,
                                    x.Ad,
                                }).ToList();
            lookUpEdit1.Properties.ValueMember = "Id";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;
          
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Personel t=new Tbl_Personel();
            t.Ad=txtAd.Text;
            t.Soyad=txtSoyad.Text;
            t.Mail=txtMail.Text;
            t.Gorsel=txtGörsel.Text;
            t.Departman=int.Parse(lookUpEdit1.EditValue.ToString());
            db.Tbl_Personel.Add(t);
                db.SaveChanges();
            XtraMessageBox.Show("YENİ PERSONEL KAYDI BAŞARILI BİR ŞEKİLDE GERÇEKLEŞTİ","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(txtId.Text);
            var deger=db.Tbl_Personel.Find(x);
            deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("PERSONEL BAŞARILI BİR ŞEKİLDE SİLİNDİ ,SİLİNEN PERSONELLER LİSTESİNDEN TÜM SİLİNMİŞ PERSONEL BİLGİLERİNE ULAŞABİLİRSİNİZ","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            personeller();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text=gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            //txtGorsel.Text=gridView1.GetFocusedRowCellValue("Gorsel").ToString();
            lookUpEdit1.Text= gridView1.GetFocusedRowCellValue("Departman").ToString();

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x=int.Parse(txtId.Text);
            var deger = db.Tbl_Personel.Find(x);
            deger.Ad=txtAd.Text;
            deger.Soyad=txtSoyad.Text;
            deger.Mail=txtMail.Text;
            deger.Gorsel=txtGörsel.Text;
            deger.Departman=int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("PERSONEL BAŞARILI BİR ŞEKİLDE GÜNCELLENDİ","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Question);
            personeller();
        }
    }
}
