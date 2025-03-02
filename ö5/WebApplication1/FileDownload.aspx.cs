using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FileDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Parametreyi al (örneğin, dosyanın ID'si)
            string id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                Response.StatusCode = 400; // Bad Request
                Response.Write("ID gerekli.");
                return;
            }
            // Veritabanından PDF dosyasını al (örnek kod)
            byte[] pdfData = GetPdfFromDatabase(id);

            if (pdfData != null)
            {
                // Tarayıcıya dosya gönder
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Dosya.pdf");
                Response.BinaryWrite(pdfData);
                Response.End();
            }
            else
            {
                Response.StatusCode = 404; // Not Found
                Response.Write("Dosya bulunamadı.");
            }
        }
        private byte[] GetPdfFromDatabase(string id)
        {
            // Veritabanı bağlantısı ve PDF bayt dizisinin alınması
            // Örnek:
            return new byte[] { }; // Gerçek PDF verisini döndürün
        }
    }
}
