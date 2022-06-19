using Application.Queries.GetVaccinationQueue;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace VaccinationQueue.Api.ForFrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationQueuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VaccinationQueuesController(IMediator mediator)
        {
            _mediator = Guard.Against.Null(mediator, nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetVaccinationQueueQuery(), cancellationToken);

            return StatusCode(StatusCodes.Status200OK, result.VaccinationQueue);
        }
    }
}
