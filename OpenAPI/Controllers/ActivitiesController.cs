using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using Domain;
using OpenApp.Activities;

namespace OpenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List()
        {
            return await _mediator.Send(new List.Query());
        }
    }
}