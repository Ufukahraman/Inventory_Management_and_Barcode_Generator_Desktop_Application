using System;
using System.Windows;
using System.Windows.Controls;
using proserv.Class;
using System.Data.SqlClient;

namespace proserv.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Veridepo _viewModel = new Veridepo();
        SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");
        public Page1()
        {
            DataContext = _viewModel;
            InitializeComponent();
            Fill_combobox doldurcb = new Fill_combobox();
            doldurcb.Fillcb("SELECT DISTINCT  sto_altgrup_kod  FROM [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[STOKLAR]", altgrup_cb);
            doldurcb.Fillcb("SELECT DISTINCT sto_anagrup_kod  FROM [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[STOKLAR]", anagrup_cb);
            doldurcb.Fillcb("SELECT DISTINCT sto_marka_kodu  FROM [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[STOKLAR]", marka_cb);
            kullanici_txt.Text = Oturum.Instance.LoggedInUsername;
        }

      

        
        private void sayimagit_btn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Veri1 = kullanici_txt.Text;
            _viewModel.Veri2 = sayimadi_txt.Text;
            _viewModel.Veri3 = altgrup_cb.Text;
            _viewModel.Veri4 = anagrup_cb.Text;
            _viewModel.Veri5 = marka_cb.Text;
            _viewModel.Veri6 = depo_cb.Text;

            Page2 page2 = new Page2(_viewModel); // ViewModel'i Page2'ye iletin
            this.NavigationService.Navigate(page2);
            


        }




        private void iptal_btn_Click(object sender, RoutedEventArgs e)
        {
            // Page'in bağlı olduğu SayımWindow'u alın
            SayımWindow parentWindow = Window.GetWindow(this) as SayımWindow;

            // Eğer bağlı olduğu SayımWindow varsa, pencereyi kapatın
            if (parentWindow != null)
            {
                parentWindow.Close();
            }


            Logger logger = new Logger();
            string aksiyon = "Sayım giriş yetkisi verilmedi"; // Burada aksiyonunuzu belirtin
            logger.Log(aksiyon);
            



        }


    }
}
