namespace ETM.API.Models.DTOs.Comment
{
    public class CommentAddDTO
    {
        public int CreatedBy { get; set; }
        public int TicketId { get; set; }
        public string Message { get; set; }
    }
}
