using Mapster;
using SchoolProject.Core.Features.Students.Queries.GetStudents;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Core.Mapping.Students.QueryMapping
{
    public class StudentMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Student,GetStudentsResponse>()
                .Map(dest => dest.DepartmentName, src => src.Department.DName);
        }
    }
}
