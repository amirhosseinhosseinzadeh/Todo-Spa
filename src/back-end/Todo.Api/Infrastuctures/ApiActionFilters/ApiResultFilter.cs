using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Todo.Api.Infrastuctures.Services;

namespace Todo.Api.Infrastuctures.ApiActionFilters;

public class ApiResultFilter : IResultFilter
{
    private readonly IActionResultWrapperFactory _actionResultWrapperFactory;

    public ApiResultFilter(IActionResultWrapperFactory actionResultWrapperFactory)
        => _actionResultWrapperFactory = actionResultWrapperFactory;

    public void OnResultExecuted(ResultExecutedContext context)
    { }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (!(context.ActionDescriptor is ControllerActionDescriptor))
        {
            return;
        }
        _actionResultWrapperFactory.CreateFor(context).Wrap(context);
    }
}