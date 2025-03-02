using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void kytbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("kayit.aspx");
        }
        protected void girisbtn_Click(object sender, EventArgs e)
        {
            bool kullaniciBulundu = false;
            String email = girismail.Text;
            String password = girissifre.Text;

            // Sql Server için bağlantı string'i
            String BaglantiYolu = "Server=HY; Database=HY; Integrated Security=True";
            // SqlConnection kullanılıyor
            SqlConnection Baglanti = new SqlConnection(BaglantiYolu);
            Baglanti.Open();
            // Kullanıcı adı ve şifre ile sorgulama yapılıyor
            string Sorgu = "SELECT * FROM kullanici WHERE email=@email AND password=@password";

            SqlCommand Komut = new SqlCommand(Sorgu, Baglanti);
            Komut.Parameters.AddWithValue("@email", email);
            Komut.Parameters.AddWithValue("@password", password);
            SqlDataReader Okuyucu = Komut.ExecuteReader();

            // Kullanıcı var mı kontrol ediliyor
            while (Okuyucu.Read())
            {
                // Kullanıcı bilgileri oturuma kaydediliyor
                Session["name"] = Okuyucu["name"].ToString();
                Session["surname"] = Okuyucu["surname"].ToString();
                Session["kullaniciID"] = Okuyucu["kullaniciID"].ToString();
                Session["kullaniciTipi"] = Okuyucu["kullaniciTipi"].ToString();
                Session["OgrenciNo"] = Okuyucu["OgrenciNo"].ToString();

                lblMessage1.Text = "Giriş başarılı!";
                kullaniciBulundu = true;

                break;  // Kullanıcı bulunduğunda döngüyü sonlandırıyoruz
            }
            // Kullanıcı bulunamazsa hata mesajı gösteriliyor
            if (!kullaniciBulundu)
            {
                lblMessage2.Text = "Kullanıcı adı veya şifre yanlış!";
            }
            else
            {
                // Eğer kullanıcı bulunursa 1 saniye sonra yönlendirme işlemi yapılır
                ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                    "setTimeout(function(){ window.location = 'main.aspx'; }, 1000);", true);
            }
            // Bağlantıyı kapatıyoruz
            Baglanti.Close();
        }
    }
}