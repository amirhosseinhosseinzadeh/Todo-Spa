using MediatR;
using Todo.Api.Dtos;
using Todo.Api.Requests;
using Todo.Api.Services;

namespace Todo.Api.RequestHandlers;

public class AddApplicationRequestHandler : IRequestHandler<CreateApplicationRequest, ApplicationDto>
{
    private readonly IToDoService _toDoService;

    public AddApplicationRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task<ApplicationDto> Handle(CreateApplicationRequest request, CancellationToken cancellationToken)
        => await _toDoService.Create(request.ApplicationDto);
}
