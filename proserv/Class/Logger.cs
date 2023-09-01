using System;
using System.Collections.Generic;
using System.Text;

namespace proserv.Class
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public class Logger
    {
        private const string _connectionString = @"------<Connection String Here>----------";

        public void Log(string action)
        {
            
            string query = "INSERT INTO Depo_Log(Personel,Zaman, Aksiyon) VALUES (@Personel,@Zaman, @Aksiyon)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Personel", Oturum.Instance.LoggedInUsername);
                command.Parameters.AddWithValue("@Zaman", DateTime.Now);
                command.Parameters.AddWithValue("@Aksiyon", action);

                connection.Open();
                command.ExecuteNonQuery();
            }


        }
    }
}
