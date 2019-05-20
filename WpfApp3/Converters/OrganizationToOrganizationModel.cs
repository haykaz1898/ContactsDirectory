using ContactCatalog;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp3.ViewModels
{
    public class OrganizationToOrganizationModel
    {
        public static OrganizationModel Convert(Organization organization)
        {
            return new OrganizationModel
            {
                Id = organization.Id,
                OrganizationName = organization.OrganizationName,
                IsMain = organization.IsMain
            };
        }

        public static IEnumerable<OrganizationModel> Convert(IEnumerable<Organization> organizations)
        {
            return organizations.Select(Convert);
        }
    }
}
