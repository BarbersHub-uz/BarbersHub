using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.Comments.Comments;
using BarbersHub.Service.Interfaces.Comments;

namespace BarbersHub.Service.Services.Comments;

public class CommentService : ICommentService
{
    public Task<CommentForResultDto> AddAsync(CommentForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<CommentForResultDto> ModifyAsync(long id, CommentForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CommentForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<CommentForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
