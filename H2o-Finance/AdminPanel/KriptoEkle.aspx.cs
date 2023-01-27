using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H2o_Finance.AdminPanel
{


    public partial class KriptoEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(tb_arz.Text.Trim()))
                {
                    if (dm.VeriKontrol(tb_isim.Text.Trim()))
                    {
                        Coinler c = new Coinler();
                        c.Isim = tb_isim.Text;
                        c.CoinNick = tb_nick.Text;
                        c.Max_Arz = Convert.ToInt32(tb_arz.Text);
                        if (fu_resim.HasFile)
                        {
                            FileInfo fi = new FileInfo(fu_resim.FileName);
                            if (fi.Extension == ".jpg" || fi.Extension == ".png")
                            {
                                string uzanti = fi.Extension;
                                string isim = Guid.NewGuid().ToString();
                                c.Resim = isim + uzanti;
                                fu_resim.SaveAs(Server.MapPath("~/AdminPanel/images/NftCoinImage/" + isim + uzanti));

                                if (dm.CoinEkle(c))
                                {
                                    pnl_basarili.Visible = true;
                                    pnl_basarisiz.Visible = false;
                                    tb_isim.Text = "";
                                    tb_nick.Text = "";
                                    tb_arz.Text = "";
                                }
                                else
                                {

                                    pnl_basarili.Visible = false;
                                    pnl_basarisiz.Visible = true;
                                    lbl_mesaj.Text = "Kripto Eklenirken Bir Hata Oluştu.";
                                }
                            }
                            else
                            {
                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                            }
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Resim Ekleyiniz.";
                        }

                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kripto daha önce eklenmiş.";
                    }


                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Max Arz Boş Bırakılamaz.";
                }
            }
                
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kripto adı boş bırakılamaz.";
            }
        }
    }
}