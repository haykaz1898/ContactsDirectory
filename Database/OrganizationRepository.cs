using System.Collections.Generic;
using Database.Contexts;
using System.Linq;
using System.Data.Entity;

namespace Database
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private DirectoryContext _directoryContext;

        public OrganizationRepository(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
        }

        public void AddNewOrganization(OrganizationEntity organizationEntity)
        {
            _directoryContext.OrganizationEntities.Add(organizationEntity);
            _directoryContext.SaveChanges();
        }

        public IEnumerable<OrganizationEntity> GetAllOrganizations()
        { 
            return _directoryContext.OrganizationEntities.ToList();
        }

        public OrganizationEntity GetOrganization(string organizationName)
        {
            return _directoryContext.OrganizationEntities
                .Where(o => o.OrganizationName == organizationName)
                .FirstOrDefault();
        }

        public void RemoveOrganization(OrganizationEntity organizationEntity)
        {
            var result = _directoryContext.OrganizationEntities.SingleOrDefault(p => p.OrganizationName == organizationEntity.OrganizationName);

            _directoryContext.Entry(result).State = EntityState.Deleted;
            _directoryContext.SaveChanges();   
        }

        public void UpdateOrganization(OrganizationEntity organizationEntity)
        {
            var result = _directoryContext.OrganizationEntities.
               SingleOrDefault(p => p.OrganizationId == organizationEntity.OrganizationId);

            if (result != null)
            {
                _directoryContext.Entry(result).CurrentValues.SetValues(organizationEntity);

                _directoryContext.SaveChanges();

            }
        }
    }
}
    

