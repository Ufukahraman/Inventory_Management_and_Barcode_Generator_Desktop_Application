using proserv.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace proserv
{
    /// <summary>
    /// Interaction logic for GuncelleWindow.xaml
    /// </summary>
    public partial class GuncelleWindow : Window
    {
        public GuncelleWindow()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");
        private void btn_kaydet_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Depo_Hareket SET Stok_kodu = @yenistokkodu, Stok_adi = @newstokadi , " +
                    "islem_tarih = @newislemtarihi , seri_no = @newserino , adet = @newadet , giris_firma = @newgirisfirma ," +
                    "cikis_firma = @newcikisfirma , hareket_turu = @newhareketturu , raf = @newraf WHERE id = @id", con))
                {
                    DateTime islemTarihi = DateTime.Parse(islemtarihi_txt.Text);
                    string yeniIslemTarihi = islemTarihi.ToString("yyyy-MM-dd");

                    cmd.Parameters.AddWithValue("@id", id_txt.Text);
                    cmd.Parameters.AddWithValue("@yenistokkodu", stokkodu_txt.Text);
                    cmd.Parameters.AddWithValue("@newstokadi", stokadı_txt.Text);
                    cmd.Parameters.AddWithValue("@newislemtarihi", yeniIslemTarihi);
                    cmd.Parameters.AddWithValue("@newserino", serino_txt.Text);
                    cmd.Parameters.AddWithValue("@newadet", adet_txt.Text);
                    cmd.Parameters.AddWithValue("@newgirisfirma", girisfirma_txt.Text);
                    cmd.Parameters.AddWithValue("@newcikisfirma", cıkısfirma_txt.Text);
                    cmd.Parameters.AddWithValue("@newhareketturu", hareketturu_txt.Text);
                    cmd.Parameters.AddWithValue("@newraf", raf_txt.Text);


                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri güncellendi", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        Logger logger = new Logger();
                        string aksiyon = id_txt.Text + " numaralı kaydın Güncelleme işlemi "; // Burada aksiyonunuzu belirtin
                        logger.Log(aksiyon);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_iptal_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

      
        
    }
}
