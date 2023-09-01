
using proserv.Class;
using proserv.Ucontroller;
using System.Windows;
using System.Windows.Input;

namespace proserv
{
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

            if (Oturum.Instance.IsUserLoggedIn)
            {
                user_lbl.Content = "Hoş geldiniz, " + Oturum.Instance.LoggedInUsername;
                this.IsEnabled = true;
            }

            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        
        
        //kapat,küçült,büyült,sürükle
        private void off_btn_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();

        }

        private void maxi_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }

        }

        private void mini_btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void brd_white_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        
        private void hw_btn_Click(object sender, RoutedEventArgs e)
        {
            get_uc.Uc_Ekle(Content_icerik, new UserControl1());
        }

        private void hw_anlık_btn_Click(object sender, RoutedEventArgs e)
        {
            get_uc.Uc_Ekle(Content_icerik, new UserControl2());
        }

         private void sayimkonum_btn_Click(object sender, RoutedEventArgs e)
        {
            
            
            
            get_uc.Uc_Ekle(Content_icerik, new UserControl3());
            


        }

        private void sayimbasla_btn_Click(object sender, RoutedEventArgs e)
        {
            // Ekle penceresini açmadan önce arkaplanı görünür yap
            modalBackground.Visibility = Visibility.Visible;

            SayımWindow sayimWindow = new SayımWindow();
            sayimWindow.Owner = this;
            sayimWindow.Closed += (s, args) =>
            {
                // Ekle penceresi kapatıldığında arkaplanı gizle
                modalBackground.Visibility = Visibility.Collapsed;
            };
            if (sayimWindow.ShowDialog() == true)
            {
                
            }


        }

        private void user_btn_Click(object sender, RoutedEventArgs e)
        {
           


            MessageBoxResult result = MessageBox.Show("Çıkış yapılacaktır. Onaylıyor musunuz?", "Kullanıcı Çıkışı", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Logger logger = new Logger();
                string aksiyon = Oturum.Instance.LoggedInUsername +" Çıkış yaptı"; // Burada aksiyonunuzu belirtin
                logger.Log(aksiyon);
                // Oturumu sonlandır
                Oturum.Instance.LogOut();
                LoginWindow lg = new LoginWindow();
                lg.Show();
                this.Close();

            }

          
           



        }

       

        private void sayım_btn_Click(object sender, RoutedEventArgs e)
        {
            get_uc.Uc_Ekle(Content_icerik, new UserControl4());
        }

        private void barkod_btn_Click(object sender, RoutedEventArgs e)
        {
            get_uc.Uc_Ekle(Content_icerik, new UserControl5());
        }
    }
}