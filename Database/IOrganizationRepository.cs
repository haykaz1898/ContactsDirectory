using System.Collections.Generic;

namespace Database
{
    public interface IOrganizationRepository
    {
        void AddNewOrganization(OrganizationEntity organizationEntity);
        void RemoveOrganization(OrganizationEntity organizationEntity);
        IEnumerable<OrganizationEntity> GetAllOrganizations();
        OrganizationEntity GetOrganization(string organizationName);
        void UpdateOrganization(OrganizationEntity organizationEntity);
    }
}
    

