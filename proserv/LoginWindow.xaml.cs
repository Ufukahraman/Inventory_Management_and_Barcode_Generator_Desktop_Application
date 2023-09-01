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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

        }
       

        private void giris_btn_Click(object sender, EventArgs e)
        {
            string username = kullanici_txt.Text;
            string password = sifre_txt.Text;

            string connectionString = @"------<Connection String Here>----------";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM depo_kullanıcı WHERE kullanici = @username AND sifre = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int result = (int)command.ExecuteScalar();

                        if (result == 1)
                        {
                            Logger logger = new Logger();
                            string aksiyon = username + " Giriş yaptı"; // Burada aksiyonunuzu belirtin
                            logger.Log(aksiyon);

                            MessageBox.Show("Giriş başarılı!");
                            Oturum.Instance.LogIn(username);
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Geçersiz kullanıcı adı veya şifre!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void cikis_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}