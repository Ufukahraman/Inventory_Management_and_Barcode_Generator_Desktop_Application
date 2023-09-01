using proserv.Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace proserv
{
    public partial class EkleWindow : Window
    {
        private SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");
        
        public EkleWindow()
        {
            InitializeComponent();
            Load_grid lg = new Load_grid();
            lg.StokGrid(stokdatagrid, stok_tb.Text);
        }

        private void btn_iptal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ekle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Depo_Hareket (Stok_kodu, Stok_adi, barkod, islem_tarih, seri_no, adet, giris_firma, cikis_firma, raf, hareket_turu) VALUES (@stok_kodu, @stok_adi, @barkod, @islem_tarih, @seri_no, @adet, @giris_firma, @cikis_firma, @raf, @hareket_turu)", con))

                {
                    DataRowView selectedRow = stokdatagrid.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        string stokKodu = selectedRow["Stok Kodu"].ToString();
                        string stokAdi = selectedRow["Stok Adı"].ToString();
                        string barkodu = selectedRow["Barkod"].ToString();

                        cmd.Parameters.AddWithValue("@stok_kodu", stokKodu);
                        cmd.Parameters.AddWithValue("@stok_adi", stokAdi);
                        cmd.Parameters.AddWithValue("@barkod", barkodu);

                        stokkodu_txt.Text = stokKodu;
                        stokadi_txt.Text = stokAdi;
                        barkod_txt.Text = barkodu;

                    }





                    cmd.Parameters.AddWithValue("@islem_tarih", islemtarih_picker.SelectedDate);
                    cmd.Parameters.AddWithValue("@seri_no", serino_txt.Text);
                    cmd.Parameters.AddWithValue("@adet", (adet_txt.Text));
                    cmd.Parameters.AddWithValue("@giris_firma", girisfirma_txt.Text);
                    cmd.Parameters.AddWithValue("@cikis_firma", cıkısfirma_txt.Text);
                    cmd.Parameters.AddWithValue("@raf", raf_txt.Text);

                    if (hareketturu_cb.SelectedItem != null)
                    {
                        var selectedHareketTuru = (hareketturu_cb.SelectedItem as ComboBoxItem)?.Content?.ToString();
                        cmd.Parameters.AddWithValue("@hareket_turu", selectedHareketTuru);
                    }

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Başarıyla eklendi", "Kaydedildi", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger logger = new Logger();
                string aksiyon = " Ürün Ekleme işlemi"; // Burada aksiyonunuzu belirtin
                logger.Log(aksiyon);
                this.Close();

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
                string barkodu = selectedRow["Barkod"].ToString();


                stokkodu_txt.Text = stokKodu;
                stokadi_txt.Text = stokAdi;
                barkod_txt.Text = barkodu;

            }
        }
    }
}
