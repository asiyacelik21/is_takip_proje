using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ıs_takip_proje.Entity;

namespace ıs_takip_proje.Formlar
{
    public partial class frmGorev : Form
    {
        public frmGorev()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbisTakipEntities db = new DbisTakipEntities();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Gorevler t=new Tbl_Gorevler();
            t.Aciklama=txtAciklama.Text;
            t.Durum = true;
            t.GorevAlan=int.Parse(lookUpEdit1.EditValue.ToString());
            t.Tarih=DateTime.Parse(txtTarih.Text);
            t.GorevVeren=int.Parse(txtGorevVeren.Text);
            db.Tbl_Gorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("GÖREV BAŞARILI BİR ŞEKİLDE TAMAMLANDI","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmGorev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.Tbl_Personel
                                select new
                                {
                                    x.Id,
                                   AdSoyad=x.Ad+" "+x.Soyad
                                }).ToList();
            lookUpEdit1.Properties.ValueMember = "Id";
            lookUpEdit1.Properties.DisplayMember = "AdSoyad";
            lookUpEdit1.Properties.DataSource = degerler;
        }
    }
}
