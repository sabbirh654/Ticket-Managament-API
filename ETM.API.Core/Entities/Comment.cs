using System.ComponentModel.DataAnnotations;

namespace ETM.API.Core.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        [MaxLength(2000)]
        public string Message { get; set; }
        public User User { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
