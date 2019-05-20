using System.Collections.ObjectModel;
using ContactCatalog;
using System.Linq;

namespace WpfApp3.ViewModels
{
   
    public class OrganizationViewModel
    {
        private IOrganizationManager _organizationManager;
        private Command _addOrganizationCommand;

        public ObservableCollection<Organization> Organizations { get; set; }
        public Organization Organization { get; set; }
        public Organization SelectedOrganization { get; set; }

        public OrganizationViewModel()
        {
            Organization = new Organization();
            _organizationManager = Directory.GetOrganizationManager();
            Organizations = new ObservableCollection<Organization>(OrganizationModelToOrganization.Convert(_organizationManager.GetAllOrganizations()));
        }

        public Command AddOrganizationCommand
        {
            get
            {
                return _addOrganizationCommand ??
                  (_addOrganizationCommand = new Command(obj =>
                  {
                      _organizationManager.AddOrganization(OrganizationToOrganizationModel.Convert(Organization));
                  }));
            }
        }

    }
}
