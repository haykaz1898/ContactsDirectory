using ContactCatalog;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp3.ViewModels
{
    public class CommunicationTypeModelToCommunicationType
    {
        public static CommunicationType Convert(CommunicationTypeModel communicationTypeModel)
        {
            return new CommunicationType
            {
                Id = communicationTypeModel.Id,
                Type = communicationTypeModel.Type
            };
        }

        public static IEnumerable<CommunicationType> Convert(IEnumerable<CommunicationTypeModel> communicationTypeModels)
        {
            return communicationTypeModels.Select(Convert);
        }
    }
}
