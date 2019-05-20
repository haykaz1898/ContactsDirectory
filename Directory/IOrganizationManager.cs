using System.Collections.Generic;
namespace ContactCatalog
{
    public interface IOrganizationManager
    {
        void AddOrganization(OrganizationModel organization);
        void RemoveOrganization(OrganizationModel organization);
        IEnumerable<OrganizationModel> GetAllOrganizations();
        void SetMainOrganization(OrganizationModel organization);
        OrganizationModel GetOrganization(string organizationName);
    }
}
