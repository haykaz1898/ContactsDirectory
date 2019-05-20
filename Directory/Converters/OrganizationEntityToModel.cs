using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class OrganizationEntityToModel : IEntityToModel<OrganizationEntity, OrganizationModel>
    {
        public OrganizationModel Convert(OrganizationEntity entity)
        {
            return new OrganizationModel
            {
                Id = entity.OrganizationId,
                OrganizationName = entity.OrganizationName,
                IsMain = entity.IsMain
            };
        }

        public IEnumerable<OrganizationModel> Convert(IEnumerable<OrganizationEntity> entities)
        {
            return entities.Select(Convert); 
        }
    }

}
