using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp3.ViewModels
{
    public class CombinedViewModels
    { 
        public SettingsViewModel SettingsViewModel { get; set; }
        public ContactViewModel ContactViewModel { get; set; }
        public OrganizationViewModel OrganizationViewModel { get; set; }
        public CommunicationMethodViewModel CommunicationMethodViewModel { get; set; }
        public CommunicationTypeViewModel CommunicationTypeViewModel { get; set; }

        public Contact SelectedContact { get; set; }
        
        public CombinedViewModels()
        {
            ContactViewModel = new ContactViewModel();
            OrganizationViewModel = new OrganizationViewModel();
            CommunicationMethodViewModel = new CommunicationMethodViewModel();
            CommunicationTypeViewModel = new CommunicationTypeViewModel();
            SettingsViewModel = new SettingsViewModel();
        }

    }
}
