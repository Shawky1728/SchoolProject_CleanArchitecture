using MediatR;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Core.Features.Students.Queries.GetStudents
{
    public class GetStudentsQuery:IRequest<List<Student>>
    {
    }
}
