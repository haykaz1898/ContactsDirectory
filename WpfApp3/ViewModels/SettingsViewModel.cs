using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactCatalog;

namespace WpfApp3.ViewModels
{
    
    public class SettingsViewModel
    {
        private SettingsLoader _settingsLoader;
       
        private Command _saveCommand;

        private Command _addOrganizationCommand;
        private Command _removeOrganizationCommand;

        private Command _addCommunicationTypeCommand;
        private Command _removeCommunicationTypeCommand;

        private IOrganizationManager _organizationManager;
        private ICommunicationTypeManager _communicationTypeManager;

        public OrganizationViewModel OrganizationViewModel { get; set; }
        public CommunicationTypeViewModel CommunicationTypeViewModel { get; set; }

        public Organization SelectedOrganization { get; set; }
        public Organization MainOrganization { get; set; }
        public Organization AddedOrganization { get; set; }


        public CommunicationType AddedCommunicationType { get; set; }
        public CommunicationType SelectedCommunicationType { get; set; }


        public ProgramSettings ProgramSettings { get; set; }

        public SettingsViewModel()
        {
            _settingsLoader = SettingsLoader.Load();
            ProgramSettings = _settingsLoader.GetSettings();
            _organizationManager = Directory.GetOrganizationManager();
            _communicationTypeManager = Directory.GetCommunicationTypeManager();

            OrganizationViewModel = new OrganizationViewModel();
            CommunicationTypeViewModel = new CommunicationTypeViewModel();

            AddedOrganization = new Organization();
            AddedCommunicationType = new CommunicationType();
        }

        public Command SaveCommand
        {
            get
            {
                return _saveCommand ??
                  (_saveCommand = new Command(obj =>
                  { 
                      _settingsLoader.SaveChanges(ProgramSettings);
                      Directory.Setup(_settingsLoader.GetSettings().ConnectionString);
                        
                      if (MainOrganization != null)
                      {
                          MainOrganization.IsMain = true;
                          _organizationManager.SetMainOrganization(OrganizationToOrganizationModel.Convert(MainOrganization));
                      }
                  }));
            }
        }
       

        public Command AddOrganizationCommand
        {
            get
            {
                return _addOrganizationCommand ??
                    (_addOrganizationCommand = new Command(obj =>
                    {
                        if (AddedOrganization != null)
                        {
                            _organizationManager.AddOrganization(OrganizationToOrganizationModel.Convert(AddedOrganization));

                            OrganizationViewModel.Organizations.Add(OrganizationModelToOrganization.Convert(_organizationManager.GetOrganization(AddedOrganization.OrganizationName)));
                        }
                    }));
            }
        }
        public Command RemoveOrganizationCommand
        {
            get
            {
                return _removeOrganizationCommand ??
                    (_removeOrganizationCommand = new Command(obj =>
                    {
                        if (SelectedOrganization != null)
                        {
                            _organizationManager.RemoveOrganization(OrganizationToOrganizationModel.Convert(SelectedOrganization));
                            OrganizationViewModel.Organizations.Remove(SelectedOrganization);
                        }
                    }));
            }
        }

        public Command AddCommunicationTypeCommand
        {
            get
            {
                return _addCommunicationTypeCommand ??
                    (_addCommunicationTypeCommand = new Command(obj =>
                    {
                        if (AddedCommunicationType != null)
                        {
                            _communicationTypeManager.AddCommunicationType(CommunicationTypeToCommunicationTypeModel.Convert(AddedCommunicationType));
                            CommunicationTypeViewModel.Types.Add(CommunicationTypeModelToCommunicationType.Convert(_communicationTypeManager.GetCommunicationType(AddedCommunicationType.Type)));
                        }
                    }));
            }
        }
        public Command RemoveCommunicationTypeCommand
        {
            get
            {
                return _removeCommunicationTypeCommand ??
                    (_removeCommunicationTypeCommand = new Command(obj =>
                    {
                        if (SelectedCommunicationType != null)
                        {
                            _communicationTypeManager.RemoveCommunicationType(CommunicationTypeToCommunicationTypeModel.Convert(SelectedCommunicationType));
                            CommunicationTypeViewModel.Types.Remove(SelectedCommunicationType);
                        }
                    }));
            }
        }

        
    }
}
