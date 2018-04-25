using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Refit;

namespace RefitWithAzureFunctions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            var client = RestService.For<IEmailService>("url");

            var result = client.Method();

            return result != null
                ? (ActionResult)new OkObjectResult($"{result}")
                : new BadRequestObjectResult("error");
        }
    }
}
