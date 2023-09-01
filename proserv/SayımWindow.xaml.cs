using proserv.Class;
using proserv.Pages;
using proserv.Ucontroller;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace proserv
{
    /// <summary>
    /// Interaction logic for SayımWindow.xaml
    /// </summary>
    public partial class SayımWindow : Window
    {



        public SayımWindow()
        {
            InitializeComponent();
            frame.Navigate(new Page1());


        }


    }
}
