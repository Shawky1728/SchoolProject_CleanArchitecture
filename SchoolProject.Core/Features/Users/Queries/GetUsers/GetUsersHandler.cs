using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Shared.ReponseHandling;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.Users.Queries.GetUsers
{
    public class GetUsersHandler : ResponseHandler, IRequestHandler<GetUsersQuery, Response<PaginatedList<UserResponse>>>
    {
        private readonly UserManager<User> _userManager;

        public GetUsersHandler(IStringLocalizer<SharedResource> localizer, UserManager<User> userManager) : base(localizer)
        {
            _userManager = userManager;
        }

        public async Task<Response<PaginatedList<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var isArabic = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower() == "ar";
                users = users.Where(u => u.UserName.Contains(request.SearchTerm) || u.Email.Contains(request.SearchTerm) || (isArabic && u.NameAr.Contains(request.SearchTerm)) || (!isArabic && u.NameEn.Contains(request.SearchTerm)));
            }
            var paginatedUsers = await PaginatedList<User>.CreateAsync(users, request.PageNumber, request.PageSize, cancellationToken);
            var userResponses = paginatedUsers.Adapt<PaginatedList<UserResponse>>();

            return Success(userResponses, _localizer[SharedResourceKeys.UsersRetrieved]);
        }
    }
}
