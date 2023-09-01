using proserv.Class;
using System.Data.SqlClient;
using System.Windows;

namespace proserv
{
    /// <summary>
    /// Interaction logic for GuncelleWindow2.xaml
    /// </summary>
    public partial class GuncelleWindow2 : Window
    {
        public GuncelleWindow2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");
        private void btn_kaydet_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Depo_Anlık SET Stok_kodu = @newstokkodu, Stok_adi = @newstokadi , barkod = @newbarkod, " +
                    " Seri_no = @newserino , giren_miktar = @newgiren , cikan_miktar = @newcikan , Anlık = @newanlik," +
                    "Konum = @newkonum , Mikrostok = @newmikro ,Sayim = @newsayim ,raf = @newraf WHERE id = @id", con))
                {
                    //DateTime islemTarihi = DateTime.Parse(islemtarih_txt.Text);
                    //string yeniIslemTarihi = islemTarihi.ToString("yyyy-MM-dd");

                    double giren = string.IsNullOrWhiteSpace(giren_txt.Text) ? 0 : double.Parse(giren_txt.Text);
                    double cikan = string.IsNullOrWhiteSpace(cikan_txt.Text) ? 0 : double.Parse(cikan_txt.Text);
                    double sayim = string.IsNullOrWhiteSpace(sayim_txt.Text) ? 0 : double.Parse(sayim_txt.Text);

                    double anlik = giren + sayim - cikan;


                    cmd.Parameters.AddWithValue("@id", id_txt.Text);
                    cmd.Parameters.AddWithValue("@newstokkodu", stokkodu_txt.Text);
                    cmd.Parameters.AddWithValue("@newstokadi", stokadi_txt.Text);
                    cmd.Parameters.AddWithValue("@newbarkod", barkod_txt.Text);
                    cmd.Parameters.AddWithValue("@newsayim", sayim_txt.Text);
                    cmd.Parameters.AddWithValue("@newserino", serino_txt.Text);
                   
                    cmd.Parameters.AddWithValue("@newanlik", anlik);
                    cmd.Parameters.AddWithValue("@newkonum", konum_txt.Text);
                    cmd.Parameters.AddWithValue("@newgiren", giren_txt.Text);
                    cmd.Parameters.AddWithValue("@newcikan", cikan_txt.Text);
                    cmd.Parameters.AddWithValue("@newmikro", mikrostok_txt.Text);
                    cmd.Parameters.AddWithValue("@newraf", raf_txt.Text);


                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri güncellendi", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        Logger logger = new Logger();
                        string aksiyon = id_txt.Text + "numaralı kaydın stok güncelleme işlemi"; // Burada aksiyonunuzu belirtin
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
            Logger logger = new Logger();
            string aksiyon = "Stok güncelleme işlemi iptal edildi"; // Burada aksiyonunuzu belirtin
            logger.Log(aksiyon);
        }



    }
}
