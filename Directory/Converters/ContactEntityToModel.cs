using System.Collections.Generic;
using Database;
using System.Linq;
namespace ContactCatalog
{
    internal class ContactEntityToModel : IEntityToModel<ContactEntity, ContactModel>
    {
        public ContactModel Convert(ContactEntity entity)
        {
            GenderEntityToModel genderEntityToModel = new GenderEntityToModel();
            OrganizationEntityToModel organizationEntityToModel = new OrganizationEntityToModel();
            CommunicationMethodEntityToModel communicationMethodEntityToModel = new CommunicationMethodEntityToModel();
            return new ContactModel
            {
                Id = entity.ContactId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                FatherName = entity.FatherName,
                BirthDate = entity.BirthDate,
                Position = entity.Position,
                Details = entity.Details,
                Gender = genderEntityToModel.Convert(entity.Gender),
                Organization = organizationEntityToModel.Convert(entity.Organization),
                CommunicationMethods = communicationMethodEntityToModel.Convert(entity.CommunicationMethods),
            };
        }

        public IEnumerable<ContactModel> Convert(IEnumerable<ContactEntity> entities)
        {
            return entities.Select(Convert);
        }
    }

}
