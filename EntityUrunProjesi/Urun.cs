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
    public partial class Urun : Form
    {
        public Urun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.UrunAd = txtUrunAd.Text;
            t.Marka = txtMarka.Text;
            t.Stok = short.Parse(txtStok.Text);
            t.Kategori = int.Parse(comboBox1.Text);
            t.Fiyat = decimal.Parse(txtFiyat.Text);
            t.Durum = true;
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("ürün eklendi");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.Urunİd,
                                            x.UrunAd,
                                            x.Marka,
                                            x.Stok,
                                            x.Fiyat,
                                            x.Tbl_Kategori.Ad,
                                            x.Durum,
                                        }
                                        
                                        ).ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var urun = db.Tbl_Urun.Find(x);
            db.Tbl_Urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var urun = db.Tbl_Urun.Find(x);
            urun.UrunAd = txtUrunAd.Text;
            urun.Stok = short.Parse(txtStok.Text);
            urun.Marka = txtMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void Urun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Kategori
                               select new
                               {
                                   x.Id,
                                   x.Ad,
                               }
                              ).ToList();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Ad";
            comboBox1.DataSource = kategoriler;
        }
    }
}
