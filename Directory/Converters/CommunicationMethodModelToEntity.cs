using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class CommunicationMethodModelToEntity : IModelToEntity<CommunicationMethodModel, CommunicationMethodEntity>
    {
        public CommunicationMethodEntity Convert(CommunicationMethodModel model)
        {
            CommunicationTypeModelToEntity communicationTypeModelToEntity = new CommunicationTypeModelToEntity();
            return new CommunicationMethodEntity
            {
                Address = model.Address,
                IsPreffered = model.IsPrefered,
                CommunicationMethodId = model.Id,
                TypeId = communicationTypeModelToEntity.Convert(model.Type).TypeId
            };
        }

        public IEnumerable<CommunicationMethodEntity> Convert(IEnumerable<CommunicationMethodModel> models)
        {
            return models.Select(Convert);
        }
    }

}
