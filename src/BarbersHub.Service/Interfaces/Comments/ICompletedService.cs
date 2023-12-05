using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.Comments.Completeds;

namespace BarbersHub.Service.Interfaces.Comments;

public interface ICompletedService
{
    Task<bool> RemoveAsync(long id);
    Task<CompletedForResultDto> RetrieveByIdAsync(long id);
    Task<CompletedForResultDto> AddAsync(CompletedForCreationDto dto);
    Task<CompletedForResultDto> ModifyAsync(long id, CompletedForUpdateDto dto);
    Task<IEnumerable<CompletedForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
