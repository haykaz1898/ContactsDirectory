using ContactCatalog;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp3.ViewModels
{
    public class OrganizationModelToOrganization
    {
        public static Organization Convert(OrganizationModel organizationModel)
        {
            return new Organization
            {
                Id = organizationModel.Id,
                OrganizationName = organizationModel.OrganizationName,
                IsMain = organizationModel.IsMain
            };
        }

        public static IEnumerable<Organization> Convert(IEnumerable<OrganizationModel> organizationModels)
        {
            return organizationModels.Select(Convert);
        }
    }
}
