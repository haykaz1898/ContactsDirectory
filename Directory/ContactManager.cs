using System.Collections.Generic;
using Database;
using System.Linq;

namespace ContactCatalog
{
    public class ContactManager : IContactManager
    {
        public IEnumerable<ContactModel> _contacts;
        
        private IContactRepository _contactRepository;
        private IModelToEntity<ContactModel, ContactEntity> _modelToEntity = new ContactModelToEntity();
        private IEntityToModel<ContactEntity, ContactModel> _entityToModel = new ContactEntityToModel();
        private IModelToEntity<CommunicationMethodModel, CommunicationMethodEntity> _communicationModelToEntity = new CommunicationMethodModelToEntity();

        private string _filter = "";

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void AddContact(ContactModel contact)
        {
            _contactRepository.AddContact(_modelToEntity.Convert(contact));
        }

        public ContactModel FindContactByPartOfName(string Name)
        {
            throw new System.NotImplementedException();
        }

        public ContactModel GetContactByFullName(string FirstName, string LastName, string FatherName)
        {
            return _entityToModel.Convert(_contactRepository.GetContact(FirstName, LastName, FatherName));
        }
        
        public void RemoveContact(ContactModel contact)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ContactModel> GetAllContacts()
        {
            return _entityToModel.Convert(_contactRepository.GetAllContacts());
        }

        public IEnumerable<ContactModel> GetContactsRange(int start, int count)
        {
            return _entityToModel.Convert(_contactRepository.GetContactsRange(start, start + count,_filter));
        }
                
        public int GetCount()
        {
            return _contactRepository.GetCount(_filter);
        }

        public void UpdateContact(ContactModel contact)
        {
            _contactRepository.UpdateContact(_modelToEntity.Convert(contact));
        }

        public void AddCommunicationMethod(ContactModel contact, CommunicationMethodModel communicationMethod)
        {
            _contactRepository.AddCommunicationMethod(_modelToEntity.Convert(contact), _communicationModelToEntity.Convert(communicationMethod));
        }

        public void UpdateCommunicationMethod(CommunicationMethodModel communicationMethodEntity)
        {
            _contactRepository.UpdateCommunicationMethod(_communicationModelToEntity.Convert(communicationMethodEntity));
        }

        public void RemoveCommunicationMethod(CommunicationMethodModel communicationMethodEntity)
        {
            _contactRepository.RemoveCommunicationMethod(_communicationModelToEntity.Convert(communicationMethodEntity));
        }

        public void SetFilter(string filter)
        {
            _filter = filter;
        }

        public void ResetFilter()
        {
            _filter = "";
        }
    }

}
