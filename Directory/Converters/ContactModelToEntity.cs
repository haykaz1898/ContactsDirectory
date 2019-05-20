using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    internal class ContactModelToEntity : IModelToEntity<ContactModel, ContactEntity>
    {
        public ContactEntity Convert(ContactModel model)
        {
            GenderModelToEntity genderModelToEntity = new GenderModelToEntity();
            OrganizationModelToEntity organizationModelToEntity = new OrganizationModelToEntity();
            CommunicationMethodModelToEntity communicationMethodModelToEntity = new CommunicationMethodModelToEntity();
            return new ContactEntity
            {
                ContactId = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FatherName = model.FatherName,
                BirthDate = model.BirthDate,
                Organization = organizationModelToEntity.Convert(model.Organization),
                Position = model.Position,
                Details = model.Details,
                Gender = genderModelToEntity.Convert(model.Gender),
                OrganizationId = organizationModelToEntity.Convert(model.Organization).OrganizationId,
                GenderId = genderModelToEntity.Convert(model.Gender).GenderId,
                CommunicationMethods = communicationMethodModelToEntity.Convert(model.CommunicationMethods).ToList()
            };
        }

        public IEnumerable<ContactEntity> Convert(IEnumerable<ContactModel> models)
        {
            return models.Select(Convert);
        }
    }

}
