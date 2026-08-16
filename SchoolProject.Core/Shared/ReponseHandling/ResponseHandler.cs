using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SchoolProject.Core.Shared.ReponseHandling
{
    public class ResponseHandler
    {

        public ResponseHandler()
        {
        }

        public Response<T> Deleted<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = Message
            };
        }

        public Response<T> Success<T>(T entity, string message)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message
            };
        }

        public Response<T> Unauthorized<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = Message
            };
        }

        public Response<T> Forbidden<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.Forbidden,
                Succeeded = false,
                Message = message
            };
        }

        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message
            };
        }


        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message
            };
        }

        public Response<T> Created<T>(T entity, string message = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = message
            };
        }

        public Response<T> ServerError<T>(string message = "An unexpected error occurred.")
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Succeeded = false,
                Message = message,
            };
        }

        public Response<T> InternalServerError<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Succeeded = false,
                Message = message
            };
        }

        public Response<T> Found<T>(T entity, string message = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Found,
                Succeeded = true,
                Message = message
            };
        }
    }
}