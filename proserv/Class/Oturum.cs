using System;
using System.Collections.Generic;
using System.Text;

namespace proserv.Class
{
    public class Oturum
    {
        private static Oturum _instance;
        public static Oturum Instance => _instance ??= new Oturum();

        public bool IsUserLoggedIn { get; private set; }
        public string LoggedInUsername { get; private set; }

        private Oturum()
        {
            IsUserLoggedIn = false;
            LoggedInUsername = string.Empty;
        }

        public void LogIn(string username)
        {
            IsUserLoggedIn = true;
            LoggedInUsername = username;
        }

        public void LogOut()
        {
            IsUserLoggedIn = false;
            LoggedInUsername = string.Empty;
        }
    }

}
