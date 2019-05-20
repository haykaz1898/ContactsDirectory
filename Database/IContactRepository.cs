using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IContactRepository
    {
        IEnumerable<ContactEntity> GetAllContacts();
        IEnumerable<ContactEntity> GetContactsRange(int startIndex, int endIndex, string filter);
        ContactEntity GetContact(string FirstName, string LastName, string FatherName);
        void AddContact(ContactEntity contactEntity);
        void UpdateContact(ContactEntity contactEntity);
        void AddCommunicationMethod(ContactEntity contactEntity, CommunicationMethodEntity communicationMethod);
        void UpdateCommunicationMethod(CommunicationMethodEntity communicationMethodEntity);
        void RemoveCommunicationMethod(CommunicationMethodEntity communicationMethodEntity);
        int GetCount(string filter);
    }
}
    

