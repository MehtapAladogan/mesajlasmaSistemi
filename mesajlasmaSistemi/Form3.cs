using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mesajlasmaSistemi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=DbMesajlasmaSistemi;Integrated Security=True");

        private void btnKayıtOl_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into KISILER(AD,SOYAD,NUMARA,SIFRE) values(@e1,@e2,@e3,@e4)", baglanti);
            kmt.Parameters.AddWithValue("@e1", txtAd.Text);
            kmt.Parameters.AddWithValue("@e2", txtSoyad.Text);
            kmt.Parameters.AddWithValue("@e3", mskNumara.Text);
            kmt.Parameters.AddWithValue("@e4", txtSifre.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt işleminiz tamamlandı");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int hesapno = rastgele.Next(1000, 10000);
            mskNumara.Text = hesapno.ToString();
        }
    }
}
