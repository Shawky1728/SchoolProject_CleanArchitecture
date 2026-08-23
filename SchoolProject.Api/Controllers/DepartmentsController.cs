using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Departments.Queries.GetDepartmentById;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class DepartmentsController : BaseController
    {
        public DepartmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(Router.Departments.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var query = new GetDepartmentByIdQuery(id);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
