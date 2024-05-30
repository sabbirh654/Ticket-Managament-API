using System.ComponentModel.DataAnnotations;

namespace ETM.API.Core.Entities
{
    public class Status : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
