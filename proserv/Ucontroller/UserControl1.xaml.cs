using proserv.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proserv.Ucontroller
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");
        public UserControl1()
        {
            InitializeComponent();
            cagır();
            

        }
        //veritabanı bağlantısı yapar ve sorgu yazar aynı zamanda sıralı arama fonksiyonu içerir
        private void search_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            cagır();
        }

        public void cagır()


        {
            Load_grid lg = new Load_grid();
            string customQuery = " SELECT id as [ID], Stok_kodu as [Stok Kodu], Stok_adi as [Stok Adı], Barkod," +
                "islem_tarih as [İşlem Tarihi]," +
                "adet as [Adet],giris_firma as [Giriş Firma],cikis_firma as [Çıkış Firma]" +
                ",hareket_turu as [Hareket Türü], raf as [Raf],seri_no as [Seri Numarası] FROM Depo_Hareket";

            lg.MainGrid(datagrid, customQuery, search_tb.Text);
        }
         // ekle güncelle sil
        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {

            EkleWindow ekleWindow = new EkleWindow();

            ekleWindow.Show();
        }



        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)datagrid.SelectedItem;

            if (selectedRow == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int id = (int)selectedRow["ID"];

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Depo_Hareket WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kayıt başarıyla silindi.", "Silindi", MessageBoxButton.OK, MessageBoxImage.Information);
                    Logger logger = new Logger();
                    string aksiyon = id + " numaralı ürün silindi "; // Burada aksiyonunuzu belirtin
                    logger.Log(aksiyon);

                }
                else
                {
                    MessageBox.Show("Kayıt silme işlemi başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
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





        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            // Verileri güncelleme formuna aktarma
            if (row != null && row.IsSelected)
            {
                DataRowView rowData = row.Item as DataRowView;

                if (rowData != null)
                {


                    // İşlemler başarılıysa Güncelleme formunu aç
                    GuncelleWindow guncelleWindow = new GuncelleWindow();



                    // Formdaki TextBox'lara verileri aktarın
                    guncelleWindow.id_txt.Text = rowData["ID"].ToString();
                    guncelleWindow.stokadı_txt.Text = rowData["Stok Kodu"].ToString();
                    guncelleWindow.stokkodu_txt.Text = rowData["Stok Adı"].ToString();
                    guncelleWindow.islemtarihi_txt.Text = rowData["İşlem Tarihi"].ToString();
                    guncelleWindow.serino_txt.Text = rowData["Seri Numarası"].ToString();
                    guncelleWindow.adet_txt.Text = rowData["Adet"].ToString();
                    guncelleWindow.girisfirma_txt.Text = rowData["Giriş Firma"].ToString();
                    guncelleWindow.cıkısfirma_txt.Text = rowData["Çıkış Firma"].ToString();
                    guncelleWindow.hareketturu_txt.Text = rowData["Hareket Türü"].ToString();
                    guncelleWindow.raf_txt.Text = rowData["Raf"].ToString();


                    // Güncelleme formunu gösterin
                    guncelleWindow.ShowDialog();

                }
            }

        }

        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            search_tb.Clear();
            cagır();
        }
        public void filtrecikis()
        {
            Load_grid lg = new Load_grid();
            string customQuery = "select * from Depo_Hareket where hareket_turu = 'çıkış'";

            lg.MainGrid(datagrid, customQuery);
        }
        public void filtregiris()
        {
            Load_grid lg = new Load_grid();
            string customQuery = "select * from Depo_Hareket where hareket_turu = 'giriş'";

            lg.MainGrid(datagrid, customQuery);
        }

        private void cb_secim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedValue = (cb_secim.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if(selectedValue == "Tümü")
            {
                cagır();
            }
            else if (selectedValue == "Çıkış")
            {
                filtrecikis();
            }
            else
            {
                filtregiris();
            }

        }
    }
}
