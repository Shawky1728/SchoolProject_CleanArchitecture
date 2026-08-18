using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.AddStudent;
using SchoolProject.Core.Features.Students.Queries.GetStudentById;
using SchoolProject.Core.Features.Students.Queries.GetStudents;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.Students.GetAll)]
        public async Task<IActionResult> GetAllStudents(CancellationToken cancellationToken)
        {
            var query = new GetStudentsQuery();
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet(Router.Students.GetById)]
        public async Task<IActionResult> GetStudentById(int id, CancellationToken cancellationToken)
        {
            var query = new GetStudentByIdQuery(id);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost(Router.Students.Add)]
        public async Task<IActionResult> AddStudent(AddStudentRequest addStudentRequest, CancellationToken cancellationToken)
        {
            var query = new AddStudentCommand(addStudentRequest);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
