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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=DbMesajlasmaSistemi;Integrated Security=True");

        public string numara;

        void gelenkutusu()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select (AD+' '+SOYAD) AS GONDEREN,ALICI,BASLIK,ICERIK  from mesajlar inner join KISILER on MESAJLAR.GONDEREN=KISILER.NUMARA WHERE ALICI=" + numara, baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void gidenkutusu()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select GONDEREN,(AD+' '+SOYAD) AS ALICI,BASLIK,ICERIK  from mesajlar inner join KISILER on MESAJLAR.ALICI=KISILER.NUMARA  WHERE GONDEREN=" + numara, baglanti);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            gelenkutusu();
            gidenkutusu();

            //adsoyad çekme
            baglanti.Open();
            SqlCommand kmt1 = new SqlCommand("select AD,SOYAD from KISILER where NUMARA=" + numara, baglanti);
            SqlDataReader rd1 = kmt1.ExecuteReader();
            while (rd1.Read())
            {
                lblAdSoyad.Text = rd1[0] + " "+ rd1[1];
            }
            baglanti.Close();

        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into MESAJLAR(GONDEREN,ALICI,BASLIK,ICERIK) values(@e1,@e2,@e3,@e4)", baglanti);
            kmt.Parameters.AddWithValue("@e1", numara);
            kmt.Parameters.AddWithValue("@e2", mskAlıcı.Text);
            kmt.Parameters.AddWithValue("@e3", txtBaslık.Text);
            kmt.Parameters.AddWithValue("@e4",rchMesaj.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close() ;
            MessageBox.Show("Mesajınız gönderilmiştir");
            gidenkutusu();
        }

       
    }
}
