using Todo.Api.Dtos;
using Todo.Api.Dtos.Customqueires;
using Todo.Api.Entities;

namespace Todo.Api.Services;

public interface IToDoService
{
    Task<ApplicationDto> Create(ApplicationDto applicationDto);

    Task<List<ApplicationDto>> GetList(BaseCustomQuery input);

    Task<ApplicationDto> GetById(int applicationId);

    Task ToggleApplicationStatus(int applicationId);
}
