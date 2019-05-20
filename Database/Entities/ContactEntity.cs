using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{

    public class ContactEntity
    {
        [Key]
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? GenderId { get; set; }
        public GenderEntity Gender { get; set; }
        public int OrganizationId { get; set; }
        public OrganizationEntity Organization { get; set; }
        public string Position { get; set; }
        public string Details { get; set; }
        public ICollection<CommunicationMethodEntity> CommunicationMethods { get; set; }

    }
}
