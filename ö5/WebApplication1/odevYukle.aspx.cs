using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class odevYukle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void btnResimYukle_Click(object sender, EventArgs e)
        {
            string BaglantiYolu = "Server=HY; Database=HY; Trusted_Connection=True";

            // SqlConnection kullanarak bağlantıyı aç
            SqlConnection Baglanti = new SqlConnection(BaglantiYolu);
            Baglanti.Open();

            // TextBox'lardan verileri al
            string ProjeAdı = txtproje.Text;
            string yukleyenID = Session["kullaniciID"]?.ToString();
            byte[] resim = fileUploadResim.FileBytes;

            string Sorgu = "INSERT INTO proje (ProjeAdi , YukleyenID , Resim) VALUES (@ProjeAdi, @KullaniciID, @Resim)";

            // SqlCommand nesnesi ile sorguyu çalıştır
            SqlCommand Komut = new SqlCommand(Sorgu, Baglanti);

            // Parametreleri ekle
            Komut.Parameters.AddWithValue("@ProjeAdi", ProjeAdı);
            Komut.Parameters.AddWithValue("@KullaniciID", yukleyenID);
            Komut.Parameters.AddWithValue("@Resim", resim);
            Komut.ExecuteNonQuery();

            Label1.Text = "işlem başarılı!";

            Baglanti.Close();
            Komut.Dispose();
        }
    }
}