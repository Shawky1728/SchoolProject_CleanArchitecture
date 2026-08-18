using Mapster;
using SchoolProject.Core.Features.Students.Commands.AddStudent;
using SchoolProject.Core.Features.Students.Queries.GetStudentById;
using SchoolProject.Core.Features.Students.Queries.GetStudents;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public class StudentMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            RegisterStudentQueryMapping(config);
            RegisterStudentCommandMapping(config);

        }

        private void RegisterStudentQueryMapping(TypeAdapterConfig config)
        {
            // mapping Student entity to GetStudentsResponse 
            config.NewConfig<Student, GetStudentsResponse>()
                .Map(dest => dest.DepartmentName, src => src.Department.DName);

            // mapping Student entity to GetStudentByIdResponse
            config.NewConfig<Student, GetStudentByIdResponse>()
                .Map(dest => dest.DepartmentName, src => src.Department.DName);
        }

        private void RegisterStudentCommandMapping(TypeAdapterConfig config)
        {

            // mapping Student entity to GetStudentByIdResponse
            config.NewConfig<AddStudentRequest, Student>()
                .Map(dest => dest.DID, src => src.DepartmentId);
        }
    }
}
