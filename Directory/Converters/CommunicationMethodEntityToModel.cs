using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class CommunicationMethodEntityToModel : IEntityToModel<CommunicationMethodEntity, CommunicationMethodModel>
    {
        public CommunicationMethodModel Convert(CommunicationMethodEntity entity)
        {
            CommunicationTypeEntityToModel communicationTypeEntityToModel = new CommunicationTypeEntityToModel();
            return new CommunicationMethodModel
            {
                Address = entity.Address,
                IsPrefered = entity.IsPreffered,
                Type = communicationTypeEntityToModel.Convert(entity.Type),
                Id = entity.CommunicationMethodId
            };
        }

        public IEnumerable<CommunicationMethodModel> Convert(IEnumerable<CommunicationMethodEntity> entities)
        {
            return entities.Select(Convert);
        }
    }

}
