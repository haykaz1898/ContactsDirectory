using System.Collections.Generic;
using System.Linq;
using Database;


namespace ContactCatalog
{
    public class OrganizationManager : IOrganizationManager
    {
        private IOrganizationRepository _organizationRepository;
        private IModelToEntity<OrganizationModel, OrganizationEntity> _modelToEntity = new OrganizationModelToEntity();
        private IEntityToModel<OrganizationEntity, OrganizationModel> _entityToModel = new OrganizationEntityToModel();

        public OrganizationManager(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
  
        public void AddOrganization(OrganizationModel organization)
        {
            _organizationRepository.AddNewOrganization(_modelToEntity.Convert(organization));
        }

        public IEnumerable<OrganizationModel> GetAllOrganizations()
        {
            return _entityToModel.Convert(_organizationRepository.GetAllOrganizations());
        }

        public OrganizationModel GetOrganization(string organizationName)
        {
            return _entityToModel.Convert(_organizationRepository.GetOrganization(organizationName));
        }

        public void RemoveOrganization(OrganizationModel organization)
        {
            _organizationRepository.RemoveOrganization(_modelToEntity.Convert(organization));
        }

        public void SetMainOrganization(OrganizationModel organization)
        {
            if (organization.IsMain) {
                var orgs = GetAllOrganizations().ToList();
                foreach (var o in orgs)
                {
                    if (o.IsMain)
                    {
                        o.IsMain = false;
                        _organizationRepository.UpdateOrganization(_modelToEntity.Convert(o));
                    }
                }
                _organizationRepository.UpdateOrganization(_modelToEntity.Convert(organization));
            }
        }
    }

}
