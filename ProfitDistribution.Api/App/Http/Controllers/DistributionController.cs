using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfitDistribution.Api.App.Adapters;
using ProfitDistribution.Api.App.Http.Response;
using ProfitDistribution.Api.Core.Modules.Distribution;

namespace ProfitDistribution.Api.App.HttpControllers
{
    [ApiController]
    [Route("distribution")]
    public class DistributionController : ControllerBase
    {
        private readonly LoggerAdapter _logger;

        public DistributionController(ILogger<DistributionController> logger)
        {
            _logger = new LoggerAdapter(logger);
        }

        [HttpPost]
        public JsonResult Distribution()
        {
            try
            {
                var useCase = new UseCase(_logger);
                useCase.Execute(new Core.Modules.Distribution.Request());
                return JsonResponse.Success();
            }
            catch (System.Exception exception)
            {
                return JsonResponse.Error(exception.Message);
            }
        }
    }
}
