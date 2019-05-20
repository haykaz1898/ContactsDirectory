using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Database.Contexts
{
    public class DirectoryContext : DbContext
    {
        public DirectoryContext(string connectionString) 
            : base(connectionString) {  }

        public DbSet<ContactEntity> ContactEntities { get; set; }
        public DbSet<GenderEntity> GenderEntities { get; set; }
        public DbSet<OrganizationEntity> OrganizationEntities { get; set; }
        public DbSet<CommunicationMethodEntity> CommunicationMethodEntities { get; set; }
        public DbSet<CommunicationTypeEntity> CommunicationTypeEntities { get; set; }
    }
}
