using Application.Extentions.ErrorLogger;
using Application.Extentions.ServiceException;
using FluentValidation;
using System.Data.Common;
using System.Net;

namespace FintralearnCongestionTaxCalculator.Middleware
{

    public  class ErrorHandlingMiddleware
    {
      
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ErrorHandlingMiddleware(RequestDelegate next , ILoggerManager loggerManager)
        {
            _next = next;
            _logger = loggerManager;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {

                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception);
                var response = context.Response;
                response.ContentType = "application/json";
                string Massage = "";
                // get the response code and message
                switch (exception)
                {
                    case ValidationException:
                        ValidationException validationException = (ValidationException)exception;
                        Massage = string.Join("\n", validationException.Errors
                            .Select(exception => exception.PropertyName + ": " + exception.ErrorMessage));
                        context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;
                    case LogicException LogicException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        Massage = LogicException.Message;
                        break;

                    case NullReferenceException nullReferenceException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        break;

                    case ArgumentNullException argumentNullException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case DbException dbException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        break;
                }
                await response.WriteAsync(Massage);
            }
        }



    }
}
