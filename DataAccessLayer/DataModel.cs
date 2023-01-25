using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel ()
        {
            con = new SqlConnection(ConnectionString.H2OCon);
            cmd= con.CreateCommand();
        }
        #region YÖNETİCİ METOTLARI
        public Yoneticiler YoneticiGiris(string mail,string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT (*) FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open ();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi>0)
                {
                    cmd.CommandText = "SELECT * FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader reader=cmd.ExecuteReader();  
                    Yoneticiler y=new Yoneticiler();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.Isim = reader.GetString(1);
                        y.Soyisim = reader.GetString(2);
                        y.Mail = reader.GetString(3);
                        y.Sifre = reader.GetString(4);
                        y.Telefon=reader.GetString(5);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
                
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Coin Kontrol

        public bool CoinKontrol (string isim)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM CoinKontrol WHERE Isim = @Isim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", isim);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi==0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
            finally
            {
                con.Close ();
            }
        }
        public bool CoinEkle (Coinler c)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Coinler(Isim,Max_Arz,CoinNick) VALUES (@Isim,@Max_Arz,@CoinNick)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isim", c.Isim);
                cmd.Parameters.AddWithValue("@Max_Arz", c.Max_Arz); 
                cmd.Parameters.AddWithValue("@CoinNick", c.CoinNick);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                return false;
                
            }
            finally { con.Close(); }
        }
        

        
        



        #endregion
    }
}
