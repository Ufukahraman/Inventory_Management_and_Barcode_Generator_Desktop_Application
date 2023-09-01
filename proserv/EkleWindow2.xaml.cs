using proserv.Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace proserv
{
    /// <summary>
    /// Interaction logic for EkleWindow2.xaml
    /// </summary>
    public partial class EkleWindow2 : Window
    {
        private SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");

        public EkleWindow2()
        {
            InitializeComponent();

        }

        private void btn_iptal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ekle_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                double giren = string.IsNullOrWhiteSpace(giren_txt.Text) ? 0 : double.Parse(giren_txt.Text);
                double cikan = string.IsNullOrWhiteSpace(cikan_txt.Text) ? 0 : double.Parse(cikan_txt.Text);
                double sayim = string.IsNullOrWhiteSpace(sayim_txt.Text) ? 0 : double.Parse(sayim_txt.Text);

                double anlik = giren + sayim - cikan;

                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Depo_Anlık (stok_kodu, stok_adi, barkod, Sayim, Giren_miktar, Cikan_miktar ,Anlık ,Konum ,Mikrostok ,Seri_no ,islem_tarih ,raf)" +
                    " VALUES (@stok_kodu, @stok_adi, @barkod, @Sayim, @Giren_miktar, @Cikan_miktar, @Anlık, @Konum, @Mikrostok, @Seri_no ,@islem_tarih ,@raf)", con))

                {
                    DataRowView selectedRow = stokdatagrid.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        string stokKodu = selectedRow["Stok Kodu"].ToString();
                        string stokAdi = selectedRow["Stok Adı"].ToString();
                        string barkod = selectedRow["barkod"].ToString();

                        cmd.Parameters.AddWithValue("@stok_kodu", stokKodu);
                        cmd.Parameters.AddWithValue("@stok_adi", stokAdi);
                        cmd.Parameters.AddWithValue("@barkod", barkod);
                    }

                    cmd.Parameters.AddWithValue("@Sayim", sayim_txt.Text);
                    cmd.Parameters.AddWithValue("@Seri_no", serino_txt.Text);
                    cmd.Parameters.AddWithValue("@islem_tarih", islemtarih_picker.SelectedDate);
                    cmd.Parameters.AddWithValue("@Giren_miktar", giren_txt.Text);
                    cmd.Parameters.AddWithValue("@Cikan_miktar", (cikan_txt.Text));
                    cmd.Parameters.AddWithValue("@Anlık", anlik);
                    cmd.Parameters.AddWithValue("@Konum", konum_txt.Text);
                    cmd.Parameters.AddWithValue("@Mikrostok", mikrostok_txt.Text);
                    cmd.Parameters.AddWithValue("@raf", raf_txt.Text);



                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Başarıyla eklendi", "Kaydedildi", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                Logger logger = new Logger();
                string aksiyon = "Stok Ekleme işlemi"; // Burada aksiyonunuzu belirtin
                logger.Log(aksiyon);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }





        private void stok_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load_grid lg = new Load_grid();
            lg.StokGrid(stokdatagrid, stok_tb.Text);
        }

        private void stokdatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = stokdatagrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                string stokKodu = selectedRow["Stok Kodu"].ToString();
                string stokAdi = selectedRow["Stok Adı"].ToString();
                string barkod = selectedRow["barkod"].ToString();

                stokkodu_txt.Text = stokKodu;
                stokadi_txt.Text = stokAdi;
                barkod_txt.Text = barkod;
            }
        }
    }
}
