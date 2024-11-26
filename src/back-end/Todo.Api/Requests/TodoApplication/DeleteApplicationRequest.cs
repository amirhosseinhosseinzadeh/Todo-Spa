namespace Todo.Api.Requests.TodoApplication;

public record DeleteApplicationRequest(int TodoApplicationId) : IRequest;