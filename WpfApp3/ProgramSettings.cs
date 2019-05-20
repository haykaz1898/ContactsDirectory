using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp3
{
    public class ProgramSettings : INotifyPropertyChanged
    {
        private string _connectionString;
        private string _mainOrganizationBackgroundColor;


        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
                OnPropertyChanged("ConnectionString");
            }
        }

        public string MainOrganizationBackgroundColor
        {
            get
            {
                return _mainOrganizationBackgroundColor;
            }
            set
            {
                _mainOrganizationBackgroundColor = value;
                OnPropertyChanged("MainOrganizationBackgroundColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
