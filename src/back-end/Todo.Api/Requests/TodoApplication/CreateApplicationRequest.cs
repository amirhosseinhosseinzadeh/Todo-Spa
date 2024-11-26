namespace Todo.Api.Requests.TodoApplication;

public record CreateApplicationRequest(
    ApplicationDto ApplicationDto
) : IRequest<ApplicationDto>;
