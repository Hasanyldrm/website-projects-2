using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Oturum kontrolü
                if (Session["name"] != null)
                {
                    // Oturumdaki bilgileri Label kontrollerine yükle
                    lblIsim.Text = Session["name"].ToString();
                    lblSoyisim.Text = Session["surname"].ToString();
                    lblKullaniciTipi.Text = Session["kullaniciTipi"].ToString();
                    lblOkulNo.Text = Session["OgrenciNo"].ToString();
                }
            }
        }
        protected void OturumKapat_Click(object sender, EventArgs e)
        {
            // Oturumu temizle
            Session.Clear();
            Session.Abandon();

            // Giriş sayfasına yönlendir
            Response.Redirect("giris.aspx");
        }

        protected void btnProjeYukle_Click(object sender, EventArgs e)
        {
            Response.Redirect("odevYukle.aspx");
        }

        protected void btndonus_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }
    }
}