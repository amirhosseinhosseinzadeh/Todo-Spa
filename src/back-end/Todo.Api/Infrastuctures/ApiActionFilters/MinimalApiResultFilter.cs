namespace Todo.Api.Infrastuctures.ApiActionFilters;

public class MinimalApiResultFilter : IEndpointFilter
{
    public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var apiResult = await next.Invoke(context);
        return Results.Ok<ApiResult>(ApiResult.InitilizeSuccessfullApiResult(apiResult));
    }
}
