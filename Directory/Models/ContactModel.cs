using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalog
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderModel Gender { get; set; }
        public string Position { get; set; }
        public string Details { get; set; }
        public OrganizationModel Organization { get; set; }
        public IEnumerable<CommunicationMethodModel> CommunicationMethods { get; set; }
    }
}
