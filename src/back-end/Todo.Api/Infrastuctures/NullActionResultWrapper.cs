using Microsoft.AspNetCore.Mvc.Filters;
using Todo.Api.Infrastuctures.Services;

namespace Todo.Api.Infrastuctures;

public class NullActionResultWrapper : IActionResultWrapper
{
    public void Wrap(FilterContext context)
    {

    }

}