using ETM.API.Core.Entities;

using System.Linq.Expressions;

namespace ETM.API.Service.Interfaces
{
    public interface ICommentService
    {
        Task<bool> AddCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(Expression<Func<Comment, bool>> condition);
        Task<bool> UpdateCommentAsync(Expression<Func<Comment, bool>> condition, Comment updatedComment);
    }
}
