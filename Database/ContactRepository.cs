using System.Collections.Generic;
using Database.Contexts;
using System.Linq;
using System.Data.Entity;

namespace Database
{
    public class ContactRepository : IContactRepository
    {
        private DirectoryContext _directoryContext;

        public ContactRepository(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
        }
        
        public void AddContact(ContactEntity contactEntity)
        {
            _directoryContext.ContactEntities.Add(contactEntity);
            _directoryContext.SaveChanges();
        }

        public IEnumerable<ContactEntity> GetAllContacts()
        {
            return _directoryContext.ContactEntities
                .Include(p => p.CommunicationMethods.Select(t => t.Type))
                .Include(p => p.Organization)
                .Include(p => p.Gender)
                .ToList();
        }

        public ContactEntity GetContact(string FirstName, string LastName, string FatherName)
        { 
            var e = _directoryContext.ContactEntities
                .Include(p => p.CommunicationMethods.Select(t => t.Type))
                .Include(p => p.Organization)
                .Include(p => p.Gender)
                .Where(c => c.FirstName == FirstName && c.LastName == LastName && c.FatherName == FatherName)
                .FirstOrDefault();
            return e;
        }

        public IEnumerable<ContactEntity> GetContactsRange(int startIndex, int endIndex, string filter)
        {
            if (filter == "")
            {
                return _directoryContext.ContactEntities
                    .Include(p => p.CommunicationMethods.Select(t => t.Type))
                    .Include(p => p.Organization)
                    .Include(p => p.Gender)
                    .OrderBy(p => p.LastName)
                    .Skip(startIndex)
                    .Take(endIndex)
                    .ToList();
            }
            return _directoryContext.ContactEntities.Where(c=>c.FirstName.IndexOf(filter) >= 0 || c.LastName.IndexOf(filter) >= 0 || c.FatherName.IndexOf(filter) >= 0)
                    .Include(p => p.CommunicationMethods.Select(t => t.Type))
                    .Include(p => p.Organization)
                    .Include(p => p.Gender)
                    .OrderBy(p => p.LastName)
                    .Skip(startIndex)
                    .Take(endIndex)
                    .ToList();
        }

        public int GetCount(string filter)
        {
            if (filter == "")
            {
                return _directoryContext.ContactEntities.Count();
            }
            return _directoryContext.ContactEntities.Where(c => c.FirstName.IndexOf(filter) >= 0 || c.LastName.IndexOf(filter) >= 0 || c.FatherName.IndexOf(filter) >= 0).Count(); 
        }

        public void AddCommunicationMethod(ContactEntity contactEntity, CommunicationMethodEntity communicationMethodEntity)
        {
            var result = _directoryContext.CommunicationMethodEntities
                .SingleOrDefault(p => p.Address == communicationMethodEntity.Address && p.TypeId == communicationMethodEntity.TypeId && p.ContactId == contactEntity.ContactId);
            if (result == null)
            {
                communicationMethodEntity.ContactId = contactEntity.ContactId;
                _directoryContext.CommunicationMethodEntities.Add(communicationMethodEntity);
                _directoryContext.SaveChanges();
                _directoryContext.Entry(communicationMethodEntity).Reload();
            }
            else throw new System.Exception("An entry with this address is already exists");

        }

        public void RemoveCommunicationMethod(CommunicationMethodEntity communicationMethodEntity)
        {
            var result = _directoryContext.CommunicationMethodEntities.SingleOrDefault(p => p.Address == communicationMethodEntity.Address);

            _directoryContext.Entry(result).State = EntityState.Deleted;
            _directoryContext.SaveChanges();
        }

        public void UpdateCommunicationMethod(CommunicationMethodEntity communicationMethodEntity)
        {
            var result = _directoryContext.CommunicationMethodEntities
                .SingleOrDefault(p => p.CommunicationMethodId == communicationMethodEntity.CommunicationMethodId);

            if (result != null)
            {
                _directoryContext.Entry(result).CurrentValues.SetValues(communicationMethodEntity);
            }
        }

        public void UpdateContact(ContactEntity contactEntity)
        {
            
            var result = _directoryContext.ContactEntities.
                SingleOrDefault(p => p.ContactId == contactEntity.ContactId);

            if (result != null)
            {
                _directoryContext.Entry(result).CurrentValues.SetValues(contactEntity);

                _directoryContext.SaveChanges();
                
            }
        }
    }
}
    

