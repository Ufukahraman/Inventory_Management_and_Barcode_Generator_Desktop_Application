using proserv.Class;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace proserv.Ucontroller
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");
        public UserControl2()
        {
            InitializeComponent();
            cagır();
        }

        private void search_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            cagır();
        }
        public void cagır()
        {
            Load_grid lg = new Load_grid();
            string customQuery = "SELECT  [id] as ID,[Stok_kodu] AS [Stok Kodu],[Stok_adi]  AS [Stok Adı], barkod AS [Barkod], islem_tarih AS [İşlem Tarihi]," +
                "[Sayim] AS [Sayım], [Giren_miktar] AS [Giren Miktar],[Cikan_miktar] AS [Çıkan Miktar]," +
                "[Anlık] AS [Anlık Sayım], [Konum] , [Mikrostok], [Raf],[Seri_no] AS [Seri Numarası] FROM [VeribisCRM].[dbo].[Depo_Anlık]";
            lg.MainGrid(datagrid, customQuery, search_tb.Text);
        }

        private void btn_refresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cagır();
            search_tb.Clear();
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            // Verileri güncelleme formuna aktarma
            if (row != null)
            {
                DataRowView rowData = row.Item as DataRowView;

                if (rowData != null)
                {


                    // İşlemler başarılıysa Güncelleme formunu aç
                    GuncelleWindow2 guncelleWindow2 = new GuncelleWindow2();



                    // Formdaki TextBox'lara verileri aktarın
                    guncelleWindow2.id_txt.Text = rowData["ID"].ToString();
                    guncelleWindow2.stokkodu_txt.Text = rowData["Stok Kodu"].ToString();
                    guncelleWindow2.stokadi_txt.Text = rowData["Stok Adı"].ToString();
                    guncelleWindow2.barkod_txt.Text = rowData["Barkod"].ToString();
                    guncelleWindow2.islemtarih_txt.Text = rowData["İşlem Tarihi"].ToString();
                    guncelleWindow2.sayim_txt.Text = rowData["Sayım"].ToString();
                    guncelleWindow2.serino_txt.Text = rowData["Seri Numarası"].ToString();
                    guncelleWindow2.giren_txt.Text = rowData["Giren Miktar"].ToString();
                    guncelleWindow2.cikan_txt.Text = rowData["Çıkan Miktar"].ToString();
                    guncelleWindow2.konum_txt.Text = rowData["Konum"].ToString();
                    guncelleWindow2.mikrostok_txt.Text = rowData["Mikrostok"].ToString();
                    guncelleWindow2.raf_txt.Text = rowData["Raf"].ToString();


                    // Güncelleme formunu gösterin
                    guncelleWindow2.ShowDialog();

                }
            }

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
                SqlCommand cmd = new SqlCommand("DELETE FROM Depo_Anlık WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kayıt başarıyla silindi.", "Silindi", MessageBoxButton.OK, MessageBoxImage.Information);
                    Logger logger = new Logger();
                    string aksiyon = id + " numaralı stok silindi.";
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

        private void DataGridRow_Selected(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btn_ekle_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            EkleWindow2 ekleWindow2 = new EkleWindow2();

            ekleWindow2.Show();
        }

        private void search_tb_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            cagır();
        }
    }
}
