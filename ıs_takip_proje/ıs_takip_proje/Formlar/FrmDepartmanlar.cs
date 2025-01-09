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
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();

        void listele()
        {
           
            var degerler = (from x in db.Tbl_Departmanlar
                            select new
                            {
                                x.Id,
                                x.Ad
                            }).ToList();
            gridControl1.DataSource = degerler;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Departmanlar t=new Tbl_Departmanlar();
            t.Ad = txtAd.Text;
            db.Tbl_Departmanlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("DEPARTMAN BAŞARILI BİR ŞEKİLDE SİSTEME KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x=int.Parse(txtId.Text);
            var deger=db.Tbl_Departmanlar.Find(x);
            db.Tbl_Departmanlar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("DEPARTMAN SİLME İŞLEMİ BAŞARIYLA GERÇEKLEŞTİ","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text=gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtId.Text);
            var deger = db.Tbl_Departmanlar.Find(x);
            deger.Ad=txtAd.Text;
            db.SaveChanges();
            XtraMessageBox.Show("DEPARTMAN GÜNCELLEME İŞLEMİ BAŞARIYLA GERÇEKLEŞTİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {

        }
    }
}
