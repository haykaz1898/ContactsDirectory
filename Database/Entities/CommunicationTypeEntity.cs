using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class CommunicationTypeEntity
    {
        [Key]
        public int TypeId { get; set; }
        public string Type { get; set; }
    }
}
