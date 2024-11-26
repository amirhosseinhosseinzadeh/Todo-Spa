namespace Todo.Api.RequestHandlers;

public class DeleteApplicationRequestHandler : IRequestHandler<DeleteApplicationRequest>
{
    private readonly IToDoService _todoService;

    public DeleteApplicationRequestHandler(IToDoService todoService)
        => _todoService = todoService;


    public async Task Handle(DeleteApplicationRequest request, CancellationToken cancellationToken)
        => await _todoService.DeleteById(request.TodoApplicationId);

}