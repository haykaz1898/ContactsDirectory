using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfApp3.ViewModels
{
    public class Contact : INotifyPropertyChanged
    {
        private int _id;
        private string _fullName;
        private string _firstName;
        private string _lastName;
        private string _fatherName;
        private Organization _organization;
        private string _position;
        private string _prefferedCommunicationMethod;
        private string _details;
        private string _gender;
        private string _birthDate;
        private ObservableCollection<CommunicationMethod> _communicationMethods;

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
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string FatherName
        {
            get
            {
                return _fatherName;
            }
            set
            {
                _fatherName = value;
                OnPropertyChanged("FatherName");
            }
        }
        public string Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
                OnPropertyChanged("Details");
            }
        }
        public Organization Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
                OnPropertyChanged("Organization");
            }
        }
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }
        public string PrefferedCommunicationMethod
        {
            get
            {
                return _prefferedCommunicationMethod;
            }
            set
            {
                _prefferedCommunicationMethod = value;
                OnPropertyChanged("PrefferedCommunicationMethod");
            }
        }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
        public string BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }
        public ObservableCollection<CommunicationMethod> CommunicationMethods
        {
            get
            {
                return _communicationMethods;
            }
            set
            {
                _communicationMethods = value;
                OnPropertyChanged("CommunicationMethod");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
