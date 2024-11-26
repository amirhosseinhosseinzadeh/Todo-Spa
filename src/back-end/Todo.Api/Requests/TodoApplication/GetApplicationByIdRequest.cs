namespace Todo.Api.Requests.TodoApplication;

public record GetApplicationByIdRequest(int ApplicationId) : IRequest<ApplicationDto>;
