using Kpa.Assessment.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kpa.Assessment.WebApi;

public static class ResultExtensions
{
    // allows for easy http response mapping
    public static async Task<ObjectResult> ToHttpJsonResponse<T>(this Task<Result<T>> result)
    {
        var res = await result;
        if (res.Failed())
        {
            return new ObjectResult(new
            {
                res.ErrorMessage
            })
            {
                StatusCode = (int)res.Status
            };
        }

        return new OkObjectResult(res.Content);
    }
}