using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.Comments.Comments;

namespace BarbersHub.Service.Interfaces.Comments;

public interface ICommentService
{
    Task<bool> RemoveAsync(long id);
    Task<CommentForResultDto> RetrieveByIdAsync(long id);
    Task<CommentForResultDto> AddAsync(CommentForCreationDto dto);
    Task<CommentForResultDto> ModifyAsync(long id, CommentForUpdateDto dto);
    Task<IEnumerable<CommentForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
