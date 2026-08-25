using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Users.Commands.AddUser;
using SchoolProject.Core.Features.Users.Queries.GetUserById;
using SchoolProject.Core.Features.Users.Queries.GetUsers;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Router.Users.Add)]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet(Router.Users.GetAll)]
        public async Task<IActionResult> GetUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string searchTerm = "")
        {
            var query = new GetUsersQuery(pageNumber, pageSize, searchTerm);
            var response = await _mediator.Send(query);
            return StatusCode((int)response.StatusCode, response);

        }

        [HttpGet(Router.Users.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var response = await _mediator.Send(query);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}

