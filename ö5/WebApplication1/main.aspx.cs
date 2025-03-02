using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Oturum kontrolü
                if (Session["name"] == null)
                {
                    Response.Redirect("giris.aspx");
                }
                else
                {
                    GridViewDataLoad(); // Verileri GridView'e yükleyin
                }
            }
        }
        private void GridViewDataLoad()
        {
            string connectionString = "Server=HY; Database=HY; Trusted_Connection=True;";
            string query = @"
            SELECT 
                o.OgrenciNo, 
                CONCAT(o.name, ' ', o.surname) AS AdSoyad,
                o.email,
                p.ProjeAdi,
                p.Not_Dokuman,
                p.Not_TProje,
                p.Not_TFest,
                p.Not_Konferans,
                p.YukleyenID,
                p.Resim
            FROM kullanici o
            LEFT JOIN proje p ON o.kullaniciID = p.YukleyenID
            WHERE o.kullaniciTipi = 'Öğrenci'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Düzenlenen satırı alın
            GridViewRow row = GridView1.Rows[e.RowIndex];

            // DataKey'den birincil anahtar alanları alın
            string ogrenciNo = GridView1.DataKeys[e.RowIndex]["OgrenciNo"].ToString();
            string projeAdi = GridView1.DataKeys[e.RowIndex]["ProjeAdi"].ToString();
            // TextBox'lardan yeni değerleri alın
            string notDokuman = (row.FindControl("txtNotDokuman") as TextBox)?.Text ?? "";
            string notTProje = (row.FindControl("txtNotTProje") as TextBox)?.Text ?? "";
            string notTFest = (row.FindControl("txtNotTFest") as TextBox)?.Text ?? "";
            string notKonferans = (row.FindControl("txtNotKonferans") as TextBox)?.Text ?? "";

            // SQL sorgusu
            string query = @"
            UPDATE proje
            SET Not_Dokuman = @NotDokuman,
                Not_TProje = @NotTProje,
                Not_TFest = @NotTFest,
                Not_Konferans = @NotKonferans
            WHERE YukleyenID = (SELECT kullaniciID FROM kullanici WHERE OgrenciNo = @OgrenciNo) 
              AND ProjeAdi = @ProjeAdi";

            // Veritabanı bağlantısı ve güncelleme
            using (SqlConnection conn = new SqlConnection("Server=HY; Database=HY; Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);
                cmd.Parameters.AddWithValue("@ProjeAdi", projeAdi);
                cmd.Parameters.AddWithValue("@NotDokuman", notDokuman);
                cmd.Parameters.AddWithValue("@NotTProje", notTProje);
                cmd.Parameters.AddWithValue("@NotTFest", notTFest);
                cmd.Parameters.AddWithValue("@NotKonferans", notKonferans);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            // Düzenleme modundan çıkın ve GridView'i yeniden yükleyin
            GridView1.EditIndex = -1;
            GridViewDataLoad();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Yalnızca veri satırlarında işlem yapın (Header veya Footer'da değil)
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Oturumdaki kullanıcı tipi kontrolü
                string kullaniciTipi = Session["kullaniciTipi"]?.ToString();

                // Eğer kullanıcı tipi "Öğrenci" ise "Düzenle" butonunu gizle
                if (kullaniciTipi == "Öğrenci")
                {   
                    // GridView'deki CommandField'in Edit butonunu gizle
                    LinkButton editButton = e.Row.Cells[e.Row.Cells.Count - 1].Controls.OfType<LinkButton>()
                        .FirstOrDefault(btn => btn.CommandName == "Edit");

                    if (editButton != null)
                    {
                        editButton.Visible = false;
                    }

                    HyperLink hlPdf = e.Row.FindControl("hlPdf") as HyperLink;
                    if (hlPdf != null)
                    {
                        hlPdf.Visible = false;
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView drv = e.Row.DataItem as DataRowView;
                    HyperLink hlPdf = e.Row.FindControl("hlPdf") as HyperLink;
                    Label txtnot = e.Row.FindControl("txtnot") as Label;
                    if (hlPdf != null)
                    {
                        // FileDownload.aspx'e yönlendirme
                        hlPdf.NavigateUrl = $"FileDownload.aspx?id={drv["YukleyenID"]}"; // Veritabanı ID'sini ekleyin
                    }
                }
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid(); // GridView'i yeniden doldurun
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid(); // GridView'i yeniden doldurun
        }
        private void BindGrid()
        {
            string query = @"
            SELECT o.OgrenciNo, 
                    CONCAT(o.name, ' ', o.surname) AS AdSoyad,
                    o.email,
                    p.ProjeAdi,
                    p.Not_Dokuman,
                    p.Not_TProje,
                    p.Not_TFest,
                    p.Not_Konferans,
                    p.YukleyenID,
                    p.Resim
            FROM kullanici o
            LEFT JOIN proje p ON o.kullaniciID = p.YukleyenID
            WHERE o.kullaniciTipi = 'Öğrenci'";

            using (SqlConnection conn = new SqlConnection("Server=HY; Database=HY; Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}