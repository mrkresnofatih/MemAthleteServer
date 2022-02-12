using System;
using System.IO;
using JWT.Exceptions;
using MemAthleteServer.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MemAthleteServer.Configs
{
    public static class ExceptionHandlerConfig
    {
        public static void UseAppExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var exception = context.Features
                        .Get<IExceptionHandlerPathFeature>()
                        .Error;
                    var errorCode = GetErrorCode(exception);
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsJsonAsync(ResponseHandler.WrapFailure<object>(errorCode));
                });
            });
        }

        private static string GetErrorCode(Exception exception)
        {
            switch (exception)
            {
                case FormatException:
                case JsonReaderException:
                {
                    return ErrorCodes.BadRequest;
                }
                case SignatureVerificationException:
                {
                    return ErrorCodes.InvalidCredential;
                }
                case FileNotFoundException:
                {
                    return ErrorCodes.FileNotFound;
                }
                default:
                {
                    return exception.Message;
                }
            }
        }
    }
}