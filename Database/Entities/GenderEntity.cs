using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class GenderEntity
    {
        [Key]
        public int GenderId { get; set; }
        public string Gender { get; set; } 
    }
}
