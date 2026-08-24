using Mapster;
using SchoolProject.Core.Features.Users.Commands.AddUser;
using SchoolProject.Core.Shared.Extensions;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            ConfigureUserCommandMappings(config);
        }

        private void ConfigureUserCommandMappings(TypeAdapterConfig config)
        {
            config.NewConfig<User, AddUserResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => LocalizationExtensions.GetLocalizedValue(src.NameAr, src.NameEn));
        }
    }
}
