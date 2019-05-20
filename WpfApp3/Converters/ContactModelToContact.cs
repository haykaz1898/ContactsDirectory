using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ContactCatalog;


namespace WpfApp3.ViewModels
{
    public class ContactModelToContact
    {
        public static Contact Convert(ContactModel contactModel)
        {

            var e = new Contact
            {
                Id = contactModel.Id,
                FullName = contactModel.LastName + " " + contactModel.FirstName + " " + contactModel.FatherName,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,

                FatherName = contactModel.FatherName,
                Organization = OrganizationModelToOrganization.Convert(contactModel.Organization),
                Position = contactModel.Position,
                Details = contactModel.Details,
                Gender = contactModel.Gender.ToString(),
                BirthDate = contactModel.BirthDate.ToShortDateString().ToString(),
                PrefferedCommunicationMethod = contactModel.CommunicationMethods
                                                    .Where(t => t.IsPrefered == true)
                                                    .FirstOrDefault().Type.Type,
                CommunicationMethods = new ObservableCollection<CommunicationMethod>(CommunicationMethodModelToCommunicationMethod.Convert(contactModel.CommunicationMethods))
            };

            return e;
        }

        public static IEnumerable<Contact> Convert(IEnumerable<ContactModel> contactModels)
        {
            return contactModels.Select(Convert);
        }
    }
}
