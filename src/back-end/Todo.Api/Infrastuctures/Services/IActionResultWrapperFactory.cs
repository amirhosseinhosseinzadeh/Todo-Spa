using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Api.Infrastuctures.Services;

public interface IActionResultWrapperFactory
{
    IActionResultWrapper CreateFor(FilterContext context);

    IActionResultWrapper CreateFor(EndpointFilterInvocationContext context);
}
