using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfApp3.ViewModels
{
    public class CommunicationMethod : INotifyPropertyChanged
    {
        private int _id;
        private int _contactId;
        private string _address;
        private CommunicationType _type;
        private bool _isPreffered;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public int ContactId
        {
            get
            {
                return _contactId;
            }
            set
            {
                _contactId = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
        public CommunicationType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        public bool IsPreffered
        {
            get
            {
                return _isPreffered;
            }
            set
            {
                _isPreffered = value;
                OnPropertyChanged("IsPreffered");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
