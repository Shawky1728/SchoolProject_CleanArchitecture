using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;
using System.Net;

namespace SchoolProject.Core.Shared.ReponseHandling
{
    public class ResponseHandler
    {
        protected readonly IStringLocalizer<SharedResource> _localizer;

        public ResponseHandler(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public Response<T> Deleted<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message ?? _localizer["DeletedSuccessfully"]
            };
        }

        public Response<T> Success<T>(T entity, string message = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message ?? _localizer["Success"]
            };
        }

        public Response<T> Unauthorized<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message ?? _localizer["Unauthorized"]
            };
        }

        public Response<T> Forbidden<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.Forbidden,
                Succeeded = false,
                Message = message ?? _localizer["Forbidden"]
            };
        }

        public Response<T> BadRequest<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message ?? _localizer["BadRequest"]
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message ?? _localizer["NotFound"]
            };
        }

        public Response<T> Created<T>(T entity, string message = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = message ?? _localizer["CreatedSuccessfully"]
            };
        }

        public Response<T> ServerError<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Succeeded = false,
                Message = message ?? _localizer["ServerError"]
            };
        }

        public Response<T> UnProcessableEntity<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message ?? _localizer["UnProcessableEntity"]
            };
        }
    }
}