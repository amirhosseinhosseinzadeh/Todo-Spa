﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Todo.Api.Infrastuctures.Services;

namespace Todo.Api.Infrastuctures;

public class JsonActionResultWrapper : IActionResultWrapper
{
    public void Wrap(FilterContext context)
    {
        JsonResult jsonResult = null;

        switch (context)
        {
            case ResultExecutingContext resultExecutingContext:
                jsonResult = resultExecutingContext.Result as JsonResult;
                break;

            case PageHandlerExecutedContext pageHandlerExecutedContext:
                jsonResult = pageHandlerExecutedContext.Result as JsonResult;
                break;
        }

        if (jsonResult == null)
        {
            throw new ArgumentException("Action Result should be JsonResult!");
        }

        if (!(jsonResult.Value is ApiResult))
        {
            jsonResult.Value = ApiResult.InitilizeSuccessfullApiResult(jsonResult.Value);
        }
    }
}
