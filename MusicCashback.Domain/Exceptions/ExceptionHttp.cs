using System;
using System.Net;

namespace MusicCashback.Domain.Exceptions.Common
{
    public class ExceptionHttp : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public override string Message { get; }

        protected ExceptionHttp()
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
            Message = string.Empty;
        }

        public ExceptionHttp(HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest, string message = null)
        {
            HttpStatusCode = httpStatusCode;
            Message = message ?? string.Empty;
        }

        public ExceptionHttp(string message = null)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
            Message = message ?? string.Empty;
        }
    }
}
