using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mesajlasmaSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=DbMesajlasmaSistemi;Integrated Security=True");

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from KISILER where numara=@p1 and sıfre =@p2", baglanti);
            kmt.Parameters.AddWithValue("@p1", mskNumara.Text);
            kmt.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader reader = kmt.ExecuteReader();
            if (reader.Read())
            {
                Form2 frm = new Form2();
                frm.numara = mskNumara.Text;
                frm.Show();
                
            }
            else
            {
                MessageBox.Show("Numara veya şifre hatalı");
            }
            baglanti.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}
