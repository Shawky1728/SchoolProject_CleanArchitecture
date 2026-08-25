using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.Extensions;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : ResponseHandler, IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly UserManager<User> _userManager;
        public GetUserByIdHandler(IStringLocalizer<SharedResource> localizer, UserManager<User> userManager) : base(localizer)
        {
            _userManager = userManager;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return NotFound<GetUserByIdResponse>(_localizer[SharedResourceKeys.UserNotFound]);
            }

            var response = new GetUserByIdResponse
            {
                Id = Guid.Parse(user.Id.ToString()),
                Name = LocalizationExtensions.GetLocalizedValue(user.NameAr, user.NameEn),
                Address = user.Address,
                City = user.City,
                Country = user.Country
            };

            return Success(response);
        }
    }
}
