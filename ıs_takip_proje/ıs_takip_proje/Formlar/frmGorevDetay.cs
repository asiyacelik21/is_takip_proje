using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using ıs_takip_proje.Entity;
using System.Data.Entity.Core.Common.CommandTrees;

namespace ıs_takip_proje.Formlar
{
    public partial class frmGorevDetay : Form
    {
        public frmGorevDetay()
        {
            InitializeComponent();
        }
        DbisTakipEntities db = new DbisTakipEntities();

        private void frmGorevDetay_Load(object sender, EventArgs e)
        {
            db.Tbl_GorevDetaylar.Load();
            bindingSource1.DataSource = db.Tbl_GorevDetaylar.Local;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }

        private void görevDetaySilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }
    }
}
