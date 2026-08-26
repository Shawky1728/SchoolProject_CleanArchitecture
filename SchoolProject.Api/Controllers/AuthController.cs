using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Auth.Commands.GenerateRefreshToken;
using SchoolProject.Core.Features.Auth.Commands.SignIn;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Router.Users.SignIn)]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost(Router.Users.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromBody] GenerateRefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
