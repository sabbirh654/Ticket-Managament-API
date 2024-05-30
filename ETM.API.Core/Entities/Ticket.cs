namespace ETM.API.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public DateTime DueDate { get; set; }
        public User User { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
