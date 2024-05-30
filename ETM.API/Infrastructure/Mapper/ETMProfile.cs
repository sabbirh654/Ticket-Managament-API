using AutoMapper;

using ETM.API.Core.Entities;
using ETM.API.Models.DTOs.Comment;
using ETM.API.Models.DTOs.Ticket;

namespace ETM.API.Infrastructure.Mapper
{
    public class ETMProfile : Profile
    {
        public ETMProfile()
        {
            CreateMap<Ticket, TicketAddDTO>().ReverseMap();
            CreateMap<Ticket, TicketUpdateDTO>().ReverseMap();
            CreateMap<Comment, CommentAddDTO>().ReverseMap();
            CreateMap<Comment, CommentUpdateDTO>().ReverseMap();
        }
    }
}
