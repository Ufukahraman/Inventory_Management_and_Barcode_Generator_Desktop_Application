using DocumentFormat.OpenXml.Office.CustomUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace proserv.Class
{
    public  class Load_grid
    {
        private SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");

        public void StokGrid( DataGrid datagrid, string filter = "")
        {
            string query = "SELECT sto_kod as [Stok Kodu], sto_isim as [Stok Adı],BARKOD_TANIMLARI.bar_kodu as [Barkod] FROM [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[STOKLAR] " +
                "LEFT OUTER JOIN [18Y].[MikroDB_V16_PROSERVAS19].[dbo].[BARKOD_TANIMLARI] ON STOKLAR.sto_kod = BARKOD_TANIMLARI.bar_stokkodu";

            if (!string.IsNullOrEmpty(filter))
            {
                query += $" WHERE LOWER(sto_kod) LIKE '%' + @searchText + '%' OR LOWER(sto_isim) LIKE '%' +  @searchText + '%' OR LOWER(BARKOD_TANIMLARI.bar_kodu) LIKE '%' + @searchText + '%'";
            }

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    cmd.Parameters.AddWithValue("@searchText", filter.ToLower());
                }

                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                datagrid.ItemsSource = dt.DefaultView;

            }
        }

        public void MainGrid(DataGrid datagrid, string query, string filter = "")
        {
            if (!string.IsNullOrEmpty(filter))
            {
                query += $" WHERE LOWER(Stok_kodu) LIKE '%' + @searchText + '%' OR LOWER(Stok_adi) LIKE '%' + @searchText + '%'";
            }

            SqlCommand cmd = new SqlCommand(query, con);

            if (!string.IsNullOrEmpty(filter))
            {
                cmd.Parameters.AddWithValue("@searchText", filter.ToLower());
            }

            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public void SayimGrid(DataGrid datagrid,string query )
        {
            

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
               

                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                datagrid.ItemsSource = dt.DefaultView;

            }
        }

       






    }
}
