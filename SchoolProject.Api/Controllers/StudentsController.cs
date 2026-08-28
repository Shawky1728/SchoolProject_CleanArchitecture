using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Authorization;
using SchoolProject.Core.Features.Students.Commands.AddStudent;
using SchoolProject.Core.Features.Students.Commands.DeleteStudent;
using SchoolProject.Core.Features.Students.Commands.UpdateStudent;
using SchoolProject.Core.Features.Students.Queries.GetStudentById;
using SchoolProject.Core.Features.Students.Queries.GetStudents;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Authorization;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentsController : BaseController
    {

        public StudentsController(IMediator mediator) : base(mediator)
        {

        }

        [HasPermission(Permissions.GetStudents)]
        [HttpGet(Router.Students.GetAll)]
        public async Task<IActionResult> GetAllStudents([FromQuery] GetStudentsRequestFilters filters, CancellationToken cancellationToken)
        {
            var query = new GetStudentsQuery(filters.PageNumber, filters.PageSize, filters.SearchTerm, filters.OrderBy);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }


        [HasPermission(Permissions.GetStudents)]
        [HttpGet(Router.Students.GetById)]
        public async Task<IActionResult> GetStudentById(int id, CancellationToken cancellationToken)
        {
            var query = new GetStudentByIdQuery(id);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }

        [HasPermission(Permissions.AddStudent)]
        [HttpPost(Router.Students.Add)]
        public async Task<IActionResult> AddStudent(AddStudentCommand addStudentCommand, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(addStudentCommand, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }

        [HasPermission(Permissions.UpdateStudent)]
        [HttpPut(Router.Students.Update)]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand updateStudentCommand, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(updateStudentCommand, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }

        [HasPermission(Permissions.DeleteStudent)]
        [HttpDelete(Router.Students.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id, CancellationToken cancellationToken)
        {
            var command = new DeleteStudentCommand(id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
