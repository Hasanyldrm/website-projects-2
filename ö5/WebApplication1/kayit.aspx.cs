using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class kayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void kytbtn_Click(object sender, EventArgs e)
        {
            //Bağlantıyı Kur (SQL Server)
            string BaglantiYolu = "Server=HY; Database=HY; Trusted_Connection=True";

            // SqlConnection kullanarak bağlantıyı aç
            SqlConnection Baglanti = new SqlConnection(BaglantiYolu);
            Baglanti.Open();

            // TextBox'lardan verileri al
            string Ad1 = kytisim.Text;
            string Soyad1 = kytsoyisim.Text;
            string mail1 = kytmail.Text;
            string sifre1 = kytsifre.Text;
            string kullaniciTipi1 = kullaniciTipi.SelectedValue;
            string ogrenciNo = txtOgrenciNo.Text;

            if (kullaniciTipi1 == "0")
            {
                // Kullanıcı tipi seçilmedi
                Response.Write("<script>alert('Lütfen kullanıcı tipi seçiniz!');</script>");

            }
            else
            {
                // SQL sorgusu
                string Sorgu = "INSERT INTO kullanici (name, surname, email, password, kullaniciTipi, OgrenciNo) VALUES (@name, @surname, @email, @password, @kullaniciTipi, @OgrenciNo)";

                // SqlCommand nesnesi ile sorguyu çalıştır
                SqlCommand Komut = new SqlCommand(Sorgu, Baglanti);

                // Parametreleri ekle
                Komut.Parameters.AddWithValue("@name", Ad1);
                Komut.Parameters.AddWithValue("@surname", Soyad1);
                Komut.Parameters.AddWithValue("@email", mail1);
                Komut.Parameters.AddWithValue("@password", sifre1);
                Komut.Parameters.AddWithValue("@kullaniciTipi", kullaniciTipi1);
                Komut.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);
                // Veritabanına veri ekle
                Komut.ExecuteNonQuery();

                lblMessage1.Text = "Kayıt başarılı!";

                Baglanti.Close();
                Komut.Dispose();
                ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                "setTimeout(function(){ window.location = 'main.aspx'; }, 1000);", true);
            }
        }
        protected void kullaniciTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen değeri al
            string secim = kullaniciTipi.SelectedValue;

            // Öğrenci seçildiğinde TextBox'ı göster
            if (secim == "Öğrenci") // "Öğrenci" seçilmiş
            {
                txtOgrenciNo.Visible = true;
            }
            else
            {
                txtOgrenciNo.Visible = false;
            }
        }
    }
}