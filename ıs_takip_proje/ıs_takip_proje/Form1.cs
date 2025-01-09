using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ıs_takip_proje.Formlar;

namespace ıs_takip_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_departmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartmanlar frm=new Formlar.FrmDepartmanlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmPersoneller frm2 = new Formlar.frmPersoneller();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void btnPersonelİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Formlar.frmPersonelİstatistik frm3 = new Formlar.frmPersonelİstatistik();
            frm3.MdiParent = this;
            frm3.Show();
        }
        Formlar.frmGorevListesi frm4;
        private void btnGorevListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new Formlar.frmGorevListesi();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        private void btnGorevTanimla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmGorev fr = new Formlar.frmGorev();
            fr.Show();
        }

        private void frmGorevDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmGorevDetay fr=new Formlar.frmGorevDetay();
            fr.Show();
        }
        Formlar.frmAnaForm frm5;
        private void btnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           if(frm5== null || frm5.IsDisposed)
            {
                frm5=new Formlar.frmAnaForm();
                frm5.MdiParent = this;
                frm5.Show();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAktifCagrilar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
