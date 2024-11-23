using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Api.Infrastuctures.Services;

public class ActionRestltWrapperFactory : IActionResultWrapperFactory
{
    public IActionResultWrapper CreateFor(FilterContext context)
    {
        if (context is not { })
            throw new ArgumentNullException(nameof(context));
        switch (context)
        {
            case ResultExecutingContext resultExecutingContext when resultExecutingContext.Result is ObjectResult:
                return new ObjectActionResultWrapper();

            case ResultExecutingContext resultExecutingContext when resultExecutingContext.Result is JsonResult:
                return new JsonActionResultWrapper();

            case ResultExecutingContext resultExecutingContext when resultExecutingContext.Result is EmptyResult:
                return new EmptyActionResultWrapper();

            case PageHandlerExecutedContext pageHandlerExecutedContext when pageHandlerExecutedContext.Result is ObjectResult:
                return new ObjectActionResultWrapper();

            case PageHandlerExecutedContext pageHandlerExecutedContext when pageHandlerExecutedContext.Result is JsonResult:
                return new JsonActionResultWrapper();

            case PageHandlerExecutedContext pageHandlerExecutedContext when pageHandlerExecutedContext.Result is EmptyResult:
                return new EmptyActionResultWrapper();

            default:
                return new NullActionResultWrapper();
        }
    }

    public IActionResultWrapper CreateFor(EndpointFilterInvocationContext context)
    {
        throw new NotImplementedException();
        //switch (context)
        //{
        //    case ResultExecutingContext resultExecutingContext when resultExecutingContext.Result is ObjectResult:
        //        return new ObjectActionResultWrapper();
        //}
    }
}
