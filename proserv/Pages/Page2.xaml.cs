using proserv.Class;
using System;
using System.Collections.Generic;
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

namespace proserv.Pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private Veridepo _viewModel;
        private SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");
       
        public Page2(Veridepo veridepo)
        {
            InitializeComponent();

            _viewModel = veridepo;

            if (!string.IsNullOrEmpty(_viewModel.Veri5))
            {
                // markagrup seçiliyse
               
                Load_grid lg = new Load_grid();
                string markagrup = _viewModel.Veri5;
                lg.StokGrid(sayimdatagrid, markagrup);
            }
            else if (!string.IsNullOrEmpty(_viewModel.Veri6))
            {
                // depo seçiliyse
                string depo = _viewModel.Veri6;
                Load_grid lg = new Load_grid();
                string query = "";
                if (depo == "Proserv")
                {
                    query = "SELECT sto_kod as [Stok Kodu], sto_isim as [Stok Adı], BARKOD_TANIMLARI.bar_kodu as [Barkod] " +
                            "FROM [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[STOKLAR] " +
                            "LEFT OUTER JOIN [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[BARKOD_TANIMLARI] " +
                            "ON STOKLAR.sto_kod = BARKOD_TANIMLARI.bar_stokkodu " +
                            "WHERE SUBSTRING(sto_kod, 1, 4) = 'PRSV'";
                }
                else if (depo == "Honeywell")
                {
                    query = "SELECT sto_kod as [Stok Kodu], sto_isim as [Stok Adı], BARKOD_TANIMLARI.bar_kodu as [Barkod] " +
                            "FROM [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[STOKLAR] " +
                            "LEFT OUTER JOIN [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[BARKOD_TANIMLARI] " +
                            "ON STOKLAR.sto_kod = BARKOD_TANIMLARI.bar_stokkodu " +
                            "WHERE SUBSTRING(sto_kod, 1, 2) = 'HW'";
                }
                lg.SayimGrid(sayimdatagrid, query);
            }
        }

        private void getir()
        {
            string depo = _viewModel.Veri6;
            if (depo != null)
            {
                string query = ""; // SQL sorgusu için boş bir dize oluşturun

                if (depo == "Proserv")
                {
                    query = "SELECT sto_kod as [Stok Kodu], sto_isim as [Stok Adı], BARKOD_TANIMLARI.bar_kodu as [Barkod] " +
                            "FROM [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[STOKLAR] " +
                            "LEFT OUTER JOIN [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[BARKOD_TANIMLARI] " +
                            "ON STOKLAR.sto_kod = BARKOD_TANIMLARI.bar_stokkodu " +
                            "WHERE SUBSTRING(sto_kod, 1, 4) = 'PRSV'";
                }
                else if (depo == "Honeywell")
                {
                    query = "SELECT sto_kod as [Stok Kodu], sto_isim as [Stok Adı], BARKOD_TANIMLARI.bar_kodu as [Barkod] " +
                            "FROM [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[STOKLAR] " +
                            "LEFT OUTER JOIN [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[BARKOD_TANIMLARI] " +
                            "ON STOKLAR.sto_kod = BARKOD_TANIMLARI.bar_stokkodu " +
                            "WHERE SUBSTRING(sto_kod, 1, 2) = 'HW'";
                }

                // Şimdi query değişkenini kullanarak SQL sorgusunu çalıştırabilirsiniz.
                Load_grid lg = new Load_grid();
                lg.SayimGrid(sayimdatagrid, query);
            }
        }


        private void islemonay_btn_Click(object sender, RoutedEventArgs e)
        {
            
            
            try
            {

                string kullanici = _viewModel.Veri1;
                string sayimadi = _viewModel.Veri2;
                string altgrup = _viewModel.Veri3;
                string anagrup = _viewModel.Veri4;
                string markagrup = _viewModel.Veri5;
                
                


                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Depo_sayimagir (personeladi ,sayimtarih, sayimadi ,altgrupkodu ,anagrupkodu ,markakodu , stokkodu , stokadi, stokbarkod, sayimadedi, raf ,konum, aciklama)" +
                    " VALUES (@personeladi, @sayimtarih, @sayimadi, @altgrupkodu, @anagrupkodu, @markakodu, @stokkodu , @stokadi, @stokbarkod, @sayimadedi, @raf, @konum, @aciklama)", con))
                {
                    if (!string.IsNullOrEmpty(kullanici))
                    {
                        // Eğer kullanici değişkeni dolu ise, parametreyi ekleyin
                        cmd.Parameters.AddWithValue("@personeladi", kullanici);
                    }
                    
                    cmd.Parameters.AddWithValue("@sayimtarih", DateTime.Now);

                    if (!string.IsNullOrEmpty(sayimadi))
                    {
                        // Eğer kullanici değişkeni dolu ise, parametreyi ekleyin
                        cmd.Parameters.AddWithValue("@sayimadi", sayimadi);
                    }
                  
                    
                    cmd.Parameters.AddWithValue("@altgrupkodu", altgrup);
                    cmd.Parameters.AddWithValue("@anagrupkodu", anagrup);
                    cmd.Parameters.AddWithValue("@markakodu", markagrup);

                    DataRowView selectedRow = sayimdatagrid.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        string stokKodu = selectedRow["Stok Kodu"].ToString();
                        string stokAdi = selectedRow["Stok Adı"].ToString();
                        string barkod = selectedRow["Barkod"].ToString();

                        cmd.Parameters.AddWithValue("@stokkodu", stokKodu);
                        cmd.Parameters.AddWithValue("@stokadi", stokAdi);
                        cmd.Parameters.AddWithValue("@stokbarkod", barkod);
                    }

                    if (!string.IsNullOrEmpty(sayim_txt.Text))
                    {
                        cmd.Parameters.AddWithValue("@Sayimadedi", sayim_txt.Text);
                    }
                    

                    cmd.Parameters.AddWithValue("@Konum", konum_txt.Text);

                    cmd.Parameters.AddWithValue("@raf", raf_txt.Text);

                    cmd.Parameters.AddWithValue("@aciklama", aciklama_txt.Text);




                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("İşlem Başarılı", "Kaydedildi", MessageBoxButton.OK, MessageBoxImage.Information);
                SayımWindow parentWindow = Window.GetWindow(this) as SayımWindow;

                // Eğer bağlı olduğu SayımWindow varsa, pencereyi kapatın
                if (parentWindow != null)
                {
                    parentWindow.Close();
                }

                Logger logger = new Logger();
                string aksiyon = "Sayım Girişi yapıldı"; // Burada aksiyonunuzu belirtin
                logger.Log(aksiyon);


            }
            catch (SqlException )
            {
                MessageBox.Show(" Hata: " + "Lütfen boş değerleri girin", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void sayimdatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = sayimdatagrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                string stokKodu = selectedRow["Stok Kodu"].ToString();
                string stokAdi = selectedRow["Stok Adı"].ToString();
                string barkod = selectedRow["Barkod"].ToString();

                stokkodu_txt.Text = stokKodu;
                stokadi_txt.Text = stokAdi;
                barkod_txt.Text = barkod;
            }
        }

        private void btn_iptal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            Logger logger = new Logger();
            string aksiyon = "Sayım girişi iptal edildi"; // Burada aksiyonunuzu belirtin
            logger.Log(aksiyon);
        }

        private void sayim_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = stok_tb.Text.ToLower(); // Metin kutusundaki metni alın ve küçük harfe çevirin

            // Verileri filtrelemek için DataView'i kullanın
            DataView dv = (DataView)sayimdatagrid.ItemsSource;
            if (dv != null)
            {
                dv.RowFilter = $"[Stok Kodu] LIKE '%{searchText}%' OR [Stok Adı] LIKE '%{searchText}%' OR [Barkod] LIKE '%{searchText}%'";
            }
        }


    }
}
