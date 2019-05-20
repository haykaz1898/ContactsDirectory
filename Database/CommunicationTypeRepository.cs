using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Database.Contexts;

namespace Database
{
    public class CommunicationTypeRepository : ICommunicationTypeRepository
    {
        private DirectoryContext _directoryContext;
        
        public CommunicationTypeRepository(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
        }

        public void AddCommunicationType(CommunicationTypeEntity communicationMethodEntity)
        {
            _directoryContext.CommunicationTypeEntities.Add(communicationMethodEntity);
            _directoryContext.SaveChanges();
        }

        public IEnumerable<CommunicationTypeEntity> GetAllTypes()
        {
            return _directoryContext.CommunicationTypeEntities.ToList();
        }

        public CommunicationTypeEntity GetCommunicationType(string communicationType)
        {       
            return _directoryContext.CommunicationTypeEntities
                .Where(o => o.Type == communicationType)
                .FirstOrDefault();
        }

        public void RemoveCommunicationType(CommunicationTypeEntity communicationMethodEntity)
        {
            var result = _directoryContext.CommunicationTypeEntities.SingleOrDefault(p => p.Type == communicationMethodEntity.Type);

            _directoryContext.Entry(result).State = EntityState.Deleted;
            _directoryContext.SaveChanges();
            
        }
    }
}
