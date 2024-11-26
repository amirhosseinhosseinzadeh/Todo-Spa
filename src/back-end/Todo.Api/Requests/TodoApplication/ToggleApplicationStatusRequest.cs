namespace Todo.Api.Requests.TodoApplication;

public record ToggleApplicationStatusRequest(int ApplicationId) : IRequest;