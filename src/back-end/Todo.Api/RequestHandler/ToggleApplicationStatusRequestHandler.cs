using MediatR;
using Todo.Api.Requests;
using Todo.Api.Services;

namespace Todo.Api.RequestHandlers;

public class ToggleApplicationStatusRequestHandler : IRequestHandler<ToggleApplicationStatusRequest>
{

    IToDoService _toDoService;

    public ToggleApplicationStatusRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task Handle(ToggleApplicationStatusRequest request, CancellationToken cancellationToken)
        => await _toDoService.ToggleApplicationStatus(request.ApplicationId);
}
