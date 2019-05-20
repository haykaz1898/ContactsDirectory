using ContactCatalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp3.ViewModels
{
    public class ContactToContactModel
    {
        public static ContactModel Convert(Contact contact)
        {
            DateTime birthDate = new DateTime();
            DateTime.TryParse(contact.BirthDate, out birthDate);
           
            var e = new ContactModel
            {
                Id = contact.Id,
                BirthDate = birthDate,
                Gender = (GenderModel)Enum.Parse(typeof(GenderModel),contact.Gender),
                CommunicationMethods = CommunicationMethodToCommunicationMethodModel.Convert(contact.CommunicationMethods),
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                FatherName = contact.FatherName,
                Position = contact.Position,
                Details = contact.Details,
                Organization = OrganizationToOrganizationModel.Convert(contact.Organization)
            };
            return e;
        }

        public static IEnumerable<ContactModel> Convert(IEnumerable<Contact> contacts)
        {
            return contacts.Select(Convert);
        }
    }
}
