using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class OrganizationEntity
    {
        [Key]
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public bool IsMain { get; set; }
    }
}
