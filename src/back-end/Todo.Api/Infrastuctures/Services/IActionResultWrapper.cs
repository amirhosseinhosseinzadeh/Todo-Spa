using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Api.Infrastuctures.Services;

public interface IActionResultWrapper
{
    void Wrap(FilterContext context);
}