using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class CommunicationTypeEntityToModel : IEntityToModel<CommunicationTypeEntity, CommunicationTypeModel>
    {
        public CommunicationTypeModel Convert(CommunicationTypeEntity entity)
        {
            return new CommunicationTypeModel
            {
                Id = entity.TypeId,
                Type = entity.Type
            };
        }

        public IEnumerable<CommunicationTypeModel> Convert(IEnumerable<CommunicationTypeEntity> entities)
        {
            return entities.Select(Convert);
        }
    }

}
