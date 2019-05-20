using System.Collections;
using System.Text;
using System.Threading.Tasks;
using ContactCatalog;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp3.ViewModels
{

    public class ContactViewModel : INotifyPropertyChanged
    {
        private Command _updateCommand;
        private Command _searchCommand;

        private string _filter = "";

        private IContactManager _contactManager = Directory.GetContactManager();

        public VirtualizingCollection Contacts { get; set; }
        
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                _contactManager.SetFilter(_filter);
                Contacts = new VirtualizingCollection(_contactManager, 5, 5 * 1000);
                PropertyChanged(this, new PropertyChangedEventArgs("Contacts"));
            }
        }

        public ContactViewModel()
        {
            Contacts = new VirtualizingCollection(Directory.GetContactManager(), 5, 5 * 1000);
        }

        public Command SearchCommand
        {
            get
            {
                return _searchCommand ??
                    (_searchCommand = new Command(obj =>
                    {
                        _contactManager.SetFilter(Filter);
                    }));
            }
        }

        public Command UpdateCommand
        {
            get
            {
                return _updateCommand ??
                  (_updateCommand = new Command(obj =>
                  {
                      Contact contact = obj as Contact;
                      
                      _contactManager.UpdateContact(ContactToContactModel.Convert(contact));
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
