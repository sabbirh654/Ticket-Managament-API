using ETM.API.Core.Entities;
using ETM.API.Core.Exceptions;
using ETM.API.Infrastructure.Interfaces;
using ETM.API.Service.Interfaces;

using System.Linq.Expressions;

namespace ETM.API.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddCommentAsync(Comment comment)
        {
            try
            {
                comment.CreatedOn = DateTime.UtcNow;
                await _unitOfWork.CommentRepository.AddAsync(comment);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in CommentService : AddCommentAsync method", ex);
            }
        }

        public async Task<bool> DeleteCommentAsync(Expression<Func<Comment, bool>> condition)
        {
            try
            {
                var ticketComment = await _unitOfWork.CommentRepository.FindByAsync(condition);

                if (ticketComment != null)
                {
                    await _unitOfWork.CommentRepository.DeleteAsync(ticketComment);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in CommentService : DeleteCommentAsync method", ex);
            }
        }

        public async Task<bool> UpdateCommentAsync(Expression<Func<Comment, bool>> condition, Comment updatedComment)
        {
            try
            {
                var comment = await _unitOfWork.CommentRepository.FindByAsync(condition);

                if (comment != null)
                {
                    comment.ModifiedOn = DateTime.UtcNow;
                    comment.ModifiedBy = updatedComment.ModifiedBy;
                    comment.Message = updatedComment.Message;

                    await _unitOfWork.CommentRepository.UpdateAsync(comment);
                    await _unitOfWork.CommitAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in CommentService : UpdateCommentAsync method", ex);
            }
        }
    }
}
