using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProfitDistribution.Api.App.Adapters;
using ProfitDistribution.Api.App.Database;
using ProfitDistribution.Api.App.Http.Response;
using ProfitDistribution.Api.Core.Modules.Distribution;
using ProfitDistribution.Api.App.Http.Requests.Distribution;
using ProfitDistribution.Api.App.Http.Presenters.Distribution;
using ProfitDistribution.Api.App.Adapters.Modules.Distribution;
using ProfitDistribution.Api.Core.Modules.Distribution.Exceptions;
using ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence;

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

        /// <summary>
        /// Generates profit distribution from an input value for distribution
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /distribution
        ///     {
        ///        "available_value": 500000022
        ///     }
        ///
        /// </remarks>
        /// <response code="200">A distribution report</response>
        /// <response code="400">If the available value is insufficient</response>  
        /// <response code="500">To internal server erros</response>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Distribution([FromServices] InMemoryDataContext context, [FromBody] DistributionRequest request)
        {
            if (!ModelState.IsValid)
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
                return JsonResponse.Success((new DistributionPresenter(response)).Present());
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
