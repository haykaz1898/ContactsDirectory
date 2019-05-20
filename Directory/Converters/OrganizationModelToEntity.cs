using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class OrganizationModelToEntity : IModelToEntity<OrganizationModel, OrganizationEntity>
    {
        public OrganizationEntity Convert(OrganizationModel model)
        {
            return new OrganizationEntity
            {
                OrganizationId = model.Id,
                OrganizationName = model.OrganizationName,
                IsMain = model.IsMain
            };
        }

        public IEnumerable<OrganizationEntity> Convert(IEnumerable<OrganizationModel> models)
        {
            return models.Select(Convert);
        }
    }
}
