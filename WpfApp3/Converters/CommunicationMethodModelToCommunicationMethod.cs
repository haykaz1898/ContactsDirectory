using System.Collections.Generic;
using ContactCatalog;
using System.Linq;

namespace WpfApp3.ViewModels
{
    public class CommunicationMethodModelToCommunicationMethod
    {
        public static CommunicationMethod Convert(CommunicationMethodModel communicationMethodModel)
        {
            return new CommunicationMethod
            {
                Id = communicationMethodModel.Id,
                Address = communicationMethodModel.Address,
                IsPreffered = communicationMethodModel.IsPrefered,
                Type = CommunicationTypeModelToCommunicationType.Convert(communicationMethodModel.Type)
            };
        }

        public static IEnumerable<CommunicationMethod> Convert(IEnumerable<CommunicationMethodModel> communicationMethodModels)
        {
            return communicationMethodModels.Select(Convert);
        }
    } 
}
