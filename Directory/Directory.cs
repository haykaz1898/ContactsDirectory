using Database;
using Database.Contexts;

namespace ContactCatalog
{
    public class Directory
    {
        private static DirectoryContext _directoryContext = null;

        private static IContactManager _contactManager = null;

        private Directory() { }

        public static void Setup(string connectionString)
        {
            if (_directoryContext != null)
                return;

            _directoryContext = new DirectoryContext(connectionString);
        }

        public static IContactManager GetContactManager()
        {
            if (_directoryContext != null)
            {
                if (_contactManager == null)
                {
                    _contactManager = new ContactManager(new ContactRepository(_directoryContext));
                }
                return _contactManager;
            }
            throw new System.Exception("Database context is not initialized");
        }

        public static IOrganizationManager GetOrganizationManager()
        {
            if (_directoryContext != null)
            {
                return new OrganizationManager(new OrganizationRepository(_directoryContext));
            }
            throw new System.Exception("Database context is not initialized");
        }

        public static ICommunicationTypeManager GetCommunicationTypeManager()
        {
            if (_directoryContext != null)
            {
                return new CommunicationTypeManager(new CommunicationTypeRepository(_directoryContext));
            }
            throw new System.Exception("Database context is not initialized");
        }
    }

}
