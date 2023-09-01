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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proserv.Ucontroller
{
    /// <summary>
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        SqlConnection con = new SqlConnection(@"------<Connection String Here>----------");
        public UserControl3()
        {
            InitializeComponent();
            cagır();
            cagır2();
        }

        private void search_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            cagır();
            cagır2();
        }
        public void cagır()
        {
            Load_grid lg = new Load_grid();
            string customQuery = "SELECT  [id] as ID,[Stok_kodu] AS [Stok Kodu],[Stok_adi]  AS [Stok Adı], [barkod] AS [Barkod]," +
                "Anlık FROM [VeribisCRM].[dbo].[Depo_Anlık]";
            lg.MainGrid(datagrid, customQuery, search_tb.Text);
        }
        public void cagır2()
        {
            Load_grid lg = new Load_grid();
            string customQuery = "SELECT  [id] as ID,[Stok_kodu] AS [Stok Kodu],[Stok_adi]  AS [Stok Adı], [barkod] AS [Barkod]," +
                "[Konum] AS [Konum] FROM [VeribisCRM].[dbo].[Depo_Anlık]";
            lg.MainGrid(datagrid2, customQuery, search_tb.Text);
        }


        private void btn_refresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cagır();
            cagır2();
            search_tb.Clear();
        }

       
    }
}
