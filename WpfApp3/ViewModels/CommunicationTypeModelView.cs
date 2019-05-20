using System.Collections.ObjectModel;
using ContactCatalog;

namespace WpfApp3.ViewModels
{
    public class CommunicationTypeViewModel
    {
        private ICommunicationTypeManager _communicationTypeManager;
        
        public CommunicationType CommunicationType { get; set; }

        public ObservableCollection<CommunicationType> Types { get; set; }

        public CommunicationTypeViewModel()
        {
            CommunicationType = new CommunicationType();
            _communicationTypeManager = Directory.GetCommunicationTypeManager();
            Types = new ObservableCollection<CommunicationType>(CommunicationTypeModelToCommunicationType.Convert(_communicationTypeManager.GetAllTypes()));
        }
    }
}
