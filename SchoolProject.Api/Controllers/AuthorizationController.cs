using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Authorization.Commands.AddRole;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{

    [ApiController]
    public class AuthorizationController : BaseController
    {
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Router.Authorization.AddRole)]
        public async Task<IActionResult> AddRole([FromBody] AddRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
