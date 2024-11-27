namespace Todo.Api.RequestHandlers;

public class UpdateTodoApplicationRequestHandler : IRequestHandler<UpdateTodoApplicationRequest, ApplicationDto>
{
    private readonly IToDoService _toDoService;

    public UpdateTodoApplicationRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task<ApplicationDto> Handle(UpdateTodoApplicationRequest request, CancellationToken cancellationToken)
        => await _toDoService.Update(request.ApplicationDto, cancellationToken);
}