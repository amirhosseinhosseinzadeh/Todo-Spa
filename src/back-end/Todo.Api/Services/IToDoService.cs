namespace Todo.Api.Services;

public interface IToDoService
{
    Task<ApplicationDto> Create(ApplicationDto applicationDto, CancellationToken cancellationToken = default);

    Task<List<ApplicationDto>> GetList(BaseCustomQuery input, CancellationToken cancellationToken = default);

    Task<ApplicationDto> GetById(int applicationId, CancellationToken cancellationToken = default);

    Task ToggleApplicationStatus(int applicationId, CancellationToken cancellationToken = default);

    Task DeleteById(int applicationId, CancellationToken cancellationToken = default);

    Task<ApplicationDto> Update(ApplicationDto applicationDto, CancellationToken cancellationToken);
}
