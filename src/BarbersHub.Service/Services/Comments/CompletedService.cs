using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Comments;
using BarbersHub.Service.DTOs.Comments.Completeds;

namespace BarbersHub.Service.Services.Comments;

public class CompletedService : ICompletedService
{
    public Task<CompletedForResultDto> AddAsync(CompletedForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<CompletedForResultDto> ModifyAsync(long id, CompletedForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CompletedForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<CompletedForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
