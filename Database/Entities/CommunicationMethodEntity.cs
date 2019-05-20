using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class CommunicationMethodEntity
    {
        [Key]
        public int CommunicationMethodId { get; set; }

        public int? ContactId { get; set; }

        public ContactEntity Contact { get; set; }

        public string Address { get; set; }

        public int? TypeId { get; set; }

        public CommunicationTypeEntity Type { get; set; }

        public bool IsPreffered { get; set; }

    }
}
