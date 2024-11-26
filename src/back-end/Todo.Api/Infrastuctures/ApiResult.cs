namespace Todo.Api.Infrastuctures;

public record ApiResult
{
    //TODO: complete issue related to deserializing of exception
    public static ApiResult InitilizeFailureApiResult(Exception ex)
    {
        return new ApiResult()
        {
            Result = null,
            Error = ex.Message,
            Success = false
        };
    }

    public static ApiResult InitilizeSuccessfullApiResult(object result)
    {
        return new ApiResult()
        {
            Success = true,
            Error = null,
            Result = result
        };
    }

    private ApiResult()
    {

    }

    public object Result { get; set; }

    public bool Success { get; set; }

    public string Error { get; set; }
}