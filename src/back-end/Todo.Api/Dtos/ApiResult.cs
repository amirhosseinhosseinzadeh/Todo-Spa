namespace Todo.Api.Dtos;

public class ApiResult<TResult>
{
    public bool Success { get; set; }

    public TResult Result { get; set; }

    public Exception Error { get; set; }
}