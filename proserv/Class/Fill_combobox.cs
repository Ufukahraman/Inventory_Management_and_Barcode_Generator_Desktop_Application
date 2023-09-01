using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace proserv.Class
{
    class Fill_combobox
    {
        public void Fillcb(string query, ComboBox comboBox)
        {
            string connectionString = @"------<Connection String Here>----------";

            

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string item = reader.GetString(0); // İlgili sütunu al
                            comboBox.Items.Add(item); // ComboBox'a ekle
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
