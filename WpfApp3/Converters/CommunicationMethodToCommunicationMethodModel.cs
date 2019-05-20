using System.Collections.Generic;
using ContactCatalog;
using System.Linq;

namespace WpfApp3.ViewModels
{
    public class CommunicationMethodToCommunicationMethodModel
    {
        public static CommunicationMethodModel Convert(CommunicationMethod communicationMethod)
        {
            return new CommunicationMethodModel
            {
                Id = communicationMethod.Id,
                Address = communicationMethod.Address,
                IsPrefered = communicationMethod.IsPreffered,
                Type = CommunicationTypeToCommunicationTypeModel.Convert( communicationMethod.Type)
            };

        }

        public static IEnumerable<CommunicationMethodModel> Convert(IEnumerable<CommunicationMethod> communicationMethodModels)
        {
            return communicationMethodModels.Select(Convert);
        }
    }
}
