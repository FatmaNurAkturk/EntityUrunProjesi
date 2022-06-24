using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityUrunProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategori = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = kategori;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Kategori t = new Tbl_Kategori();
            t.Ad = txtAd.Text;
            db.Tbl_Kategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var ktgr = db.Tbl_Kategori.Find(x);
            db.Tbl_Kategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(txtId.Text);
            var ktgr = db.Tbl_Kategori.Find(y);
            ktgr.Ad = txtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme YApıldı");
        }
    }
}
