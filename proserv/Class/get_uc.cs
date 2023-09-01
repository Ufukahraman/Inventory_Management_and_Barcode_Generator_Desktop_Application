using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace proserv.Class
{
    public class get_uc
    {
        public static void Uc_Ekle(Grid grd,UserControl uc)
        {
            if(grd.Children.Count > 0)
            {
                grd.Children.Clear();
                grd.Children.Add(uc);
            }
            else
            {
                grd.Children.Add(uc);
            }
            

            
        }
    }
}
