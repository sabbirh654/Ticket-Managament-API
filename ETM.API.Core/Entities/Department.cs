using System.ComponentModel.DataAnnotations;

namespace ETM.API.Core.Entities
{
    public class Department : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
