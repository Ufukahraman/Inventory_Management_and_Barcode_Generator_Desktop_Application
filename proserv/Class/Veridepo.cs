using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace proserv.Class
{
    public class Veridepo : INotifyPropertyChanged
    {
        private string _veri1;
        public string Veri1
        {
            get { return _veri1; }
            set
            {
                if (_veri1 != value)
                {
                    _veri1 = value;
                    OnPropertyChanged(nameof(Veri1));
                }
            }
        }

        private string _veri2;
        public string Veri2
        {
            get { return _veri2; }
            set
            {
                if (_veri2 != value)
                {
                    _veri2 = value;
                    OnPropertyChanged(nameof(Veri2));
                }
            }
        }

        private string _veri3;
        public string Veri3
        {
            get { return _veri3; }
            set
            {
                if (_veri3 != value)
                {
                    _veri3 = value;
                    OnPropertyChanged(nameof(Veri3));
                }
            }
        }

        private string _veri4;
        public string Veri4
        {
            get { return _veri4; }
            set
            {
                if (_veri4 != value)
                {
                    _veri4 = value;
                    OnPropertyChanged(nameof(Veri4));
                }
            }
        }

        private string _veri5;
        public string Veri5
        {
            get { return _veri5; }
            set
            {
                if (_veri5 != value)
                {
                    _veri5 = value;
                    OnPropertyChanged(nameof(Veri5));
                }
            }
        }
        private string _veri6;
        public string Veri6
        {
            get { return _veri6; }
            set
            {
                if (_veri6 != value)
                {
                    _veri6 = value;
                    OnPropertyChanged(nameof(Veri6));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
