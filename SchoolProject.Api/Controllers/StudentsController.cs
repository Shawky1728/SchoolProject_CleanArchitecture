using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Queries.GetStudents;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents(CancellationToken cancellationToken)
        {
            var query = new GetStudentsQuery();
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
