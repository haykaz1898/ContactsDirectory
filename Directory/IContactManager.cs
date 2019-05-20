using System.Collections;
using System.Collections.Generic;

namespace ContactCatalog
{
    public interface IContactManager
    {
        void AddContact(ContactModel contact);
        void RemoveContact(ContactModel contact);
        void UpdateContact(ContactModel contact);
        ContactModel GetContactByFullName(string FirstName, string LastName, string FatherName);
        ContactModel FindContactByPartOfName(string Name);
        IEnumerable<ContactModel> GetAllContacts();
        IEnumerable<ContactModel> GetContactsRange(int start, int count);
        int GetCount();
        void SetFilter(string filter);
        void ResetFilter();
        void AddCommunicationMethod(ContactModel contactModel, CommunicationMethodModel communicationMethodModel);
        void UpdateCommunicationMethod(CommunicationMethodModel communicationMethodEntity);
        void RemoveCommunicationMethod(CommunicationMethodModel communicationMethodEntity);
    }
}
