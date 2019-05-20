using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    public class CommunicationTypeManager : ICommunicationTypeManager
    {
        private ICommunicationTypeRepository _communicationTypeRepository;
        private IModelToEntity<CommunicationTypeModel, CommunicationTypeEntity> _modelToEntity = new CommunicationTypeModelToEntity();
        private IEntityToModel<CommunicationTypeEntity, CommunicationTypeModel> _entityToModel = new CommunicationTypeEntityToModel();

        public CommunicationTypeManager(ICommunicationTypeRepository communicationTypeRepository)
        {
            _communicationTypeRepository = communicationTypeRepository;
        }

        public void AddCommunicationType(CommunicationTypeModel communicationMethodModel)
        {
            _communicationTypeRepository.AddCommunicationType(_modelToEntity.Convert(communicationMethodModel));
        }

        public IEnumerable<CommunicationTypeModel> GetAllTypes()
        {
            return _entityToModel.Convert(_communicationTypeRepository.GetAllTypes());

        }

        public CommunicationTypeModel GetCommunicationType(string communicationType)
        {
            return _entityToModel.Convert(_communicationTypeRepository.GetCommunicationType(communicationType));
        }

        public void RemoveCommunicationType(CommunicationTypeModel communicationMethodModel)
        {
            _communicationTypeRepository.RemoveCommunicationType(_modelToEntity.Convert(communicationMethodModel));
        }
    }

}
