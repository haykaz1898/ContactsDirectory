using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface ICommunicationTypeRepository
    {
        void AddCommunicationType(CommunicationTypeEntity communicationMethodEntity);
        void RemoveCommunicationType(CommunicationTypeEntity communicationMethodEntity);
        IEnumerable<CommunicationTypeEntity> GetAllTypes();
        CommunicationTypeEntity GetCommunicationType(string communicationType);
    }
}
