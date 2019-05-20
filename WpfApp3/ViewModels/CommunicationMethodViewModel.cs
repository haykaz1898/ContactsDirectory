using ContactCatalog;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp3.ViewModels
{
    
    public class CommunicationMethodViewModel
    {
        private Command _addCommunicationMethod;
        private Command _deleteCommand;

        private IContactManager _contactManager;

        public CommunicationMethod CommunicationMethod { get; set; }
        public CommunicationMethod SelectedCommunicationMethod { get; set; }

        public CommunicationMethodViewModel()
        {
            _contactManager = Directory.GetContactManager();
            CommunicationMethod = new CommunicationMethod();
        }

        public Command AddCommunicationMethodCommand
        {
            get
            {
                return _addCommunicationMethod ??
                  (_addCommunicationMethod = new Command(obj =>
                  {
                      Contact selectedContact = obj as Contact;
                    
                      _contactManager.AddCommunicationMethod(ContactToContactModel.Convert(selectedContact),
                          CommunicationMethodToCommunicationMethodModel.Convert(CommunicationMethod));
                      selectedContact.CommunicationMethods.Add(CommunicationMethod);                      
                  }));
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                    (_deleteCommand = new Command(obj =>
                    {
                        Contact selectedContact = obj as Contact;

                        _contactManager.RemoveCommunicationMethod(CommunicationMethodToCommunicationMethodModel.Convert(SelectedCommunicationMethod));
                        selectedContact.CommunicationMethods.Remove(SelectedCommunicationMethod);
                    }));
            }
        }
    }
}
