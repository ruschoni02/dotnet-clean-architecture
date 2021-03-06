using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfitDistribution.Api.App.Adapters;
using ProfitDistribution.Api.App.Database;
using ProfitDistribution.Api.App.Http.Response;
using ProfitDistribution.Api.Core.Modules.Distribution;
using ProfitDistribution.Api.App.Http.Requests.Distribution;
using ProfitDistribution.Api.App.Http.Presenters.Distribution;
using ProfitDistribution.Api.App.Adapters.Modules.Distribution;
using ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence;
using ProfitDistribution.Api.Core.Modules.Distribution.Exceptions;

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
        public ActionResult Distribution([FromServices] InMemoryDataContext context, [FromBody] DistributionRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var useCase = new UseCase(
                    _logger,
                    new EmployeeAdapter(context),
                    new CalculationInfluenceAdapter(
                        new AreaCalculator(),
                        new SalaryCalculator(),
                        new AdmissionAtCalculator()
                    )
                );
                var response = useCase.Execute(new Request(
                    request.AvailableValue
                ));
                return JsonResponse.Success((new DistributionPresenter(response)).present());
            }
            catch (InsufficientAvailableValueException exception)
            {
                return JsonResponse.Error(exception.Message, 400);
            }
            catch (System.Exception exception)
            {
                return JsonResponse.Error(exception.Message);
            }
        }
    }
}
