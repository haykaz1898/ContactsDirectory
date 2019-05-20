using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfApp3.ViewModels
{
    public class Organization : INotifyPropertyChanged
    {
        private int _id;
        private string _organizationName;
        private bool _isMain;

        public string OrganizationName
        {
            get
            {
                return _organizationName;
            }
            set
            {
                _organizationName = value;
                OnPropertyChanged("OrganizationName");
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("OrganizationId");
            }
        }
        public bool IsMain
        {
            get
            {
                return _isMain;
            }
            set
            {
                _isMain = value;
                OnPropertyChanged("IsMain");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
