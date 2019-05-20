using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class CommunicationTypeModelToEntity : IModelToEntity<CommunicationTypeModel, CommunicationTypeEntity>
    {
        public CommunicationTypeEntity Convert(CommunicationTypeModel model)
        {
            return new CommunicationTypeEntity
            {
                TypeId = model.Id,
                Type = model.Type
            };
        }

        public IEnumerable<CommunicationTypeEntity> Convert(IEnumerable<CommunicationTypeModel> models)
        {
            return models.Select(Convert);
        }
    }

}
