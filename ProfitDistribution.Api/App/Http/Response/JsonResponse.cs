using Microsoft.AspNetCore.Mvc;

namespace ProfitDistribution.Api.App.Http.Response
{
    public static class JsonResponse
    {
        public static JsonResult Success(object data = null)
        {
            return new JsonResult(data);
        }

        public static JsonResult Error(string message = "Internal Server Error", int statusCode = 500)
        {
            var response = new JsonResult(new
            {
                Error = message != null ? message : "Internal Server Error",
            });
            response.StatusCode = statusCode;
            return response;
        }
    }
}
