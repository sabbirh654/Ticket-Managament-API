namespace ETM.API.Models.DTOs.Ticket
{
    public class TicketAddDTO
    {
        public int CreatedBy { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
        public int DepartmentId { get; set; }
    }
}
