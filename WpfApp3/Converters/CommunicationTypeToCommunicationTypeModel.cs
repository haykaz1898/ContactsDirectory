using ContactCatalog;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp3.ViewModels
{
    public class CommunicationTypeToCommunicationTypeModel
    {
        public static CommunicationTypeModel Convert(CommunicationType communicationType)
        {
            return new CommunicationTypeModel
            {
                Id = communicationType.Id,
                Type = communicationType.Type
            };
        }

        public static IEnumerable<CommunicationTypeModel> Convert(IEnumerable<CommunicationType> communicationTypeModels)
        {
            return communicationTypeModels.Select(Convert);
        }
    }
}
