using Mapster;
using SchoolProject.Core.Features.Students.Commands.AddStudent;
using SchoolProject.Core.Features.Students.Commands.UpdateStudent;
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
            config.NewConfig<AddStudentCommand, Student>()
                .Map(dest => dest.DID, src => src.DepartmentId);

            config.NewConfig<UpdateStudentCommand, Student>()
                .IgnoreNullValues(true)
                .Map(dest => dest.DID, src => src.DepartmentId, srcCmd => srcCmd.DepartmentId.HasValue)
                .Map(dest => dest.StudID, src => src.Id)
                .Map(dest => dest.Name, src => src.Name, srcCmd => !string.IsNullOrEmpty(srcCmd.Name))
                .Map(dest => dest.Address, src => src.Address, srcCmd => !string.IsNullOrEmpty(srcCmd.Address))
                .Map(dest => dest.Phone, src => src.Phone, srcCmd => !string.IsNullOrEmpty(srcCmd.Phone));


        }
    }
}
