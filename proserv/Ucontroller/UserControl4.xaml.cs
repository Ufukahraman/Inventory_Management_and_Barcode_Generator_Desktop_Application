using proserv.Class;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserControl4.xaml
    /// </summary>
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
            Load_grid lg = new Load_grid();
            lg.SayimGrid(sayimgrid, "SELECT [personeladi] AS  Personel ,[sayimtarih] AS Tarih ,[stokkodu] AS[Stok Kodu] ,[stokadi] AS[Stok Adı] ,[stokbarkod] AS[Stok Barkod] ,[sayimadedi] AS[Sayım Adedi] ,[raf] ,[konum],[aciklama] AS [Açıklama]  FROM[VeribisCRM].[dbo].[Depo_sayimagir]");
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            Load_grid lg = new Load_grid();
            lg.SayimGrid(sayimgrid, "SELECT [personeladi] AS  Personel ,[sayimtarih] AS Tarih ,[stokkodu] AS[Stok Kodu] ,[stokadi] AS[Stok Adı] ,[stokbarkod] AS[Stok Barkod] ,[sayimadedi] AS[Sayım Adedi] ,[raf] ,[konum],[aciklama] AS [Açıklama]  FROM[VeribisCRM].[dbo].[Depo_sayimagir]");
            
        }
    }
    
}
