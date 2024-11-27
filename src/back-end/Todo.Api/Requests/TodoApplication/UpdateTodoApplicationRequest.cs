namespace Todo.Api.Requests.TodoApplication;

public record UpdateTodoApplicationRequest(ApplicationDto ApplicationDto) : IRequest<ApplicationDto>;