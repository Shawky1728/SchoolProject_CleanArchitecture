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
                .Map(dest => dest.DepartmentName, src => src.GetLocalizedValue(src.Department.DNameAr, src.Department.DNameEn))
                .Map(dest => dest.Name, src => src.GetLocalizedValue(src.NameAr, src.NameEn));

            // mapping Student entity to GetStudentByIdResponse
            config.NewConfig<Student, GetStudentByIdResponse>()
                .Map(dest => dest.DepartmentName, src => src.GetLocalizedValue(src.Department.DNameAr, src.Department.DNameEn))
                .Map(dest => dest.Name, src => src.GetLocalizedValue(src.NameAr, src.NameEn));
        }

        private void RegisterStudentCommandMapping(TypeAdapterConfig config)
        {

            // mapping Student entity to GetStudentByIdResponse
            config.NewConfig<AddStudentCommand, Student>()
                .Map(dest => dest.DID, src => src.DepartmentId)
                .Map(dest => dest.NameEn, src => src.NameEn)
                .Map(dest => dest.NameAr, src => src.NameAr);

            config.NewConfig<UpdateStudentCommand, Student>()
                .IgnoreNullValues(true)
                .Map(dest => dest.DID, src => src.DepartmentId, srcCmd => srcCmd.DepartmentId.HasValue)
                .Map(dest => dest.StudID, src => src.Id)
                .Map(dest => dest.NameEn, src => src.NameEn, srcCmd => !string.IsNullOrEmpty(srcCmd.NameEn))
                .Map(dest => dest.NameAr, src => src.NameAr, srcCmd => !string.IsNullOrEmpty(srcCmd.NameAr))
                .Map(dest => dest.Address, src => src.Address, srcCmd => !string.IsNullOrEmpty(srcCmd.Address))
                .Map(dest => dest.Phone, src => src.Phone, srcCmd => !string.IsNullOrEmpty(srcCmd.Phone));


            config.NewConfig<Student, AddStudentResponse>()
                .Map(dest => dest.Name, src => src.GetLocalizedValue(src.NameAr, src.NameEn));

        }
    }
}
