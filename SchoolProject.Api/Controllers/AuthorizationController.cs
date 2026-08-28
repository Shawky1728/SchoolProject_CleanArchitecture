using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Authorization.Commands.AddRole;
using SchoolProject.Core.Features.Authorization.Commands.DeleteRole;
using SchoolProject.Core.Features.Authorization.Commands.EditRole;
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

        [HttpPut(Router.Authorization.EditRole)]
        public async Task<IActionResult> EditRole([FromBody] EditRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpDelete(Router.Authorization.DeleteRole)]
        public async Task<IActionResult> DeleteRole([FromRoute] string id)
        {
            var response = await _mediator.Send(new DeleteRoleCommand(id));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
