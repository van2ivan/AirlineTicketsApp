using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetNewApiResponse(statusCode);
        }

        private string GetNewApiResponse(int statusCode)
        {
            return statusCode switch
            {
                404 => "Resource not found",
                401 => "Not authorized",
                400 => "Bad request",
                500 => "Internal server error",
                _ => null

            };
        }
    }
}