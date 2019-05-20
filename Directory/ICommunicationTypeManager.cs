using System.Collections.Generic;

namespace ContactCatalog
{
    public interface ICommunicationTypeManager
    {
        void AddCommunicationType(CommunicationTypeModel communicationTypeModel);
        void RemoveCommunicationType(CommunicationTypeModel communicationTypeModel);
        IEnumerable<CommunicationTypeModel> GetAllTypes();
        CommunicationTypeModel GetCommunicationType(string communicationType);
    }

}
