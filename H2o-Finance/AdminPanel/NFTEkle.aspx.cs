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
    public partial class NFTEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(tb_fiyat.Text.Trim()))
                {
                    if (dm.NFTKontrol (tb_isim.Text.Trim()))
                    {
                        NFT n = new NFT();
                        n.isim = tb_isim.Text;
                        n.fiyat=Convert.ToDecimal(tb_fiyat.Text);
                        if (fu_resim.HasFile)
                        {
                            FileInfo fi =new FileInfo(fu_resim.FileName);
                            if (fi.Extension==".jpg" || fi.Extension == ".png")
                            {
                                string uzanti = fi.Extension;
                                string isim=Guid.NewGuid().ToString();
                                n.resim = isim + uzanti;
                                fu_resim.SaveAs(Server.MapPath("~/AdminPanel/images/NftCoinImage/" + isim + uzanti));

                                if (dm.NFTEkle(n))
                                {
                                    pnl_basarili.Visible = true;
                                    pnl_basarisiz.Visible = false;
                                    tb_isim.Text = "";
                                    tb_fiyat.Text = "";
                                   
                                }
                                else
                                {
                                    pnl_basarili.Visible = false;
                                    pnl_basarisiz.Visible = true;
                                    lbl_mesaj.Text = "NFT Eklenirken Bir Hata Oluştu.";
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
                        lbl_mesaj.Text = "NFT daha önce eklenmiş.";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Fiyat Boş Bırakılamaz.";
                }

            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "NFT adı boş bırakılamaz.";
            }
        }
    }
}