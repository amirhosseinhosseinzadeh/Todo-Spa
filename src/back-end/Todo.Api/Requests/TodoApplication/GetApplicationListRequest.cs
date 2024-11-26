namespace Todo.Api.Requests.TodoApplication;

public record GetApplicationListRequest(BaseCustomQuery Input) : IRequest<List<ApplicationDto>>;
